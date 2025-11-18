using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class SizeConfiguration: BaseEntityConfiguration<Size>
{
    public override void Configure(EntityTypeBuilder<Size> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Sizes");
        
        builder.HasKey(temp => temp.Id).HasName("PK_SizeId");

        builder.HasIndex(temp => temp.Name);
        
        builder.Property(temp => temp.Name).IsRequired().HasColumnName("SizeName").HasMaxLength(60);
        
        builder.Property(temp => temp.SizeType).IsRequired().HasColumnName("SizeType");
    }
}