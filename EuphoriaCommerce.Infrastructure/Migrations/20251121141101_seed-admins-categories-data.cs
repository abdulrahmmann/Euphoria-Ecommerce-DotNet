using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EuphoriaCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedadminscategoriesdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "CategoryDescription", "ModifiedAt", "ModifiedBy", "CategoryName", "RestoredAt", "RestoredBy" },
                values: new object[,]
                {
                    { new Guid("33208193-1413-ce51-ab9b-5b6b358db411"), new DateTime(2025, 11, 21, 14, 11, 1, 5, DateTimeKind.Utc).AddTicks(4943), "System", null, null, "Hoodies and sweatshirts for all", null, null, "Hoodies", null, null },
                    { new Guid("3ffbccf0-69d6-1a5a-8040-b0af290bde83"), new DateTime(2025, 11, 21, 14, 11, 1, 5, DateTimeKind.Utc).AddTicks(5011), "System", null, null, "Swimsuits, bikinis, and beachwear", null, null, "Swimwear", null, null },
                    { new Guid("409c122e-a2de-1259-9499-a1e496e65cdb"), new DateTime(2025, 11, 21, 14, 11, 1, 5, DateTimeKind.Utc).AddTicks(4930), "System", null, null, "Casual and formal dresses for women and girls", null, null, "Dresses", null, null },
                    { new Guid("483dcc60-ac7e-d453-b20c-677936b05937"), new DateTime(2025, 11, 21, 14, 11, 1, 5, DateTimeKind.Utc).AddTicks(4976), "System", null, null, "Jackets, coats and outerwear", null, null, "Jackets", null, null },
                    { new Guid("61854766-5368-5559-8b3a-4961a66d456e"), new DateTime(2025, 11, 21, 14, 11, 1, 5, DateTimeKind.Utc).AddTicks(4530), "System", null, null, "All types of shoes including sneakers, formal and casual", null, null, "Shoes", null, null },
                    { new Guid("7c1b2532-d955-2753-bb3d-fe0199ba2547"), new DateTime(2025, 11, 21, 14, 11, 1, 5, DateTimeKind.Utc).AddTicks(5000), "System", null, null, "Gym, running, and sports clothing", null, null, "Sportswear", null, null },
                    { new Guid("926d4b51-c316-6c5b-8973-a09394584474"), new DateTime(2025, 11, 21, 14, 11, 1, 0, DateTimeKind.Utc).AddTicks(9834), "System", null, null, "All types of shirts for men, women and kids", null, null, "Shirts", null, null },
                    { new Guid("a66986e1-bced-5550-846a-779b9149f3d8"), new DateTime(2025, 11, 21, 14, 11, 1, 5, DateTimeKind.Utc).AddTicks(4900), "System", null, null, "Jeans, trousers, leggings, and other pants", null, null, "Pants", null, null },
                    { new Guid("d50cb5f3-c43c-af50-a780-81e2d995abc7"), new DateTime(2025, 11, 21, 14, 11, 1, 5, DateTimeKind.Utc).AddTicks(4963), "System", null, null, "Bags, belts, hats, and other accessories", null, null, "Accessories", null, null },
                    { new Guid("f51d0637-cf0d-e952-bf9c-a8064d21239b"), new DateTime(2025, 11, 21, 14, 11, 1, 5, DateTimeKind.Utc).AddTicks(4988), "System", null, null, "Socks, underwear, lingerie", null, null, "Underwear", null, null }
                });

            migrationBuilder.InsertData(
                table: "GenderCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "RestoredAt", "RestoredBy" },
                values: new object[,]
                {
                    { new Guid("0188105b-9870-c856-93c1-0139faf1bd0b"), new DateTime(2025, 11, 21, 14, 11, 1, 6, DateTimeKind.Utc).AddTicks(1622), "System", null, null, false, null, null, "Kids", null, null },
                    { new Guid("053bb5a9-44c3-eb5e-ae05-9f55fa44d7ef"), new DateTime(2025, 11, 21, 14, 11, 1, 6, DateTimeKind.Utc).AddTicks(1519), "System", null, null, false, null, null, "Men", null, null },
                    { new Guid("70e7653a-8ab2-5056-964e-9f6d344162ce"), new DateTime(2025, 11, 21, 14, 11, 1, 6, DateTimeKind.Utc).AddTicks(1605), "System", null, null, false, null, null, "Women", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33208193-1413-ce51-ab9b-5b6b358db411"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3ffbccf0-69d6-1a5a-8040-b0af290bde83"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("409c122e-a2de-1259-9499-a1e496e65cdb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("483dcc60-ac7e-d453-b20c-677936b05937"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("61854766-5368-5559-8b3a-4961a66d456e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7c1b2532-d955-2753-bb3d-fe0199ba2547"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("926d4b51-c316-6c5b-8973-a09394584474"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a66986e1-bced-5550-846a-779b9149f3d8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d50cb5f3-c43c-af50-a780-81e2d995abc7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f51d0637-cf0d-e952-bf9c-a8064d21239b"));

            migrationBuilder.DeleteData(
                table: "GenderCategories",
                keyColumn: "Id",
                keyValue: new Guid("0188105b-9870-c856-93c1-0139faf1bd0b"));

            migrationBuilder.DeleteData(
                table: "GenderCategories",
                keyColumn: "Id",
                keyValue: new Guid("053bb5a9-44c3-eb5e-ae05-9f55fa44d7ef"));

            migrationBuilder.DeleteData(
                table: "GenderCategories",
                keyColumn: "Id",
                keyValue: new Guid("70e7653a-8ab2-5056-964e-9f6d344162ce"));
        }
    }
}
