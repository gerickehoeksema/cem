using CEM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEM.DAL.Configuration
{
    /// <summary>
    /// Configure all entities that has base class <c>AuditableEntity</c>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DateUpdated).IsRequired(false);
            builder.Property(p => p.UpdatedBy).IsRequired(false);

            ConfigureEntity(builder);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
