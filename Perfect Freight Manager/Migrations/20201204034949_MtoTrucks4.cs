using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class MtoTrucks4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "notes",
                table: "maintenancetrucktipo2s");

            migrationBuilder.DropColumn(
                name: "numberorder",
                table: "maintenancetrucktipo2s");

            migrationBuilder.DropColumn(
                name: "statusorder",
                table: "maintenancetrucktipo2s");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "notes",
                table: "maintenancetrucktipo2s",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numberorder",
                table: "maintenancetrucktipo2s",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "statusorder",
                table: "maintenancetrucktipo2s",
                type: "text",
                nullable: true);
        }
    }
}
