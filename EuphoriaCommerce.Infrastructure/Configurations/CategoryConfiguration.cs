using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class CategoryConfiguration: BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Categories");
        
        builder.HasKey(temp => temp.Id).HasName("PK_CategoryId");

        builder.HasIndex(temp => temp.Name);
        
        builder.Property(temp => temp.Name).IsRequired().HasColumnName("CategoryName").HasMaxLength(60);
        
        builder.Property(temp => temp.Description).IsRequired().HasColumnName("CategoryDescription").HasMaxLength(1000);
    }
}