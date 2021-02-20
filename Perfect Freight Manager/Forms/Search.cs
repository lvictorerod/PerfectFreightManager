using Npgsql;
using Perfect_Freight_Manager.Models;
using System;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Revenue
{
    public partial class frmSearch : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        string TblNameS = "";
        private string nombre, ciudad, estado, zip, contacto, direccion, telef, notas;
        private int driver = 0;
        private string idBrokerS = "";

        public frmSearch(string TblName, string idBroker)
        {
            InitializeComponent();
            TblNameS = TblName;
            txtSearch.Text = "";
            if (TblNameS == "agents")
            {
                idBrokerS = idBroker;
                dgvSearchData.DataSource = conectandose.ConsultarAgents(TblNameS,idBrokerS);
            }
            else
            {
                dgvSearchData.DataSource = conectandose.Consultar(TblNameS);
            }
        }
        
        public string Nombre
        {
            get { return nombre; }
        }
        public string Shipper
        {
            get { return nombre; }
        }
        public string Estado
        {
            get { return estado; }
        }
        public string Zip
        {
            get { return zip; }
        }
        public string Contacto
        {
            get { return contacto; }
        }
        public string Direccion
        {
            get { return direccion; }
        }
        public string Telef
        {
            get { return telef; }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre = lbSeleccionado.Text;
            estado = lblState.Text;
            zip = lblZip.Text;
            this.Close();
        }

        public string Ciudad
        {
            get { return ciudad; }
        }
        public string Notas
        {
            get { return notas; }
        }
        public int Driver
        {
            get { return driver; }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = (txtSearch.Text).ToUpper();
            if (TblNameS != "codezips")
                dgvSearchData.DataSource = conectandose.ConsultarWith(TblNameS, search);
            else
                dgvSearchData.DataSource = conectandose.ConsultarZip(TblNameS, search);

        }
        private void dgvSearchData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lbSeleccionado.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[1].Value);
            if (TblNameS == "trucksprofiles")
                lbSeleccionado.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[3].Value);
            if (TblNameS == "driverprofiles")
            {
                string firstname = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[1].Value);
                string lastname = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[3].Value);
                driver = Convert.ToInt32(dgvSearchData.Rows[e.RowIndex].Cells[0].Value);
                lbSeleccionado.Text = firstname + " " + lastname;
            }
            if (TblNameS == "trailersprofiles")
                lbSeleccionado.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[2].Value);
            if (TblNameS == "citystates")
                lbSeleccionado.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[3].Value);
            if (TblNameS == "rvpickupDrop")
                lbSeleccionado.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[4].Value);
            if (TblNameS == "phonebooks")
                lbSeleccionado.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[7].Value);
            if (TblNameS == "codezips")
            {
                lbSeleccionado.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[2].Value);
                lblState.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[4].Value);
                lblZip.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[1].Value);
            }
            if (TblNameS == "brokers")
            {
                lbSeleccionado.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[1].Value);
                lblState.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[0].Value);
            }
            if (TblNameS == "vendors")
            {
                lbSeleccionado.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[1].Value);
                direccion = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[4].Value);
                ciudad = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[6].Value);
                lblState.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[7].Value);
                lblZip.Text = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[8].Value);
                telef = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[10].Value);
                contacto = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[12].Value);
                notas = Convert.ToString(dgvSearchData.Rows[e.RowIndex].Cells[15].Value);
            }
        }
        private void btnClearTrip_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            lbSeleccionado.Text = "";
            lblState.Text = "";
            lblZip.Text = "";
        }
    }
}
