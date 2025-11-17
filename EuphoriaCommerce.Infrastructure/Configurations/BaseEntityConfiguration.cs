using EuphoriaCommerce.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

/// <summary>
/// Base configuration for all entities inheriting from Entity
/// </summary>
public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity<Guid>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // Primary Key
        builder.HasKey(be => be.Id);

        // Created At / By
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired(false);
        
        builder.Property(e => e.CreatedBy).IsRequired(false);

        // Modified At / By
        builder.Property(e => e.ModifiedAt).IsRequired(false);
        builder.Property(e => e.ModifiedBy).IsRequired(false);
        
        // Deleted At / By
        builder.Property(e => e.DeletedAt).IsRequired(false);
        builder.Property(e => e.DeletedBy).IsRequired(false);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        
        builder.HasQueryFilter(e => !e.IsDeleted);
        
        // Restored At / By
        builder.Property(e => e.RestoredAt).IsRequired(false);
        builder.Property(e => e.RestoredBy).IsRequired(false);
    }
}