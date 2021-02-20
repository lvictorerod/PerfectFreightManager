using Npgsql;
using Perfect_Freight_Manager.Models;
using System;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.ExpensesInvoices
{
    public partial class frmResumens : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        string TblName = "exresumens";
        int codigo;
        public frmResumens(string invoice)
        {
            InitializeComponent();
            btnResumeDel.Enabled = false;
            btnResumeUpd.Enabled = false;
            lblInvoiceResume.Text = invoice;
            dgvResumes.DataSource = conectandose.ConsultarExpense(TblName, invoice);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvResumes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = Convert.ToInt32(dgvResumes.Rows[e.RowIndex].Cells[0].Value);

            //lblInvoiceResume.Text = Convert.ToString(dgvResumes.Rows[e.RowIndex].Cells[1].Value);
            txtTrip.Text = Convert.ToString(dgvResumes.Rows[e.RowIndex].Cells[2].Value);
            cbCategory.Text = Convert.ToString(dgvResumes.Rows[e.RowIndex].Cells[3].Value); ;
            txtDescription.Text = Convert.ToString(dgvResumes.Rows[e.RowIndex].Cells[4].Value); ;
            txtPrice.Text = Convert.ToString(dgvResumes.Rows[e.RowIndex].Cells[5].Value); ;
        }

        private void btnResumeAdd_Click(object sender, EventArgs e)
        {
            if (!(txtTrip.Text == ""))
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into exresumens (idexpense,tripid,expensecategory,description,price) values ('" + lblInvoiceResume.Text + "','" + txtTrip.Text + "','" + cbCategory.Text + "',@description,'" + txtPrice.Text + "')", conn);
                    cmd.Parameters.AddWithValue("description", txtDescription.Text);
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
                dgvResumes.DataSource = conectandose.ConsultarExpense(TblName, lblInvoiceResume.Text);
            }
        }

        private void btnResumeDel_Click(object sender, EventArgs e)
        {
            try
            {
                conectandose.DeleteRecord(TblName, codigo);
                btnClearTrip_Click(sender, e);
                //dgvExpenses.DataSource = conectandose.Consultar(TblName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            dgvResumes.DataSource = conectandose.ConsultarExpense(TblName, lblInvoiceResume.Text);
        }

        private void btnResumeUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update exresumens set txtPrice.Text='" + lblInvoiceResume.Text + "',tripid='" + txtTrip.Text + "',expensecategory='" + cbCategory.Text + "',description=@description,price='" + txtPrice.Text + "'" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("description", txtDescription.Text);
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
            dgvResumes.DataSource = conectandose.ConsultarExpense(TblName, lblInvoiceResume.Text);
        }

        private void btnClearTrip_Click(object sender, EventArgs e)
        {
            txtTrip.Text = "";
            cbCategory.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtNotesSearch.Text = "";

            btnResumeAdd.Enabled = true;
            btnResumeDel.Enabled = false;
            btnResumeUpd.Enabled = false;
        }
        //////////////////////////////////////////////////////////
        /// SEARCH
        //////////////////////////////////////////////////////////
        ///
        private AutoCompleteStringCollection CargaDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvResumes.DataSource = conectandose.ConsultarWith(TblName, txtNotesSearch.Text);
            return datos;
        }

        private void txtNotesSearch_TextChanged(object sender, EventArgs e)
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
                dgvResumes.DataSource = conectandose.ConsultarWith(TblName, lblInvoiceResume.Text);
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
