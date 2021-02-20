using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class Profiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "statusstop",
                table: "trucksprofiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusstop",
                table: "trailersprofiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusstop",
                table: "apuprofiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statusstop",
                table: "trucksprofiles");

            migrationBuilder.DropColumn(
                name: "statusstop",
                table: "trailersprofiles");

            migrationBuilder.DropColumn(
                name: "statusstop",
                table: "apuprofiles");
        }
    }
}
