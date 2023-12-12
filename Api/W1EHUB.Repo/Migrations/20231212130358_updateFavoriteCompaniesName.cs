using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W1EHUB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class updateFavoriteCompaniesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCompany_Companies_CompanyId",
                table: "FavoriteCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCompany_Favorites_FavoriteId",
                table: "FavoriteCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteCompany",
                table: "FavoriteCompany");

            migrationBuilder.RenameTable(
                name: "FavoriteCompany",
                newName: "FavoriteCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCompany_FavoriteId",
                table: "FavoriteCompanies",
                newName: "IX_FavoriteCompanies_FavoriteId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCompany_CompanyId",
                table: "FavoriteCompanies",
                newName: "IX_FavoriteCompanies_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteCompanies",
                table: "FavoriteCompanies",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 12, 18, 3, 57, 928, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCompanies_Companies_CompanyId",
                table: "FavoriteCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCompanies_Favorites_FavoriteId",
                table: "FavoriteCompanies",
                column: "FavoriteId",
                principalTable: "Favorites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCompanies_Companies_CompanyId",
                table: "FavoriteCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCompanies_Favorites_FavoriteId",
                table: "FavoriteCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteCompanies",
                table: "FavoriteCompanies");

            migrationBuilder.RenameTable(
                name: "FavoriteCompanies",
                newName: "FavoriteCompany");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCompanies_FavoriteId",
                table: "FavoriteCompany",
                newName: "IX_FavoriteCompany_FavoriteId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCompanies_CompanyId",
                table: "FavoriteCompany",
                newName: "IX_FavoriteCompany_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteCompany",
                table: "FavoriteCompany",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 12, 12, 17, 47, 20, 202, DateTimeKind.Local).AddTicks(3449));

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCompany_Companies_CompanyId",
                table: "FavoriteCompany",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCompany_Favorites_FavoriteId",
                table: "FavoriteCompany",
                column: "FavoriteId",
                principalTable: "Favorites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
