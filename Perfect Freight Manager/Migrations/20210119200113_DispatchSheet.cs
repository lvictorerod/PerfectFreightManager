using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class DispatchSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dispatchsheets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dsid = table.Column<string>(nullable: true),
                    dsloadid = table.Column<string>(nullable: true),
                    dsdriver = table.Column<string>(nullable: true),
                    tdsequipment = table.Column<string>(nullable: true),
                    dsshipper = table.Column<string>(nullable: true),
                    dsaddressshipper = table.Column<string>(nullable: true),
                    dsphoneshipper = table.Column<string>(nullable: true),
                    dspickupdate = table.Column<string>(nullable: true),
                    dspickuptime = table.Column<string>(nullable: true),
                    dspickupnumber = table.Column<string>(nullable: true),
                    dspickupappoinment = table.Column<string>(nullable: true),
                    dsreceiver = table.Column<string>(nullable: true),
                    dsaddressreceiver = table.Column<string>(nullable: true),
                    dsphonereceiver = table.Column<string>(nullable: true),
                    dsreceiverdate = table.Column<string>(nullable: true),
                    dsdeliverytime = table.Column<string>(nullable: true),
                    dsdeliverynumber = table.Column<string>(nullable: true),
                    dsdeliveryappoinment = table.Column<string>(nullable: true),
                    rdloadid = table.Column<string>(nullable: true),
                    dsammount = table.Column<string>(nullable: true),
                    dsrate = table.Column<string>(nullable: true),
                    dsextended = table.Column<string>(nullable: true),
                    dstotal = table.Column<string>(nullable: true),
                    dsnotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispatchsheets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "docregisters",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idreg = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    document = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docregisters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "registeraccidents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idreg = table.Column<string>(nullable: true),
                    regcarrier = table.Column<string>(nullable: true),
                    regfilenumber = table.Column<string>(nullable: true),
                    regvehiclenumber = table.Column<string>(nullable: true),
                    regdriver = table.Column<string>(nullable: true),
                    regfechafrom = table.Column<string>(nullable: true),
                    regfechato = table.Column<string>(nullable: true),
                    regfechaaccident = table.Column<string>(nullable: true),
                    reglocation = table.Column<string>(nullable: true),
                    reginjurence = table.Column<string>(nullable: true),
                    regfatalities = table.Column<string>(nullable: true),
                    regdollars = table.Column<string>(nullable: true),
                    reghazardous = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registeraccidents", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dispatchsheets");

            migrationBuilder.DropTable(
                name: "docregisters");

            migrationBuilder.DropTable(
                name: "registeraccidents");
        }
    }
}
