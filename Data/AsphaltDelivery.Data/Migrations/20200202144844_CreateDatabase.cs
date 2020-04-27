using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsphaltDelivery.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsphaltBases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsphaltBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AsphaltMixtures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsphaltMixtures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoadObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 60, nullable: false),
                    FirmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Firms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(maxLength: 8, nullable: false),
                    FirmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trucks_Firms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    TruckId = table.Column<int>(nullable: false),
                    FirmId = table.Column<int>(nullable: false),
                    AsphaltBaseId = table.Column<int>(nullable: false),
                    AsphaltMixtureId = table.Column<int>(nullable: false),
                    RoadObjectId = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    TransportDistance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AsphaltBases_AsphaltBaseId",
                        column: x => x.AsphaltBaseId,
                        principalTable: "AsphaltBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_AsphaltMixtures_AsphaltMixtureId",
                        column: x => x.AsphaltMixtureId,
                        principalTable: "AsphaltMixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Firms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_RoadObjects_RoadObjectId",
                        column: x => x.RoadObjectId,
                        principalTable: "RoadObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TruckDrivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(nullable: false),
                    TruckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckDrivers", x => new { x.DriverId, x.TruckId });
                    table.ForeignKey(
                        name: "FK_TruckDrivers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckDrivers_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsphaltBases_Name",
                table: "AsphaltBases",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AsphaltMixtures_Type",
                table: "AsphaltMixtures",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AsphaltBaseId",
                table: "Courses",
                column: "AsphaltBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AsphaltMixtureId",
                table: "Courses",
                column: "AsphaltMixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DriverId",
                table: "Courses",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FirmId",
                table: "Courses",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_RoadObjectId",
                table: "Courses",
                column: "RoadObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TruckId",
                table: "Courses",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_FirmId",
                table: "Drivers",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_FullName",
                table: "Drivers",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Firms_Name",
                table: "Firms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoadObjects_Name",
                table: "RoadObjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TruckDrivers_TruckId",
                table: "TruckDrivers",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_FirmId",
                table: "Trucks",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_RegistrationNumber",
                table: "Trucks",
                column: "RegistrationNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "TruckDrivers");

            migrationBuilder.DropTable(
                name: "AsphaltBases");

            migrationBuilder.DropTable(
                name: "AsphaltMixtures");

            migrationBuilder.DropTable(
                name: "RoadObjects");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "Firms");
        }
    }
}
