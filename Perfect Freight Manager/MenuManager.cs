using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace Truck_Fleet_Manager
{
    public partial class PerfectFreightManager : Form
    {       
        public PerfectFreightManager()
        {
            InitializeComponent();
            //Attribute[] attribute = AssemblyFileVersionAttribute.GetCustomAttributes(MemberInfo element, Type type);
            //label2.Text = attribute;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void revenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnRevenue revenue = new mnRevenue();
            revenue.ShowDialog();
        }

        private void shipperReceiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnShipReceiver shipperreceive = new mnShipReceiver();
            shipperreceive.ShowDialog();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnExpenses expenses = new mnExpenses();
            expenses.ShowDialog();
        }

        private void truckStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnTruckFleet truckfleet = new mnTruckFleet();
            truckfleet.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnClients catalogos = new mnClients();
            catalogos.ShowDialog();
        }

        private void brokersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnInsurance insurance = new mnInsurance();
            insurance.ShowDialog();
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnVendor vendor = new mnVendor();
            vendor.ShowDialog();
        }

        private void tripPlannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnTripPlanner tripplanner = new mnTripPlanner();
            tripplanner.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnInvoicesStatus invoicestatus = new mnInvoicesStatus();
            invoicestatus.ShowDialog();
        }

        private void phoneBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnPhoneBook phonebook = new mnPhoneBook();
            phonebook.ShowDialog();
        }

        private void utilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnUtilites utilities = new mnUtilites();
            utilities.ShowDialog();
        }

        private void PerfectFreightManager_Load(object sender, EventArgs e)
        {

        }
    }
}
