using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceToINt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Gear",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 233);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 250);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 220);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 90);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Gear",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 233.0);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 220.0);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 110.0);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "Gear",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 90.0);
        }
    }
}
