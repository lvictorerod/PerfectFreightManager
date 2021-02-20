using Npgsql;
using Perfect_Freight_Manager.Forms;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Models;
using System;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Catalogs
{
    public partial class frmCatalogInsurance : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string TblName = "insurances";
        int codigo;
        public frmCatalogInsurance()
        {
            InitializeComponent();
            btnInsAdd.Enabled = true;
            btnInsUpd.Enabled = false;
            btnInsDel.Enabled = false;
            dgvConsulta.DataSource = conectandose.Consultar(TblName);
        }

        private AutoCompleteStringCollection CargaDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvConsulta.DataSource = conectandose.ConsultarWith(TblName, txtSearch.Text);
            return datos;
        }

        private void quirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = Convert.ToInt32(dgvConsulta.Rows[e.RowIndex].Cells[0].Value);

            txtAgency.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[1].Value);
            txtAddress.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[2].Value);
            txtAddress2.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[3].Value);
            txtCity.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[4].Value);
            txtState.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[5].Value);
            mtbZip.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[8].Value);
            txtContact.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[6].Value);
            mtbPhone.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[7].Value);
            mtbPhoneToll.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[8].Value);
            mtbFax.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[9].Value);
            txtEmail.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[10].Value);
            txtWebsite.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[11].Value);
            txtNotes.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[12].Value);

            btnInsAdd.Enabled = false;
            btnInsUpd.Enabled = true;
            btnInsDel.Enabled = true;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtAgency.Text = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            mtbZip.Text = "";
            txtContact.Text = "";
            mtbPhone.Text = "";
            mtbPhoneToll.Text = "";
            mtbFax.Text = "";
            txtEmail.Text = "";
            txtWebsite.Text = "";
            txtNotes.Text = "";
            txtSearch.Text = "";

            btnInsAdd.Enabled = false;
            btnInsUpd.Enabled = true;
            btnInsDel.Enabled = true;
        }

        private void btnInsAdd_Click(object sender, EventArgs e)
        {
            if (txtAgency.Text != "" && txtAddress.Text != "")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into clients (name,address,address2,city,state,codezip,contactname,phonenumber,phonetollfree,faxnumber,email,website,notes) values ('" + txtAgency.Text + "','" + txtAddress.Text + "','" + txtAddress2.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + mtbZip.Text + "','" + txtContact.Text + "','" + mtbPhone.Text + "','" + mtbPhoneToll.Text + "','" + mtbFax.Text + "','" + txtEmail.Text + "','" + txtWebsite.Text + "',@notes", conn);
                    cmd.Parameters.AddWithValue("notes", txtNotes.Text);
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
            }
            else MessageBox.Show("Lack data, check that have:\nAgency and Address ", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvConsulta.DataSource = conectandose.Consultar(TblName);
            btnInsAdd.Enabled = false;
            btnInsUpd.Enabled = true;
            btnInsDel.Enabled = true;
        }

        private void btnInsDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnClean_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnInsUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update clients set name='" + txtAgency.Text + "',address='" + txtAddress.Text + "',address2='" + txtAddress2.Text + "',city='" + txtCity.Text + "',state='" + txtState.Text + "',codezip='" + mtbZip.Text + "',contactname='" + txtContact.Text + "',phonenumber='" + mtbPhone.Text + "',phonetollfree='" + mtbPhoneToll.Text + "',faxnumber='" + mtbFax.Text + "',email='" + txtEmail.Text + "',website='" + txtWebsite.Text + "',notes=@notes" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close(); throw;
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            //Consulta
            string search = (txtSearch.Text).ToUpper();
            if (txtSearch.Text != "")
            { 
                dgvConsulta.DataSource = conectandose.ConsultarWith(TblName, search);
            }
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            frmMail nuevomail = new frmMail(txtEmail.Text, "");
            nuevomail.ShowDialog();
        }

        private void btnFinfCSZ_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("codezips","");
            search.ShowDialog();
            txtCity.Text = search.Nombre;
            txtState.Text = search.Estado;
            mtbZip.Text = search.Zip;
        }

        private void btnFinfCSZ_MouseHover(object sender, EventArgs e)
        {
            lblCSZ.Visible = true;
        }

        private void btnFinfCSZ_MouseLeave(object sender, EventArgs e)
        {
            lblCSZ.Visible = false;
        }

        private void btnPrintPDF_Click(object sender, EventArgs e)
        {
            frmPrintCatalogs catalogs = new frmPrintCatalogs();
            catalogs.ShowDialog();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAgency_Leave(object sender, EventArgs e)
        {
            txtAgency.Text = (txtAgency.Text).ToUpper();
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtAddress.Text = (txtAddress.Text).ToUpper();
        }

        private void txtAgency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnAddCD_Click(object sender, EventArgs e)
        {

        }
    }
}
