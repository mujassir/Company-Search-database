using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W1EHUB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Password", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2023, 11, 3, 19, 0, 55, 742, DateTimeKind.Local).AddTicks(4039), "abc@email.com", "abc", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
