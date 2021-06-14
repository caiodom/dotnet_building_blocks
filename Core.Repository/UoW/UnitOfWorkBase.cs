using Core.Infra.Data.Context;
using Core.Infra.Data.Extensions;
using Core.Infra.Data.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Infra.Data.UoW
{
   public class UnitOfWorkBase:DbContext
    {
        private readonly string _connectionString;
        public static Type _TypeToMap;
        private readonly IConfiguration _configuration;
        public UnitOfWorkBase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseLazyLoadingProxies()
                            .UseSqlServer(_connectionString);


        protected void BaseOnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.RemovePluralizingTableNameConvetion();
            modelBuilder.RemoveCascadeDeleteConvention();

            //var coreAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                                                          //.Where(x => x.FullName.Contains(".Infra.Data"))
                                                          //.ToList();

            //coreAssemblies.ForEach(assembly => modelBuilder.ApplyConfigurationsFromAssembly(assembly)); 

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvetion();
            modelBuilder.RemoveCascadeDeleteConvention();

            var appSettingSection = _configuration.GetSection("AppSettings")
                                                        .GetChildren()
                                                        .First(x=>x.Key=="AssemblyToMap");
            //var appSettings = appSettingSectio;

            var coreAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                                                          .Where(x=>x.FullName.Contains(".Infra.Data"))
                                                          .ToList();

             coreAssemblies.ForEach(assembly => modelBuilder.ApplyConfigurationsFromAssembly(assembly));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
            if (_TypeToMap != null)
            {
                var externAssemblies = _TypeToMap.Assembly;
                modelBuilder.ApplyConfigurationsFromAssembly(_TypeToMap.Assembly);
            }


            base.OnModelCreating(modelBuilder);

        }

        private List<Type> GetMappingTypes()
        {
            var executingAssemblies = Assembly.GetExecutingAssembly();
            var callingAssemblies = Assembly.GetCallingAssembly();

            var returnList=executingAssemblies.GetTypes().Where(tp => tp.IsClass && typeof(IMapping).IsAssignableFrom(tp)).ToList();

            returnList.AddRange(callingAssemblies.GetTypes().Where(callTp => callTp.IsClass && typeof(IMapping).IsAssignableFrom(callTp)));

            return returnList;
        }
    }
}
