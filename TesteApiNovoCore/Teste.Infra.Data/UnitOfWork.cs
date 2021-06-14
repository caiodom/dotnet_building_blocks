using Core.Infra.Data.Extensions;
using Core.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Infra.Data.Context;

namespace Teste.Infra.Data
{
    public class UnitOfWork:UnitOfWorkBase
    {
        public UnitOfWork(IConfiguration configuration):base(configuration)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvetion();
            modelBuilder.RemoveCascadeDeleteConvention();


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppContext).Assembly);

            BaseOnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
