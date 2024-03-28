using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidPortal.web.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CovidPositiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecoveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoronaVaccine1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoronaManufacturer1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoronaVaccine2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoronaManufacturer2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoronaVaccine3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoronaManufacturer3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoronaVaccine4 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoronaManufacturer4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccins", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Vaccins");
        }
    }
}
