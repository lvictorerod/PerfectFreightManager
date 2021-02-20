using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class PickupDrop2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pickupappoinment",
                table: "rvpickupdrops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pickupnumber",
                table: "rvpickupdrops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pickuptime",
                table: "rvpickupdrops",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pickupappoinment",
                table: "rvpickupdrops");

            migrationBuilder.DropColumn(
                name: "pickupnumber",
                table: "rvpickupdrops");

            migrationBuilder.DropColumn(
                name: "pickuptime",
                table: "rvpickupdrops");
        }
    }
}
