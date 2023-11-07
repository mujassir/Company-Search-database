using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W1EHUB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class CountryAndRegionTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
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
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreateAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5761), "England", null },
                    { 2, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5763), "Scotland", null },
                    { 3, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5764), "Wales", null },
                    { 4, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5765), "Northern Ireland", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5606));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateAt", "Name", "RegionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5782), "North East England", 1, null },
                    { 2, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5783), "North West England", 1, null },
                    { 3, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5785), "Yorkshire and the Humber", 1, null },
                    { 4, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5786), "West Midlands", 1, null },
                    { 5, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5787), "East Midlands", 1, null },
                    { 6, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5836), "East of England", 1, null },
                    { 7, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5837), "South West England", 1, null },
                    { 8, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5838), "London", 1, null },
                    { 9, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5839), "South East England", 1, null },
                    { 10, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5840), "Highlands and Islands", 2, null },
                    { 11, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5841), "North East Scotland", 2, null },
                    { 12, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5842), "Central Scotland", 2, null },
                    { 13, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5843), "South of Scotland", 2, null },
                    { 14, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5845), "Glasgow", 2, null },
                    { 15, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5846), "Edinburgh and the Lothians", 2, null },
                    { 16, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5847), "West of Scotland", 2, null },
                    { 17, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5848), "North Wales", 3, null },
                    { 18, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5849), "Mid Wales", 3, null },
                    { 19, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5850), "South Wales", 3, null },
                    { 20, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5851), "Cardiff", 3, null },
                    { 21, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5852), "Swansea", 3, null },
                    { 22, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5853), "Newport", 3, null },
                    { 23, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5854), "Antrim and Newtownabbey", 4, null },
                    { 24, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5855), "Armagh, Banbridge, and Craigavon", 4, null },
                    { 25, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5856), "Belfast", 4, null },
                    { 26, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5857), "Causeway Coast and Glens", 4, null },
                    { 27, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5858), "Derry and Strabane", 4, null },
                    { 28, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5859), "Fermanagh and Omagh", 4, null },
                    { 29, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5860), "Lisburn and Castlereagh", 4, null },
                    { 30, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5861), "Mid and East Antrim", 4, null },
                    { 31, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5862), "Mid Ulster", 4, null },
                    { 32, new DateTime(2023, 11, 7, 15, 12, 50, 224, DateTimeKind.Local).AddTicks(5863), "Newry, Mourne, and Down", 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_RegionId",
                table: "Countries",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 11, 3, 19, 0, 55, 742, DateTimeKind.Local).AddTicks(4039));
        }
    }
}
