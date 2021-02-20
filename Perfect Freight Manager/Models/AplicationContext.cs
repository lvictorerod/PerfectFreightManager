using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Npgsql;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Models
{
    public class AplicationContext : DbContext
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        // Crear una instancia global singlenton de LoggerFactory para la version 3.x de EF        
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information)
                    .AddConsole();
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=12345;Server=localhost;Port=5432;Database=PerfectFreight;Integrated Security=true;Pooling=true;")
                .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(MyLoggerFactory);
        }

        //definir las entidades que representan mis tablas y persisten.
        public DbSet<AdminAcces> adminaccess { get; set; }
        public DbSet<AdminCompany> admincompanys { get; set; }
        public DbSet<AdminMaintenance> adminmaintenances { get; set; }
        public DbSet<AdminSystem> adminsystems { get; set; }
        public DbSet<AdminUser> adminusers { get; set; }
        public DbSet<Agents> agents { get; set; }
        public DbSet<ApuProfiles> apuprofiles { get; set; }
        public DbSet<Broker> brokers { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CityState> citystates { get; set; }
        public DbSet<Clients> clients { get; set; }
        public DbSet<CodeZIp> codezips { get; set; }
        public DbSet<CompanyProfile> companyprofiles { get; set; }
        public DbSet<Descriptnotes> descriptnotes { get; set; }
        public DbSet<Documents> documents { get; set; }
        public DbSet<Driverprofile> driverprofiles { get; set; }
        public DbSet<EmailSetting> emailsettings { get; set; }
        public DbSet<EmployeeProfile> employeeprofile { get; set; }
        public DbSet<Expense> expenses { get; set; }
        public DbSet<Exresumen> exresumens { get; set; }
        public DbSet<FaxSetting> faxsetting { get; set; }
        public DbSet<Insurance> insurances { get; set; }
        public DbSet<MaintenanceApu> maintenanceapus { get; set; }
        public DbSet<MaintenanceSummer> maintenancesummers { get; set; }
        public DbSet<MaintenanceTrailer> maintenancetrailers { get; set; }
        public DbSet<MaintenanceTruckTipoII> maintenancetrucktipo2s { get; set; }
        public DbSet<MaintenanceTruckTipoIII> maintenancetrucktipo3s { get; set; }
        public DbSet<MaintenanceWinter> maintenancewinters { get; set; }
        public DbSet<MaintenanceTruckPM> maintenancetruckpms { get; set; }
        public DbSet<PayCategory> paycategories { get; set; }
        public DbSet<PhoneBook> phonebooks { get; set; }
        public DbSet<PickupDropType> pickupdroptypes { get; set; }
        public DbSet<Receipt> receipts { get; set; }
        public DbSet<Revenue> revenues { get; set; }
        public DbSet<RVDriverPay> rvdriverpays { get; set; }
        public DbSet<RVExpenses> rvexpenses { get; set; }
        public DbSet<RVFuel> rvfuels { get; set; }
        public DbSet<RVNotes> rvnotes { get; set; }
        public DbSet<RVPickupDrop> rvpickupdrops { get; set; }
        public DbSet<RVRoute> rvroutes { get; set; }
        public DbSet<SRCalls> srcalls { get; set; }
        public DbSet<TrailersProfile> trailersprofiles { get; set; }
        public DbSet<TrucksProfile> trucksprofiles { get; set; }
        public DbSet<VendorCategory> vendorcategories { get; set; }
        public DbSet<Vendors> vendors { get; set; }
        public DbSet<RegisterAccident> registeraccidents { get; set; }
        public DbSet<DocRegister> docregisters { get; set; }
        public DbSet<DispatchSheet> dispatchsheets { get; set; }
        public DbSet<LoadType> loadtypes { get; set; }
        public DbSet<TruckType> trucktypes { get; set; }
        public DbSet<TrailerType> trailertypes { get; set; }

        public void Conectar()
        {
            conn.Open();
            MessageBox.Show("Conexion establecida");
        }

        public void Desconectar()
        {
            conn.Close();
            MessageBox.Show("Conexion terminada");
        }

        public DataTable ConsultarTrailer(string TblName)
        {
            string query = "select id,trailerid,milestotal,dateinitial,dateend,drivername from " + TblName + " order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable Consultar(string TblName)
        {
            string query = "select * from " + TblName + " order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarPickup(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where idrevenue like '%" + Zwhere + "%' order by customerliveload";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarPickupDrop(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where idrevenue like '%" + Zwhere + "%' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarFactoryDate(string TblName)
        {
            string query = "select * from " + TblName + " order by factorydate";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarClients(string TblName)
        {
            string query = "select * from " + TblName + " order by shipper";//customerliveload
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarBrokers(string TblName)
        {
            string query = "select * from " + TblName + " order by client";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarBrokersWith(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " were name like '%" + Zwhere + "%' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarAgents(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where idclient like '" + Zwhere + "' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarWith(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where name like '%" + Zwhere + "%' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarUsers(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where nick like '%" + Zwhere + "%' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarZip(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where city like '%" + Zwhere + "%' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }

        public DataTable ConsultarStatus(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where loadstatus like '%" + Zwhere + "%' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }

        public DataTable ConsultarDriverPay(string TblName, string Zwhere, string Zfrom, string Zto, string ZchkPaid)
        {
            string query = "select * from " + TblName + " where loadstatus like '" + Zwhere + "' and factorypaid >='" + Zfrom + "' and factorypaid <='" + Zto + "' and chkfactorypaid like '" + ZchkPaid + "' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarRevenue(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where idrevenue like '%" + Zwhere + "%' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarRegister(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where idreg like '%" + Zwhere + "%' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarInvoice(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where loadid like '%" + Zwhere + "%' order by id";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarExpense(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where idexpense like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarIncidence(string TblName, string Zwhere, string Zlast)
        {
            string query = "select * from " + TblName + " where name like '%" + Zwhere + "%' and lastname like '%" + Zlast + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarTROwner(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where ownername like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarTRVin(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where vinnumber like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarTrucks(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where trucknumber like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarTLOwner(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where name like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarVendorName(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where name like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarVendorCode(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where venderidcode like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarTLVin(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where vinnumber like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarTrailers(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where trailernumber like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarApuOwner(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where owner like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarApuVin(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where vinnumber like '%" + Zwhere + "%'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public DataTable ConsultarApus(string TblName, string Zwhere)
        {
            string query = "select * from " + TblName + " where apunumber like '" + Zwhere + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Open();
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conn.Close();
            return tabla;
        }
        public void DeleteRecord(string TblName, int Codigo)
        {
            string query = "delete from " + TblName + " where id = " + Codigo;
            NpgsqlCommand deleterecord = new NpgsqlCommand(query, conn);
            conn.Open();
            deleterecord.ExecuteNonQuery();
            conn.Close();
        }

    }
}
