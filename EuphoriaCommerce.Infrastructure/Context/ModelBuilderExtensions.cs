using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Context;

public static class ModelBuilderExtensions
{
    public static void SeedCategories(this ModelBuilder builder)
    {
        var categories = new[]
        {
            new { Name = "Shirts", Description = "All types of shirts for men, women and kids" },
            new { Name = "Shoes", Description = "All types of shoes including sneakers, formal and casual" },
            new { Name = "Pants", Description = "Jeans, trousers, leggings, and other pants" },
            new { Name = "Dresses", Description = "Casual and formal dresses for women and girls" },
            new { Name = "Hoodies", Description = "Hoodies and sweatshirts for all" },
            new { Name = "Accessories", Description = "Bags, belts, hats, and other accessories" },
            new { Name = "Jackets", Description = "Jackets, coats and outerwear" },
            new { Name = "Underwear", Description = "Socks, underwear, lingerie" },
            new { Name = "Sportswear", Description = "Gym, running, and sports clothing" },
            new { Name = "Swimwear", Description = "Swimsuits, bikinis, and beachwear" }
        };
        
        builder.Entity<Category>().HasData(
            categories.Select(c => new Category(c.Name, c.Description)
            {
                Id = GuidHelper.CreateGuidFromName(c.Name)
            }).ToArray()
        );

        string[] genders = new[] { "Men", "Women", "Kids" };

        builder.Entity<GenderCategory>().HasData(
            genders.Select(name => new GenderCategory(name)
            {
                Id = GuidHelper.CreateGuidFromName(name)
            }).ToArray()
        );
    }
}
