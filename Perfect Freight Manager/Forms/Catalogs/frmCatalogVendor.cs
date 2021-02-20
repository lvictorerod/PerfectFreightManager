using Npgsql;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Models;
using System;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Catalogs
{
    public partial class frmCatalogVendor : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        string TblName = "vendors";
        int codigo;
        private int sgte = 0, cuenta = 0;
        public frmCatalogVendor(string id)
        {
            InitializeComponent();
            btnAdiciona.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            dgvConsulta.DataSource = conectandose.Consultar(TblName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("http://www.mapquest.com/?q=,,++");
            servicio.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("https://www.bing.com/maps/?q=,+,+++");
            servicio.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("https://www.google.com/maps/place/,+,+++");
            servicio.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("https://www.weather.com/weather/today/l/");
            servicio.ShowDialog();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //conectandose.Desconectar();
            this.Close();
        }

        private void rellena()
        {
            codigo = Convert.ToInt32(dgvConsulta.Rows[sgte].Cells[0].Value);

            cbCategory.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[2].Value);
            txtName.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[1].Value);
            txtVenderIdCode.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[3].Value);
            txtAddress.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[4].Value);
            txtAddress2.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[5].Value);
            txtCity.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[6].Value);
            txtState.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[7].Value);
            txtZip.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[8].Value);
            txtTax.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[9].Value);
            txtPhone.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[10].Value);
            txtFax.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[11].Value);
            txtContact.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[12].Value);
            txtEmail.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[13].Value);
            txtWebsite.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[14].Value);
            txtNotes.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[15].Value);
            txtLat.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[16].Value);
            txtLong.Text = Convert.ToString(dgvConsulta.Rows[sgte].Cells[17].Value);

            lbRecord.Text = "Record " + (sgte + 1) + " of  " + cuenta;

            btnAdiciona.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && cbCategory.Text != "" && txtVenderIdCode.Text != "" && txtAddress.Text != "" && txtPhone.Text != "")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into vendors (name,category,venderidcode,addres,addres2,city,state,codezip,taxid,phonenumber,faxnumber,contact,email,website,notes,lat,longt) values ('" + txtName.Text + "','" + cbCategory.Text + "','" + txtVenderIdCode.Text + "','" + txtAddress.Text + "','" + txtAddress2.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZip.Text + "','" + txtTax.Text + "','" + txtPhone.Text + "','" + txtFax.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "','" + txtWebsite.Text + "',@notes,'" + txtLat.Text + "','" + txtLong.Text + "')", conn);
                    cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nName, Category, IdCode, Address and Phone", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvConsulta.DataSource = conectandose.Consultar(TblName);
            btnAdiciona.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update vendors set name='" + txtName.Text + "',category='" + cbCategory.Text + "',venderidcode='" + txtVenderIdCode.Text + "',addres='" + txtAddress.Text + "',addres2='" + txtAddress2.Text + "',city='" + txtCity.Text + "',state='" + txtState.Text + "',codezip='" + txtZip.Text + "',taxid='" + txtTax.Text + "',phonenumber='" + txtPhone.Text + "',faxnumber='" + txtFax.Text + "',contact='" + txtContact.Text + "',email='" + txtEmail.Text + "',website='" + txtWebsite.Text + "',notes=@notes,lat='" + txtLat.Text + "',longt='" + txtLong.Text + "'" + " where id=" + codigo, conn);
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
            dgvConsulta.DataSource = conectandose.Consultar(TblName);
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            cbCategory.Text = "";
            txtName.Text = "";
            txtVenderIdCode.Text = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtTax.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtWebsite.Text = "";
            txtNotes.Text = "";
            txtLat.Text = "";
            txtLong.Text = "";
            txtSearch.Text = "";
            rbId.Checked = true;

            btnAdiciona.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void btnFindCSZ_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("codezips","");
            search.ShowDialog();
            txtCity.Text = search.Nombre;
            txtState.Text = search.Estado;
            txtZip.Text = search.Zip;
        }

        private void btnFindCSZ_MouseHover(object sender, EventArgs e)
        {
            lblCSZ.Visible = true;
        }

        private void btnFindCSZ_MouseLeave(object sender, EventArgs e)
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
            frmHelpVendors helpVendors = new frmHelpVendors();
            helpVendors.Show();
        }

        private void btnVendorFirst_Click(object sender, EventArgs e)
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

        private void btnVendorPrevious_Click(object sender, EventArgs e)
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

        private void btnVendorNext_Click(object sender, EventArgs e)
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
        private void btnVendorEnd_Click(object sender, EventArgs e)
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

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtName.Text = (txtName.Text).ToUpper();
        }

        private void dgvConsulta_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnAdiciona.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            string search = (txtSearch.Text).ToUpper();
            if (txtSearch.Text != "")
            {
                if (rbName.Checked == true)
                {
                    dgvConsulta.DataSource = conectandose.ConsultarVendorName(TblName, search);
                    sgte = 0;
                    cuenta = dgvConsulta.Rows.GetRowCount(0);
                    if (cuenta != 0)
                        rellena();
                }
                else if (rbId.Checked == true)
                {
                    dgvConsulta.DataSource = conectandose.ConsultarVendorCode(TblName, search);
                    sgte = 0;
                    cuenta = dgvConsulta.Rows.GetRowCount(0);
                    if (cuenta != 0)
                        rellena();
                }
            }
            else
            {
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
                cuenta = dgvConsulta.Rows.GetLastRow(0);
            }
        }

        private void dgvConsulta_RowEnter(object sender, EventArgs e)
        {
            dgvConsulta.ClearSelection();
            dgvConsulta.Rows[sgte].Selected = true;
            dgvConsulta.FirstDisplayedScrollingRowIndex = dgvConsulta.Rows.GetNextRow(sgte - 1, 0);
        }
    }
}
