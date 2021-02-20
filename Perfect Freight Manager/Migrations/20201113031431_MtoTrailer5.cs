using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class MtoTrailer5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "innr39",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "innr40",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "innr41",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "innr42",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "innr43",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "innr44",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "innr45",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "innr46",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "innr47",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "innr48",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok39",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok40",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok41",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok42",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok43",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok44",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok45",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok46",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok47",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "inok48",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "notes",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr39",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr40",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr41",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr42",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr43",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr44",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr45",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr46",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr47",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outnr48",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok39",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok40",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok41",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok42",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok43",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok44",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok45",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok46",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok47",
                table: "maintenancetrailers");

            migrationBuilder.DropColumn(
                name: "outok48",
                table: "maintenancetrailers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "innr39",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "innr40",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "innr41",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "innr42",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "innr43",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "innr44",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "innr45",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "innr46",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "innr47",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "innr48",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok39",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok40",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok41",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok42",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok43",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok44",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok45",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok46",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok47",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inok48",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "notes",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr39",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr40",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr41",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr42",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr43",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr44",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr45",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr46",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr47",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outnr48",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok39",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok40",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok41",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok42",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok43",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok44",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok45",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok46",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok47",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "outok48",
                table: "maintenancetrailers",
                type: "text",
                nullable: true);
        }
    }
}
