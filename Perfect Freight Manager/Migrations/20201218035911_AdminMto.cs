using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class AdminMto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "summerfrom",
                table: "adminmaintenances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "summerto",
                table: "adminmaintenances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "winterfrom",
                table: "adminmaintenances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "winterto",
                table: "adminmaintenances",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "summerfrom",
                table: "adminmaintenances");

            migrationBuilder.DropColumn(
                name: "summerto",
                table: "adminmaintenances");

            migrationBuilder.DropColumn(
                name: "winterfrom",
                table: "adminmaintenances");

            migrationBuilder.DropColumn(
                name: "winterto",
                table: "adminmaintenances");
        }
    }
}
