using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCrudGame.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "skins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nchar(60)", fixedLength: true, maxLength: 60, nullable: true),
                    Code = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<int>(type: "int", nullable: false),
                    mnk = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    NickName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.id);
                    table.ForeignKey(
                        name: "FK_players_users",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSkin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    SkinId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSkin", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlayerSkin_players",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSkin_skins",
                        column: x => x.SkinId,
                        principalTable: "skins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ranks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nchar(40)", fixedLength: true, maxLength: 40, nullable: true),
                    icon = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    MaxExperience = table.Column<double>(type: "float", nullable: true),
                    MinExperience = table.Column<double>(type: "float", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ranks", x => x.id);
                    table.ForeignKey(
                        name: "FK_ranks_players",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkin_PlayerId",
                table: "PlayerSkin",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkin_SkinId",
                table: "PlayerSkin",
                column: "SkinId");

            migrationBuilder.CreateIndex(
                name: "IX_ranks_PlayerId",
                table: "ranks",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSkin");

            migrationBuilder.DropTable(
                name: "ranks");

            migrationBuilder.DropTable(
                name: "skins");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
