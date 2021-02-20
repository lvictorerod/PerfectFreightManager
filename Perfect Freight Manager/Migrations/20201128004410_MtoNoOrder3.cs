using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class MtoNoOrder3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "statusorder",
                table: "maintenancewinters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusorder",
                table: "maintenancetrucktipo3s",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusorder",
                table: "maintenancetrucktipo2s",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusorder",
                table: "maintenancetruckpms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusorder",
                table: "maintenancetrailers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusorder",
                table: "maintenancesummers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statusorder",
                table: "maintenancewinters");

            migrationBuilder.DropColumn(
                name: "statusorder",
                table: "maintenancetrucktipo3s");

            migrationBuilder.DropColumn(
                name: "statusorder",
                table: "maintenancetrucktipo2s");

            migrationBuilder.DropColumn(
                name: "statusorder",
                table: "maintenancetruckpms");

            migrationBuilder.DropColumn(
                name: "statusorder",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "statusorder",
                table: "maintenancesummers");
        }
    }
}
