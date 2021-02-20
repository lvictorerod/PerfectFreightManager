using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class PickupDrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sealreceiver",
                table: "rvpickupdrops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sealshipper",
                table: "rvpickupdrops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shipper",
                table: "rvpickupdrops",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sealreceiver",
                table: "rvpickupdrops");

            migrationBuilder.DropColumn(
                name: "sealshipper",
                table: "rvpickupdrops");

            migrationBuilder.DropColumn(
                name: "shipper",
                table: "rvpickupdrops");
        }
    }
}
