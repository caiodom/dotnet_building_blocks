using Core.Domain;
using Core.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Entities;

namespace Teste.Infra.Data.Mapping
{
    public class TesteEntityMap : IEntityTypeConfiguration<TesteEntity>, IMapping
    {
        public void Configure(EntityTypeBuilder<TesteEntity> builder)
        {
            builder.ToTable("Teste");


            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();

            builder.Property(x => x.Nome).HasColumnName("Nome").IsRequired();

            builder.Property(x => x.Descricao).HasColumnName("Descricao").IsRequired();

        }
    }
}
