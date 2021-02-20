using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class MtoNoOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apu6",
                table: "maintenanceapus");

            migrationBuilder.DropColumn(
                name: "apu7",
                table: "maintenanceapus");

            migrationBuilder.AddColumn<string>(
                name: "numberorder",
                table: "maintenancewinters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numberorder",
                table: "maintenancetrucktipo3s",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numberorder",
                table: "maintenancetrucktipo2s",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numberorder",
                table: "maintenancetruckpms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numberorder",
                table: "maintenancetrailers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numberorder",
                table: "maintenancesummers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numberorder",
                table: "maintenanceapus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numberorder",
                table: "maintenancewinters");

            migrationBuilder.DropColumn(
                name: "numberorder",
                table: "maintenancetrucktipo3s");

            migrationBuilder.DropColumn(
                name: "numberorder",
                table: "maintenancetrucktipo2s");

            migrationBuilder.DropColumn(
                name: "numberorder",
                table: "maintenancetruckpms");

            migrationBuilder.DropColumn(
                name: "numberorder",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "numberorder",
                table: "maintenancesummers");

            migrationBuilder.DropColumn(
                name: "numberorder",
                table: "maintenanceapus");

            migrationBuilder.AddColumn<string>(
                name: "apu6",
                table: "maintenanceapus",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "apu7",
                table: "maintenanceapus",
                type: "text",
                nullable: true);
        }
    }
}
