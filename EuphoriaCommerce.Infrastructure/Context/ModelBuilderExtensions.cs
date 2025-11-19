using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Context;

public static class ModelBuilderExtensions
{
    public static void SeedCategories(this ModelBuilder modelBuilder)
    {
        // ======= Predefined GUIDs =======
        var fashionId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var menId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var womenId = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var kidsId = Guid.Parse("44444444-4444-4444-4444-444444444444");
        var accessoriesId = Guid.Parse("55555555-5555-5555-5555-555555555555");

        // ======= Categories =======
        modelBuilder.Entity<Category>().HasData(
            new Category("Fashion", "All fashion products including men, women, and kids.") { Id = fashionId },
            new Category("Men", "Men's clothing, shoes, and accessories.") { Id = menId },
            new Category("Women", "Women's clothing, shoes, and accessories.") { Id = womenId },
            new Category("Kids", "Clothing, shoes, and accessories for children.") { Id = kidsId },
            new Category("Accessories", "Fashion accessories like bags, belts, hats, and jewelry.") { Id = accessoriesId }
        );

        // ======= SubCategories =======
        modelBuilder.Entity<SubCategory>().HasData(
            // Men
            new SubCategory("Shirts", "Men's shirts", menId)
                { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
            new SubCategory("Pants", "Men's pants", menId) { Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
            new SubCategory("Jackets", "Men's jackets and coats", menId)
                { Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc") },
            new SubCategory("Shoes", "Men's shoes", menId) { Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd") },
            new SubCategory("Accessories", "Men's accessories", menId)
                { Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },

            // Women
            new SubCategory("Dresses", "Women's dresses", womenId)
                { Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff") },
            new SubCategory("Tops", "Women's tops and blouses", womenId)
                { Id = Guid.Parse("11111111-2222-3333-4444-555555555555") },
            new SubCategory("Pants", "Women's pants and trousers", womenId)
                { Id = Guid.Parse("66666666-6666-6666-6666-666666666666") },
            new SubCategory("Jackets", "Women's jackets and coats", womenId)
                { Id = Guid.Parse("77777777-7777-7777-7777-777777777777") },
            new SubCategory("Shoes", "Women's shoes", womenId)
                { Id = Guid.Parse("88888888-8888-8888-8888-888888888888") },
            new SubCategory("Accessories", "Women's accessories", womenId)
                { Id = Guid.Parse("99999999-9999-9999-9999-999999999999") },

            // Kids
            new SubCategory("Boys Clothing", "Clothing for boys", kidsId)
                { Id = Guid.Parse("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa") },
            new SubCategory("Girls Clothing", "Clothing for girls", kidsId)
                { Id = Guid.Parse("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb") },
            new SubCategory("Shoes", "Shoes for kids", kidsId)
                { Id = Guid.Parse("cccccccc-3333-cccc-3333-cccccccccccc") },
            new SubCategory("Accessories", "Accessories for kids", kidsId)
                { Id = Guid.Parse("dddddddd-4444-dddd-4444-dddddddddddd") },

            // Accessories
            new SubCategory("Bags", "Bags and backpacks", accessoriesId)
                { Id = Guid.Parse("eeeeeeee-5555-eeee-5555-eeeeeeeeeeee") },
            new SubCategory("Belts", "Belts for men and women", accessoriesId)
                { Id = Guid.Parse("ffffffff-6666-ffff-6666-ffffffffffff") },
            new SubCategory("Hats", "Hats and caps", accessoriesId)
                { Id = Guid.Parse("11111111-7777-1111-7777-111111111111") },
            new SubCategory("Jewelry", "Fashion jewelry", accessoriesId)
                { Id = Guid.Parse("22222222-8888-2222-8888-222222222222") }
        );
    }
}