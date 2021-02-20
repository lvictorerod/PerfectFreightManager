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

namespace Perfect_Freight_Manager.Forms.AlertsIncidences
{
    public partial class AlertsTrailer : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string TblName = "trailersprofiles";
        int codigo;
        private int sgtetl = 0;
        public AlertsTrailer(string Trailer)
        {
            InitializeComponent();

            dgvTrailers.DataSource = conectandose.ConsultarTrailers(TblName,Trailer);
            codigo = Convert.ToInt32(dgvTrailers.Rows[sgtetl].Cells[0].Value);

            conn.Open();
            string query = "select photo from " + TblName + " where id = " + codigo;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "img");

            byte[] datos = new byte[0];
            DataRow dr = ds.Tables["img"].Rows[0];
            datos = (byte[])dr["photo"];
            MemoryStream ms = new MemoryStream(datos);
            pbTrailerPhoto.Image = System.Drawing.Bitmap.FromStream(ms);
            conn.Close();

            txtTrailerOwner.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[1].Value);
            txtTrailerId.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[2].Value);
            txtTrailerVin.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[3].Value);
            txtTrailerTag.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[4].Value);
            txtTrailerPmMileage.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[5].Value);

            txtTrailerYear.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[6].Value);
            txtTrailerMake.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[7].Value);
            txtTrailerModel.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[8].Value);
            txtTrailerColor.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[9].Value);
            txtTrailerTire.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[10].Value);
            txtTrailerAxles.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[11].Value);
            txtTrailerNotes.Text = Convert.ToString(dgvTrailers.Rows[sgtetl].Cells[12].Value);
            dtLicenseTrailer.Value = Convert.ToDateTime(dgvTrailers.Rows[sgtetl].Cells[14].Value);
            dtLicenseExpireTrailer.Value = Convert.ToDateTime(dgvTrailers.Rows[sgtetl].Cells[15].Value);
        }

        private void btnUpdTrailer_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update trailersprofiles set licensedate='" + dtLicenseTrailer.Value + "',licensedateexpire='" + dtLicenseExpireTrailer.Value + "'" + " where id=" + codigo, conn);
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
