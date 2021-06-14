using Core.Infra.Data.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.WebApi.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
                => new BaseIdentityConfig().AddBaseIdentityConfig(services, configuration,projetoInfraData:"Teste.Infra.Data");
    }
}
