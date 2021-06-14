using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Util
{
    public abstract class EntityTypeConfiguration<TEntity>:IMapping where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);

    }
}
