using EuphoriaCommerce.Domain.Entities.ProductDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class ProductImageConfiguration: BaseEntityConfiguration<ProductImage>
{
    public override void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("ProductImages");
        
        builder.HasKey(temp => temp.Id).HasName("PK_ProductImageId");
        
        builder.Property(temp => temp.ImageUrl).IsRequired().HasColumnName("ImageUrl");

        builder.HasOne(b => b.Product)
            .WithMany(p => p.ProductImages)
            .HasForeignKey(b => b.ProductId)
            .HasConstraintName("FK_Product_image")
            .OnDelete(DeleteBehavior.NoAction);
    }
}