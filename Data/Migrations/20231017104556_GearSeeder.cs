using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class GearSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Intelligence", "Name", "Price", "Strength" },
                values: new object[] { 2, "Gold Helmet", 70, 15 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Agility", "Category", "Intelligence", "Name", "Price", "Strength" },
                values: new object[] { 10, 0, 12, "Iron Helmet", 150, 20 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Agility", "Category", "Intelligence", "Name", "Strength" },
                values: new object[] { 15, 0, 16, "Diamond Helmet", 30 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Agility", "Category", "Intelligence", "Name", "Price", "Strength" },
                values: new object[] { 2, 1, 1, "Gold Chestplate", 150, 3 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Agility", "Category", "Intelligence", "Name", "Price", "Strength" },
                values: new object[] { 16, 1, 20, "Iron Chestplate", 225, 9 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Agility", "Category", "Name", "Price", "Strength" },
                values: new object[] { 5, 0, "Diamond Chestplate", 275, 15 });

            migrationBuilder.InsertData(
                table: "Gear",
                columns: new[] { "Id", "Agility", "Category", "Intelligence", "Name", "Price", "Strength" },
                values: new object[,]
                {
                    { 1, 5, 0, 2, "Gold Helmet", 70, 15 },
                    { 2, 10, 0, 12, "Iron Helmet", 150, 20 },
                    { 3, 15, 0, 16, "Diamond Helmet", 220, 30 },
                    { 4, 2, 1, 1, "Gold Chestplate", 150, 3 },
                    { 5, 16, 1, 20, "Iron Chestplate", 225, 9 },
                    { 6, 5, 0, 8, "Diamond Chestplate", 275, 15 },
                    { 7, 14, 2, 13, "Gold Sword", 150, 18 },
                    { 8, 18, 2, 16, "Iron Sword", 205, 25 },
                    { 9, 23, 2, 20, "Diamond Sword", 265, 31 },
                    { 10, 5, 3, 3, "Gold Boots", 60, 6 },
                    { 11, 10, 3, 6, "Iron Boots", 100, 12 },
                    { 12, 7, 3, 8, "Diamond Boots", 120, 16 },
                    { 13, 3, 4, 1, "Gold Ring", 40, 2 },
                    { 14, 4, 4, 2, "Iron Ring", 60, 6 },
                    { 15, 5, 5, 4, "Diamond Ring", 80, 9 },
                    { 16, 10, 4, 1, "Gold Necklace", 25, 11 },
                    { 17, 20, 5, 8, "Iron Necklace", 50, 18 },
                    { 18, 30, 5, 24, "Diamond Necklace", 75, 24 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Intelligence", "Name", "Price", "Strength" },
                values: new object[] { 6, "Sample Gear 1", 233, 4 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Agility", "Category", "Intelligence", "Name", "Price", "Strength" },
                values: new object[] { 7, 1, 4, "Sample Gear 2", 250, 8 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Agility", "Category", "Intelligence", "Name", "Strength" },
                values: new object[] { 4, 3, 2, "Sample Gear 3", 4 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Agility", "Category", "Intelligence", "Name", "Price", "Strength" },
                values: new object[] { 12, 2, 7, "Sample Gear 4", 110, 14 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Agility", "Category", "Intelligence", "Name", "Price", "Strength" },
                values: new object[] { 5, 4, 3, "Sample Gear 5", 90, 10 });

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Agility", "Category", "Name", "Price", "Strength" },
                values: new object[] { 10, 5, "Sample Gear 6", 90, 12 });
        }
    }
}
