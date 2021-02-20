using Npgsql;
using Perfect_Freight_Manager.Forms.ExpensesInvoices;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Models;
using System;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Catalogs
{
    public partial class frmExpenses : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string TblName = "expenses";
        int codigo;
        public frmExpenses()
        {
            InitializeComponent();
            btnAdd.Enabled = true;
            btnDel.Enabled = false;
            btnUpd.Enabled = false;
            btnAddNotes.Enabled = false;

            dgvExpenses.DataSource = conectandose.Consultar(TblName);
        }



        private void dgvExpenses_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;
            btnAddNotes.Enabled = true;

            codigo = Convert.ToInt32(dgvExpenses.Rows[e.RowIndex].Cells[0].Value);

            txtInvoice.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[1].Value);
            dtDate.Value = Convert.ToDateTime(dgvExpenses.Rows[e.RowIndex].Cells[2].Value);
            cbPayment.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[3].Value);
            txtTruck.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[4].Value);
            txtTrailer.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[5].Value);
            txtApu.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[6].Value);
            txtTruckMileage.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[7].Value);
            txtTrailerMileage.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[8].Value);
            txtApuHours.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[9].Value);
            txtVendor.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[18].Value);
            txtContact.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[13].Value);
            txtCity.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[15].Value);
            txtState.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[16].Value);
            txtZip.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[17].Value);
            txtAddress.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[14].Value);
            txtPhone.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[12].Value);
            txtNotes.Text = Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[11].Value);
            if (Convert.ToString(dgvExpenses.Rows[e.RowIndex].Cells[10].Value) == "True")
                chkPmTruck.Checked = true;
            else chkPmTruck.Checked = false;
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtInvoice.Text = "";
            dtDate.Text = "";
            cbPayment.Text = "";
            txtTruck.Text = "";
            txtTrailer.Text = "";
            txtApu.Text = "";
            txtTruckMileage.Text = "";
            txtTrailerMileage.Text = "";
            txtApuHours.Text = "";
            txtVendor.Text = "";
            txtContact.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtNotes.Text = "";
            chkPmTruck.Checked = false;
            txtSearchExpenses.Text = "";

            btnAdd.Enabled = true;
            btnDel.Enabled = false;
            btnUpd.Enabled = false;
            btnAddNotes.Enabled = false;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtInvoice.Text != "" && dtDate.Value != null && txtTruck.Text !="" && txtVendor.Text !="" && txtAddress.Text !="" && txtPhone.Text !="")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into expenses (invoicenumber,date,payment,truck,trailer,apu,truckmileage,trailermileage,apuhours,pmtruck,notes,phone,contact,address,city,state,codezip,vendor) values ('" + txtInvoice.Text + "','" + dtDate.Value + "','" + cbPayment.Text + "','" + txtTruck.Text + "','" + txtTrailer.Text + "','" + txtApu.Text + "','" + txtTruckMileage.Text + "','" + txtTrailerMileage.Text + "','" + txtApuHours.Text + "','" + chkPmTruck.Checked + "',@notes,'" + txtPhone.Text + "','" + txtContact.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZip.Text + "','" + txtVendor.Text + "')", conn);
                    //cmd.Parameters.AddWithValue("loadstatus", LoadStatus);
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
            else MessageBox.Show("Lack data, check that have:\n#Invoice, Date Invoice, #Truck, Vendor, Address and Phone", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvExpenses.DataSource = conectandose.Consultar(TblName);
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;
            btnAddNotes.Enabled = true;
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnClear_Click_1(sender, e);
                    //dgvExpenses.DataSource = conectandose.Consultar(TblName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvExpenses.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpd_Click_1(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update expenses set invoicenumber='" + txtInvoice.Text + "',date='" + dtDate.Value + "',payment='" + cbPayment.Text + "',truck='" + txtTruck.Text + "',trailer='" + txtTrailer.Text + "',apu='" + txtApu.Text + "',truckmileage='" + txtTruckMileage.Text + "',trailermileage='" + txtTrailerMileage.Text + "',apuhours='" + txtApuHours.Text + "',pmtruck='" + chkPmTruck.Checked + "',notes=@notes,phone='" + txtPhone.Text + "',contact='" + txtContact.Text + "',address='" + txtAddress.Text + "',city='" + txtCity.Text + "',state='" + txtState.Text + "',codezip='" + txtZip.Text + "',vendor='" + txtVendor.Text + "'" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("notes", txtNotes.Text);
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
            dgvExpenses.DataSource = conectandose.Consultar(TblName);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCatalogVendor vendor = new frmCatalogVendor("");
            vendor.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnReportExpenses_Click(object sender, EventArgs e)
        {
            frmPrintExpenses expenses = new frmPrintExpenses();
            expenses.Show();
        }

        /// <summary>//////////////////////////////////////////////
        /// GENERALES
        /// </summary>/////////////////////////////////////////////
        /// 

        private void btnSearchTruck_Click_1(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("trucksprofiles","");
            search.ShowDialog();
            txtTruck.Text = search.Nombre;
        }

        private void btnSearchTrailer_Click_1(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("trailersprofiles","");
            search.ShowDialog();
            txtTrailer.Text = search.Nombre;
        }

        private void btnSearchApu_Click_1(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("","");
            search.ShowDialog();
            txtApu.Text = search.Nombre;
        }

        private void btnSearchTruck_MouseHover(object sender, EventArgs e)
        {
            lblTruck.Visible = true;
        }

        private void btnSearchTrailer_MouseLeave(object sender, EventArgs e)
        {
            lblTrailer.Visible = false;
        }

        private void btnSearchApu_MouseHover(object sender, EventArgs e)
        {
            lblApu.Visible = true;
        }

        private void btnSearchApu_MouseLeave(object sender, EventArgs e)
        {
            lblApu.Visible = false;
        }

        private void btnFinfCSZ_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("codezips","");
            search.ShowDialog();
            txtCity.Text = search.Nombre;
            txtState.Text = search.Estado;
            txtZip.Text = search.Zip;
        }

        private void btnVendor_Click_1(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("vendors","");
            search.ShowDialog();
            txtVendor.Text = search.Nombre;
            txtContact.Text = search.Contacto;
            txtCity.Text = search.Ciudad;
            txtState.Text = search.Estado;
            txtZip.Text = search.Zip;
            txtAddress.Text = search.Direccion;
            txtPhone.Text = search.Telef;
            txtNotes.Text = search.Notas;
        }

        private void btnAddNotes_Click_1(object sender, EventArgs e)
        {
            frmResumens resumens = new frmResumens(txtInvoice.Text);
            resumens.ShowDialog();
        }

        private void btnAddNotes_MouseLeave(object sender, EventArgs e)
        {
            lblAddResumes.Visible = false;
        }

        private void txtSearchExpenses_TextChanged(object sender, EventArgs e)
        {
            //Consulta
            string search = (txtSearchExpenses.Text).ToUpper();
            if (txtSearchExpenses.Text != "")
            {
                dgvExpenses.DataSource = conectandose.ConsultarWith(TblName, search);
            }
        }

        private void btnSearchTruck_MouseLeave(object sender, EventArgs e)
        {
            lblTruck.Visible = false;
        }

        private void btnSearchTrailer_MouseLeave_1(object sender, EventArgs e)
        {
            lblTrailer.Visible = false;
        }

        private void btnSearchTrailer_MouseHover(object sender, EventArgs e)
        {
            lblTrailer.Visible = true;
        }

        private void btnAddNotes_MouseHover(object sender, EventArgs e)
        {
            lblAddResumes.Visible = true;
        }

        private void btnAddNotes_MouseLeave_1(object sender, EventArgs e)
        {
            lblAddResumes.Visible = false;
        }

        private void btnVendor_MouseHover(object sender, EventArgs e)
        {
            lblVendor.Visible = true;
        }

        private void btnVendor_MouseLeave(object sender, EventArgs e)
        {
            lblVendor.Visible = false;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpExpenses helpExpenses = new frmHelpExpenses();
            helpExpenses.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFindCSZ_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("codezips", "");
            search.ShowDialog();
            txtCity.Text = search.Nombre;
            txtState.Text = search.Estado;
            txtZip.Text = search.Zip;
        }

        private void txtInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnFindCSZ_MouseHover(object sender, EventArgs e)
        {
            lblCSZ.Visible = true;
        }

        private void btnFindCSZ_MouseLeave(object sender, EventArgs e)
        {
            lblCSZ.Visible = false;
        }
    }
}
