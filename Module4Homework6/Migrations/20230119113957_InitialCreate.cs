using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module4Homework6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSong",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "DateOfBirth", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "snoop@gmail.com", "https://www.instagram.com/snoopdogg/", "Snoop Dogg", "+380761234567" },
                    { 2, new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "lil@gmail.com", "https://www.instagram.com/lilnasxunlimited/", "Lil Nas X", "+3804567812567" },
                    { 3, new DateTime(1988, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "katy@gmail.com", "https://www.instagram.com/katyperry/", "Katy Perry", "+3807891234456" },
                    { 4, new DateTime(1995, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "rihanna@gmail.com", "https://www.instagram.com/badgalriri/", "Rihanna", "+3807895678123" },
                    { 5, new DateTime(1997, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "billie@gmail.com", "https://www.instagram.com/billieeilish/", "Billie Eilish", "+3805674523456" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "Rap" },
                    { 3, "Rock" },
                    { 4, "Jazz" },
                    { 5, "Classical" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 8, 15, 0, 2, 30, 0, DateTimeKind.Unspecified), 1, new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beautiful" },
                    { 2, new DateTime(2000, 8, 15, 0, 3, 50, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Old Town Road" },
                    { 3, new DateTime(2000, 8, 15, 0, 1, 40, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dark Hourse" },
                    { 4, new DateTime(2000, 8, 15, 0, 2, 25, 0, DateTimeKind.Unspecified), 4, new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diamonds" },
                    { 5, new DateTime(2000, 8, 15, 0, 3, 22, 0, DateTimeKind.Unspecified), 5, new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lovely" }
                });

            migrationBuilder.InsertData(
                table: "ArtistSong",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongId",
                table: "ArtistSong",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreId",
                table: "Song",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
