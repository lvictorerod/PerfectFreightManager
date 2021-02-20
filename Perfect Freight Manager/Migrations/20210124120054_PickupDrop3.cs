using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class PickupDrop3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "apptdeliverynumber",
                table: "rvpickupdrops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "apptpickupnumber",
                table: "rvpickupdrops",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "trailertypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trailertypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trucktypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trucktypes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trailertypes");

            migrationBuilder.DropTable(
                name: "trucktypes");

            migrationBuilder.DropColumn(
                name: "apptdeliverynumber",
                table: "rvpickupdrops");

            migrationBuilder.DropColumn(
                name: "apptpickupnumber",
                table: "rvpickupdrops");
        }
    }
}
