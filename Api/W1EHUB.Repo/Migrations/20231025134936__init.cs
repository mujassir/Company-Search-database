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
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMember_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Address", "Country", "CreateAt", "Email", "Name", "Region", "Telephone", "TypeOfCompany", "UpdatedAt", "Website" },
                values: new object[,]
                {
                    { 1, "1 Main St, Sampleville", "Country 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company1.com", "Company 1", "Region 1", "123-456-1000", "Type Of Company1", null, "www.company1.com" },
                    { 2, "2 Main St, Sampleville", "Country 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company2.com", "Company 2", "Region 2", "123-456-2000", "Type Of Company2", null, "www.company2.com" },
                    { 3, "3 Main St, Sampleville", "Country 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company3.com", "Company 3", "Region 3", "123-456-3000", "Type Of Company3", null, "www.company3.com" },
                    { 4, "4 Main St, Sampleville", "Country 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company4.com", "Company 4", "Region 4", "123-456-4000", "Type Of Company4", null, "www.company4.com" },
                    { 5, "5 Main St, Sampleville", "Country 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company5.com", "Company 5", "Region 5", "123-456-5000", "Type Of Company5", null, "www.company5.com" },
                    { 6, "6 Main St, Sampleville", "Country 6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company6.com", "Company 6", "Region 6", "123-456-6000", "Type Of Company6", null, "www.company6.com" },
                    { 7, "7 Main St, Sampleville", "Country 7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company7.com", "Company 7", "Region 7", "123-456-7000", "Type Of Company7", null, "www.company7.com" },
                    { 8, "8 Main St, Sampleville", "Country 8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company8.com", "Company 8", "Region 8", "123-456-8000", "Type Of Company8", null, "www.company8.com" },
                    { 9, "9 Main St, Sampleville", "Country 9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company9.com", "Company 9", "Region 9", "123-456-9000", "Type Of Company9", null, "www.company9.com" },
                    { 10, "10 Main St, Sampleville", "Country 10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company10.com", "Company 10", "Region 10", "123-456-10000", "Type Of Company10", null, "www.company10.com" },
                    { 11, "11 Main St, Sampleville", "Country 11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company11.com", "Company 11", "Region 11", "123-456-11000", "Type Of Company11", null, "www.company11.com" },
                    { 12, "12 Main St, Sampleville", "Country 12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company12.com", "Company 12", "Region 12", "123-456-12000", "Type Of Company12", null, "www.company12.com" },
                    { 13, "13 Main St, Sampleville", "Country 13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company13.com", "Company 13", "Region 13", "123-456-13000", "Type Of Company13", null, "www.company13.com" },
                    { 14, "14 Main St, Sampleville", "Country 14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company14.com", "Company 14", "Region 14", "123-456-14000", "Type Of Company14", null, "www.company14.com" },
                    { 15, "15 Main St, Sampleville", "Country 15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company15.com", "Company 15", "Region 15", "123-456-15000", "Type Of Company15", null, "www.company15.com" },
                    { 16, "16 Main St, Sampleville", "Country 16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company16.com", "Company 16", "Region 16", "123-456-16000", "Type Of Company16", null, "www.company16.com" },
                    { 17, "17 Main St, Sampleville", "Country 17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company17.com", "Company 17", "Region 17", "123-456-17000", "Type Of Company17", null, "www.company17.com" },
                    { 18, "18 Main St, Sampleville", "Country 18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company18.com", "Company 18", "Region 18", "123-456-18000", "Type Of Company18", null, "www.company18.com" },
                    { 19, "19 Main St, Sampleville", "Country 19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company19.com", "Company 19", "Region 19", "123-456-19000", "Type Of Company19", null, "www.company19.com" },
                    { 20, "20 Main St, Sampleville", "Country 20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@company20.com", "Company 20", "Region 20", "123-456-20000", "Type Of Company20", null, "www.company20.com" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Password", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 25, 18, 49, 36, 544, DateTimeKind.Local).AddTicks(9557), "a@abc.com", "aaa", null },
                    { 2, new DateTime(2023, 10, 25, 18, 49, 36, 544, DateTimeKind.Local).AddTicks(9570), "b@abc.com", "bbb", null },
                    { 3, new DateTime(2023, 10, 25, 18, 49, 36, 544, DateTimeKind.Local).AddTicks(9571), "c@abc.com", "ccc", null },
                    { 4, new DateTime(2023, 10, 25, 18, 49, 36, 544, DateTimeKind.Local).AddTicks(9573), "d@abc.com", "ddd", null }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CompanyId", "CreateAt", "Description", "Level", "Nature", "Title", "Type", "UpdatedAt", "Year" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 1", "Project 1 Type", null, 2023 },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 1", "Project 2 Type", null, 2023 },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 1", "Project 3 Type", null, 2023 },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 2", "Project 1 Type", null, 2023 },
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 2", "Project 2 Type", null, 2023 },
                    { 6, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 2", "Project 3 Type", null, 2023 },
                    { 7, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 3", "Project 1 Type", null, 2023 },
                    { 8, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 3", "Project 2 Type", null, 2023 },
                    { 9, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 3", "Project 3 Type", null, 2023 },
                    { 10, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 4", "Project 1 Type", null, 2023 },
                    { 11, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 4", "Project 2 Type", null, 2023 },
                    { 12, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 4", "Project 3 Type", null, 2023 },
                    { 13, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 5", "Project 1 Type", null, 2023 },
                    { 14, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 5", "Project 2 Type", null, 2023 },
                    { 15, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 5", "Project 3 Type", null, 2023 },
                    { 16, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 6", "Project 1 Type", null, 2023 },
                    { 17, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 6", "Project 2 Type", null, 2023 },
                    { 18, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 6", "Project 3 Type", null, 2023 },
                    { 19, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 7", "Project 1 Type", null, 2023 },
                    { 20, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 7", "Project 2 Type", null, 2023 },
                    { 21, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 7", "Project 3 Type", null, 2023 },
                    { 22, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 8", "Project 1 Type", null, 2023 },
                    { 23, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 8", "Project 2 Type", null, 2023 },
                    { 24, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 8", "Project 3 Type", null, 2023 },
                    { 25, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 9", "Project 1 Type", null, 2023 },
                    { 26, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 9", "Project 2 Type", null, 2023 },
                    { 27, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 9", "Project 3 Type", null, 2023 },
                    { 28, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 10", "Project 1 Type", null, 2023 },
                    { 29, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 10", "Project 2 Type", null, 2023 },
                    { 30, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 10", "Project 3 Type", null, 2023 },
                    { 31, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 11", "Project 1 Type", null, 2023 },
                    { 32, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 11", "Project 2 Type", null, 2023 },
                    { 33, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 11", "Project 3 Type", null, 2023 },
                    { 34, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 12", "Project 1 Type", null, 2023 },
                    { 35, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 12", "Project 2 Type", null, 2023 },
                    { 36, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 12", "Project 3 Type", null, 2023 },
                    { 37, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 13", "Project 1 Type", null, 2023 },
                    { 38, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 13", "Project 2 Type", null, 2023 },
                    { 39, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 13", "Project 3 Type", null, 2023 },
                    { 40, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 14", "Project 1 Type", null, 2023 },
                    { 41, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 14", "Project 2 Type", null, 2023 },
                    { 42, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 14", "Project 3 Type", null, 2023 },
                    { 43, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 15", "Project 1 Type", null, 2023 },
                    { 44, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 15", "Project 2 Type", null, 2023 },
                    { 45, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 15", "Project 3 Type", null, 2023 },
                    { 46, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 16", "Project 1 Type", null, 2023 },
                    { 47, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 16", "Project 2 Type", null, 2023 },
                    { 48, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 16", "Project 3 Type", null, 2023 },
                    { 49, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 17", "Project 1 Type", null, 2023 },
                    { 50, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 17", "Project 2 Type", null, 2023 },
                    { 51, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 17", "Project 3 Type", null, 2023 },
                    { 52, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 18", "Project 1 Type", null, 2023 },
                    { 53, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 18", "Project 2 Type", null, 2023 },
                    { 54, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 18", "Project 3 Type", null, 2023 },
                    { 55, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 19", "Project 1 Type", null, 2023 },
                    { 56, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 19", "Project 2 Type", null, 2023 },
                    { 57, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 19", "Project 3 Type", null, 2023 },
                    { 58, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 1", "Project 1 Nature", "Project 1 for Company 20", "Project 1 Type", null, 2023 },
                    { 59, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 2", "Project 2 Nature", "Project 2 for Company 20", "Project 2 Type", null, 2023 },
                    { 60, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Level 3", "Project 3 Nature", "Project 3 for Company 20", "Project 3 Type", null, 2023 }
                });

            migrationBuilder.InsertData(
                table: "StaffMember",
                columns: new[] { "Id", "CompanyId", "CreateAt", "Name", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 5, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 6, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 7, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 8, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 9, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 10, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 11, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 12, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 13, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 14, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 15, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 16, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 17, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 18, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 19, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 20, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 21, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 22, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 23, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 24, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 25, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 26, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 27, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 28, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 29, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 30, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 31, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 32, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 33, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 34, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 35, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 36, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 37, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 38, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null },
                    { 39, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 1", "Role 1", null },
                    { 40, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff Member 2", "Role 2", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMember_CompanyId",
                table: "StaffMember",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "StaffMember");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
