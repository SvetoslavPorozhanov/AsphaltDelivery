using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsphaltDelivery.Data.Migrations
{
    public partial class TruckBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Trucks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Trucks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Trucks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Trucks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_IsDeleted",
                table: "Trucks",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trucks_IsDeleted",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Trucks");
        }
    }
}
