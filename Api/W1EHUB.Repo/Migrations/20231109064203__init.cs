using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W1EHUB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class _init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorite_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RunTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Votes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMembers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CreateAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3781), "England", null },
                    { 2, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3783), "Scotland", null },
                    { 3, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3784), "Wales", null },
                    { 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3785), "Northern Ireland", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Password", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3656), "abc@email.com", "abc", null });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "CountryId", "CreateAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3799), "North East England", null },
                    { 2, 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3801), "North West England", null },
                    { 3, 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3802), "Yorkshire and the Humber", null },
                    { 4, 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3839), "West Midlands", null },
                    { 5, 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3840), "East Midlands", null },
                    { 6, 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3841), "East of England", null },
                    { 7, 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3843), "South West England", null },
                    { 8, 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3844), "London", null },
                    { 9, 1, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3845), "South East England", null },
                    { 10, 2, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3846), "Highlands and Islands", null },
                    { 11, 2, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3847), "North East Scotland", null },
                    { 12, 2, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3848), "Central Scotland", null },
                    { 13, 2, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3849), "South of Scotland", null },
                    { 14, 2, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3850), "Glasgow", null },
                    { 15, 2, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3851), "Edinburgh and the Lothians", null },
                    { 16, 2, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3852), "West of Scotland", null },
                    { 17, 3, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3853), "North Wales", null },
                    { 18, 3, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3854), "Mid Wales", null },
                    { 19, 3, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3856), "South Wales", null },
                    { 20, 3, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3857), "Cardiff", null },
                    { 21, 3, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3858), "Swansea", null },
                    { 22, 3, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3859), "Newport", null },
                    { 23, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3860), "Antrim and Newtownabbey", null },
                    { 24, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3861), "Armagh, Banbridge, and Craigavon", null },
                    { 25, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3862), "Belfast", null },
                    { 26, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3863), "Causeway Coast and Glens", null },
                    { 27, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3864), "Derry and Strabane", null },
                    { 28, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3865), "Fermanagh and Omagh", null },
                    { 29, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3866), "Lisburn and Castlereagh", null },
                    { 30, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3867), "Mid and East Antrim", null },
                    { 31, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3868), "Mid Ulster", null },
                    { 32, 4, new DateTime(2023, 11, 9, 11, 42, 3, 25, DateTimeKind.Local).AddTicks(3869), "Newry, Mourne, and Down", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CategoryId",
                table: "Companies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UserId",
                table: "Favorite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCompany_CompanyId",
                table: "FavoriteCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCompany_FavoriteId",
                table: "FavoriteCompany",
                column: "FavoriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CompanyId",
                table: "Programs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CountryId",
                table: "Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_CompanyId",
                table: "StaffMembers",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteCompany");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
