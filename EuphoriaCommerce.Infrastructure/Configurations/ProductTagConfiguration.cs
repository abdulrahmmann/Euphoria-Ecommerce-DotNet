using EuphoriaCommerce.Domain.Entities.ProductDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class ProductTagConfiguration: BaseEntityConfiguration<ProductTag>
{
    public override void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Tags");
        
        builder.HasKey(temp => temp.Id).HasName("PK_TagId");

        builder.HasIndex(temp => temp.Name);
        
        builder.Property(temp => temp.Name).IsRequired().HasColumnName("TagName").HasMaxLength(60);

    }
}