using EuphoriaCommerce.Domain.Entities.CartDomain;
using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using EuphoriaCommerce.Domain.Entities.OrderDomain;
using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.Entities.ReviewDomain;
using EuphoriaCommerce.Domain.Entities.WishlistDomain;
using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Context;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    protected ApplicationDbContext() { }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<ProductBadge> ProductBadges { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Cart>().OwnsMany(c => c.CartItems, ct =>
        {
            ct.Property(x => x.Price).HasPrecision(18,2);
        });
        
        builder.Entity<Order>().OwnsMany(o => o.OrderItems, oi =>
        {
            oi.Property(x => x.Price).HasPrecision(18,2);
        });
        
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        builder.Entity<ApplicationUser>().HasQueryFilter(u => !u.IsActive);
        builder.Entity<Product>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<ProductVariant>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<ProductTag>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<ProductBadge>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<ProductImage>().HasQueryFilter(u => !u.IsDeleted);
            
        builder.Entity<Brand>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<Color>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<Size>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<Category>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<SubCategory>().HasQueryFilter(u => !u.IsDeleted);
            
        builder.Entity<Wishlist>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<Feedback>().HasQueryFilter(u => !u.IsDeleted);
        
        builder.Entity<Cart>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<Order>().HasQueryFilter(u => !u.IsDeleted);
    }
}