using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class TruckTrailer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "equipment",
                table: "trucksprofiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "equipment",
                table: "trailersprofiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "equipment",
                table: "trucksprofiles");

            migrationBuilder.DropColumn(
                name: "equipment",
                table: "trailersprofiles");
        }
    }
}
