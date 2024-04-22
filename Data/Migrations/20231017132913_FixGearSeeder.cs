using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixGearSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 6,
                column: "Category",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 15,
                column: "Category",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 16,
                column: "Category",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 6,
                column: "Category",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 15,
                column: "Category",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 16,
                column: "Category",
                value: 4);
        }
    }
}
