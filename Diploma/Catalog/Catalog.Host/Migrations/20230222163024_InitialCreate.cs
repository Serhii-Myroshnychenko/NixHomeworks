using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Host.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_cars_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_manfacturers_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FoundationYear = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HeadquartersLocation = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Year = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Transmission = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PictureFileName = table.Column<string>(type: "text", nullable: false),
                    EngineDisplacement = table.Column<double>(type: "double precision", nullable: false),
                    CatalogManufacturerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogs_CatalogManufacturers_CatalogManufacturerId",
                        column: x => x.CatalogManufacturerId,
                        principalTable: "CatalogManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_CatalogManufacturerId",
                table: "Catalogs",
                column: "CatalogManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "CatalogManufacturers");

            migrationBuilder.DropSequence(
                name: "catalog_cars_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_manfacturers_hilo");
        }
    }
}
