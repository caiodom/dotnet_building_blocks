using Core.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Infra.Data.Context;

namespace Teste.IoC
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyAppContext>();

            return new BaseDependencyInjectionConfig().ResolveBaseDependencies(services);
        }

    }
}
