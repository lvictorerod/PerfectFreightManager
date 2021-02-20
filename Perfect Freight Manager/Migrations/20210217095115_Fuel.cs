using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class Fuel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "def",
                table: "rvfuels");

            migrationBuilder.DropColumn(
                name: "premileage",
                table: "rvfuels");

            migrationBuilder.DropColumn(
                name: "rf",
                table: "rvfuels");

            migrationBuilder.AddColumn<string>(
                name: "costdef",
                table: "rvfuels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "quantitydef",
                table: "rvfuels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "station",
                table: "rvfuels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "costdef",
                table: "rvfuels");

            migrationBuilder.DropColumn(
                name: "quantitydef",
                table: "rvfuels");

            migrationBuilder.DropColumn(
                name: "station",
                table: "rvfuels");

            migrationBuilder.AddColumn<string>(
                name: "def",
                table: "rvfuels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "premileage",
                table: "rvfuels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rf",
                table: "rvfuels",
                type: "text",
                nullable: true);
        }
    }
}
