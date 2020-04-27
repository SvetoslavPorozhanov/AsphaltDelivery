namespace AsphaltDelivery.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AllDeletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "RoadObjects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "RoadObjects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RoadObjects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "RoadObjects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Firms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Firms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Firms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Firms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Drivers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Drivers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Courses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AsphaltMixtures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AsphaltMixtures",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AsphaltMixtures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AsphaltMixtures",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AsphaltBases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AsphaltBases",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AsphaltBases",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AsphaltBases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoadObjects_IsDeleted",
                table: "RoadObjects",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_IsDeleted",
                table: "Firms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_IsDeleted",
                table: "Drivers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IsDeleted",
                table: "Courses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AsphaltMixtures_IsDeleted",
                table: "AsphaltMixtures",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AsphaltBases_IsDeleted",
                table: "AsphaltBases",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoadObjects_IsDeleted",
                table: "RoadObjects");

            migrationBuilder.DropIndex(
                name: "IX_Firms_IsDeleted",
                table: "Firms");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_IsDeleted",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Courses_IsDeleted",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AsphaltMixtures_IsDeleted",
                table: "AsphaltMixtures");

            migrationBuilder.DropIndex(
                name: "IX_AsphaltBases_IsDeleted",
                table: "AsphaltBases");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RoadObjects");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "RoadObjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RoadObjects");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "RoadObjects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AsphaltMixtures");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AsphaltMixtures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AsphaltMixtures");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AsphaltMixtures");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AsphaltBases");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AsphaltBases");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AsphaltBases");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AsphaltBases");
        }
    }
}
