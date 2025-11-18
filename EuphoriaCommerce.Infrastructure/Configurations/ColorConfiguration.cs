using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class ColorConfiguration: BaseEntityConfiguration<Color>
{
    public override void Configure(EntityTypeBuilder<Color> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Colors");
        
        builder.HasKey(temp => temp.Id).HasName("PK_ColorId");

        builder.HasIndex(temp => temp.Name);
        
        builder.Property(temp => temp.Name).IsRequired().HasColumnName("ColorName").HasMaxLength(60);
        
        builder.Property(temp => temp.HexCode).IsRequired().HasColumnName("HexCode").HasMaxLength(60);
    }
}