using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W1EHUB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class verbalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteComapny");

            migrationBuilder.CreateTable(
                name: "FavoriteCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavoriteId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteCompany_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteCompany_Favorite_FavoriteId",
                        column: x => x.FavoriteId,
                        principalTable: "Favorite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCompany_CompanyId",
                table: "FavoriteCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCompany_FavoriteId",
                table: "FavoriteCompany",
                column: "FavoriteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteCompany");

            migrationBuilder.CreateTable(
                name: "FavoriteComapny",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FavoriteId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteComapny", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteComapny_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteComapny_Favorite_FavoriteId",
                        column: x => x.FavoriteId,
                        principalTable: "Favorite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteComapny_CompanyId",
                table: "FavoriteComapny",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteComapny_FavoriteId",
                table: "FavoriteComapny",
                column: "FavoriteId");
        }
    }
}
