using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFAssetTrackingDb.Migrations
{
    /// <inheritdoc />
    public partial class initDatabaseWithTablesAndModelBuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HQName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HQCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HQId = table.Column<int>(type: "int", nullable: false),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_HQs_HQId",
                        column: x => x.HQId,
                        principalTable: "HQs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HQs",
                columns: new[] { "Id", "HQCountry", "HQName" },
                values: new object[,]
                {
                    { 1, "Sweden", "Stockholm" },
                    { 2, "Denmark", "Copenhagen" }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "HQId", "OfficeCountry", "OfficeName" },
                values: new object[,]
                {
                    { 1, 1, "Sverige", "SveaKontoret" },
                    { 2, 2, "Denmark", "ZooKontoret" },
                    { 3, 2, "Kroatien", "SisakUred" },
                    { 4, 1, "Norge", "OsloKontoret" },
                    { 5, 1, "Norge", "HelsinkiToimisto" }
                });

            migrationBuilder.InsertData(
                table: "Computers",
                columns: new[] { "Id", "Brand", "Model", "OfficeId", "Price", "PurchaseDate", "Type" },
                values: new object[,]
                {
                    { 1, "HP", "Spectre x360", 1, 1180, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2in1 Laptop" },
                    { 2, "HP", "Envy x360", 1, 1180, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2in1 Laptop" },
                    { 3, "Dell", "Latetude XPS", 3, 1220, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2in1 Laptop" },
                    { 4, "Dell", "Alienware", 4, 1855, new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stationär" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "Model", "OfficeId", "Price", "PurchaseDate", "Type" },
                values: new object[,]
                {
                    { 1, "Apple", "Iphone 15 Pro Max", 1, 1406, new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone" },
                    { 2, "Apple", "Iphone 13", 4, 781, new DateTime(2021, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone" },
                    { 3, "Samsung", "S23 Ultra", 2, 1016, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone" },
                    { 4, "Google", "Pixel 8 Pro", 1, 1023, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone" },
                    { 5, "Doro", "901c", 1, 27, new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_OfficeId",
                table: "Computers",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_HQId",
                table: "Offices",
                column: "HQId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_OfficeId",
                table: "Phones",
                column: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "HQs");
        }
    }
}
