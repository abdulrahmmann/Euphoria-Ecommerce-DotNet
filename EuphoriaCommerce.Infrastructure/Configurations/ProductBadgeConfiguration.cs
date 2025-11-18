using EuphoriaCommerce.Domain.Entities.ProductDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class ProductBadgeConfiguration: BaseEntityConfiguration<ProductBadge>
{
    public override void Configure(EntityTypeBuilder<ProductBadge> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Badges");
        
        builder.HasKey(temp => temp.Id).HasName("PK_BadgeId");

        builder.HasIndex(temp => temp.Name);
        
        builder.Property(temp => temp.Name).IsRequired().HasColumnName("BadgeName").HasMaxLength(60);
        
        builder.Property(temp => temp.Color).IsRequired().HasColumnName("BadgeColor").HasMaxLength(60);

        builder.HasOne(b => b.Product)
            .WithMany(p => p.Badges)
            .HasForeignKey(b => b.ProductId)
            .HasConstraintName("FK_Badge_Product")
            .OnDelete(DeleteBehavior.NoAction);
    }
}