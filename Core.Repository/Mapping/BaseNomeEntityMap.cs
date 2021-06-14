using Core.Domain;
using Core.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Mapping
{
    public class BaseNomeEntityMap : IEntityTypeConfiguration<BaseNameEntity>, IMapping
    {
        public void Configure(EntityTypeBuilder<BaseNameEntity> builder)
        {
            builder.ToTable("BaseNameEntity");


            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();

            builder.Property(x => x.Nome).HasColumnName("Nome").IsRequired();

        }
    }
}
