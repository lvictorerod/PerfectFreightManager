using Npgsql;
using Perfect_Freight_Manager.Models;
using System;
using System.Windows.Forms;

namespace Truck_Fleet_Manager
{
    public partial class frmShipReceiver : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string TblName = "shipperreceivers";
        int codigo;
        public frmShipReceiver()
        {
            InitializeComponent();
            btnShippAdd.Enabled = true;
            btnShippUpd.Enabled = false;
            btnShippDel.Enabled = false;

            dgvShippConsulta.DataSource = conectandose.Consultar(TblName);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private AutoCompleteStringCollection CargaDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvShippConsulta.DataSource = conectandose.Consultar(TblName, txtShippSearch.Text);
            return datos;
        }

        private void txtShippSearch_TextChanged(object sender, EventArgs e)
        {
            //Consulta
            if (txtShippSearch.Text != "")
            {
                txtShippSearch.AutoCompleteCustomSource = CargaDatos();
                txtShippSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtShippSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                dgvShippConsulta.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtShippReceive.Text = "";
            txtShippAddress.Text = "";
            txtShippAddress2.Text = "";
            txtShippCity.Text = "";
            txtShippState.Text = "";
            mtbShippZip.Text = "";

            mtbShippEmergeNumber.Text = "";
            txtShippOfficeDay.Text = "";
            txtShippWebsite.Text = "";
            txtShippNotes.Text = "";
            txtShippDirections.Text = "";

            cbContactDepartment.Text = "";
            txtContactName.Text = "";
            txtContactPhone.Text = "";
            txtContactExt.Text = "";
            txtContactCellPhone.Text = "";
            txtContactFax.Text = "";
            txtContactEmail.Text = "";

            btnShippAdd.Enabled = true;
            btnShippUpd.Enabled = false;
            btnShippDel.Enabled = false;
        }

        private void btnShippAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnShippDel_Click(object sender, EventArgs e)
        {

        }

        private void btnShippUpd_Click(object sender, EventArgs e)
        {

        }

        private void dgvShippConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = Convert.ToInt32(dgvShippConsulta.Rows[e.RowIndex].Cells[0].Value);

            txtShippReceive.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[1].Value);
            txtShippAddress.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[2].Value);
            txtShippAddress2.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[3].Value);
            txtShippCity.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[4].Value);
            txtShippState.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[5].Value);
            mtbShippZip.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[6].Value);
            mtbShippEmergeNumber.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[7].Value);

            txtShippOfficeDay.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[8].Value);
            txtShippWebsite.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[9].Value);
            txtShippNotes.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[10].Value);
            txtShippDirections.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[11].Value);
            cbContactDepartment.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[12].Value);
            txtContactName.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[13].Value);

            txtContactPhone.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[14].Value);
            txtContactExt.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[15].Value);
            txtContactPhone.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[16].Value);
            txtContactExt.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[17].Value);
            txtContactCellPhone.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[18].Value);
            txtContactFax.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[19].Value);
            txtContactFax.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[20].Value);
            txtContactEmail.Text = Convert.ToString(dgvShippConsulta.Rows[e.RowIndex].Cells[21].Value);
        }

        /// <summary>///////////////////////////////////////////////
        /// GENERAL
        /// </summary>///////////////////////////////////////////////
        /// 
        private void btnGoWebsite_Click(object sender, EventArgs e)
        {

        }

        private void btmMapquest_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("http://www.mapquest.com/?q=,,++");
            servicio.ShowDialog();
            //"http://www.mapquest.com/?q=,,++";
        }

        private void btnBingMap_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("https://www.bing.com/maps/?q=,+,+++");
            servicio.ShowDialog();
            //https://www.bing.com/maps/?q=,+,+++
        }

        private void btnGoogleMap_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("https://www.google.com/maps/place/,+,+++");
            servicio.ShowDialog();
            //https://www.google.com/maps/place/,+,+++
        }

        private void btnWeather_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("https://www.weather.com/weather/today/l/");
            servicio.ShowDialog();
            //https://www.weather.com/weather/today/l/
        }

        private void mnShipReceiver_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchClient_MouseHover(object sender, EventArgs e)
        {
            lblCustomer.Visible = true;
        }

        private void btnSearchClient_MouseLeave(object sender, EventArgs e)
        {
            lblCustomer.Visible = false;
        }

        private void btnGoWebsite_MouseHover(object sender, EventArgs e)
        {
            lblGoWebsite.Visible = true;
        }

        private void btnGoWebsite_MouseLeave(object sender, EventArgs e)
        {
            lblGoWebsite.Visible = false;
        }

        private void btmMapquest_MouseHover(object sender, EventArgs e)
        {
            lblMapquest.Visible = true;
        }

        private void btmMapquest_MouseLeave(object sender, EventArgs e)
        {
            lblMapquest.Visible = false;
        }

        private void btnBingMap_MouseHover(object sender, EventArgs e)
        {
            lblBingMap.Visible = true;
        }

        private void btnBingMap_MouseLeave(object sender, EventArgs e)
        {
            lblBingMap.Visible = false;
        }

        private void btnGoogleMap_MouseHover(object sender, EventArgs e)
        {
            lblGoogleMap.Visible = true;
        }

        private void btnGoogleMap_MouseLeave(object sender, EventArgs e)
        {
            lblGoogleMap.Visible = false;
        }

        private void btnWeather_MouseHover(object sender, EventArgs e)
        {
            lblWeather.Visible = true;
        }

        private void btnWeather_MouseLeave(object sender, EventArgs e)
        {
            lblWeather.Visible = false;
        }


    }
}
