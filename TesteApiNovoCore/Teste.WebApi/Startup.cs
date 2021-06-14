using Core.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.WebApi.Configuration;
using Teste.IoC;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Teste.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
           
            var builder = new ConfigurationBuilder()
                       .SetBasePath(hostEnvironment.ContentRootPath)
                       .AddJsonFile("appsettings.json", true, true)
                      .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                      .AddEnvironmentVariables();


            /*if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
            */

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentityConfig(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.AddApiConfig();
            services.ResolveDependencies();
            services.AddSwaggerConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseApiConfig(env);
            app.UseSwaggerConfig(provider);
        }
    }
}
