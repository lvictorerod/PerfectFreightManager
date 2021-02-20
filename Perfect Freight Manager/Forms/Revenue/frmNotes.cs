using Npgsql;
using Perfect_Freight_Manager.Models;
using System;
using System.Windows.Forms;


namespace Perfect_Freight_Manager.Forms.Revenue
{
    public partial class frmNotes : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string TblName = "descriptnotes";
        int codigo;
        public frmNotes(string LoadId)
        {
            InitializeComponent();
            btnNotesDel.Enabled = false;
            btnNotesUpd.Enabled = false;
            lblCodigodNotes.Text = LoadId;
            dgvDescNotes.DataSource = conectandose.ConsultarRevenue(TblName, LoadId);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDescNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNotesAdd.Enabled = false;
            btnNotesUpd.Enabled = true;
            btnNotesDel.Enabled = true;

            codigo = Convert.ToInt32(dgvDescNotes.Rows[e.RowIndex].Cells[0].Value);

            txtDescription.Text = Convert.ToString(dgvDescNotes.Rows[e.RowIndex].Cells[2].Value);
            cbCategory.Text = Convert.ToString(dgvDescNotes.Rows[e.RowIndex].Cells[3].Value);
            txtPayAmount.Text = Convert.ToString(dgvDescNotes.Rows[e.RowIndex].Cells[4].Value);

        }

        private void btnClearTrip_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            cbCategory.Text = "";
            txtPayAmount.Text = "";
            txtNotesSearch.Text = "";

            btnNotesAdd.Enabled = true;
            btnNotesUpd.Enabled = false;
            btnNotesDel.Enabled = false;

        }

        private void btnNotesAdd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into descriptnotes (idrevenue,description,paycategory,payamount) values ('" + lblCodigodNotes.Text + "','" + txtDescription.Text + "','" + cbCategory.Text + "','" + txtPayAmount.Text + "')", conn);
                //cmd.Parameters.AddWithValue("loadstatus", LoadStatus);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Insert successfully");
                //description,paycategory,payamount,
                //'" + txtDescription.Text + "','" + cbCategory.Text + "','" + txtPayAmount.Text + "',
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            dgvDescNotes.DataSource = conectandose.ConsultarRevenue(TblName, lblCodigodNotes.Text);
            btnNotesAdd.Enabled = false;
            btnNotesUpd.Enabled = true;
            btnNotesDel.Enabled = true;
        }

        private void btnNotesDel_Click(object sender, EventArgs e)
        {
            try
            {
                conectandose.DeleteRecord(TblName, codigo);
                btnClearTrip_Click(sender, e);
                //dgvExpenses.DataSource = conectandose.Consultar(TblName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Record Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            dgvDescNotes.DataSource = conectandose.ConsultarRevenue(TblName, lblCodigodNotes.Text);
        }

        private void btnNotesUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update descriptnotes set idrevenue='" + lblCodigodNotes.Text + "',description='" + txtDescription.Text + "',paycategory='" + cbCategory.Text + "',payamount='" + txtPayAmount.Text + "'" + " where id=" + codigo, conn);
                //cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
        //////////////////////////////////////////////////////////
        /// SEARCH
        //////////////////////////////////////////////////////////
        ///
        private AutoCompleteStringCollection CargaDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvDescNotes.DataSource = conectandose.ConsultarWith(TblName, txtNotesSearch.Text);
            return datos;
        }

        private void txtNotesSearch_TextChanged_1(object sender, EventArgs e)
        {

            //Consulta
            if (txtNotesSearch.Text != "")
            {
                txtNotesSearch.AutoCompleteCustomSource = CargaDatos();
                txtNotesSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtNotesSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                dgvDescNotes.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
