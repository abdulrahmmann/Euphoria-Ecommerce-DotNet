using EuphoriaCommerce.Domain.Entities.WishlistDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuphoriaCommerce.Infrastructure.Configurations;

public class WishlistConfiguration: BaseEntityConfiguration<Wishlist>
{
    public override void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Wishlists");
        
        builder.HasKey(temp => temp.Id).HasName("PK_WishlistId");

        builder.HasIndex(temp => temp.Id);
        
        builder
            .HasOne(w => w.Product)
            .WithMany(p => p.Wishlists)
            .HasForeignKey(w => w.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Wishlist_Product_Id");
        
        builder
            .HasOne(u => u.ApplicationUser)
            .WithMany(p => p.Wishlists)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Wishlist_User_Id");
    }
}