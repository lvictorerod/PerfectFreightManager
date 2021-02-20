using Microsoft.EntityFrameworkCore.Migrations;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class RVNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "requirements",
                table: "rvnotes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "requirements",
                table: "rvnotes");
        }
    }
}
