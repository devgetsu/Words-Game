using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Word_Game.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstMigrationWordGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Coins = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    Coins = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    _Word = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LevelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Coins", "Name" },
                values: new object[,]
                {
                    { new Guid("42d2a78b-3b29-4c73-8495-4177a872828a"), 2L, "Easy" },
                    { new Guid("aaef71b2-750a-42c6-ae6d-9e5ab5e2c1ab"), 4L, "Medium" },
                    { new Guid("f7c92048-4153-4b64-9466-0693b90b8396"), 6L, "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Coins", "IsAdmin", "Password", "Username" },
                values: new object[] { new Guid("ec1370b9-7780-45f3-b43b-c2ab10ee26b0"), 0L, true, "google_admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Words_LevelId",
                table: "Words",
                column: "LevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Levels");
        }
    }
}
