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
    
    public static void SeedColors(this ModelBuilder builder)
    {
        var colors = new[]
        {
            new { Name = "Red", Hex = "#FF0000" },
            new { Name = "Blue", Hex = "#0000FF" },
            new { Name = "Green", Hex = "#00FF00" },
            new { Name = "Black", Hex = "#000000" },
            new { Name = "White", Hex = "#FFFFFF" },
            new { Name = "Yellow", Hex = "#FFFF00" },
            new { Name = "Pink", Hex = "#FFC0CB" },
            new { Name = "Purple", Hex = "#800080" },
            new { Name = "Orange", Hex = "#FFA500" },
            new { Name = "Brown", Hex = "#A52A2A" }
        };

        builder.Entity<Color>().HasData(
            colors.Select(c => new Color(c.Name, c.Hex)
            {
                Id = GuidHelper.CreateGuidFromName(c.Name)
            }).ToArray()
        );
    }
    
    public static void SeedSizes(this ModelBuilder builder)
    {
        var sizes = new[]
        {
            new { Name = "XXS", SizeType = "Clothing" },
            new { Name = "XS", SizeType = "Clothing" },
            new { Name = "S",  SizeType = "Clothing" },
            new { Name = "M",  SizeType = "Clothing" },
            new { Name = "L",  SizeType = "Clothing" },
            new { Name = "XL", SizeType = "Clothing" },
            new { Name = "XXL", SizeType = "Clothing" },
            new { Name = "3XL", SizeType = "Clothing" },
            new { Name = "4XL", SizeType = "Clothing" },
            new { Name = "5XL", SizeType = "Clothing" },
            new { Name = "38", SizeType = "Shoes" },
            new { Name = "39", SizeType = "Shoes" },
            new { Name = "40", SizeType = "Shoes" },
            new { Name = "41", SizeType = "Shoes" },
            new { Name = "42", SizeType = "Shoes" },
            new { Name = "43", SizeType = "Shoes" },
            new { Name = "44", SizeType = "Shoes" },
            new { Name = "45", SizeType = "Shoes" },
            new { Name = "46", SizeType = "Shoes" },
            new { Name = "47", SizeType = "Shoes" },
        };

        builder.Entity<Size>().HasData(
            sizes.Select(s => new Size(s.Name, s.SizeType)
            {
                Id = GuidHelper.CreateGuidFromName(s.Name)
            }).ToArray()
        );
    }
    
    
}
