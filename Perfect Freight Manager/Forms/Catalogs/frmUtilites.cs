using Npgsql;
using Perfect_Freight_Manager.Forms;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Forms.Utilities;
using Perfect_Freight_Manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Catalogs
{

    public partial class frmUtilites : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string TblName = "companyprofiles";
        int codigo;
        private string LoadDriverState = "";
        private string LoadActive = "";
        private int RowIndex;
        private int cuentadriver = 0, sgtedriver = 0;
        public frmUtilites()
        {
            InitializeComponent();
            btnDriverDel.Enabled = false;
            btnCompanyDel.Enabled = false;
            btnCompanyUpd.Enabled = false;
            btnDriverUpd.Enabled = false;
            btnEmployDel.Enabled = false;
            btnEmployUpd.Enabled = false;
            btnEmailDel.Enabled = false;
            btnEmailUpd.Enabled = false;
            btnFaxDel.Enabled = false;
            btnFaxUpd.Enabled = false;

            dgvConsulta.DataSource = conectandose.Consultar(TblName);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tbCompany")
            {
                TblName = "companyprofiles";
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tbDriver")
            {
                TblName = "driverprofiles";
                dgvDriver.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tbOffice")
            {
                TblName = "employeeprofile";
                dgvEmploy.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tbEmail")
            {
                TblName = "emailsettings";
                dgvEmail.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tbFax")
            {
                TblName = "faxsetting";
                dgvFax.DataSource = conectandose.Consultar(TblName);
            }
        }

        /// <summary>////////////////////////////////////
        /// COMPANY PROFILES
        /// </summary>///////////////////////////////////
        /// 

        private AutoCompleteStringCollection CargaDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvConsulta.DataSource = conectandose.ConsultarWith(TblName, txtCompanySearch.Text);
            return datos;
        }

        private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCompanyAdd.Enabled = false;
            btnCompanyUpd.Enabled = true;
            btnCompanyDel.Enabled = true;

            codigo = Convert.ToInt32(dgvConsulta.Rows[e.RowIndex].Cells[0].Value);

            conn.Open();
            string query = "select companylogo from " + TblName + " where id = " + codigo;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "img");

            byte[] datos = new byte[0];
            DataRow dr = ds.Tables["img"].Rows[0];
            datos = (byte[])dr["companylogo"];
            MemoryStream ms = new MemoryStream(datos);
            pbCompanyLogo.Image = System.Drawing.Bitmap.FromStream(ms);
            conn.Close();

            txtCompanyName.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[1].Value);
            txtCompanyOwner.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[2].Value);
            txtCompanyAddress.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[3].Value);
            txtCompanyAddress2.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[4].Value);
            txtCompanyCity.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[5].Value);
            txtCompanyState.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[6].Value);
            txtCompanyZip.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[7].Value);
            txtCompanyEmail.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[8].Value);
            txtCompanyWebsite.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[9].Value);
            txtCompanyPhone.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[10].Value);

            txtCompanyContact.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[11].Value);
            txtCompanyBillingEmail.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[12].Value);
            txtCompanyToll.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[13].Value);
            txtCompanyFax.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[14].Value);
            txtCompanyUsdot.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[15].Value);
            txtCompanyFid.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[16].Value);
            txtCompanyMcMx.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[17].Value);

            //Aqui va el Holder

            txtCompanyNotes.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[22].Value);
            txtCompanyInvoice.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[23].Value);
            //Aqui van dos cosas, entre ellas una foto

        }

        private void txtCompanySearch_TextChanged(object sender, EventArgs e)
        {
            //Consulta
            if (txtCompanySearch.Text != "")
            {
                txtCompanySearch.AutoCompleteCustomSource = CargaDatos();
                txtCompanySearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtCompanySearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnCleanCompany_Click_1(object sender, EventArgs e)
        {
            txtCompanyName.Text = "";
            txtCompanyOwner.Text = "";
            txtCompanyAddress.Text = "";
            txtCompanyAddress2.Text = "";
            txtCompanyCity.Text = "";
            txtCompanyState.Text = "";
            txtCompanyZip.Text = "";
            txtCompanyWebsite.Text = "";
            txtCompanyEmail.Text = "";
            txtCompanyPhone.Text = "";
            txtCompanyContact.Text = "";
            txtCompanyBillingEmail.Text = "";
            txtCompanyToll.Text = "";
            txtCompanyFax.Text = "";
            txtCompanyUsdot.Text = "";
            txtCompanyFid.Text = "";
            txtCompanyMcMx.Text = "";
            txtCompanyNotes.Text = "";
            txtCompanyInvoice.Text = "";
            pbCompanyLogo.Image = null;


            btnCompanyAdd.Enabled = true;
            btnCompanyUpd.Enabled = false;
            btnCompanyDel.Enabled = false;
        }

        private void btnCompanyAdd_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text != "" && pbCompanyLogo.Image != null && txtCompanyOwner.Text !="" && txtCompanyAddress.Text !="" && txtCompanyPhone.Text !="")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into companyprofiles (company,owner,address,address2,city,state,zip,email,website,phone,contact,billingemail,tollfree,fax,usddot,fid,mc,@notes,invoicemessage,) values ('" + txtCompanyName.Text + "','" + txtCompanyOwner.Text + "','" + txtCompanyAddress.Text + "','" + txtCompanyAddress2.Text + "','" + txtCompanyCity.Text + "','" + txtCompanyState.Text + "','" + txtCompanyZip.Text + "','" + txtCompanyEmail.Text + "','" + txtCompanyWebsite.Text + "','" + txtCompanyPhone.Text + "','" + txtCompanyContact.Text + "','" + txtCompanyBillingEmail.Text + "','" + txtCompanyToll.Text + "','" + txtCompanyFax.Text + "','" + txtCompanyUsdot.Text + "','" + txtCompanyFid.Text + "','" + txtCompanyMcMx.Text + "','" + txtCompanyNotes.Text + "','" + txtCompanyInvoice.Text + "',@photo)", conn);
                    MemoryStream ms = new MemoryStream();
                    pbCompanyLogo.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();
                    cmd.Parameters.AddWithValue("photo", aByte);
                    cmd.Parameters.AddWithValue("notes", txtCompanyNotes.Text);
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
            else MessageBox.Show("Lack data, check that have:\nCompany, Owner, Address, Logo and Phone", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvConsulta.DataSource = conectandose.Consultar(TblName);
            btnCompanyAdd.Enabled = false;
            btnCompanyUpd.Enabled = true;
            btnCompanyDel.Enabled = true;
        }

        private void btnCompanyDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnCleanCompany_Click_1(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnCompanyUpd_Click_1(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update companyprofiles set company='" + txtCompanyName.Text + "',owner='" + txtCompanyOwner.Text + "',address='" + txtCompanyAddress.Text + "',address2='" + txtCompanyAddress2.Text + "',city='" + txtCompanyCity.Text + "',state='" + txtCompanyState.Text + "',zip='" + txtCompanyZip.Text + "',email='" + txtCompanyEmail.Text + "',website='" + txtCompanyWebsite.Text + "',phone='" + txtCompanyPhone.Text + "',contact='" + txtCompanyContact.Text + "',billingemail='" + txtCompanyBillingEmail.Text + "',tollfree='" + txtCompanyToll.Text + "',fax='" + txtCompanyFax.Text + "',usddot='" + txtCompanyUsdot.Text + "',fid='" + txtCompanyFid.Text + "',mc='" + txtCompanyMcMx.Text + "',notes='" + txtCompanyNotes.Text + "',invoicemessage='" + txtCompanyInvoice.Text + "', companylogo=@photo" + " where id=" + codigo, conn);
                MemoryStream ms = new MemoryStream();
                pbCompanyLogo.Image.Save(ms, ImageFormat.Jpeg);
                byte[] aByte = ms.ToArray();
                cmd.Parameters.AddWithValue("photo", aByte);
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
            dgvConsulta.DataSource = conectandose.Consultar(TblName);
        }

        private void btnSelCompanyLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbCompanyLogo.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

/// <summary>///////////////////////////////////////
/// DRIVERS PROFILES
/// </summary>//////////////////////////////////////
///
        private void btnDriverFirst_Click(object sender, EventArgs e)
        {
            cuentadriver = dgvDriver.Rows.GetRowCount(0);
            sgtedriver = dgvDriver.Rows.GetFirstRow(0);
            dgvDriver_RowEnter(sender, e);
            //sgte += 1;
            rellenaDriver();
            
        }

        private void btnDriverPrevios_Click(object sender, EventArgs e)
        {
            cuentadriver = dgvDriver.Rows.GetRowCount(0);
            sgtedriver = dgvDriver.Rows.GetPreviousRow(sgtedriver, 0);
            if (sgtedriver == -1) sgtedriver = cuentadriver - 1;
            if (sgtedriver <= cuentadriver && sgtedriver >= 0)
            {
                dgvDriver_RowEnter(sender, e);
                rellenaDriver();
            }
        }
        private void btnDriverNext_Click(object sender, EventArgs e)
        {
            cuentadriver = dgvDriver.Rows.GetRowCount(0);
            sgtedriver = dgvDriver.Rows.GetNextRow(sgtedriver, 0);
            if (sgtedriver == -1) sgtedriver = 0;
            if (sgtedriver <= cuentadriver && sgtedriver >= 0)
            {
                dgvDriver_RowEnter(sender, e);
                rellenaDriver();
            }
        }
        private void btnDriverEnd_Click(object sender, EventArgs e)
        {
            cuentadriver = dgvDriver.Rows.GetRowCount(0);
            RowIndex = sgtedriver;
            sgtedriver = dgvDriver.Rows.GetLastRow(0);
            dgvDriver_RowEnter(sender, e);
            rellenaDriver();
        }
        private void dgvDriver_RowEnter(object sender, EventArgs e)
        {
            dgvDriver.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvDriver.Rows[sgtedriver].Selected = true;
            dgvDriver.FirstDisplayedScrollingRowIndex = dgvDriver.Rows.GetNextRow(sgtedriver-1,0);
        }

        private void rellenaDriver()
        {
            btnDriverAdd.Enabled = false;
            btnDriverUpd.Enabled = true;
            btnDriverDel.Enabled = true;
            
            codigo = Convert.ToInt32(dgvDriver.Rows[sgtedriver].Cells[0].Value);
            conn.Open();
            string query = "select driverphoto, cdlphoto, medcardphoto, ssphoto from " + TblName + " where id = " + codigo;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "img");

            byte[] datos = new byte[0];
            DataRow dr = ds.Tables["img"].Rows[0];
            datos = (byte[])dr["driverphoto"];
            MemoryStream ms = new MemoryStream(datos);
            pbDriverPhoto.Image = System.Drawing.Bitmap.FromStream(ms);


            datos = (byte[])dr["cdlphoto"];
            MemoryStream ms2 = new MemoryStream(datos);
            pbCDLPhoto.Image = System.Drawing.Bitmap.FromStream(ms2);


            datos = (byte[])dr["medcardphoto"];
            MemoryStream ms3 = new MemoryStream(datos);
            pbDriverMedCardPhoto.Image = System.Drawing.Bitmap.FromStream(ms3);


            datos = (byte[])dr["ssphoto"];
            MemoryStream ms4 = new MemoryStream(datos);
            pbDriverSSPhoto.Image = System.Drawing.Bitmap.FromStream(ms4);
            conn.Close();

            txtDriverFirstName.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[1].Value);
            txtDriverMiddleName.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[2].Value);
            txtDriverLastName.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[3].Value);
            dtDriverBirthay.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[4].Value);
            txtDriverAsignedTruck.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[5].Value);
            dtDriverHire.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[6].Value);
            dtDriverEndService.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[7].Value);
            switch (Convert.ToInt32(dgvDriver.Rows[sgtedriver].Cells[42].Value))
            {
                case 0:
                    rbDriver.Checked = true;
                    LoadDriverState = "0";
                    break;
                case 1:
                    rbOwner.Checked = true;
                    LoadDriverState = "1";
                    break;
            }
            txtAddress.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[8].Value);
            txtCity.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[9].Value);
            txtState.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[10].Value);
            txtCodeZip.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[11].Value);
            txtHomePhone.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[12].Value);
            txtCellPhone.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[13].Value);
            cbCellService.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[14].Value);
            txtEmail.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[15].Value);
            txtEName.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[16].Value);
            txtEAddress.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[17].Value);
            txtECity.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[18].Value);
            txtEState.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[19].Value);
            txtEZip.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[20].Value);
            txtEPhone.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[21].Value);
            txtECell.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[22].Value);
            txtDriverLoadedPay.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[24].Value);
            txtDriverEmptyPay.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[25].Value);
            txtDriverPercentagePay.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[26].Value);
            txtDriverPercentageOf.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[27].Value);
            txtDriverTonnagePay.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[28].Value);
            txtDriverPaybyHour.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[29].Value);
            for (int count = 0; count < chkDriverPayMetod.Items.Count; count++)
            {
                chkDriverPayMetod.SetItemChecked(count, false);
            }
            chkDriverPayMetod.SetItemChecked(Convert.ToInt32(dgvDriver.Rows[sgtedriver].Cells[30].Value), true);
            //chkDriverPayMetod.SetItemChecked(2, true);

            switch (Convert.ToInt32(dgvDriver.Rows[sgtedriver].Cells[30].Value))
            {
                case 0: //Flat Rate
                    txtDriverFlatRate.Enabled = true;
                    txtDriverLoadedPay.Enabled = false;
                    txtDriverEmptyPay.Enabled = false;
                    txtDriverTonnagePay.Enabled = false;
                    txtDriverPaybyHour.Enabled = false;
                    txtDriverPercentagePay.Enabled = false;
                    break;
                case 1: // Mileage
                    txtDriverFlatRate.Enabled = false;
                    txtDriverLoadedPay.Enabled = true;
                    txtDriverEmptyPay.Enabled = true;
                    txtDriverTonnagePay.Enabled = false;
                    txtDriverPaybyHour.Enabled = false;
                    txtDriverPercentagePay.Enabled = false;
                    break;
                case 2: //Percentage
                    txtDriverFlatRate.Enabled = false;
                    txtDriverLoadedPay.Enabled = false;
                    txtDriverEmptyPay.Enabled = false;
                    txtDriverTonnagePay.Enabled = false;
                    txtDriverPaybyHour.Enabled = false;
                    txtDriverPercentagePay.Enabled = true;
                    break;
                case 3: //Tonnage
                    txtDriverFlatRate.Enabled = false;
                    txtDriverLoadedPay.Enabled = false;
                    txtDriverEmptyPay.Enabled = false;
                    txtDriverTonnagePay.Enabled = true;
                    txtDriverPaybyHour.Enabled = false;
                    txtDriverPercentagePay.Enabled = false;
                    break;
                case 4: //Hourly
                    txtDriverFlatRate.Enabled = false;
                    txtDriverLoadedPay.Enabled = false;
                    txtDriverEmptyPay.Enabled = false;
                    txtDriverTonnagePay.Enabled = false;
                    txtDriverPaybyHour.Enabled = true;
                    txtDriverPercentagePay.Enabled = false;
                    break;
            }
            if (rbOwner.Checked)
            {
                txtDriverELD.Enabled = true;
                txtDriverPrePass.Enabled = true;
            }
            else
            {
                txtDriverELD.Enabled = false;
                txtDriverPrePass.Enabled = false;
            }

            txtNotes.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[31].Value);
            txtCDLNumber.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[32].Value);
            txtCDLState.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[33].Value);
            txtCDLClass.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[34].Value);
            txtCDLEndor.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[35].Value);
            dtCDLExpireDate.Value = Convert.ToDateTime(dgvDriver.Rows[sgtedriver].Cells[36].Value);
            dtMedExpireDate.Value = Convert.ToDateTime(dgvDriver.Rows[sgtedriver].Cells[38].Value);
            txtSSNumber.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[39].Value);
            //dtWhDate.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[41].Value);
            //txtWhDescription.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[42].Value);
            //cbWhCategory.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[43].Value);
            //txtWhAmount.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[44].Value);
            txtDriverFlatRate.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[43].Value);
            switch (Convert.ToInt32(dgvDriver.Rows[sgtedriver].Cells[44].Value))
            {
                case 0:
                    rbActive.Checked = true;
                    lbactive.Text = "Active";
                    LoadActive = "0";
                    break;
                case 1:
                    rbNoActive.Checked = true;
                    lbactive.Text = "No Active";
                    LoadActive = "1";
                    break;
            }
            txtDriverPDPay.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[45].Value);
            txtDriverVacations.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[46].Value);
            txtDriverELD.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[47].Value);
            txtDriverEZPass.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[48].Value);
            txtDriverInsurance.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[49].Value);
            txtDriverPrePass.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[50].Value);
            if (Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[51].Value) == "True")
                chkExpenses.Checked = true;
            else chkExpenses.Checked = false;
            if (Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[52].Value) == "True")
                chkFuel.Checked = true;
            else chkFuel.Checked = false;
            txtDriverFactoryFee.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[53].Value);
            txtDriverPaymentFee.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[54].Value);

            cuentadriver = dgvDriver.Rows.GetRowCount(0);
            lbDriverRecord.Text = "Record " + (sgtedriver + 1) + " of  " + cuentadriver;

            btnDriverAdd.Enabled = false;
            btnDriverUpd.Enabled = true;
            btnDriverDel.Enabled = true;
        }

        private void btnCleanDrivers_Click(object sender, EventArgs e)
        {
            txtDriverFirstName.Text = "";
            txtDriverMiddleName.Text = "";
            txtDriverLastName.Text = "";
            dtDriverBirthay.Text = "";
            txtDriverAsignedTruck.Text = "";
            dtDriverHire.Text = "";
            dtDriverEndService.Text = "";
            rbDriver.Checked = true;
            rbActive.Checked = true;
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCodeZip.Text = "";
            txtHomePhone.Text = "";
            txtCellPhone.Text = "";
            cbCellService.Text = "";
            txtEmail.Text = "";
            txtEName.Text = "";
            txtEAddress.Text = "";
            txtECity.Text = "";
            txtEState.Text = "";
            txtEZip.Text = "";
            txtEPhone.Text = "";
            txtECell.Text = "";
            pbDriverPhoto.Image = null;
            txtDriverFlatRate.Text = "0";
            txtDriverLoadedPay.Text = "0";
            txtDriverEmptyPay.Text = "0";
            txtDriverPercentagePay.Text = "0";
            txtDriverPercentageOf.Text = "0";
            txtDriverTonnagePay.Text = "0";
            txtDriverPaybyHour.Text = "0";
            txtDriverVacations.Text = "0";
            txtDriverPDPay.Text = "0";
            txtDriverELD.Text = "0";
            txtDriverPrePass.Text = "0";
            txtDriverEZPass.Text = "0";
            txtDriverInsurance.Text = "0";
            
            for (int count = 0; count < chkDriverPayMetod.Items.Count; count++)
            {
                chkDriverPayMetod.SetItemChecked(count, false);
            }
            chkDriverPayMetod.SetItemChecked(2, true);
            txtDriverFlatRate.Enabled = true;
            txtDriverLoadedPay.Enabled = true;
            txtDriverEmptyPay.Enabled = true;
            txtDriverTonnagePay.Enabled = true;
            txtDriverPaybyHour.Enabled = true;
            txtNotes.Text = "";
            txtCDLNumber.Text = "";
            txtCDLState.Text = "";
            txtCDLClass.Text = "";
            txtCDLEndor.Text = "";
            dtCDLExpireDate.Value = DateTime.Today;
            pbCDLPhoto.Image = null;
            pbDriverMedCardPhoto.Image = null;
            dtMedExpireDate.Value = DateTime.Today;
            txtSSNumber.Text = "";
            pbDriverSSPhoto.Image = null;
            //dtWhDate.Text = "";
            //txtWhDescription.Text = "";
            //cbWhCategory.Text = "";
            //txtWhAmount.Text = "";
            txtDriverSearch.Text = "";
            chkExpenses.Checked = false;
            chkFuel.Checked = false;
            txtDriverFactoryFee.Text = "0";
            txtDriverPaymentFee.Text = "0";
            btnDriverAdd.Enabled = true;
            btnDriverUpd.Enabled = false;
            btnDriverDel.Enabled = false;

        }

        private void txtDriverSearch_TextChanged(object sender, EventArgs e)
        {
            btnDriverAdd.Enabled = false;
            btnDriverUpd.Enabled = true;
            btnDriverDel.Enabled = true;

            string search = (txtDriverSearch.Text).ToUpper();
            if (txtDriverSearch.Text != "")
            {
                dgvDriver.DataSource = conectandose.ConsultarWith(TblName, search);
                sgtedriver = 0;
                cuentadriver = dgvDriver.Rows.GetRowCount(0);
                if (cuentadriver != 0)
                    rellenaDriver();
            }
            
        }
        private void btnDriverAdd_Click(object sender, EventArgs e)
        {
            if (!(txtDriverFirstName.Text == "" || pbDriverPhoto.Image == null || pbCDLPhoto.Image == null || pbDriverMedCardPhoto.Image == null || pbDriverSSPhoto.Image == null || txtDriverLastName.Text == "" || txtAddress.Text == "" || txtHomePhone.Text == "" || txtEmail.Text == ""))
            {
                string paymethod = "";
                try
                {
                    if (rbDriver.Checked == true)
                        LoadDriverState = "0";
                    if (rbOwner.Checked == true)
                        LoadDriverState = "1";
                    for (int count = 0; count < chkDriverPayMetod.Items.Count; count++)
                    {
                        if (count != 2)
                        {
                            if (chkDriverPayMetod.GetItemChecked(count) == true)
                            {
                                paymethod = count.ToString();
                                break;
                            }
                        }
                    }
                    if (rbActive.Checked == true)
                        LoadActive = "0";
                    if (rbNoActive.Checked == true)
                        LoadActive = "1";
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into driverprofiles (name,middlename,lastname,birthay,assignedtruck,hiredate,endservicedate,address,city,state,codezip,homephone,cellphone,cellservice,email,emergname,emergaddress,emergcity,emergstate,emergzip,emerghomephone,emergcellphone,@driverphoto,loadedparpermile,emptypaypermile,percentagepay,percentof,tonnagepay,paybyhours,@paymethod,@notes,cdlnumber,cdlstate,cdlclass,cdlendor,cdlexpirdate,@cdlphoto,medcareexpirdate,ssnumber,@ssphoto,@medcardphoto,@statusdriver,flatratepay,@activedriver,pickupdroppay,vacation,drivereld,driverezpass,driverinsurace,driverprepass,driverexpense,driverfuel,driverfactoryfee,driverpaymentfee) values ('" + txtDriverFirstName.Text + "','" + txtDriverMiddleName.Text + "','" + txtDriverLastName.Text + "','" + dtDriverBirthay.Text + "','" + txtDriverAsignedTruck.Text + "','" + dtDriverHire.Text + "','" + dtDriverEndService.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtCodeZip.Text + "','" + txtHomePhone.Text + "','" + txtCellPhone.Text + "','" + cbCellService.Text + "','" + txtEmail.Text + "','" + txtEName.Text + "','" + txtEAddress.Text + "','" + txtECity.Text + "','" + txtEState.Text + "','" + txtEZip.Text + "','" + txtEPhone.Text + "','" + txtECell.Text + "','" + txtDriverLoadedPay.Text + "','" + txtDriverEmptyPay.Text + "','" + txtDriverPercentagePay.Text + "','" + txtDriverPercentageOf.Text + "','" + txtDriverTonnagePay.Text + "','" + txtDriverPaybyHour.Text + "','" + txtCDLNumber.Text + "','" + txtCDLState.Text + "','" + txtCDLClass.Text + "','" + txtCDLEndor.Text + "','" + dtCDLExpireDate.Value + "','" + dtMedExpireDate.Value + "','" + txtSSNumber.Text + "','" + txtDriverFlatRate.Text + "','" + txtDriverPDPay.Text + "','" + txtDriverVacations.Text + "','" + txtDriverELD.Text + "','" + txtDriverEZPass.Text + "','" + txtDriverInsurance.Text + "','" + txtDriverPrePass.Text + "','" + chkExpenses.Checked + "','" + chkFuel.Checked + "','" + txtDriverFactoryFee.Text + "','" + txtDriverPaymentFee.Text + "')", conn);

                    MemoryStream ms = new MemoryStream();
                    pbDriverPhoto.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();
                    cmd.Parameters.AddWithValue("driverphoto", aByte);
                    cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                    cmd.Parameters.AddWithValue("paymethod", paymethod);
                    cmd.Parameters.AddWithValue("statusdriver", LoadDriverState);
                    cmd.Parameters.AddWithValue("activedriver", LoadActive);

                    MemoryStream ms2 = new MemoryStream();
                    pbCDLPhoto.Image.Save(ms2, ImageFormat.Jpeg);
                    byte[] abByte = ms2.ToArray();
                    cmd.Parameters.AddWithValue("cdlphoto", abByte);

                    MemoryStream ms3 = new MemoryStream();
                    pbDriverMedCardPhoto.Image.Save(ms3, ImageFormat.Jpeg);
                    byte[] acByte = ms3.ToArray();
                    cmd.Parameters.AddWithValue("medcardphoto", acByte);

                    MemoryStream ms4 = new MemoryStream();
                    pbDriverSSPhoto.Image.Save(ms4, ImageFormat.Jpeg);
                    byte[] adByte = ms4.ToArray();
                    cmd.Parameters.AddWithValue("ssphoto", adByte);
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
            else MessageBox.Show("Lack data, check that have:\n First & Last Name, Address, Phone, Mail, Photo Driver, Photo CDL, Photo Medcard, Photo SS and Phone", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvDriver.DataSource = conectandose.Consultar(TblName);
            btnDriverAdd.Enabled = false;
            btnDriverUpd.Enabled = true;
            btnDriverDel.Enabled = true;
        }

        private void btnDriverDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnCleanDrivers_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvDriver.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnDriverUpd_Click(object sender, EventArgs e)
        {
            if (!(txtDriverFirstName.Text == "" || pbDriverPhoto.Image == null || pbCDLPhoto.Image == null || pbDriverMedCardPhoto.Image == null || pbDriverSSPhoto.Image == null))
            {
                string paymethod = "";
                try
                {
                    if (rbDriver.Checked == true)
                        LoadDriverState = "0";
                    if (rbOwner.Checked == true)
                        LoadDriverState = "1";
                    for (int count = 0; count < chkDriverPayMetod.Items.Count; count++)
                    {  
                        if (chkDriverPayMetod.GetItemChecked(count) == true)
                        {
                            paymethod = count.ToString();
                            break;
                        }
                    }
                    if (rbActive.Checked == true)
                    {
                        LoadActive = "0";
                        lbactive.Text = "Active";
                    }

                    if (rbNoActive.Checked == true)
                    {
                        LoadActive = "1";
                        lbactive.Text = "No Active";
                    }
                        
                    NpgsqlCommand cmd = new NpgsqlCommand("update driverprofiles set name='" + txtDriverFirstName.Text + "',middlename='" + txtDriverMiddleName.Text + "',lastname='" + txtDriverLastName.Text + "',birthay='" + dtDriverBirthay.Text + "',assignedtruck='" + txtDriverAsignedTruck.Text + "',hiredate='" + dtDriverHire.Text + "',endservicedate='" + dtDriverEndService.Text + "',address='" + txtAddress.Text + "',city='" + txtCity.Text + "',state='" + txtState.Text + "',codezip='" + txtCodeZip.Text + "',homephone='" + txtHomePhone.Text + "',cellphone='" + txtCellPhone.Text + "',cellservice='" + cbCellService.Text + "',email='" + txtEmail.Text + "',emergname='" + txtEName.Text + "',emergaddress='" + txtEAddress.Text + "',emergcity='" + txtECity.Text + "',emergstate='" + txtEState.Text + "',emergzip='" + txtEZip.Text + "',emerghomephone='" + txtEPhone.Text + "',emergcellphone='" + txtECell.Text + "',driverphoto=@driverphoto,loadedparpermile='" + txtDriverLoadedPay.Text + "',emptypaypermile='" + txtDriverEmptyPay.Text + "',percentagepay='" + txtDriverPercentagePay.Text + "',percentof='" + txtDriverPercentageOf.Text + "',tonnagepay='" + txtDriverTonnagePay.Text + "',paybyhours='" + txtDriverPaybyHour.Text + "',paymethod=@paymethod,notes=@notes,cdlnumber='" + txtCDLNumber.Text + "',cdlstate='" + txtCDLState.Text + "',cdlclass='" + txtCDLClass.Text + "',cdlendor='" + txtCDLEndor.Text + "',cdlexpirdate='" + dtCDLExpireDate.Value + "',cdlphoto=@cdlphoto,medcareexpirdate='" + dtMedExpireDate.Value + "',ssnumber='" + txtSSNumber.Text + "',ssphoto=@ssphoto,medcardphoto=@medcardphoto,statusdriver=@statusdriver,flatratepay='" + txtDriverFlatRate.Text + "',activedriver=@activedriver,pickupdroppay='" + txtDriverPDPay.Text + "',vacation='" + txtDriverVacations.Text + "',drivereld='" + txtDriverELD.Text + "',driverezpass='" + txtDriverEZPass.Text + "',driverinsurace='" + txtDriverInsurance.Text + "',driverprepass='" + txtDriverPrePass.Text + "',driverexpense='" + chkExpenses.Checked + "',driverfuel='" + chkFuel.Checked + "',driverfactoryfee='" + txtDriverFactoryFee.Text + "',driverpaymentfee='" + txtDriverPaymentFee.Text + "'" + " where id=" + codigo, conn);


                    MemoryStream ms = new MemoryStream();
                    pbDriverPhoto.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();
                    cmd.Parameters.AddWithValue("driverphoto", aByte);
                    cmd.Parameters.AddWithValue("paymethod", paymethod);
                    cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                    cmd.Parameters.AddWithValue("statusdriver", LoadDriverState);
                    cmd.Parameters.AddWithValue("activedriver", LoadActive);


                    MemoryStream ms2 = new MemoryStream();
                    pbCDLPhoto.Image.Save(ms2, ImageFormat.Jpeg);
                    byte[] abByte = ms2.ToArray();
                    cmd.Parameters.AddWithValue("cdlphoto", abByte);

                    MemoryStream ms3 = new MemoryStream();
                    pbDriverMedCardPhoto.Image.Save(ms3, ImageFormat.Jpeg);
                    byte[] acByte = ms3.ToArray();
                    cmd.Parameters.AddWithValue("medcardphoto", acByte);

                    MemoryStream ms4 = new MemoryStream();
                    pbDriverSSPhoto.Image.Save(ms4, ImageFormat.Jpeg);
                    byte[] adByte = ms4.ToArray();
                    cmd.Parameters.AddWithValue("ssphoto", adByte);
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
                dgvDriver.DataSource = conectandose.Consultar(TblName);
            }
            else MessageBox.Show("Lack data, check that have PHOTO");
        }

        private void btnSelDriverPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbDriverPhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void dtWhDate_ValueChanged(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbDriverPhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void btnSelDriverCDL_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbCDLPhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void btnSelDriverMedCard_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbDriverMedCardPhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void btDriverSSCard_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbDriverSSPhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void btnSelEmployeePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbOfficeEmployeePhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void chkDriverPayMetod_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = chkDriverPayMetod.SelectedIndex;
            if ((chkDriverPayMetod.GetItemChecked(0) == true || chkDriverPayMetod.GetItemChecked(1) == true || chkDriverPayMetod.GetItemChecked(3) == true || chkDriverPayMetod.GetItemChecked(4) == true))
            {

                if (indice != -1)
                {
                    switch (indice)
                    {
                        case 0: //Flat Rate
                            txtDriverFlatRate.Enabled = true;
                            txtDriverLoadedPay.Enabled = false;
                            txtDriverEmptyPay.Enabled = false;
                            txtDriverTonnagePay.Enabled = false;
                            txtDriverPaybyHour.Enabled = false;
                            txtDriverPercentagePay.Enabled = false;
                            chkDriverPayMetod.SetItemChecked(2, false);
                            chkDriverPayMetod.SetItemChecked(1, false);
                            chkDriverPayMetod.SetItemChecked(3, false);
                            chkDriverPayMetod.SetItemChecked(4, false);
                            break;
                        case 1: // Mileage
                            txtDriverFlatRate.Enabled = false;
                            txtDriverLoadedPay.Enabled = true;
                            txtDriverEmptyPay.Enabled = true;
                            txtDriverTonnagePay.Enabled = false;
                            txtDriverPaybyHour.Enabled = false;
                            txtDriverPercentagePay.Enabled = false;
                            chkDriverPayMetod.SetItemChecked(2, false);
                            chkDriverPayMetod.SetItemChecked(0, false);
                            chkDriverPayMetod.SetItemChecked(3, false);
                            chkDriverPayMetod.SetItemChecked(4, false);
                            break;
                        case 2: //Percentage
                            txtDriverFlatRate.Enabled = false;
                            txtDriverLoadedPay.Enabled = false;
                            txtDriverEmptyPay.Enabled = false;
                            txtDriverTonnagePay.Enabled = false;
                            txtDriverPaybyHour.Enabled = false;
                            txtDriverPercentagePay.Enabled = true;
                            chkDriverPayMetod.SetItemChecked(0, false);
                            chkDriverPayMetod.SetItemChecked(1, false);
                            chkDriverPayMetod.SetItemChecked(3, false);
                            chkDriverPayMetod.SetItemChecked(4, false);
                            break;
                        case 3: //Tonnage
                            txtDriverFlatRate.Enabled = false;
                            txtDriverLoadedPay.Enabled = false;
                            txtDriverEmptyPay.Enabled = false;
                            txtDriverTonnagePay.Enabled = true;
                            txtDriverPaybyHour.Enabled = false;
                            txtDriverPercentagePay.Enabled = false;
                            chkDriverPayMetod.SetItemChecked(2, false);
                            chkDriverPayMetod.SetItemChecked(0, false);
                            chkDriverPayMetod.SetItemChecked(1, false);
                            chkDriverPayMetod.SetItemChecked(4, false);
                            break;
                        case 4: //Hourly
                            txtDriverFlatRate.Enabled = false;
                            txtDriverLoadedPay.Enabled = false;
                            txtDriverEmptyPay.Enabled = false;
                            txtDriverTonnagePay.Enabled = false;
                            txtDriverPaybyHour.Enabled = true;
                            txtDriverPercentagePay.Enabled = false;
                            chkDriverPayMetod.SetItemChecked(2, false);
                            chkDriverPayMetod.SetItemChecked(1, false);
                            chkDriverPayMetod.SetItemChecked(3, false);
                            chkDriverPayMetod.SetItemChecked(0, false);
                            break;
                    }
                    
                    txtDriverFlatRate.Text = "0";
                    txtDriverLoadedPay.Text = "0";
                    txtDriverEmptyPay.Text = "0";
                    txtDriverPercentagePay.Text = "0";
                    txtDriverPercentageOf.Text = "0";
                    txtDriverTonnagePay.Text = "0";
                    txtDriverPaybyHour.Text = "0";
                }
            }
            else
            {
                txtDriverFlatRate.Enabled = true;
                txtDriverLoadedPay.Enabled = true;
                txtDriverEmptyPay.Enabled = true;
                txtDriverTonnagePay.Enabled = true;
                txtDriverPaybyHour.Enabled = true;
                txtDriverFlatRate.Text = "0";
                txtDriverLoadedPay.Text = "0";
                txtDriverEmptyPay.Text = "0";
                txtDriverPercentagePay.Text = "87";
                txtDriverPercentageOf.Text = "0";
                txtDriverTonnagePay.Text = "0";
                txtDriverPaybyHour.Text = "0";
            }
        }
        /// <summary>///////////////////////////////////////
        /// EMPLOYEE PROFILES
        /// </summary>//////////////////////////////////////
        ///
        private AutoCompleteStringCollection CargaDatosEmploy()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvEmploy.DataSource = conectandose.ConsultarWith(TblName, txtEmploySearch.Text);
            return datos;
        }

        private void txtEmploySearch_TextChanged(object sender, EventArgs e)
        {
            //Consulta
            string search = (txtEmploySearch.Text).ToUpper();
            if (txtEmploySearch.Text != "")
            {
                dgvEmploy.DataSource = conectandose.ConsultarWith(TblName, search);
            }
        }

        private void dgvEmploy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEmployAdd.Enabled = false;
            btnEmployUpd.Enabled = true;
            btnEmployDel.Enabled = true;

            codigo = Convert.ToInt32(dgvEmploy.Rows[e.RowIndex].Cells[0].Value);

            conn.Open();
            string query = "select employeephoto from " + TblName + " where id = " + codigo;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "img");

            byte[] datos = new byte[0];
            DataRow dr = ds.Tables["img"].Rows[0];
            datos = (byte[])dr["employeephoto"];
            MemoryStream ms = new MemoryStream(datos);
            pbOfficeEmployeePhoto.Image = System.Drawing.Bitmap.FromStream(ms);
            conn.Close();

            txtOfficeFirstName.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[1].Value);
            txtOfficeMiddleName.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[2].Value);
            txtOfficeLastName.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[3].Value);
            dtOfficeBirthay.Value = Convert.ToDateTime(dgvEmploy.Rows[e.RowIndex].Cells[4].Value);
            txtOfficeSS.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[5].Value);
            txtOfficeWorkFinal.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[6].Value);
            dtOfficeHireDate.Value = Convert.ToDateTime(dgvEmploy.Rows[e.RowIndex].Cells[7].Value);
            dtOfficeEndServiceDate.Value = Convert.ToDateTime(dgvEmploy.Rows[e.RowIndex].Cells[8].Value);
            txtOfficeNotes.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[9].Value);
            txtOfficeEmailSignature.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[10].Value);

            txtOfficeAddress.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[11].Value);
            txtOfficeCity.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[12].Value);
            txtOfficeState.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[13].Value);
            txtOfficeZip.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[14].Value);
            txtOfficeHomePhone.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[15].Value);
            txtOfficeCellPhone.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[16].Value);
            txtOfficeEmail.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[17].Value);

            txtOfficeEName.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[18].Value);
            txtOfficeEAddress.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[19].Value);
            txtOfficeECity.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[20].Value);
            txtOfficeEState.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[21].Value);
            txtOfficeEZip.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[22].Value);
            txtOfficeEHomePhone.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[23].Value);
            txtOfficeECellPhone.Text = Convert.ToString(dgvEmploy.Rows[e.RowIndex].Cells[24].Value);
        }

        private void btnEmployClear_Click(object sender, EventArgs e)
        {
            txtOfficeFirstName.Text = "";
            txtOfficeMiddleName.Text = "";
            txtOfficeLastName.Text = "";
            dtOfficeBirthay.Text = "";
            txtOfficeSS.Text = "";
            txtOfficeWorkFinal.Text = "";
            dtOfficeHireDate.Text = "";
            dtOfficeEndServiceDate.Text = "";
            txtOfficeNotes.Text = "";
            txtOfficeEmailSignature.Text = "";

            txtOfficeAddress.Text = "";
            txtOfficeCity.Text = "";
            txtOfficeState.Text = "";
            txtOfficeZip.Text = "";
            txtOfficeHomePhone.Text = "";
            txtOfficeCellPhone.Text = "";
            txtOfficeEmail.Text = "";

            txtOfficeEName.Text = "";
            txtOfficeEAddress.Text = "";
            txtOfficeECity.Text = "";
            txtOfficeEState.Text = "";
            txtOfficeEZip.Text = "";
            txtOfficeEHomePhone.Text = "";
            txtOfficeECellPhone.Text = "";
            txtEmploySearch.Text = "";
            pbOfficeEmployeePhoto.Image = null;

            btnEmployAdd.Enabled = true;
            btnEmployUpd.Enabled = false;
            btnEmployDel.Enabled = false;

        }

        private void btnEmployAdd_Click(object sender, EventArgs e)
        {
            if (txtOfficeFirstName.Text != "" && txtOfficeLastName.Text !="" && pbOfficeEmployeePhoto.Image != null && txtOfficeAddress.Text !="" && txtOfficeHomePhone.Text !="")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into employeeprofile (firstname,middlename,lastname,birthay,ss,workfinal,hiredate,endservicedate,notes,emailsignature,address,city,state,zip,homephone,cellphone,email,ename,eaddress,ecity,estate,ezip,ehomephone,ecellphone,employeephoto) values ('" + txtOfficeFirstName.Text + "','" + txtOfficeMiddleName.Text + "','" + txtOfficeLastName.Text + "','" + dtOfficeBirthay.Value + "','" + txtOfficeSS.Text + "','" + txtOfficeWorkFinal.Text + "','" + dtOfficeHireDate.Value + "','" + dtOfficeEndServiceDate.Value + "',@notes,'" + txtOfficeEmailSignature.Text + "','" + txtOfficeAddress.Text + "','" + txtOfficeCity.Text + "','" + txtOfficeState.Text + "','" + txtOfficeZip.Text + "','" + txtOfficeHomePhone.Text + "','" + txtOfficeCellPhone.Text + "','" + txtOfficeEmail.Text + "','" + txtOfficeEName.Text + "','" + txtOfficeEAddress.Text + "','" + txtOfficeECity.Text + "','" + txtOfficeEState.Text + "','" + txtOfficeEZip.Text + "','" + txtOfficeEHomePhone.Text + "','" + txtOfficeECellPhone.Text + "',@photo)", conn);


                    MemoryStream ms = new MemoryStream();
                    pbOfficeEmployeePhoto.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();
                    cmd.Parameters.AddWithValue("photo", aByte);
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
            else MessageBox.Show("Lack data, check that have:\nFirst & Last Name, Address and Phone and Photo", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvEmploy.DataSource = conectandose.Consultar(TblName);
            btnEmployAdd.Enabled = false;
            btnEmployUpd.Enabled = true;
            btnEmployDel.Enabled = true;
        }

        private void btnEmployDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnEmployClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvEmploy.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnEmployUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update employeeprofile set firstname='" + txtOfficeFirstName.Text + "',middlename='" + txtOfficeMiddleName.Text + "',lastname='" + txtOfficeLastName.Text + "',birthay='" + dtOfficeBirthay.Value + "',ss='" + txtOfficeSS.Text + "',workfinal='" + txtOfficeWorkFinal.Text + "',hiredate='" + dtOfficeHireDate.Value + "',endservicedate='" + dtOfficeEndServiceDate.Value + "',notes=@notes,emailsignature='" + txtOfficeEmailSignature.Text + "',address='" + txtOfficeAddress.Text + "',city='" + txtOfficeCity.Text + "',state='" + txtOfficeState.Text + "',zip='" + txtOfficeZip.Text + "',homephone='" + txtOfficeHomePhone.Text + "',cellphone='" + txtOfficeCellPhone.Text + "',email='" + txtOfficeEmail.Text + "',eaddress='" + txtOfficeEAddress.Text + "',ecity='" + txtOfficeECity.Text + "',estate='" + txtOfficeEState.Text + "',ezip='" + txtOfficeEZip.Text + "',ehomephone='" + txtOfficeEHomePhone.Text + "',ecellphone='" + txtOfficeECellPhone.Text + "',employeephoto=@photo" + " where id=" + codigo, conn);


                MemoryStream ms = new MemoryStream();
                pbOfficeEmployeePhoto.Image.Save(ms, ImageFormat.Jpeg);
                byte[] aByte = ms.ToArray();
                cmd.Parameters.AddWithValue("photo", aByte);
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
            dgvEmploy.DataSource = conectandose.Consultar(TblName);
        }

        /// <summary>///////////////////////////////////////
        /// EMAIL SETTINGS
        /// </summary>//////////////////////////////////////
        ///
        private AutoCompleteStringCollection CargaDatosEmail()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvEmail.DataSource = conectandose.ConsultarWith(TblName, txtEmailSearch.Text);
            return datos;
        }
        private void txtEmailSearch_TextChanged(object sender, EventArgs e)
        {
            //Consulta
            if (txtEmailSearch.Text != "")
            {
                txtEmailSearch.AutoCompleteCustomSource = CargaDatosEmail();
                txtEmailSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtEmailSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                dgvEmail.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void dgvEmail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEmailAdd.Enabled = false;
            btnEmailDel.Enabled = true;
            btnEmailUpd.Enabled = true;

            codigo = Convert.ToInt32(dgvEmail.Rows[e.RowIndex].Cells[0].Value);

            txtEmailUser.Text = Convert.ToString(dgvEmail.Rows[e.RowIndex].Cells[1].Value);
            txtEmailPassw.Text = Convert.ToString(dgvEmail.Rows[e.RowIndex].Cells[2].Value);
            txtEmailPort.Text = Convert.ToString(dgvEmail.Rows[e.RowIndex].Cells[3].Value);
            if (Convert.ToString(dgvEmail.Rows[e.RowIndex].Cells[4].Value) == "True")
                chkEmailDefault.Checked = true;
            else chkEmailDefault.Checked = false;
            txtEmailSmtp.Text = Convert.ToString(dgvEmail.Rows[e.RowIndex].Cells[5].Value);
            cbEmailSecurity.Text = Convert.ToString(dgvEmail.Rows[e.RowIndex].Cells[6].Value);

            btnEmailAdd.Enabled = false;
            btnEmailDel.Enabled = true;
            btnEmailUpd.Enabled = true;
        }

        private void btnEmailClear_Click(object sender, EventArgs e)
        {
            txtEmailUser.Text = "";
            txtEmailPassw.Text = "";
            txtEmailSmtp.Text = "";
            txtEmailPort.Text = "";
            cbEmailSecurity.Text = "";
            chkEmailDefault.Checked = false; ;
            txtEmailSearch.Text = "";
        }

        private void btnEmailAdd_Click(object sender, EventArgs e)
        {
            if (txtEmailUser.Text != "" && txtEmailPassw.Text !="" && txtEmailSmtp.Text !="")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into emailsettings (nombre,clave,port,principal,smtp,ssl) values ('" + txtEmailUser.Text + "','" + txtEmailPassw.Text + "','" + txtEmailPort.Text + "','" + chkEmailDefault.Checked + "','" + txtEmailSmtp.Text + "','" + cbEmailSecurity.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert correct");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nUser, Password, SMTP", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvEmail.DataSource = conectandose.Consultar(TblName);
            btnEmailAdd.Enabled = false;
            btnEmailDel.Enabled = true;
            btnEmailUpd.Enabled = true;
        }

        private void btnEmailDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnEmailClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvEmail.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnEmailUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update emailsettings set nombre='" + txtEmailUser.Text + "',clave='" + txtEmailPassw.Text + "',port='" + txtEmailPort.Text + "',principal='" + chkEmailDefault.Checked + "',smtp='" + txtEmailSmtp.Text + "',ssl='" + cbEmailSecurity.Text + "'" + " where id=" + codigo, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correct");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            dgvEmail.DataSource = conectandose.Consultar(TblName);
        }

        private void btnEmailDriver_Click(object sender, EventArgs e)
        {
            frmMail nuevomail = new frmMail(txtEmail.Text,"");
            nuevomail.ShowDialog();
        }

        private void btnOfficeEmail_Click(object sender, EventArgs e)
        {
            frmMail nuevomail = new frmMail(txtOfficeEmail.Text, "");
            nuevomail.ShowDialog();
        }

        private void cbEmailPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbEmailSecurity.Text)
            {
                case "Apagado":
                    txtEmailPort.Text = "25";
                    break;
                case "SSL":
                    txtEmailPort.Text = "465";
                    break;
                case "TSL":
                    txtEmailPort.Text = "587";
                    break;
            }
        }

        private void txtEmailUser_Leave(object sender, EventArgs e)
        {
            int largo = txtEmailUser.Text.Length;
            int indice = txtEmailUser.Text.IndexOf('@') + 1;
            string subcadena = txtEmailUser.Text.Substring(indice, largo - indice);
            txtEmailSmtp.Text = "smtp." + subcadena;
        }

        /// <summary>///////////////////////////////////////
        /// FAX SETTINGS
        /// </summary>//////////////////////////////////////
        ///
        private AutoCompleteStringCollection CargaDatosFax()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvFax.DataSource = conectandose.ConsultarWith(TblName, txtFaxSearch.Text);
            return datos;
        }

        private void txtFaxSearch_TextChanged(object sender, EventArgs e)
        {
            //Consulta
            if (txtFaxSearch.Text != "")
            {
                txtFaxSearch.AutoCompleteCustomSource = CargaDatosFax();
                txtFaxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtFaxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                dgvFax.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void dgvFax_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnFaxAdd.Enabled = false;
            btnFaxDel.Enabled = true;
            btnFaxUpd.Enabled = true;

            codigo = Convert.ToInt32(dgvFax.Rows[e.RowIndex].Cells[0].Value);

            txtFaxName.Text = Convert.ToString(dgvFax.Rows[e.RowIndex].Cells[1].Value);
            txtFaxServiceCode.Text = Convert.ToString(dgvFax.Rows[e.RowIndex].Cells[2].Value);
        }

        private void btnFaxClear_Click(object sender, EventArgs e)
        {
            txtFaxName.Text = "";
            txtFaxServiceCode.Text = "";
            txtFaxSearch.Text = "";

            btnFaxAdd.Enabled = true;
            btnFaxDel.Enabled = false;
            btnFaxUpd.Enabled = false;
        }

        private void btnFaxAdd_Click(object sender, EventArgs e)
        {
            if (txtFaxName.Text != "" && txtFaxServiceCode.Text !="")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into faxsetting (name,servicecode) values ('" + txtFaxName.Text + "','" + txtFaxServiceCode.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert correct");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nFax Name and Fax Code", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvFax.DataSource = conectandose.Consultar(TblName);
            btnFaxAdd.Enabled = false;
            btnFaxDel.Enabled = true;
            btnFaxUpd.Enabled = true;
        }

        private void btnFaxDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnEmployClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvFax.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnFaxUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update faxsetting set name='" + txtFaxName.Text + "',servicecode='" + txtFaxServiceCode.Text + "'" + " where id=" + codigo, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correct");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            dgvFax.DataSource = conectandose.Consultar(TblName);
        }
        /// <summary>//////////////////////////////////////////////
        /// GENERALES
        /// </summary>/////////////////////////////////////////////
        /// 
        /// 
        private void btnFinfCSZ_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("codezips","");
            search.ShowDialog();
            txtCompanyCity.Text = search.Nombre;
            txtCompanyState.Text = search.Estado;
            txtCompanyZip.Text = search.Zip;
        }

        private void btnDriverFindCSZ_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("codezips","");
            search.ShowDialog();
            txtECity.Text = search.Nombre;
            txtEState.Text = search.Estado;
            txtEZip.Text = search.Zip;
        }

        private void btnDCFindCSZ_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("codezips","");
            search.ShowDialog();
            txtCity.Text = search.Nombre;
            txtState.Text = search.Estado;
            txtCodeZip.Text = search.Zip;
        }

        private void btnDCFindCSZ_MouseHover(object sender, EventArgs e)
        {
            lblDCCSZ.Visible = true;
        }

        private void btnDCFindCSZ_MouseLeave(object sender, EventArgs e)
        {
            lblDCCSZ.Visible = false;
        }

        private void btnPrintUtilities_Click(object sender, EventArgs e)
        {
            frmPrintUtilities utilities = new frmPrintUtilities();
            utilities.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            txtCompanyName.Text = (txtCompanyName.Text).ToUpper();
        }

        private void txtCompanyOwner_Leave(object sender, EventArgs e)
        {
            txtCompanyOwner.Text = (txtCompanyOwner.Text).ToUpper();
        }

        private void txtCompanyAddress_Leave(object sender, EventArgs e)
        {
            txtCompanyAddress.Text = (txtCompanyAddress.Text).ToUpper();
        }

        private void txtDriverFirstName_Leave(object sender, EventArgs e)
        {
            txtDriverFirstName.Text = (txtDriverFirstName.Text).ToUpper();
        }

        private void txtDriverMiddleName_Leave(object sender, EventArgs e)
        {
            txtDriverMiddleName.Text = (txtDriverMiddleName.Text).ToUpper();
        }

        private void txtDriverLastName_Leave(object sender, EventArgs e)
        {
            txtDriverLastName.Text = (txtDriverLastName.Text).ToUpper();
        }

        private void txtCompanySearch_TextChanged_1(object sender, EventArgs e)
        {
            //Consulta
            string search = (txtCompanySearch.Text).ToUpper();
            if (txtCompanySearch.Text != "")
            {
                dgvConsulta.DataSource = conectandose.ConsultarWith(TblName, search);
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpUtilities helpUtilities = new frmHelpUtilities();
            helpUtilities.Show();
        }

        private void txtCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnFinfCSZ_MouseHover(object sender, EventArgs e)
        {
            lblCSZ.Visible = true;
        }

        private void btnFinfCSZ_MouseLeave(object sender, EventArgs e)
        {
            lblCSZ.Visible = false;
        }

        private void txtDriverFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

       
    }
}
