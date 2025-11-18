using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class SubCategoryConfiguration: BaseEntityConfiguration<SubCategory>
{
    public override void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("SubCategories");
        
        builder.HasKey(x => x.Id).HasName("PK_SubCategoryId");

        builder.HasIndex(temp => temp.Name);
        
        builder.Property(temp => temp.Name).IsRequired().HasColumnName("SubCategoryName").HasMaxLength(60);
        
        builder.Property(temp => temp.Description).IsRequired().HasColumnName("SubCategoryDescription").HasMaxLength(1000);
        
        builder.HasOne(temp => temp.Category)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(temp => temp.CategoryId)
            .HasConstraintName("FK_SubCategory_CategoryId")
            .OnDelete(DeleteBehavior.NoAction);
    }
}