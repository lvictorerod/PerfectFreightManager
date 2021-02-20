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
                name: "adminaccess",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idusers = table.Column<int>(nullable: false),
                    load = table.Column<int>(nullable: false),
                    driverpay = table.Column<int>(nullable: false),
                    pickupdrop = table.Column<int>(nullable: false),
                    fuel = table.Column<int>(nullable: false),
                    expense = table.Column<int>(nullable: false),
                    route = table.Column<int>(nullable: false),
                    notes = table.Column<int>(nullable: false),
                    profitloss = table.Column<int>(nullable: false),
                    documents = table.Column<int>(nullable: false),
                    invoicestatus = table.Column<int>(nullable: false),
                    expensebyinvoice = table.Column<int>(nullable: false),
                    tripplanner = table.Column<int>(nullable: false),
                    customer = table.Column<int>(nullable: false),
                    insurance = table.Column<int>(nullable: false),
                    vendors = table.Column<int>(nullable: false),
                    phonebook = table.Column<int>(nullable: false),
                    truckfleet = table.Column<int>(nullable: false),
                    utilities = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminaccess", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adminmaintenances",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    trucktipopm = table.Column<string>(nullable: true),
                    truckstoppm = table.Column<string>(nullable: true),
                    trucktipo2 = table.Column<string>(nullable: true),
                    truckstoptipo2 = table.Column<string>(nullable: true),
                    trucktipo3 = table.Column<string>(nullable: true),
                    truckstoptipo3 = table.Column<string>(nullable: true),
                    trailertipopm = table.Column<string>(nullable: true),
                    trailerstoppm = table.Column<string>(nullable: true),
                    trailertipo2 = table.Column<string>(nullable: true),
                    trailerstoptipo2 = table.Column<string>(nullable: true),
                    trailertipo3 = table.Column<string>(nullable: true),
                    trailerstoptipo3 = table.Column<string>(nullable: true),
                    apu = table.Column<string>(nullable: true),
                    apustop = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminmaintenances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adminsystems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rphotodoc = table.Column<string>(nullable: true),
                    rprogram = table.Column<string>(nullable: true),
                    browsepref = table.Column<string>(nullable: true),
                    dueinvoice = table.Column<string>(nullable: true),
                    pastinvoice = table.Column<string>(nullable: true),
                    outinvoice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminsystems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adminusers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    codezip = table.Column<string>(nullable: true),
                    nick = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    datestart = table.Column<string>(nullable: true),
                    dateend = table.Column<string>(nullable: true),
                    photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    idclient = table.Column<string>(nullable: true),
                    department = table.Column<string>(nullable: true),
                    phonenumber = table.Column<string>(nullable: true),
                    extnumber = table.Column<string>(nullable: true),
                    celphonenumber = table.Column<string>(nullable: true),
                    faxnumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    dptcategory = table.Column<string>(nullable: true),
                    agreementdate = table.Column<string>(nullable: true),
                    detentionpay = table.Column<string>(nullable: true),
                    banned = table.Column<string>(nullable: true),
                    inactive = table.Column<string>(nullable: true),
                    startime = table.Column<string>(nullable: true),
                    usddotnumber = table.Column<string>(nullable: true),
                    mcnumber = table.Column<string>(nullable: true),
                    insuranceagency = table.Column<string>(nullable: true),
                    policynumber = table.Column<string>(nullable: true),
                    cargoamount = table.Column<string>(nullable: true),
                    liabilityamount = table.Column<string>(nullable: true),
                    expirationdate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "apuprofiles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    owner = table.Column<string>(nullable: true),
                    apunumber = table.Column<string>(nullable: true),
                    vinnumber = table.Column<string>(nullable: true),
                    licensedate = table.Column<string>(nullable: true),
                    licensedateexpire = table.Column<string>(nullable: true),
                    year = table.Column<string>(nullable: true),
                    make = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    totalhours = table.Column<string>(nullable: true),
                    photo = table.Column<byte[]>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apuprofiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brokers",
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
                    phonelocal = table.Column<string>(nullable: true),
                    phonetollfree = table.Column<string>(nullable: true),
                    cellphone = table.Column<string>(nullable: true),
                    cellservice = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true),
                    emergencynumber = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    mcnumber = table.Column<string>(nullable: true),
                    usddot = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brokers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "citystates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
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
                    name = table.Column<string>(nullable: true),
                    ownername = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    codezip = table.Column<string>(nullable: true),
                    mainphonenumber = table.Column<string>(nullable: true),
                    officedayhours = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    emailaddress = table.Column<string>(nullable: true),
                    faxnumber = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
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
                    zipcode = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    county = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    areacode = table.Column<string>(nullable: true),
                    lat = table.Column<string>(nullable: true),
                    longt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codezips", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companyprofiles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company = table.Column<string>(nullable: true),
                    owner = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    billingemail = table.Column<string>(nullable: true),
                    tollfree = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true),
                    usddot = table.Column<string>(nullable: true),
                    fid = table.Column<string>(nullable: true),
                    mc = table.Column<string>(nullable: true),
                    autohauler = table.Column<string>(nullable: true),
                    sendmailviaoutlook = table.Column<string>(nullable: true),
                    checkupdate = table.Column<string>(nullable: true),
                    uselogin = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    invoicemessage = table.Column<string>(nullable: true),
                    emailsignature = table.Column<string>(nullable: true),
                    companylogo = table.Column<byte[]>(nullable: true),
                    paypermileload = table.Column<string>(nullable: true),
                    paypermileempty = table.Column<string>(nullable: true),
                    percentagepay = table.Column<string>(nullable: true),
                    percentagepayof = table.Column<string>(nullable: true),
                    tonnagepay = table.Column<string>(nullable: true),
                    paybyhours = table.Column<string>(nullable: true),
                    paymethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyprofiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "descriptnotes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idrevenue = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    paycategory = table.Column<string>(nullable: true),
                    payamount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_descriptnotes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idrevenue = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    document = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "driverprofiles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    middlename = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    birthay = table.Column<string>(nullable: true),
                    assignedtruck = table.Column<string>(nullable: true),
                    hiredate = table.Column<string>(nullable: true),
                    endservicedate = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    codezip = table.Column<string>(nullable: true),
                    homephone = table.Column<string>(nullable: true),
                    cellphone = table.Column<string>(nullable: true),
                    cellservice = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    emergname = table.Column<string>(nullable: true),
                    emergaddress = table.Column<string>(nullable: true),
                    emergcity = table.Column<string>(nullable: true),
                    emergstate = table.Column<string>(nullable: true),
                    emergzip = table.Column<string>(nullable: true),
                    emerghomephone = table.Column<string>(nullable: true),
                    emergcellphone = table.Column<string>(nullable: true),
                    driverphoto = table.Column<byte[]>(nullable: true),
                    loadedparpermile = table.Column<string>(nullable: true),
                    emptypaypermile = table.Column<string>(nullable: true),
                    percentagepay = table.Column<string>(nullable: true),
                    percentof = table.Column<string>(nullable: true),
                    tonnagepay = table.Column<string>(nullable: true),
                    paybyhours = table.Column<string>(nullable: true),
                    paymethod = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    cdlnumber = table.Column<string>(nullable: true),
                    cdlstate = table.Column<string>(nullable: true),
                    cdlclass = table.Column<string>(nullable: true),
                    cdlendor = table.Column<string>(nullable: true),
                    cdlexpirdate = table.Column<string>(nullable: true),
                    cdlphoto = table.Column<byte[]>(nullable: true),
                    medcareexpirdate = table.Column<string>(nullable: true),
                    ssnumber = table.Column<string>(nullable: true),
                    ssphoto = table.Column<byte[]>(nullable: true),
                    medcardphoto = table.Column<byte[]>(nullable: true),
                    statusdriver = table.Column<string>(nullable: true),
                    flatratepay = table.Column<string>(nullable: true),
                    activedriver = table.Column<string>(nullable: true),
                    pickupdroppay = table.Column<string>(nullable: true),
                    vacation = table.Column<string>(nullable: true),
                    drivereld = table.Column<string>(nullable: true),
                    driverezpass = table.Column<string>(nullable: true),
                    driverinsurace = table.Column<string>(nullable: true),
                    driverprepass = table.Column<string>(nullable: true),
                    driverexpense = table.Column<string>(nullable: true),
                    driverfuel = table.Column<string>(nullable: true),
                    driverfactoryfee = table.Column<string>(nullable: true),
                    driverpaymentfee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driverprofiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "emailsettings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(nullable: true),
                    clave = table.Column<string>(nullable: true),
                    port = table.Column<string>(nullable: true),
                    principal = table.Column<string>(nullable: true),
                    smtp = table.Column<string>(nullable: true),
                    ssl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailsettings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employeeprofile",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(nullable: true),
                    middlename = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    birthay = table.Column<string>(nullable: true),
                    ss = table.Column<string>(nullable: true),
                    workfinal = table.Column<string>(nullable: true),
                    hiredate = table.Column<string>(nullable: true),
                    endservicedate = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    emailsignature = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true),
                    homephone = table.Column<string>(nullable: true),
                    cellphone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    ename = table.Column<string>(nullable: true),
                    eaddress = table.Column<string>(nullable: true),
                    ecity = table.Column<string>(nullable: true),
                    estate = table.Column<string>(nullable: true),
                    ezip = table.Column<string>(nullable: true),
                    ehomephone = table.Column<string>(nullable: true),
                    ecellphone = table.Column<string>(nullable: true),
                    employeephoto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeprofile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    invoicenumber = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    payment = table.Column<string>(nullable: true),
                    truck = table.Column<string>(nullable: true),
                    trailer = table.Column<string>(nullable: true),
                    apu = table.Column<string>(nullable: true),
                    truckmileage = table.Column<string>(nullable: true),
                    trailermileage = table.Column<string>(nullable: true),
                    apuhours = table.Column<string>(nullable: true),
                    pmtruck = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    codezip = table.Column<string>(nullable: true),
                    vendor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exresumens",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idexpense = table.Column<string>(nullable: true),
                    tripid = table.Column<string>(nullable: true),
                    expensecategory = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exresumens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "faxsetting",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    servicecode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faxsetting", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    codezip = table.Column<string>(nullable: true),
                    contactname = table.Column<string>(nullable: true),
                    phonenumber = table.Column<string>(nullable: true),
                    phonetollfree = table.Column<string>(nullable: true),
                    faxnumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenanceapus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apuid = table.Column<string>(nullable: true),
                    hourstotal = table.Column<string>(nullable: true),
                    dateinitial = table.Column<string>(nullable: true),
                    dateend = table.Column<string>(nullable: true),
                    apu1 = table.Column<string>(nullable: true),
                    apu2 = table.Column<string>(nullable: true),
                    apu3 = table.Column<string>(nullable: true),
                    apu4 = table.Column<string>(nullable: true),
                    apu5 = table.Column<string>(nullable: true),
                    apu6 = table.Column<string>(nullable: true),
                    apu7 = table.Column<string>(nullable: true),
                    incidense = table.Column<string>(nullable: true),
                    expense = table.Column<string>(nullable: true),
                    drivername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenanceapus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenancesummers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    truckid = table.Column<string>(nullable: true),
                    dateinitial = table.Column<string>(nullable: true),
                    dateend = table.Column<string>(nullable: true),
                    drivername = table.Column<string>(nullable: true),
                    sm1 = table.Column<string>(nullable: true),
                    sm2 = table.Column<string>(nullable: true),
                    sm3 = table.Column<string>(nullable: true),
                    sm4 = table.Column<string>(nullable: true),
                    sm5 = table.Column<string>(nullable: true),
                    sm6 = table.Column<string>(nullable: true),
                    sm7 = table.Column<string>(nullable: true),
                    sm8 = table.Column<string>(nullable: true),
                    sm9 = table.Column<string>(nullable: true),
                    sm10 = table.Column<string>(nullable: true),
                    sm11 = table.Column<string>(nullable: true),
                    sm12 = table.Column<string>(nullable: true),
                    sm13 = table.Column<string>(nullable: true),
                    sm14 = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenancesummers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenancetrailers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    trailerid = table.Column<string>(nullable: true),
                    milestotal = table.Column<string>(nullable: true),
                    dateinitial = table.Column<string>(nullable: true),
                    dateend = table.Column<string>(nullable: true),
                    drivername = table.Column<string>(nullable: true),
                    InOk1 = table.Column<string>(nullable: true),
                    InOk2 = table.Column<string>(nullable: true),
                    InOk3 = table.Column<string>(nullable: true),
                    InOk4 = table.Column<string>(nullable: true),
                    InOk5 = table.Column<string>(nullable: true),
                    InOk6 = table.Column<string>(nullable: true),
                    InOk7 = table.Column<string>(nullable: true),
                    InOk8 = table.Column<string>(nullable: true),
                    InOk9 = table.Column<string>(nullable: true),
                    InOk10 = table.Column<string>(nullable: true),
                    InOk11 = table.Column<string>(nullable: true),
                    InOk12 = table.Column<string>(nullable: true),
                    InOk13 = table.Column<string>(nullable: true),
                    InOk14 = table.Column<string>(nullable: true),
                    InOk15 = table.Column<string>(nullable: true),
                    InOk16 = table.Column<string>(nullable: true),
                    InOk17 = table.Column<string>(nullable: true),
                    InOk18 = table.Column<string>(nullable: true),
                    InOk19 = table.Column<string>(nullable: true),
                    InOk20 = table.Column<string>(nullable: true),
                    InOk21 = table.Column<string>(nullable: true),
                    InOk22 = table.Column<string>(nullable: true),
                    InOk23 = table.Column<string>(nullable: true),
                    InOk24 = table.Column<string>(nullable: true),
                    InNR1 = table.Column<string>(nullable: true),
                    InNR2 = table.Column<string>(nullable: true),
                    InNR3 = table.Column<string>(nullable: true),
                    InNR4 = table.Column<string>(nullable: true),
                    InNR5 = table.Column<string>(nullable: true),
                    InNR6 = table.Column<string>(nullable: true),
                    InNR7 = table.Column<string>(nullable: true),
                    InNR8 = table.Column<string>(nullable: true),
                    InNR9 = table.Column<string>(nullable: true),
                    InNR10 = table.Column<string>(nullable: true),
                    InNR11 = table.Column<string>(nullable: true),
                    InNR12 = table.Column<string>(nullable: true),
                    InNR13 = table.Column<string>(nullable: true),
                    InNR14 = table.Column<string>(nullable: true),
                    InNR15 = table.Column<string>(nullable: true),
                    InNR16 = table.Column<string>(nullable: true),
                    InNR17 = table.Column<string>(nullable: true),
                    InNR18 = table.Column<string>(nullable: true),
                    InNR19 = table.Column<string>(nullable: true),
                    InNR20 = table.Column<string>(nullable: true),
                    InNR21 = table.Column<string>(nullable: true),
                    InNR22 = table.Column<string>(nullable: true),
                    InNR23 = table.Column<string>(nullable: true),
                    InNR24 = table.Column<string>(nullable: true),
                    OutOk1 = table.Column<string>(nullable: true),
                    OutOk2 = table.Column<string>(nullable: true),
                    OutOk3 = table.Column<string>(nullable: true),
                    OutOk4 = table.Column<string>(nullable: true),
                    OutOk5 = table.Column<string>(nullable: true),
                    OutOk6 = table.Column<string>(nullable: true),
                    OutOk7 = table.Column<string>(nullable: true),
                    OutOk8 = table.Column<string>(nullable: true),
                    OutOk9 = table.Column<string>(nullable: true),
                    OutOk10 = table.Column<string>(nullable: true),
                    OutOk11 = table.Column<string>(nullable: true),
                    OutOk12 = table.Column<string>(nullable: true),
                    OutOk13 = table.Column<string>(nullable: true),
                    OutOk14 = table.Column<string>(nullable: true),
                    OutOk15 = table.Column<string>(nullable: true),
                    OutOk16 = table.Column<string>(nullable: true),
                    OutOk17 = table.Column<string>(nullable: true),
                    OutOk18 = table.Column<string>(nullable: true),
                    OutOk19 = table.Column<string>(nullable: true),
                    OutOk20 = table.Column<string>(nullable: true),
                    OutOk21 = table.Column<string>(nullable: true),
                    OutOk22 = table.Column<string>(nullable: true),
                    OutOk23 = table.Column<string>(nullable: true),
                    OutOk24 = table.Column<string>(nullable: true),
                    OutNR1 = table.Column<string>(nullable: true),
                    OutNR2 = table.Column<string>(nullable: true),
                    OutNR3 = table.Column<string>(nullable: true),
                    OutNR4 = table.Column<string>(nullable: true),
                    OutNR5 = table.Column<string>(nullable: true),
                    OutNR6 = table.Column<string>(nullable: true),
                    OutNR7 = table.Column<string>(nullable: true),
                    OutNR8 = table.Column<string>(nullable: true),
                    OutNR9 = table.Column<string>(nullable: true),
                    OutNR10 = table.Column<string>(nullable: true),
                    OutNR11 = table.Column<string>(nullable: true),
                    OutNR12 = table.Column<string>(nullable: true),
                    OutNR13 = table.Column<string>(nullable: true),
                    OutNR14 = table.Column<string>(nullable: true),
                    OutNR15 = table.Column<string>(nullable: true),
                    OutNR16 = table.Column<string>(nullable: true),
                    OutNR17 = table.Column<string>(nullable: true),
                    OutNR18 = table.Column<string>(nullable: true),
                    OutNR = table.Column<string>(nullable: true),
                    OutNR19 = table.Column<string>(nullable: true),
                    OutNR20 = table.Column<string>(nullable: true),
                    OutNR21 = table.Column<string>(nullable: true),
                    OutNR22 = table.Column<string>(nullable: true),
                    OutNR23 = table.Column<string>(nullable: true),
                    OutNR24 = table.Column<string>(nullable: true),
                    InOk25 = table.Column<string>(nullable: true),
                    InOk26 = table.Column<string>(nullable: true),
                    InOk27 = table.Column<string>(nullable: true),
                    InOk28 = table.Column<string>(nullable: true),
                    InOk29 = table.Column<string>(nullable: true),
                    InOk30 = table.Column<string>(nullable: true),
                    InOk31 = table.Column<string>(nullable: true),
                    InOk32 = table.Column<string>(nullable: true),
                    InOk33 = table.Column<string>(nullable: true),
                    InOk34 = table.Column<string>(nullable: true),
                    InOk35 = table.Column<string>(nullable: true),
                    InOk36 = table.Column<string>(nullable: true),
                    InOk37 = table.Column<string>(nullable: true),
                    InOk38 = table.Column<string>(nullable: true),
                    InOk39 = table.Column<string>(nullable: true),
                    InOk40 = table.Column<string>(nullable: true),
                    InOk41 = table.Column<string>(nullable: true),
                    InOk42 = table.Column<string>(nullable: true),
                    InOk43 = table.Column<string>(nullable: true),
                    InOk44 = table.Column<string>(nullable: true),
                    InOk45 = table.Column<string>(nullable: true),
                    InOk46 = table.Column<string>(nullable: true),
                    InOk47 = table.Column<string>(nullable: true),
                    InOk48 = table.Column<string>(nullable: true),
                    InNR25 = table.Column<string>(nullable: true),
                    InNR26 = table.Column<string>(nullable: true),
                    InNR27 = table.Column<string>(nullable: true),
                    InNR28 = table.Column<string>(nullable: true),
                    InNR29 = table.Column<string>(nullable: true),
                    InNR30 = table.Column<string>(nullable: true),
                    InNR31 = table.Column<string>(nullable: true),
                    InNR32 = table.Column<string>(nullable: true),
                    InNR33 = table.Column<string>(nullable: true),
                    InNR34 = table.Column<string>(nullable: true),
                    InNR35 = table.Column<string>(nullable: true),
                    InNR36 = table.Column<string>(nullable: true),
                    InNR37 = table.Column<string>(nullable: true),
                    InNR38 = table.Column<string>(nullable: true),
                    InNR39 = table.Column<string>(nullable: true),
                    InNR40 = table.Column<string>(nullable: true),
                    InNR41 = table.Column<string>(nullable: true),
                    InNR42 = table.Column<string>(nullable: true),
                    InNR43 = table.Column<string>(nullable: true),
                    InNR44 = table.Column<string>(nullable: true),
                    InNR45 = table.Column<string>(nullable: true),
                    InNR46 = table.Column<string>(nullable: true),
                    InNR47 = table.Column<string>(nullable: true),
                    InNR48 = table.Column<string>(nullable: true),
                    OutOk25 = table.Column<string>(nullable: true),
                    OutOk26 = table.Column<string>(nullable: true),
                    OutOk27 = table.Column<string>(nullable: true),
                    OutOk28 = table.Column<string>(nullable: true),
                    OutOk29 = table.Column<string>(nullable: true),
                    OutOk30 = table.Column<string>(nullable: true),
                    OutOk31 = table.Column<string>(nullable: true),
                    OutOk32 = table.Column<string>(nullable: true),
                    OutOk33 = table.Column<string>(nullable: true),
                    OutOk34 = table.Column<string>(nullable: true),
                    OutOk35 = table.Column<string>(nullable: true),
                    OutOk36 = table.Column<string>(nullable: true),
                    OutOk37 = table.Column<string>(nullable: true),
                    OutOk38 = table.Column<string>(nullable: true),
                    OutOk39 = table.Column<string>(nullable: true),
                    OutOk40 = table.Column<string>(nullable: true),
                    OutOk41 = table.Column<string>(nullable: true),
                    OutOk42 = table.Column<string>(nullable: true),
                    OutOk43 = table.Column<string>(nullable: true),
                    OutOk44 = table.Column<string>(nullable: true),
                    OutOk45 = table.Column<string>(nullable: true),
                    OutOk46 = table.Column<string>(nullable: true),
                    OutOk47 = table.Column<string>(nullable: true),
                    OutOk48 = table.Column<string>(nullable: true),
                    OutNR25 = table.Column<string>(nullable: true),
                    OutNR26 = table.Column<string>(nullable: true),
                    OutNR27 = table.Column<string>(nullable: true),
                    OutNR28 = table.Column<string>(nullable: true),
                    OutNR29 = table.Column<string>(nullable: true),
                    OutNR30 = table.Column<string>(nullable: true),
                    OutNR31 = table.Column<string>(nullable: true),
                    OutNR32 = table.Column<string>(nullable: true),
                    OutNR33 = table.Column<string>(nullable: true),
                    OutNR34 = table.Column<string>(nullable: true),
                    OutNR35 = table.Column<string>(nullable: true),
                    OutNR36 = table.Column<string>(nullable: true),
                    OutNR37 = table.Column<string>(nullable: true),
                    OutNR38 = table.Column<string>(nullable: true),
                    OutNR39 = table.Column<string>(nullable: true),
                    OutNR40 = table.Column<string>(nullable: true),
                    OutNR41 = table.Column<string>(nullable: true),
                    OutNR42 = table.Column<string>(nullable: true),
                    OutNR43 = table.Column<string>(nullable: true),
                    OutNR44 = table.Column<string>(nullable: true),
                    OutNR45 = table.Column<string>(nullable: true),
                    OutNR46 = table.Column<string>(nullable: true),
                    OutNR47 = table.Column<string>(nullable: true),
                    OutNR48 = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenancetrailers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenancetruckpms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    truckid = table.Column<string>(nullable: true),
                    milestotal = table.Column<string>(nullable: true),
                    dateinitial = table.Column<string>(nullable: true),
                    dateend = table.Column<string>(nullable: true),
                    drivername = table.Column<string>(nullable: true),
                    pm1 = table.Column<string>(nullable: true),
                    pm2 = table.Column<string>(nullable: true),
                    pm3 = table.Column<string>(nullable: true),
                    pm4 = table.Column<string>(nullable: true),
                    pm5 = table.Column<string>(nullable: true),
                    pm6 = table.Column<string>(nullable: true),
                    pm7 = table.Column<string>(nullable: true),
                    pm8 = table.Column<string>(nullable: true),
                    pm9 = table.Column<string>(nullable: true),
                    pm10 = table.Column<string>(nullable: true),
                    pm11 = table.Column<string>(nullable: true),
                    pm12 = table.Column<string>(nullable: true),
                    pm13 = table.Column<string>(nullable: true),
                    pm14 = table.Column<string>(nullable: true),
                    pm15 = table.Column<string>(nullable: true),
                    pm16 = table.Column<string>(nullable: true),
                    pm17 = table.Column<string>(nullable: true),
                    pm18 = table.Column<string>(nullable: true),
                    pm19 = table.Column<string>(nullable: true),
                    pm20 = table.Column<string>(nullable: true),
                    pm21 = table.Column<string>(nullable: true),
                    pm22 = table.Column<string>(nullable: true),
                    incidense = table.Column<string>(nullable: true),
                    expense = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenancetruckpms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenancetrucktipo2s",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    truckid = table.Column<string>(nullable: true),
                    milestotal = table.Column<string>(nullable: true),
                    dateinitial = table.Column<string>(nullable: true),
                    dateend = table.Column<string>(nullable: true),
                    drivername = table.Column<string>(nullable: true),
                    prt1 = table.Column<string>(nullable: true),
                    prt2 = table.Column<string>(nullable: true),
                    prt3 = table.Column<string>(nullable: true),
                    prt4 = table.Column<string>(nullable: true),
                    prt5 = table.Column<string>(nullable: true),
                    prt6 = table.Column<string>(nullable: true),
                    prt7 = table.Column<string>(nullable: true),
                    prt8 = table.Column<string>(nullable: true),
                    prt9 = table.Column<string>(nullable: true),
                    prt10 = table.Column<string>(nullable: true),
                    prt11 = table.Column<string>(nullable: true),
                    prt12 = table.Column<string>(nullable: true),
                    prt13 = table.Column<string>(nullable: true),
                    prt14 = table.Column<string>(nullable: true),
                    prt15 = table.Column<string>(nullable: true),
                    prt16 = table.Column<string>(nullable: true),
                    prt17 = table.Column<string>(nullable: true),
                    prt18 = table.Column<string>(nullable: true),
                    prt19 = table.Column<string>(nullable: true),
                    prt20 = table.Column<string>(nullable: true),
                    prt21 = table.Column<string>(nullable: true),
                    prt22 = table.Column<string>(nullable: true),
                    prt23 = table.Column<string>(nullable: true),
                    prt24 = table.Column<string>(nullable: true),
                    prt25 = table.Column<string>(nullable: true),
                    prt26 = table.Column<string>(nullable: true),
                    prt27 = table.Column<string>(nullable: true),
                    prt28 = table.Column<string>(nullable: true),
                    prt29 = table.Column<string>(nullable: true),
                    prt30 = table.Column<string>(nullable: true),
                    prt31 = table.Column<string>(nullable: true),
                    prt32 = table.Column<string>(nullable: true),
                    prt33 = table.Column<string>(nullable: true),
                    prt34 = table.Column<string>(nullable: true),
                    prt35 = table.Column<string>(nullable: true),
                    prt36 = table.Column<string>(nullable: true),
                    prt37 = table.Column<string>(nullable: true),
                    prt38 = table.Column<string>(nullable: true),
                    prt39 = table.Column<string>(nullable: true),
                    prt40 = table.Column<string>(nullable: true),
                    prt41 = table.Column<string>(nullable: true),
                    prt42 = table.Column<string>(nullable: true),
                    prt43 = table.Column<string>(nullable: true),
                    prt44 = table.Column<string>(nullable: true),
                    prt45 = table.Column<string>(nullable: true),
                    prt46 = table.Column<string>(nullable: true),
                    prt47 = table.Column<string>(nullable: true),
                    prt48 = table.Column<string>(nullable: true),
                    prt49 = table.Column<string>(nullable: true),
                    prt50 = table.Column<string>(nullable: true),
                    prt51 = table.Column<string>(nullable: true),
                    prt52 = table.Column<string>(nullable: true),
                    prt53 = table.Column<string>(nullable: true),
                    prt54 = table.Column<string>(nullable: true),
                    prt55 = table.Column<string>(nullable: true),
                    prt56 = table.Column<string>(nullable: true),
                    pot1 = table.Column<string>(nullable: true),
                    pot2 = table.Column<string>(nullable: true),
                    pot3 = table.Column<string>(nullable: true),
                    pot4 = table.Column<string>(nullable: true),
                    pot5 = table.Column<string>(nullable: true),
                    pot6 = table.Column<string>(nullable: true),
                    pot7 = table.Column<string>(nullable: true),
                    pot8 = table.Column<string>(nullable: true),
                    pot9 = table.Column<string>(nullable: true),
                    pot10 = table.Column<string>(nullable: true),
                    pot11 = table.Column<string>(nullable: true),
                    pot12 = table.Column<string>(nullable: true),
                    pot13 = table.Column<string>(nullable: true),
                    pot14 = table.Column<string>(nullable: true),
                    pot15 = table.Column<string>(nullable: true),
                    pot16 = table.Column<string>(nullable: true),
                    pot17 = table.Column<string>(nullable: true),
                    pot18 = table.Column<string>(nullable: true),
                    pot19 = table.Column<string>(nullable: true),
                    pot20 = table.Column<string>(nullable: true),
                    pot21 = table.Column<string>(nullable: true),
                    pot22 = table.Column<string>(nullable: true),
                    pot23 = table.Column<string>(nullable: true),
                    pot24 = table.Column<string>(nullable: true),
                    pot25 = table.Column<string>(nullable: true),
                    pot26 = table.Column<string>(nullable: true),
                    pot27 = table.Column<string>(nullable: true),
                    pot28 = table.Column<string>(nullable: true),
                    pot29 = table.Column<string>(nullable: true),
                    pot30 = table.Column<string>(nullable: true),
                    pot31 = table.Column<string>(nullable: true),
                    pot32 = table.Column<string>(nullable: true),
                    pot33 = table.Column<string>(nullable: true),
                    pot34 = table.Column<string>(nullable: true),
                    pot35 = table.Column<string>(nullable: true),
                    pot36 = table.Column<string>(nullable: true),
                    pot37 = table.Column<string>(nullable: true),
                    pot38 = table.Column<string>(nullable: true),
                    pot39 = table.Column<string>(nullable: true),
                    pot40 = table.Column<string>(nullable: true),
                    pot41 = table.Column<string>(nullable: true),
                    pot42 = table.Column<string>(nullable: true),
                    pot43 = table.Column<string>(nullable: true),
                    pot44 = table.Column<string>(nullable: true),
                    pot45 = table.Column<string>(nullable: true),
                    pot46 = table.Column<string>(nullable: true),
                    pot47 = table.Column<string>(nullable: true),
                    pot48 = table.Column<string>(nullable: true),
                    pot49 = table.Column<string>(nullable: true),
                    pot50 = table.Column<string>(nullable: true),
                    pot51 = table.Column<string>(nullable: true),
                    pot52 = table.Column<string>(nullable: true),
                    pot53 = table.Column<string>(nullable: true),
                    pot54 = table.Column<string>(nullable: true),
                    pot55 = table.Column<string>(nullable: true),
                    pot56 = table.Column<string>(nullable: true),
                    rr1 = table.Column<string>(nullable: true),
                    rr2 = table.Column<string>(nullable: true),
                    rr3 = table.Column<string>(nullable: true),
                    rr4 = table.Column<string>(nullable: true),
                    rr5 = table.Column<string>(nullable: true),
                    rr6 = table.Column<string>(nullable: true),
                    rr7 = table.Column<string>(nullable: true),
                    rr8 = table.Column<string>(nullable: true),
                    rr9 = table.Column<string>(nullable: true),
                    rr10 = table.Column<string>(nullable: true),
                    rr11 = table.Column<string>(nullable: true),
                    rr12 = table.Column<string>(nullable: true),
                    rr13 = table.Column<string>(nullable: true),
                    rr14 = table.Column<string>(nullable: true),
                    rr15 = table.Column<string>(nullable: true),
                    rr16 = table.Column<string>(nullable: true),
                    rr17 = table.Column<string>(nullable: true),
                    rr18 = table.Column<string>(nullable: true),
                    rr19 = table.Column<string>(nullable: true),
                    rr20 = table.Column<string>(nullable: true),
                    rr21 = table.Column<string>(nullable: true),
                    rr22 = table.Column<string>(nullable: true),
                    rr23 = table.Column<string>(nullable: true),
                    rr24 = table.Column<string>(nullable: true),
                    rr25 = table.Column<string>(nullable: true),
                    rr26 = table.Column<string>(nullable: true),
                    rr27 = table.Column<string>(nullable: true),
                    rr28 = table.Column<string>(nullable: true),
                    rr29 = table.Column<string>(nullable: true),
                    rr30 = table.Column<string>(nullable: true),
                    rr31 = table.Column<string>(nullable: true),
                    rr32 = table.Column<string>(nullable: true),
                    rr33 = table.Column<string>(nullable: true),
                    rr34 = table.Column<string>(nullable: true),
                    rr35 = table.Column<string>(nullable: true),
                    rr36 = table.Column<string>(nullable: true),
                    rr37 = table.Column<string>(nullable: true),
                    rr38 = table.Column<string>(nullable: true),
                    rr39 = table.Column<string>(nullable: true),
                    rr40 = table.Column<string>(nullable: true),
                    rr41 = table.Column<string>(nullable: true),
                    rr42 = table.Column<string>(nullable: true),
                    rr43 = table.Column<string>(nullable: true),
                    rr44 = table.Column<string>(nullable: true),
                    rr45 = table.Column<string>(nullable: true),
                    rr46 = table.Column<string>(nullable: true),
                    rr47 = table.Column<string>(nullable: true),
                    rr48 = table.Column<string>(nullable: true),
                    rr49 = table.Column<string>(nullable: true),
                    rr50 = table.Column<string>(nullable: true),
                    rr51 = table.Column<string>(nullable: true),
                    rr52 = table.Column<string>(nullable: true),
                    rr53 = table.Column<string>(nullable: true),
                    rr54 = table.Column<string>(nullable: true),
                    rr55 = table.Column<string>(nullable: true),
                    rr56 = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenancetrucktipo2s", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenancetrucktipo3s",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    truckid = table.Column<string>(nullable: true),
                    milestotal = table.Column<string>(nullable: true),
                    dateinitial = table.Column<string>(nullable: true),
                    dateend = table.Column<string>(nullable: true),
                    drivername = table.Column<string>(nullable: true),
                    t3p1 = table.Column<string>(nullable: true),
                    t3p2 = table.Column<string>(nullable: true),
                    t3p3 = table.Column<string>(nullable: true),
                    t3p4 = table.Column<string>(nullable: true),
                    t3p5 = table.Column<string>(nullable: true),
                    t3p6 = table.Column<string>(nullable: true),
                    t3p7 = table.Column<string>(nullable: true),
                    incidense = table.Column<string>(nullable: true),
                    expense = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenancetrucktipo3s", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenancewinters",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    truckid = table.Column<string>(nullable: true),
                    dateinitial = table.Column<string>(nullable: true),
                    dateend = table.Column<string>(nullable: true),
                    drivername = table.Column<string>(nullable: true),
                    wt1 = table.Column<string>(nullable: true),
                    wt2 = table.Column<string>(nullable: true),
                    wt3 = table.Column<string>(nullable: true),
                    wt4 = table.Column<string>(nullable: true),
                    wt5 = table.Column<string>(nullable: true),
                    wt6 = table.Column<string>(nullable: true),
                    wt7 = table.Column<string>(nullable: true),
                    wt8 = table.Column<string>(nullable: true),
                    wt9 = table.Column<string>(nullable: true),
                    wt10 = table.Column<string>(nullable: true),
                    wt11 = table.Column<string>(nullable: true),
                    wt12 = table.Column<string>(nullable: true),
                    wt13 = table.Column<string>(nullable: true),
                    wt14 = table.Column<string>(nullable: true),
                    wt15 = table.Column<string>(nullable: true),
                    wt16 = table.Column<string>(nullable: true),
                    wt17 = table.Column<string>(nullable: true),
                    wt18 = table.Column<string>(nullable: true),
                    wt19 = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenancewinters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paycategories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idrevenue = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    ammount = table.Column<string>(nullable: true),
                    loadstatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paycategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phonebooks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    codezip = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    birthay = table.Column<string>(nullable: true),
                    homephone = table.Column<string>(nullable: true),
                    workphone = table.Column<string>(nullable: true),
                    mobilephone = table.Column<string>(nullable: true),
                    faxnumber = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phonebooks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pickupdroptypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pickupdroptypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    receiptphoto = table.Column<byte[]>(nullable: true)
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
                    client = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    loadid = table.Column<string>(nullable: true),
                    loadstatus = table.Column<string>(nullable: true),
                    driver = table.Column<string>(nullable: true),
                    truckid = table.Column<string>(nullable: true),
                    trailerid = table.Column<string>(nullable: true),
                    chassisid = table.Column<string>(nullable: true),
                    sealnumber = table.Column<string>(nullable: true),
                    weight = table.Column<string>(nullable: true),
                    piececount = table.Column<string>(nullable: true),
                    loadtemp = table.Column<string>(nullable: true),
                    loadtype = table.Column<string>(nullable: true),
                    deadheadfrom = table.Column<string>(nullable: true),
                    loaddate = table.Column<string>(nullable: true),
                    startcityst = table.Column<string>(nullable: true),
                    loadodometer = table.Column<string>(nullable: true),
                    enddate = table.Column<string>(nullable: true),
                    endcityst = table.Column<string>(nullable: true),
                    endodometer = table.Column<string>(nullable: true),
                    personalmiles = table.Column<string>(nullable: true),
                    deadheadmiles = table.Column<string>(nullable: true),
                    loadmiles = table.Column<string>(nullable: true),
                    totalmiles = table.Column<string>(nullable: true),
                    flatrate = table.Column<string>(nullable: true),
                    totalotherpay = table.Column<string>(nullable: true),
                    totaltrippay = table.Column<string>(nullable: true),
                    lastemptydate = table.Column<string>(nullable: true),
                    lastemptyodometer = table.Column<string>(nullable: true),
                    totaltripbasic = table.Column<string>(nullable: true),
                    factorydate = table.Column<string>(nullable: true),
                    ammount = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    iddriver = table.Column<string>(nullable: true),
                    factory = table.Column<string>(nullable: true),
                    chkfactorydate = table.Column<string>(nullable: true),
                    chkfactorypaid = table.Column<string>(nullable: true),
                    datefrompaid = table.Column<string>(nullable: true),
                    datetopaid = table.Column<string>(nullable: true),
                    datepaid = table.Column<string>(nullable: true),
                    statuspaid = table.Column<string>(nullable: true),
                    bonus = table.Column<string>(nullable: true),
                    factorypaid = table.Column<string>(nullable: true),
                    totalpaydue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revenues", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rvdriverpays",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idrevenue = table.Column<string>(nullable: true),
                    driverstatus = table.Column<string>(nullable: true),
                    percentage = table.Column<string>(nullable: true),
                    fuel = table.Column<string>(nullable: true),
                    expense = table.Column<string>(nullable: true),
                    factoryfee = table.Column<string>(nullable: true),
                    paymentfee = table.Column<string>(nullable: true),
                    insurance = table.Column<string>(nullable: true),
                    other = table.Column<string>(nullable: true),
                    eld = table.Column<string>(nullable: true),
                    pp = table.Column<string>(nullable: true),
                    ezpass = table.Column<string>(nullable: true),
                    bonus = table.Column<string>(nullable: true),
                    vacation = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    loadpay = table.Column<string>(nullable: true),
                    emptypay = table.Column<string>(nullable: true),
                    pickupdrop = table.Column<string>(nullable: true),
                    tonnage = table.Column<string>(nullable: true),
                    flatrate = table.Column<string>(nullable: true),
                    paybyhours = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rvdriverpays", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rvexpenses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idrevenue = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    cost = table.Column<string>(nullable: true),
                    cargostatus = table.Column<string>(nullable: true)
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
                    idrevenue = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    rf = table.Column<string>(nullable: true),
                    def = table.Column<string>(nullable: true),
                    premileage = table.Column<string>(nullable: true),
                    mileage = table.Column<string>(nullable: true),
                    truckstop = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    payment = table.Column<string>(nullable: true),
                    quantity = table.Column<string>(nullable: true),
                    cost = table.Column<string>(nullable: true),
                    total = table.Column<string>(nullable: true),
                    advance = table.Column<string>(nullable: true),
                    invoicenumber = table.Column<string>(nullable: true)
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
                    idrevenue = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rvnotes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rvpickupdrops",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idrevenue = table.Column<string>(nullable: true),
                    pickdroptype = table.Column<string>(nullable: true),
                    startdate = table.Column<string>(nullable: true),
                    startcs = table.Column<string>(nullable: true),
                    arrivadate = table.Column<string>(nullable: true),
                    endcs = table.Column<string>(nullable: true),
                    customerliveload = table.Column<string>(nullable: true),
                    appoinmentdate = table.Column<string>(nullable: true),
                    totaltime = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    driver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rvpickupdrops", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rvroutes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idrevenue = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    startodom = table.Column<string>(nullable: true),
                    endodom = table.Column<string>(nullable: true),
                    miles = table.Column<string>(nullable: true),
                    tollmiles = table.Column<string>(nullable: true),
                    gallons = table.Column<string>(nullable: true),
                    highways = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rvroutes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "srcalls",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    calldate = table.Column<string>(nullable: true),
                    callcustomer = table.Column<string>(nullable: true),
                    callnotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srcalls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trailersprofiles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    trailernumber = table.Column<string>(nullable: true),
                    vinnumber = table.Column<string>(nullable: true),
                    tag = table.Column<string>(nullable: true),
                    pmmileage = table.Column<string>(nullable: true),
                    year = table.Column<string>(nullable: true),
                    make = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    tiresize = table.Column<string>(nullable: true),
                    axels = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    photo = table.Column<byte[]>(nullable: true),
                    licensedate = table.Column<string>(nullable: true),
                    licensedateexpire = table.Column<string>(nullable: true),
                    totalmiles = table.Column<string>(nullable: true)
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
                    name = table.Column<string>(nullable: true),
                    ownername = table.Column<string>(nullable: true),
                    trucknumber = table.Column<string>(nullable: true),
                    vinnumber = table.Column<string>(nullable: true),
                    year = table.Column<string>(nullable: true),
                    make = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    tag = table.Column<string>(nullable: true),
                    pmmileage = table.Column<string>(nullable: true),
                    truckcolor = table.Column<string>(nullable: true),
                    tiresize = table.Column<string>(nullable: true),
                    axles = table.Column<string>(nullable: true),
                    enginemake = table.Column<string>(nullable: true),
                    enginepower = table.Column<string>(nullable: true),
                    enginesn = table.Column<string>(nullable: true),
                    transtype = table.Column<string>(nullable: true),
                    emptywgt = table.Column<string>(nullable: true),
                    fueltank = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    photo = table.Column<byte[]>(nullable: true),
                    licensedate = table.Column<string>(nullable: true),
                    licensedateexpire = table.Column<string>(nullable: true),
                    totalmiles = table.Column<string>(nullable: true)
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
                    addres = table.Column<string>(nullable: true),
                    addres2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    codezip = table.Column<string>(nullable: true),
                    taxid = table.Column<string>(nullable: true),
                    phonenumber = table.Column<string>(nullable: true),
                    faxnumber = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    lat = table.Column<string>(nullable: true),
                    longt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendors", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminaccess");

            migrationBuilder.DropTable(
                name: "adminmaintenances");

            migrationBuilder.DropTable(
                name: "adminsystems");

            migrationBuilder.DropTable(
                name: "adminusers");

            migrationBuilder.DropTable(
                name: "agents");

            migrationBuilder.DropTable(
                name: "apuprofiles");

            migrationBuilder.DropTable(
                name: "brokers");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "citystates");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "codezips");

            migrationBuilder.DropTable(
                name: "companyprofiles");

            migrationBuilder.DropTable(
                name: "descriptnotes");

            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "driverprofiles");

            migrationBuilder.DropTable(
                name: "emailsettings");

            migrationBuilder.DropTable(
                name: "employeeprofile");

            migrationBuilder.DropTable(
                name: "expenses");

            migrationBuilder.DropTable(
                name: "exresumens");

            migrationBuilder.DropTable(
                name: "faxsetting");

            migrationBuilder.DropTable(
                name: "insurances");

            migrationBuilder.DropTable(
                name: "maintenanceapus");

            migrationBuilder.DropTable(
                name: "maintenancesummers");

            migrationBuilder.DropTable(
                name: "maintenancetrailers");

            migrationBuilder.DropTable(
                name: "maintenancetruckpms");

            migrationBuilder.DropTable(
                name: "maintenancetrucktipo2s");

            migrationBuilder.DropTable(
                name: "maintenancetrucktipo3s");

            migrationBuilder.DropTable(
                name: "maintenancewinters");

            migrationBuilder.DropTable(
                name: "paycategories");

            migrationBuilder.DropTable(
                name: "phonebooks");

            migrationBuilder.DropTable(
                name: "pickupdroptypes");

            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropTable(
                name: "revenues");

            migrationBuilder.DropTable(
                name: "rvdriverpays");

            migrationBuilder.DropTable(
                name: "rvexpenses");

            migrationBuilder.DropTable(
                name: "rvfuels");

            migrationBuilder.DropTable(
                name: "rvnotes");

            migrationBuilder.DropTable(
                name: "rvpickupdrops");

            migrationBuilder.DropTable(
                name: "rvroutes");

            migrationBuilder.DropTable(
                name: "srcalls");

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
