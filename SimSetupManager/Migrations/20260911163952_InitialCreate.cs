using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimSetupManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition_Weather = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition_TimeOfDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition_TrackTemp = table.Column<double>(type: "float", nullable: false),
                    Condition_AirTemp = table.Column<double>(type: "float", nullable: false),
                    Settings = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Variante = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Assetto Corsa" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "rFactor 2" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Assetto Corsa Competizione" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "iRacing" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "Project CARS 2" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "F1 2026" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "Automobilista 2" },
                    { new Guid("10000000-0000-0000-0000-000000000008"), "RaceRoom Racing Experience" },
                    { new Guid("10000000-0000-0000-0000-000000000009"), "Dirt Rally 2.0" },
                    { new Guid("10000000-0000-0000-0000-000000000010"), "Gran Turismo 7" },
                    { new Guid("10000000-0000-0000-0000-000000000011"), "Forza Motorsport 7" },
                    { new Guid("10000000-0000-0000-0000-000000000012"), "Project CARS 3" },
                    { new Guid("10000000-0000-0000-0000-000000000013"), "F1 2025" },
                    { new Guid("10000000-0000-0000-0000-000000000014"), "Forza Horizon 6" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), "Nürburgring Nordschleife" },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "Mount Panorama" },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "Circuit de Spa-Francorchamps" },
                    { new Guid("20000000-0000-0000-0000-000000000004"), "Silverstone Circuit" },
                    { new Guid("20000000-0000-0000-0000-000000000005"), "Monza Circuit" },
                    { new Guid("20000000-0000-0000-0000-000000000006"), "Suzuka Circuit" },
                    { new Guid("20000000-0000-0000-0000-000000000007"), "Laguna Seca" },
                    { new Guid("20000000-0000-0000-0000-000000000008"), "Brands Hatch" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Name", "Variante", "Year" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), "Ferrari", "488 GT3", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "Porsche", "911 GT3 R", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "Lamborghini", "Huracán GT3", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000004"), "Audi", "R8 LMS", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000005"), "Mercedes-AMG", "GT3", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000006"), "BMW", "M6 GT3", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000007"), "McLaren", "720S GT3", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000008"), "Aston Martin", "Vantage GT3", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000009"), "Nissan", "GT-R Nismo GT3", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000010"), "Chevrolet", "Corvette C8.R", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000011"), "Ford", "GT GT3", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000012"), "Toyota", "GR Supra GT4", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000013"), "Alpine", "A110 GT4", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000014"), "Honda", "NSX GT3", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000015"), "Jaguar", "F-Type GT4", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000016"), "KTM", "X-Bow GT4", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000017"), "Lotus", "Evora GT4", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000018"), "Maserati", "MC20 GT4", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000019"), "Subaru", "BRZ GT4", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000020"), "Toyota", "GR86 GT4", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000021"), "Volkswagen", "Golf GTI TCR", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000022"), "Hyundai", "i30 N TCR", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000023"), "Cupra", "Leon Competición", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000024"), "Audi", "RS 3 LMS", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000025"), "Honda", "Civic Type R TCR", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000026"), "Lexus", "RC F GT3", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Setups");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
