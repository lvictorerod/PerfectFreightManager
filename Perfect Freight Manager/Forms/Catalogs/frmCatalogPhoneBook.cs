using Npgsql;
using Perfect_Freight_Manager.Forms;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Models;
using System;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Catalogs
{
    public partial class frmCatalogPhoneBook : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        private string TblName = "phonebooks";
        private int codigo;
        private int sgte = 0, cuenta = 0;
        public frmCatalogPhoneBook()
        {
            InitializeComponent();
            btnAdd.Enabled = true;
            btnUpd.Enabled = false;
            btnDel.Enabled = false;
            dgvConsulta.DataSource = conectandose.Consultar(TblName);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";

            txtEmail.Text = "";
            txtBirthay.Text = "";
            mbtHPhone.Text = "";
            mtbWPhone.Text = "";
            mtbMPhone.Text = "";
            mtbFax.Text = "";
            txtNotes.Text = "";

            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;
        }

        private void rellena()
        {
            codigo = Convert.ToInt32(dgvConsulta.Rows[sgte].Cells[0].Value);

            txtFName.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[1].Value);
            txtLName.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[2].Value);
            txtAddress.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[3].Value);
            txtCity.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[4].Value);
            txtState.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[5].Value);
            txtZip.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[6].Value);

            txtEmail.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[7].Value);
            txtBirthay.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[8].Value);
            mbtHPhone.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[9].Value);
            mtbWPhone.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[10].Value);
            mtbMPhone.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[11].Value);
            mtbFax.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[12].Value);
            txtNotes.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[13].Value);

            lbRecord.Text = "Record " + (sgte + 1) + " of  " + cuenta;
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFName.Text != "" && txtLName.Text != "" && txtAddress.Text != "" && mbtHPhone.Text != "")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into phonebooks (name,lastname,address,city,state,codezip,email,birthay,homephone,workphone,mobilephone,faxnumber,notes) values ('" + txtFName.Text + "','" + txtLName.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZip.Text + "','" + txtEmail.Text + "','" + txtBirthay.Text + "','" + mbtHPhone.Text + "','" + mtbWPhone.Text + "','" + mtbMPhone.Text + "','" + mtbFax.Text + "',@notes", conn);
                    cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert Correct", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nFirst Name, Last Name, Address and Phone", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvConsulta.DataSource = conectandose.Consultar(TblName);
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update phonebooks set name='" + txtFName.Text + "',lastname='" + txtLName.Text + "',address='" + txtAddress.Text + "',city='" + txtCity.Text + "',state='" + txtState.Text + "',codezip='" + txtZip.Text + "',email='" + txtEmail.Text + "',birthay='" + txtBirthay.Text + "',homephone='" + mbtHPhone.Text + "',workphone='" + mtbWPhone.Text + "',mobilephone='" + mtbMPhone.Text + "',faxnumber='" + mtbFax.Text + "',notes=@notes" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correct", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close(); throw;
            }
            dgvConsulta.DataSource = conectandose.Consultar(TblName);
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
            txtZip.Text = search.Zip;
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
            catalogs.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpPhoneBook helpPhoneBook = new frmHelpPhoneBook();
            helpPhoneBook.Show();
        }

        private void btnPhoneFirst_Click(object sender, EventArgs e)
        {
            cuenta = dgvConsulta.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvConsulta.Rows.GetFirstRow(0);
                //sgte += 1;
                dgvConsulta_RowEnter(sender, e);
                rellena();
            }
        }

        private void btnPhonePrevious_Click(object sender, EventArgs e)
        {
            cuenta = dgvConsulta.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvConsulta.Rows.GetPreviousRow(sgte, 0);
                if (sgte == -1) sgte = cuenta - 1;
                if (sgte <= cuenta && sgte >= 0)
                {
                    dgvConsulta_RowEnter(sender, e);
                    rellena();
                }
            }
        }

        private void btnPhoneNext_Click(object sender, EventArgs e)
        {
            cuenta = dgvConsulta.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvConsulta.Rows.GetNextRow(sgte, 0);
                if (sgte == -1) sgte = 0;
                if (sgte <= cuenta && sgte >= 0)
                {
                    dgvConsulta_RowEnter(sender, e);
                    rellena();
                }

            }
        }

        private void btnPhoneEnd_Click(object sender, EventArgs e)
        {
            cuenta = dgvConsulta.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvConsulta.Rows.GetLastRow(0);
                dgvConsulta_RowEnter(sender, e);
                rellena();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFName_Leave(object sender, EventArgs e)
        {
            txtFName.Text = (txtFName.Text).ToUpper();
        }

        private void txtLName_Leave(object sender, EventArgs e)
        {
            txtLName.Text = (txtLName.Text).ToUpper();
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtAddress.Text = (txtAddress.Text).ToUpper();
        }

        private void dgvConsulta_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvConsulta_RowEnter(object sender, EventArgs e)
        {
            dgvConsulta.ClearSelection();
            dgvConsulta.Rows[sgte].Selected = true;
            dgvConsulta.FirstDisplayedScrollingRowIndex = dgvConsulta.Rows.GetNextRow(sgte - 1, 0);
        }
    }
}
