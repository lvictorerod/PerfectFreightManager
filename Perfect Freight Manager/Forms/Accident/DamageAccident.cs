using Npgsql;
using Perfect_Freight_Manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Accident
{
    public partial class DamageAccident : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        string TblName = "registeraccidents";
        private int codigo = 0, cuentareg = 0, cuentadoc = 0;
        private int sgte = 0, cuenta = 0;
        private bool initdocument = false;
        private string ruta;
        private int codigoDocuments;
        private int codigoReg;
        private string raiz = "";
        public DamageAccident()
        {
            InitializeComponent();
            string cadena2 = "select * from adminsystems";

            conn2.Open();
            NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
            NpgsqlDataReader dr2 = comando2.ExecuteReader();
            while (dr2.Read())
            {
                raiz = dr2["rphotodoc"].ToString();
            }
            conn2.Close();

            btnRegDel.Enabled = false;
            btnRegUpd.Enabled = false;
            btnRegAdd.Enabled = true;

            btnRegFirst.Enabled = false;
            btnRegPrevios.Enabled = false;
            btnRegNext.Enabled = false;
            btnRegEnd.Enabled = false;

            btnAddAttachment.Enabled = false;
            btnUpdAttachment.Enabled = false;
            btnDelAttacment.Enabled = false;
            btnOpen.Enabled = true;

            dgvReg.DataSource = conectandose.Consultar(TblName);
            cuentareg = dgvReg.Rows.GetRowCount(0);
            lbRecord.Text = "Record " + (sgte) + " of  " + cuentareg;
            if (cuentareg != 0)
            {
                btnRegFirst.Enabled = true;
                btnRegPrevios.Enabled = true;
                btnRegNext.Enabled = true;
                btnRegEnd.Enabled = true;
            }
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCarrier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtCarrier_Leave(object sender, EventArgs e)
        {
            txtRegCarrier.Text = (txtRegCarrier.Text).ToUpper();
        }

        private void txtDriver_Leave(object sender, EventArgs e)
        {
            txtRegDriver.Text = (txtRegDriver.Text).ToUpper();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabRegister")
            {
                TblName = "registeraccidents";
                cuentareg = dgvReg.Rows.GetLastRow(0);
                if (cuentareg != 0)
                {
                    btnRegFirst.Enabled = true;
                    btnRegPrevios.Enabled = true;
                    btnRegNext.Enabled = true;
                    btnRegEnd.Enabled = true;
                }
                dgvReg.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tabDocuments")
            {
                lbDocuments.Text = txtIDReg.Text;
                TblName = "docregisters";
                if (!(txtIDReg.Text == ""))
                    dgvDocuments.DataSource = conectandose.ConsultarRegister(TblName, txtIDReg.Text);
                if (!initdocument)
                {
                    string pdfDoc = raiz + @"Documents\Contact_us.pdf";
                    if (pdfDoc == raiz + @"Documents\Contact_us.pdf")
                    {
                        axAcroPDF1.src = pdfDoc;
                    }
                    initdocument = true;
                }
            }
        }

        /// <summary>
        /// Register
        /// </summary>
        ////////////////////////////
        private void btnClearReg_Click(object sender, EventArgs e)
        {
            txtIDReg.Text = "";
            txtRegCarrier.Text = "";
            txtRegFileNumber.Text = "";
            txtRegVehicleNumber.Text = "";
            txtRegDriver.Text = "";
            dtRegFrom.Text = "";
            dtRegTo.Text = "";
            dtRegFechaAccident.Text = "";
            txtRegLocation.Text = "";
            txtRegInjurence.Text = "0";
            txtRegFatalities.Text = "0";
            txtRegDollars.Text = "0";
            txtRegHazardous.Text = "";

            btnRegDel.Enabled = false;
            btnRegUpd.Enabled = false;
            btnRegAdd.Enabled = true;
        }

        private void btnRegFirst_Click(object sender, EventArgs e)
        {
            cuenta = dgvReg.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvReg.Rows.GetFirstRow(0);
                dgvReg_RowEnter(sender, e);
                rellena();
            }
        }

        private void btnRegPrevios_Click(object sender, EventArgs e)
        {
            cuenta = dgvReg.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvReg.Rows.GetPreviousRow(sgte, 0);
                if (sgte == -1) sgte = cuenta - 1;
                if (sgte <= cuenta && sgte >= 0)
                {
                    dgvReg_RowEnter(sender, e);
                    rellena();
                }
            }
        }
        private void btnRegNext_Click(object sender, EventArgs e)
        {
                cuenta = dgvReg.Rows.GetRowCount(0);
                if (cuenta != 0)
                {
                    sgte = dgvReg.Rows.GetNextRow(sgte, 0);
                    if (sgte == -1) sgte = 0;
                    if (sgte <= cuenta && sgte >= 0)
                    {
                        dgvReg_RowEnter(sender, e);
                        rellena();
                    }
                }
        }
        private void btnRegEnd_Click(object sender, EventArgs e)
        {
            cuenta = dgvReg.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvReg.Rows.GetLastRow(0);
                dgvReg_RowEnter(sender, e);
                rellena();
            }
        }

        private void dgvReg_RowEnter(object sender, EventArgs e)
        {
            dgvReg.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvReg.Rows[sgte].Selected = true;
            dgvReg.FirstDisplayedScrollingRowIndex = dgvReg.Rows.GetNextRow(sgte - 1, 0);
        }
        private void rellena()
        {
            btnRegAdd.Enabled = false;
            btnRegUpd.Enabled = true;
            btnRegDel.Enabled = true;

            codigoReg = Convert.ToInt32(dgvReg.Rows[sgte].Cells[0].Value);

            txtIDReg.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[1].Value);
            txtRegCarrier.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[2].Value);
            txtRegFileNumber.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[3].Value);
            txtRegVehicleNumber.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[4].Value);
            txtRegDriver.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[5].Value);
            dtRegFrom.Value = Convert.ToDateTime(dgvReg.Rows[sgte].Cells[6].Value);
            dtRegTo.Value = Convert.ToDateTime(dgvReg.Rows[sgte].Cells[7].Value);
            dtRegFechaAccident.Value = Convert.ToDateTime(dgvReg.Rows[sgte].Cells[8].Value);
            txtRegLocation.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[9].Value);
            txtRegInjurence.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[10].Value);
            txtRegFatalities.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[11].Value);
            txtRegDollars.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[12].Value);
            txtRegHazardous.Text = Convert.ToString(dgvReg.Rows[sgte].Cells[13].Value);

            lbRecord.Text = "Record " + (sgte + 1) + " of  " + cuenta;

            btnRegDel.Enabled = true;
            btnRegUpd.Enabled = true;
            btnRegAdd.Enabled = false;
        }

        private void btnRegAdd_Click(object sender, EventArgs e)
        {
            if (txtIDReg.Text != "" && txtRegCarrier.Text != "")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into registeraccidents (idreg, regcarrier, regfilenumber, regvehiclenumber, regdriver, regfechafrom, regfechato, regfechaaccident, reglocation, reginjurence, regfatalities, regdollars, reghazardous) values ('" + txtIDReg.Text + "','" + txtRegCarrier.Text + "','" + txtRegFileNumber.Text + "', '" + txtRegVehicleNumber.Text + "','" + 
                        txtRegDriver.Text + "', '" + dtRegFrom.Value + "','" + dtRegTo.Value + "','" + dtRegFechaAccident.Value + "','" + txtRegLocation.Text + "','" + txtRegInjurence.Text + "','" + txtRegFatalities.Text + "','" + txtRegDollars.Text + "','" + txtRegHazardous.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert Correct", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nIDRegister, Register Carrier", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvReg.DataSource = conectandose.Consultar(TblName);

            btnRegDel.Enabled = true;
            btnRegUpd.Enabled = true;
            btnRegAdd.Enabled = false;

            btnRegFirst.Enabled = true;
            btnRegPrevios.Enabled = true;
            btnRegNext.Enabled = true;
            btnRegEnd.Enabled = true;
        }
        private void btnRegDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoReg);
                    btnClearReg_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvReg.DataSource = conectandose.Consultar(TblName);
            }
        }
        private void btnRegUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update registeraccidents set idreg='" + txtIDReg.Text + "',regcarrier='" + txtRegCarrier.Text + "',regfilenumber='" + txtRegFileNumber.Text + "',regvehiclenumber='" + txtRegVehicleNumber.Text + "',regdriver= '" + txtRegDriver.Text + "', regfechafrom = '" + dtRegFrom.Value + "', regfechato = '" + dtRegTo.Value + "', regfechaaccident = '" + dtRegFechaAccident.Value + "', reglocation= '" + txtRegLocation.Text + "', reginjurence= '" + txtRegInjurence.Text + "',regdollars='" + txtRegDollars.Text + "',reghazardous='" + txtRegHazardous.Text + "'" + " where id=" + codigoReg, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update Correct", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvReg.DataSource = conectandose.Consultar(TblName);
        }

        private void btnRegReports_Click(object sender, EventArgs e)
        {

        }

        /////////////////////////////////
        ///Documents
        /////////////////////////////////
        /////////////////////////////////
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            fd.Filter = "Documents PDF |*.pdf; ";
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            fd.Title = "Seleccionar Document";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ruta = fd.FileName;
                    axAcroPDF1.src = fd.FileName;
                    btnAddAttachment.Enabled = true;
                    btnUpdAttachment.Enabled = false;
                    btnDelAttacment.Enabled = false;
                    btnOpen.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "PerfectFreight PdfViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && dtAnnotation.Value != null)
            {
                //Convirtiendo PDF a binario
                FileStream path = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                byte[] binario = new byte[path.Length];
                path.Read(binario, 0, (int)path.Length);
                path.Close();
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into docregisters (idreg,date,description,document,name) values ('" + lbDocuments.Text + "','" + dtAnnotation.Value + "','" + txtDescription.Text + "','" + axAcroPDF1.src + "','" + txtName.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nName, Date", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvDocuments.DataSource = conectandose.ConsultarRevenue(TblName, lbDocuments.Text);
            btnAddAttachment.Enabled = false;
            btnUpdAttachment.Enabled = true;
            btnDelAttacment.Enabled = true;
            btnOpen.Enabled = true;
        }

        private void txtIDReg_Leave(object sender, EventArgs e)
        {
            txtIDReg.Text = (txtIDReg.Text).ToUpper();
        }

        private void txtRegFileNumber_Leave(object sender, EventArgs e)
        {
            txtRegFileNumber.Text = (txtRegFileNumber.Text).ToUpper();
        }

        private void btnDelAttacment_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoDocuments);
                    btnCleanDocuments_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvDocuments.DataSource = conectandose.ConsultarRevenue(TblName, lbDocuments.Text);
            }
        }
        private void btnUpdAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update docregisters set idrevenue='" + lbDocuments.Text + "',date='" + dtAnnotation.Value + "', description='" + txtDescription.Text + "',name='" + txtName.Text + "',document='" + axAcroPDF1.src + "'" + " where id=" + codigoDocuments, conn);
                //cmd.Parameters.AddWithValue("document", axAcroPDF1.src);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvDocuments.DataSource = conectandose.ConsultarRevenue(TblName, lbDocuments.Text);
        }

        private void btnCleanDocuments_Click(object sender, EventArgs e)
        {

            txtName.Text = "";
            dtAnnotation.Text = "";
            txtDescription.Text = "";

            string pdfDoc = raiz + @"Documents\Contact_us.pdf";
            if (pdfDoc == raiz + @"Documents\Contact_us.pdf")
            {
                axAcroPDF1.src = pdfDoc;
            }
            initdocument = true;

            btnAddAttachment.Enabled = false;
            btnUpdAttachment.Enabled = false;
            btnDelAttacment.Enabled = false;
            btnOpen.Enabled = true;
        }

    }
}
