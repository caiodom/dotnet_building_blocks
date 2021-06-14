using Core.Service.Configuration.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service.Configuration.Swagger
{
    public class BaseSwaggerConfig
    {
        public IServiceCollection AddSwaggerConfig(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerDefaultValues>();

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer",new string[]{ } }
                };

                c.AddSecurityDefinition(name: "Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey

                });


                

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{ }
                    }
                
                });
            });

            return services;
        }

        public IApplicationBuilder UseSwaggerConfig(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            /*Utilizando esse middleware nós interceptamos a chamada da route inicial,no caso da confguração do launch.settings local é a do swagger
             e então vamos verificar se o usuario esta autenticado para ver o swagger
            esta comentando caso precise usar
             */
            //app.UseMiddleware<SwaggerAuthorizedMiddleware>();
            app.UseSwagger();

            app.UseSwaggerUI(
               options =>
               {
                   foreach (var description in provider.ApiVersionDescriptions)
                   {
                       options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                   }
               });

            return app;
        }
    }
}