using Npgsql;
using Perfect_Freight_Manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.AlertsIncidences
{
    public partial class Incidencias : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        string TblName = "driverprofiles";
        int codigo, sgtedriver=0;
        public Incidencias(string first, string last)
        {
            InitializeComponent();
            dgvDriver.DataSource = conectandose.ConsultarIncidence(TblName,first,last);
            driverName.Text = first + " " + last;
            codigo = Convert.ToInt32(dgvDriver.Rows[sgtedriver].Cells[0].Value);
            
            conn.Open();
            string query = "select driverphoto, cdlphoto, medcardphoto, ssphoto from " + TblName + " where id = " + codigo;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "img");

            byte[] datos = new byte[0];
            DataRow dr = ds.Tables["img"].Rows[0];

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

            txtEmail.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[15].Value);
            txtCDLNumber.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[32].Value);
            txtCDLState.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[33].Value);
            txtCDLClass.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[34].Value);
            txtCDLEndor.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[35].Value);
            dtCDLExpireDate.Value = Convert.ToDateTime(dgvDriver.Rows[sgtedriver].Cells[36].Value);
            dtMedExpireDate.Value = Convert.ToDateTime(dgvDriver.Rows[sgtedriver].Cells[38].Value);
            txtSSNumber.Text = Convert.ToString(dgvDriver.Rows[sgtedriver].Cells[39].Value);
        }

        private void btnDriverUpd_Click(object sender, EventArgs e)
        {
            if (!(pbCDLPhoto.Image == null || pbDriverMedCardPhoto.Image == null || pbDriverSSPhoto.Image == null))
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("update driverprofiles set email='" + txtEmail.Text + "',cdlnumber='" + txtCDLNumber.Text + "',cdlstate='" + txtCDLState.Text + "',cdlclass='" + txtCDLClass.Text + "',cdlendor='" + txtCDLEndor.Text + "',cdlexpirdate='" + dtCDLExpireDate.Value + "',cdlphoto=@cdlphoto,medcareexpirdate='" + dtMedExpireDate.Value + "',ssnumber='" + txtSSNumber.Text + "',ssphoto=@ssphoto,medcardphoto=@medcardphoto" + " where id=" + codigo, conn);

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
                //dgvDriver.DataSource = conectandose.Consultar(TblName);
            }
            else MessageBox.Show("Lack data, check that have PHOTO");
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

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
