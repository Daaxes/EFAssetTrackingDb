using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFAssetTrackingDb.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "Model", "OfficeId", "Price", "PurchaseDate", "Type" },
                values: new object[,]
                {
                    { 6, "Iphone", "X", 4, 632, new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone" },
                    { 7, "Samsung", "Galaxy S10", 5, 752, new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
