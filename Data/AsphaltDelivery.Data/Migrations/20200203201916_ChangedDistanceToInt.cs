using Microsoft.EntityFrameworkCore.Migrations;

namespace AsphaltDelivery.Data.Migrations
{
    public partial class ChangedDistanceToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TransportDistance",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TransportDistance",
                table: "Courses",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
