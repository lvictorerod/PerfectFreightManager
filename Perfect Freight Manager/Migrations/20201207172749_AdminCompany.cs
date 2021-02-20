using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class AdminCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admincompanys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    cat1 = table.Column<string>(nullable: true),
                    cat2 = table.Column<string>(nullable: true),
                    cat3 = table.Column<string>(nullable: true),
                    cat4 = table.Column<string>(nullable: true),
                    cat5 = table.Column<string>(nullable: true),
                    cat6 = table.Column<string>(nullable: true),
                    cat7 = table.Column<string>(nullable: true),
                    cat8 = table.Column<string>(nullable: true),
                    cat9 = table.Column<string>(nullable: true),
                    cat10 = table.Column<string>(nullable: true),
                    cat11 = table.Column<string>(nullable: true),
                    cat12 = table.Column<string>(nullable: true),
                    cat13 = table.Column<string>(nullable: true),
                    cat14 = table.Column<string>(nullable: true),
                    cat15 = table.Column<string>(nullable: true),
                    cat16 = table.Column<string>(nullable: true),
                    cat17 = table.Column<string>(nullable: true),
                    cat18 = table.Column<string>(nullable: true),
                    cat19 = table.Column<string>(nullable: true),
                    cat20 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admincompanys", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admincompanys");
        }
    }
}
