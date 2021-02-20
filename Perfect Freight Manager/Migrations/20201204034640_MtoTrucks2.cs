using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class MtoTrucks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pot1",
                table: "maintenancetrucktipo2s");

            migrationBuilder.DropColumn(
                name: "prt1",
                table: "maintenancetrucktipo2s");

            migrationBuilder.DropColumn(
                name: "rr1",
                table: "maintenancetrucktipo2s");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pot1",
                table: "maintenancetrucktipo2s",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prt1",
                table: "maintenancetrucktipo2s",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rr1",
                table: "maintenancetrucktipo2s",
                type: "text",
                nullable: true);
        }
    }
}
