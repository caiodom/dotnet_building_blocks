
using Core.Application;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Base;
using Core.Domain.Services;
using Core.Infra.Data.Context;
using Core.Infra.Data.Repositories;
using Core.Service.Configuration.Swagger;
using Core.Service.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IoC
{
    public class BaseDependencyInjectionConfig
    {


        public IServiceCollection ResolveBaseDependencies(IServiceCollection services)
        {

            services.AddScoped<MainContext>();
            services.AddScoped<INotificadorService, NotificadorService>();
            services.AddScoped<IAppUser, AppUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseAppService<,>), typeof(BaseAppService<,>));

            return services;
        }
    }
}
