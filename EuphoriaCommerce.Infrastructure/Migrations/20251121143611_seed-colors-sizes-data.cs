using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EuphoriaCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedcolorssizesdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "HexCode", "ModifiedAt", "ModifiedBy", "ColorName", "RestoredAt", "RestoredBy" },
                values: new object[,]
                {
                    { new Guid("07f62635-d4bc-1a55-90bc-05f814579a42"), new DateTime(2025, 11, 21, 14, 36, 10, 366, DateTimeKind.Utc).AddTicks(1900), "System", null, null, "#FFFF00", null, null, "Yellow", null, null },
                    { new Guid("0b35473a-7c7d-9156-a01c-cff5ad5d3aca"), new DateTime(2025, 11, 21, 14, 36, 10, 366, DateTimeKind.Utc).AddTicks(2003), "System", null, null, "#A52A2A", null, null, "Brown", null, null },
                    { new Guid("1af23b93-d5fd-0d5a-a283-845fed0e7bbd"), new DateTime(2025, 11, 21, 14, 36, 10, 366, DateTimeKind.Utc).AddTicks(1847), "System", null, null, "#00FF00", null, null, "Green", null, null },
                    { new Guid("44bc447d-2a9c-3756-8800-a503f10f3d89"), new DateTime(2025, 11, 21, 14, 36, 10, 366, DateTimeKind.Utc).AddTicks(1301), "System", null, null, "#0000FF", null, null, "Blue", null, null },
                    { new Guid("4f6f5732-c0ed-635f-8203-53af6a8aac66"), new DateTime(2025, 11, 21, 14, 36, 10, 366, DateTimeKind.Utc).AddTicks(1972), "System", null, null, "#800080", null, null, "Purple", null, null },
                    { new Guid("57fb06b4-9fb2-6f57-b186-4fbb37f02380"), new DateTime(2025, 11, 21, 14, 36, 10, 366, DateTimeKind.Utc).AddTicks(1879), "System", null, null, "#000000", null, null, "Black", null, null },
                    { new Guid("59630754-c7fd-f051-a000-b9ae15b96f8b"), new DateTime(2025, 11, 21, 14, 36, 10, 366, DateTimeKind.Utc).AddTicks(1912), "System", null, null, "#FFC0CB", null, null, "Pink", null, null },
                    { new Guid("a7b39dcc-5795-7e5c-b1f4-5670a1da7ff4"), new DateTime(2025, 11, 21, 14, 36, 10, 361, DateTimeKind.Utc).AddTicks(4448), "System", null, null, "#FF0000", null, null, "Red", null, null },
                    { new Guid("ab6afb09-94a7-7b5a-bffd-bc9cbb9b3498"), new DateTime(2025, 11, 21, 14, 36, 10, 366, DateTimeKind.Utc).AddTicks(1991), "System", null, null, "#FFA500", null, null, "Orange", null, null },
                    { new Guid("c19f6137-5330-2b58-bcb7-da3d24ceb159"), new DateTime(2025, 11, 21, 14, 36, 10, 366, DateTimeKind.Utc).AddTicks(1890), "System", null, null, "#FFFFFF", null, null, "White", null, null }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "ModifiedAt", "ModifiedBy", "SizeName", "RestoredAt", "RestoredBy", "SizeType" },
                values: new object[,]
                {
                    { new Guid("13cf1017-741a-a25f-a8fc-a17f102841bc"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5006), "System", null, null, null, null, "4XL", null, null, "Clothing" },
                    { new Guid("2fc4fb98-dcae-4952-a397-cb5962ea3a3f"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5149), "System", null, null, null, null, "44", null, null, "Shoes" },
                    { new Guid("34133eaf-b928-5c52-95bc-59fe534248e6"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5090), "System", null, null, null, null, "40", null, null, "Shoes" },
                    { new Guid("45fc7b82-0887-b450-8200-9c9c9836f7e4"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5309), "System", null, null, null, null, "47", null, null, "Shoes" },
                    { new Guid("514364fb-0d56-9652-be6d-a332236b1f8d"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5289), "System", null, null, null, null, "45", null, null, "Shoes" },
                    { new Guid("55dd8602-9b2c-9a5a-a9ec-b3759e7b9477"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5138), "System", null, null, null, null, "43", null, null, "Shoes" },
                    { new Guid("95f42efe-15a1-6155-9729-49784c16bf23"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5299), "System", null, null, null, null, "46", null, null, "Shoes" },
                    { new Guid("98e060d1-ca6a-1457-b14a-16f29ec605af"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(4956), "System", null, null, null, null, "L", null, null, "Clothing" },
                    { new Guid("9c62aa02-168b-175d-a44f-3a0efec2feed"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(4932), "System", null, null, null, null, "S", null, null, "Clothing" },
                    { new Guid("ab3fa6a9-48b9-f056-9948-c35e2bf2974e"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(4983), "System", null, null, null, null, "XXL", null, null, "Clothing" },
                    { new Guid("b1b2a3ff-83e4-345d-8cb7-90a05daa28b2"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(4995), "System", null, null, null, null, "3XL", null, null, "Clothing" },
                    { new Guid("b2221f76-59c1-0b5d-b87e-0b606f990ba4"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5113), "System", null, null, null, null, "41", null, null, "Shoes" },
                    { new Guid("b3cecf92-579d-1459-ad8b-14d0e37643de"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5127), "System", null, null, null, null, "42", null, null, "Shoes" },
                    { new Guid("c8d457c0-373b-e05e-b477-b22feeb4f238"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(4818), "System", null, null, null, null, "XXS", null, null, "Clothing" },
                    { new Guid("d1d0f9a2-026d-0e52-b369-e6029d9e5929"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(4968), "System", null, null, null, null, "XL", null, null, "Clothing" },
                    { new Guid("d1e45fd5-1c39-3858-a407-69dea25e2cf7"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5016), "System", null, null, null, null, "5XL", null, null, "Clothing" },
                    { new Guid("d2d0b1bd-0d76-ae50-b3b0-2dff5258e945"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(4915), "System", null, null, null, null, "XS", null, null, "Clothing" },
                    { new Guid("dde63ac6-c94f-dd59-a669-70e827d13f7c"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(4944), "System", null, null, null, null, "M", null, null, "Clothing" },
                    { new Guid("e34c385b-8c2d-f05e-abc3-a139d4cac0a2"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5064), "System", null, null, null, null, "38", null, null, "Shoes" },
                    { new Guid("f41235ca-a9df-035a-969c-5a670a4c91a1"), new DateTime(2025, 11, 21, 14, 36, 10, 367, DateTimeKind.Utc).AddTicks(5078), "System", null, null, null, null, "39", null, null, "Shoes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("07f62635-d4bc-1a55-90bc-05f814579a42"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("0b35473a-7c7d-9156-a01c-cff5ad5d3aca"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("1af23b93-d5fd-0d5a-a283-845fed0e7bbd"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("44bc447d-2a9c-3756-8800-a503f10f3d89"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("4f6f5732-c0ed-635f-8203-53af6a8aac66"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("57fb06b4-9fb2-6f57-b186-4fbb37f02380"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("59630754-c7fd-f051-a000-b9ae15b96f8b"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("a7b39dcc-5795-7e5c-b1f4-5670a1da7ff4"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("ab6afb09-94a7-7b5a-bffd-bc9cbb9b3498"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("c19f6137-5330-2b58-bcb7-da3d24ceb159"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("13cf1017-741a-a25f-a8fc-a17f102841bc"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("2fc4fb98-dcae-4952-a397-cb5962ea3a3f"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("34133eaf-b928-5c52-95bc-59fe534248e6"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("45fc7b82-0887-b450-8200-9c9c9836f7e4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("514364fb-0d56-9652-be6d-a332236b1f8d"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("55dd8602-9b2c-9a5a-a9ec-b3759e7b9477"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("95f42efe-15a1-6155-9729-49784c16bf23"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("98e060d1-ca6a-1457-b14a-16f29ec605af"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("9c62aa02-168b-175d-a44f-3a0efec2feed"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("ab3fa6a9-48b9-f056-9948-c35e2bf2974e"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("b1b2a3ff-83e4-345d-8cb7-90a05daa28b2"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("b2221f76-59c1-0b5d-b87e-0b606f990ba4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("b3cecf92-579d-1459-ad8b-14d0e37643de"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("c8d457c0-373b-e05e-b477-b22feeb4f238"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("d1d0f9a2-026d-0e52-b369-e6029d9e5929"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("d1e45fd5-1c39-3858-a407-69dea25e2cf7"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("d2d0b1bd-0d76-ae50-b3b0-2dff5258e945"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("dde63ac6-c94f-dd59-a669-70e827d13f7c"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("e34c385b-8c2d-f05e-abc3-a139d4cac0a2"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("f41235ca-a9df-035a-969c-5a670a4c91a1"));

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
    }
}
