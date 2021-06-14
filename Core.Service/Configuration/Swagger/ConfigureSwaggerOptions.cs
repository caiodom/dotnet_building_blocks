
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service.Configuration.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private  readonly IConfiguration _configuration;
       

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider,IConfiguration configuration)
        {

            this._provider = provider;
            this._configuration = configuration;

        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, _configuration));
            }

          

        
            
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description,IConfiguration configuration)
        {
              var swaggerInfosSection = configuration.GetSection("SwaggerInfos");
            var title = swaggerInfosSection.Get<SwaggerInfos>().Title;
            var name = swaggerInfosSection.Get<SwaggerInfos>().Name;
            var swaggerInfosDescription = swaggerInfosSection.Get<SwaggerInfos>().Description;
            var email = swaggerInfosSection.Get<SwaggerInfos>().Email;

            var info = new OpenApiInfo()
            {
                Title = title,
                Version = description.ApiVersion.ToString(),
                Description = swaggerInfosDescription,
                Contact = new OpenApiContact() { Name = name, Email = email },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            };

            if (description.IsDeprecated)
            {
                info.Description += " Esta versão está obsoleta!";
            }

            return info;

        }
    }
}
