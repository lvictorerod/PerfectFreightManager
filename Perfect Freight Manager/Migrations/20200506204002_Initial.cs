using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Perfect_Freight_Manager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    nick = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    authorization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "citystates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CtyState = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citystates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CodeZip = table.Column<string>(nullable: true),
                    MainPhoneNumber = table.Column<string>(nullable: true),
                    OfficeDayHours = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    BillingEmailAddress = table.Column<string>(nullable: true),
                    BillingFaxNumber = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "codezips",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    AreaCode = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Long = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codezips", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contactclients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idClient = table.Column<int>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ExtNumber = table.Column<string>(nullable: true),
                    CellPhoneNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DptCategory = table.Column<string>(nullable: true),
                    AgreementDate = table.Column<DateTime>(nullable: false),
                    DetentionPay = table.Column<string>(nullable: true),
                    Banned = table.Column<int>(nullable: false),
                    Inactive = table.Column<int>(nullable: false),
                    StarTime = table.Column<int>(nullable: false),
                    USDDOTNumber = table.Column<int>(nullable: false),
                    MCNumber = table.Column<int>(nullable: false),
                    InsuranceAgency = table.Column<int>(nullable: false),
                    PolicyNumber = table.Column<string>(nullable: true),
                    CargoAmount = table.Column<string>(nullable: true),
                    LiabilityAmount = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    MyProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactclients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "driverprofiles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthay = table.Column<DateTime>(nullable: false),
                    AssignedTruck = table.Column<int>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    EndServiceDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CodeZip = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    CellService = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmergName = table.Column<string>(nullable: true),
                    EmergAddress = table.Column<string>(nullable: true),
                    EmergCity = table.Column<string>(nullable: true),
                    EmergState = table.Column<string>(nullable: true),
                    EmergZip = table.Column<string>(nullable: true),
                    EmergHomePhone = table.Column<string>(nullable: true),
                    EmergCellPhone = table.Column<string>(nullable: true),
                    LoadedParPerMile = table.Column<int>(nullable: false),
                    EmptyPayPerMile = table.Column<int>(nullable: false),
                    TonnagePay = table.Column<int>(nullable: false),
                    PayByHours = table.Column<int>(nullable: false),
                    PayMethod = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    CDLNumber = table.Column<int>(nullable: false),
                    CDLState = table.Column<string>(nullable: true),
                    CDLClass = table.Column<string>(nullable: true),
                    CDLEndor = table.Column<string>(nullable: true),
                    CDLExpirDate = table.Column<DateTime>(nullable: false),
                    MedCard = table.Column<string>(nullable: true),
                    SSNumber = table.Column<string>(nullable: true),
                    WHDate = table.Column<DateTime>(nullable: false),
                    WHDescription = table.Column<string>(nullable: true),
                    WHCategory = table.Column<int>(nullable: false),
                    WHAmount = table.Column<int>(nullable: false),
                    DriverPhoto = table.Column<byte>(nullable: false),
                    CDLPhoto = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driverprofiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceNumber = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Payment = table.Column<int>(nullable: false),
                    Truck = table.Column<int>(nullable: false),
                    Trailer = table.Column<int>(nullable: false),
                    APU = table.Column<int>(nullable: false),
                    TruckMileage = table.Column<string>(nullable: true),
                    TrailerMileage = table.Column<string>(nullable: true),
                    APUHours = table.Column<string>(nullable: true),
                    PMTruck = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    VendorID = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CodeZip = table.Column<string>(nullable: true),
                    TripID = table.Column<int>(nullable: false),
                    ExpenseCategory = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MR = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Receipt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgencyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CodeZip = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneTollFree = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phoneBooks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CodeZip = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthay = table.Column<DateTime>(nullable: false),
                    HomePhone = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    MyProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phoneBooks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReceiptPhoto = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "revenues",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Client = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    loadID = table.Column<string>(nullable: true),
                    LoadStatus = table.Column<int>(nullable: false),
                    Driver = table.Column<string>(nullable: true),
                    TruckID = table.Column<int>(nullable: false),
                    TrailerID = table.Column<int>(nullable: false),
                    ChassisID = table.Column<int>(nullable: false),
                    SealNumber = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    PieceCount = table.Column<int>(nullable: false),
                    LoadTemp = table.Column<int>(nullable: false),
                    LoadType = table.Column<int>(nullable: false),
                    LastEmpytDate = table.Column<DateTime>(nullable: false),
                    DeadHeadFrom = table.Column<int>(nullable: false),
                    LasEmptyOdometer = table.Column<int>(nullable: false),
                    LoadDate = table.Column<DateTime>(nullable: false),
                    StartCitySt = table.Column<int>(nullable: false),
                    LoadOdometer = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EndCityST = table.Column<int>(nullable: false),
                    EndOdometer = table.Column<int>(nullable: false),
                    PersonalMiles = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PayCategory = table.Column<int>(nullable: false),
                    PayAmount = table.Column<int>(nullable: false),
                    DeadHeadMiles = table.Column<int>(nullable: false),
                    LoadMiles = table.Column<int>(nullable: false),
                    TotalMiles = table.Column<int>(nullable: false),
                    FlatRate = table.Column<int>(nullable: false),
                    TotalOtherPay = table.Column<int>(nullable: false),
                    TotalTripPay = table.Column<int>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revenues", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rvexpenses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    iDRevenue = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rvexpenses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rvfuels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    iDRevenue = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    RF = table.Column<int>(nullable: false),
                    DEF = table.Column<int>(nullable: false),
                    PreMileage = table.Column<int>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    TruckStop = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Payment = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    Advance = table.Column<int>(nullable: false),
                    InvoiceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rvfuels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rvnotes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    iDRevenue = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rvnotes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rvpickupDrops",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    iDRevenue = table.Column<int>(nullable: false),
                    ArrivaDate = table.Column<DateTime>(nullable: false),
                    PickupDropDate = table.Column<DateTime>(nullable: false),
                    ShipperReceive = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ProNumber = table.Column<int>(nullable: false),
                    AppoinmentDate = table.Column<DateTime>(nullable: false),
                    SignedFor = table.Column<string>(nullable: true),
                    Odometer = table.Column<int>(nullable: false),
                    DepartDate = table.Column<DateTime>(nullable: false),
                    TotalTime = table.Column<int>(nullable: false),
                    DetentioPay = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rvpickupDrops", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shipperreceivers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    codezip = table.Column<string>(nullable: true),
                    phoneemergency = table.Column<string>(nullable: true),
                    officeday = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    directions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipperreceivers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trailersprofiles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerName = table.Column<string>(nullable: true),
                    TrailerNumber = table.Column<int>(nullable: false),
                    VinNumber = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    PmMileage = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    TireSize = table.Column<string>(nullable: true),
                    Axels = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Photo = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trailersprofiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trucksprofiles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    TruckNumber = table.Column<int>(nullable: false),
                    VinNumber = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    PmMileage = table.Column<int>(nullable: false),
                    TruckColor = table.Column<string>(nullable: true),
                    TireSize = table.Column<string>(nullable: true),
                    Axles = table.Column<string>(nullable: true),
                    EngineMake = table.Column<string>(nullable: true),
                    EnginePower = table.Column<string>(nullable: true),
                    EngineSN = table.Column<string>(nullable: true),
                    TransType = table.Column<string>(nullable: true),
                    EmptyWgt = table.Column<string>(nullable: true),
                    FuelTank = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Photo = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trucksprofiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vendorcategories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendorcategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vendors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    venderidcode = table.Column<string>(nullable: true),
                    Addres = table.Column<string>(nullable: true),
                    Addres2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CodeZip = table.Column<string>(nullable: true),
                    TaxID = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Long = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendors", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrations");

            migrationBuilder.DropTable(
                name: "citystates");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "codezips");

            migrationBuilder.DropTable(
                name: "contactclients");

            migrationBuilder.DropTable(
                name: "driverprofiles");

            migrationBuilder.DropTable(
                name: "expenses");

            migrationBuilder.DropTable(
                name: "insurances");

            migrationBuilder.DropTable(
                name: "phoneBooks");

            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropTable(
                name: "revenues");

            migrationBuilder.DropTable(
                name: "rvexpenses");

            migrationBuilder.DropTable(
                name: "rvfuels");

            migrationBuilder.DropTable(
                name: "rvnotes");

            migrationBuilder.DropTable(
                name: "rvpickupDrops");

            migrationBuilder.DropTable(
                name: "shipperreceivers");

            migrationBuilder.DropTable(
                name: "trailersprofiles");

            migrationBuilder.DropTable(
                name: "trucksprofiles");

            migrationBuilder.DropTable(
                name: "vendorcategories");

            migrationBuilder.DropTable(
                name: "vendors");
        }
    }
}
