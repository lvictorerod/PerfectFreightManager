using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Perfect_Freight_Manager.Forms.Catalogs;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Models;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms
{
    public partial class UserControlTruck : UserControl
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string TblName = "trucksprofiles";
        int codigo;
        public UserControlTruck()
        {
            InitializeComponent();
            btnDelTruck.Enabled = false;
            btnUpdTruck.Enabled = false;
            btnDelTrailer.Enabled = false;
            btnUpdTrailer.Enabled = false;

            dgvTrucks.DataSource = conectandose.Consultar(TblName);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabTrucs")
            {
                TblName = "trucksprofiles";
                dgvTrucks.DataSource = conectandose.Consultar(TblName);
                //MessageBox.Show("Estoy en Company Profile");
            }
            if (tabControl1.SelectedTab.Name == "tabTrailers")
            {
                TblName = "trailersprofiles";
                dgvTrailers.DataSource = conectandose.Consultar(TblName);
                //MessageBox.Show("Estoy en Driver Profile");
            }
        }
        /// <summary>//////////////////////////////////////
        /// TRUCKS PROFILES
        /// </summary>/////////////////////////////////////
        ///
        private AutoCompleteStringCollection CargaDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvTrucks.DataSource = conectandose.Consultar(TblName, txtSearchTruck.Text);
            return datos;
        }

        private void txtSearchTruck_TextChanged(object sender, EventArgs e)
        {
            //Consulta
            if (txtSearchTruck.Text != "")
            {
                txtSearchTruck.AutoCompleteCustomSource = CargaDatos();
                txtSearchTruck.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtSearchTruck.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                dgvTrucks.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void dgvTrucks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddTruck.Enabled = false;
            btnUpdTruck.Enabled = true;
            btnDelTruck.Enabled = true;

            codigo = Convert.ToInt32(dgvTrucks.Rows[e.RowIndex].Cells[0].Value);

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
            pbTruckPhoto.Image = System.Drawing.Bitmap.FromStream(ms);
            conn.Close();


            txtTruckCompany.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[1].Value);
            txtTruckOwner.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[2].Value);
            txtTruckNumber.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[3].Value);
            txtTruckVin.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[4].Value);
            txtTruckYear.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[5].Value);
            txtTruckMake.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[6].Value);
            txtTruckModel.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[7].Value);
            txtTruckTag.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[8].Value);
            txtTruckPmMileage.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[9].Value);
            txtTruckColor.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[10].Value);

            txtTruckTire.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[11].Value);
            txtTruckAxles.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[12].Value);
            txtTruckEngineMake.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[13].Value);
            txtTruckEnginePower.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[14].Value);
            txtTruckEngineSn.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[15].Value);
            txtTruckTranspType.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[16].Value);
            txtTruckEmptyWgt.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[17].Value);
            txtTruckFuelTank.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[18].Value);
            txtTruckNotes.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[19].Value);
        }

        private void btnCleanTruck_Click(object sender, EventArgs e)
        {
            txtTruckCompany.Text = "";
            txtTruckOwner.Text = "";
            txtTruckNumber.Text = "";
            txtTruckVin.Text = "";
            txtTruckYear.Text = "";
            txtTruckMake.Text = "";
            txtTruckModel.Text = "";
            txtTruckTag.Text = "";
            txtTruckPmMileage.Text = "";
            txtTruckColor.Text = "";

            txtTruckTire.Text = "";
            txtTruckAxles.Text = "";
            txtTruckEngineMake.Text = "";
            txtTruckEnginePower.Text = "";
            txtTruckEngineSn.Text = "";
            txtTruckTranspType.Text = "";
            txtTruckEmptyWgt.Text = "";
            txtTruckFuelTank.Text = "";
            txtTruckNotes.Text = "";
            txtSearchTruck.Text = "";
            pbTruckPhoto.Image = null;

            btnAddTruck.Enabled = true;
            btnUpdTruck.Enabled = false;
            btnDelTruck.Enabled = false;
        }

        private void btnSelPhotoTruck_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbTruckPhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void btnAddTruck_Click(object sender, EventArgs e)
        {
            if (!(txtTruckCompany.Text == "" || pbTruckPhoto.Image == null))
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into trucksprofiles (name,ownername,trucknumber,vinnumber,year,make,model,tag,pmmileage,truckcolor,tiresize,axles,                    enginemake,enginepower,enginesn,transtype,emptywgt,fueltank,notes,photo) values ('" + txtTruckCompany.Text + "','" + txtTruckOwner.Text + "','" + txtTruckNumber.Text + "','" + txtTruckVin.Text + "','" + txtTruckYear.Text + "','" + txtTruckMake.Text + "','" + txtTruckModel.Text + "','" + txtTruckTag.Text + "','" + txtTruckPmMileage.Text + "','" + txtTruckColor.Text + "','" + txtTruckTire.Text + "','" + txtTruckAxles.Text + "','" + txtTruckEngineMake.Text + "','" + txtTruckEnginePower.Text + "','" + txtTruckEngineSn.Text + "','" + txtTruckTranspType.Text + "','" + txtTruckEmptyWgt.Text + "','" + txtTruckFuelTank.Text + "',@notes, @photo)", conn);
                    MemoryStream ms = new MemoryStream();
                    pbTruckPhoto.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();
                    cmd.Parameters.AddWithValue("photo", aByte);
                    cmd.Parameters.AddWithValue("notes", txtTruckNotes.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Datos guardados");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }

                dgvTrucks.DataSource = conectandose.Consultar(TblName);
                btnAddTruck.Enabled = false;
                btnUpdTruck.Enabled = true;
                btnDelTruck.Enabled = true;
            }
            else MessageBox.Show("Lack data, check that have PHOTO");
        }

        private void btnDelTruck_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnCleanTruck_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Record Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvTrucks.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpdTruck_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update trucksprofiles set name='" + txtTruckCompany.Text + "',ownername='" + txtTruckOwner.Text + "',trucknumber='" + txtTruckNumber.Text + "',vinnumber='" + txtTruckVin.Text + "',year='" + txtTruckYear.Text + "',make='" + txtTruckMake.Text + "',model='" + txtTruckModel.Text + "',tag='" + txtTruckTag.Text + "',pmmileage='" + txtTruckPmMileage.Text + "',truckcolor='" + txtTruckColor.Text + "',tiresize='" + txtTruckTire.Text + "',axles='" + txtTruckAxles.Text + "',enginemake='" + txtTruckEngineMake.Text + "',enginepower='" + txtTruckEnginePower.Text + "',enginesn='" + txtTruckEngineSn.Text + "',transtype='" + txtTruckTranspType.Text + "',emptywgt='" + txtTruckEmptyWgt.Text + "',fueltank='" + txtTruckFuelTank.Text + "',notes=@notes, photo=@photo" + " where id=" + codigo, conn);
                MemoryStream ms = new MemoryStream();
                pbTruckPhoto.Image.Save(ms, ImageFormat.Jpeg);
                byte[] aByte = ms.ToArray();
                cmd.Parameters.AddWithValue("photo", aByte);
                cmd.Parameters.AddWithValue("notes", txtTruckNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correcto");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvTrucks.DataSource = conectandose.Consultar(TblName);
        }
        /// <summary>////////////////////////////////////////
        /// TRAILERS PROFILES
        /// </summary>///////////////////////////////////////
        ////
        private AutoCompleteStringCollection CargaDatosTrailers()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            dgvTrailers.DataSource = conectandose.Consultar(TblName, txtSearchTrailer.Text);
            return datos;
        }

        private void txtSearchTrailer_TextChanged(object sender, EventArgs e)
        {
            //Consulta
            if (txtSearchTrailer.Text != "")
            {
                txtSearchTrailer.AutoCompleteCustomSource = CargaDatosTrailers();
                txtSearchTrailer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtSearchTrailer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                dgvTrailers.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void dgvTrailers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddTrailer.Enabled = false;
            btnUpdTrailer.Enabled = true;
            btnDelTrailer.Enabled = true;

            codigo = Convert.ToInt32(dgvTrucks.Rows[e.RowIndex].Cells[0].Value);

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

            txtTrailerOwner.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[1].Value);
            txtTrailerId.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[2].Value);
            txtTrailerVin.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[3].Value);
            txtTrailerTag.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[4].Value);
            txtTrailerPmMileage.Text = Convert.ToString(dgvTrucks.Rows[e.RowIndex].Cells[5].Value);

            txtTrailerYear.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[6].Value);
            txtTrailerMake.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[7].Value);
            txtTrailerModel.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[8].Value);
            txtTrailerColor.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[9].Value);
            txtTrailerTire.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[10].Value);
            txtTrailerAxles.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[11].Value);

            txtTrailerNotes.Text = Convert.ToString(dgvTrailers.Rows[e.RowIndex].Cells[12].Value);
        }

        private void btnCleanTrailer_Click(object sender, EventArgs e)
        {
            txtTrailerOwner.Text = "";
            txtTrailerId.Text = "";
            txtTrailerVin.Text = "";
            txtTrailerTag.Text = "";
            txtTrailerPmMileage.Text = "";

            txtTrailerYear.Text = "";
            txtTrailerMake.Text = "";
            txtTrailerModel.Text = "";
            txtTrailerColor.Text = "";
            txtTrailerTire.Text = "";
            txtTrailerAxles.Text = "";

            txtTrailerNotes.Text = "";
            txtSearchTrailer.Text = "";
            pbTrailerPhoto.Image = null;

            btnAddTrailer.Enabled = true;
            btnAddTrailer.Enabled = false;
            btnAddTrailer.Enabled = false;
        }

        private void btnAddTrailer_Click(object sender, EventArgs e)
        {
            if (!(txtTrailerOwner.Text == "" || pbTrailerPhoto.Image == null))
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into trailersprofiles (name,Trailernumber,vinnumber,tag,pmmileage,year,make,model,color,tiresize,axles,@notes,@photo) values ('" + txtTrailerOwner.Text + "','" + txtTrailerId.Text + "','" + txtTrailerVin.Text + "','" + txtTrailerTag.Text + "','" + txtTrailerPmMileage.Text + "','" + txtTrailerYear.Text + "','" + txtTrailerMake.Text + "','" + txtTrailerModel.Text + "','" + txtTrailerColor.Text + "','" + txtTrailerTire.Text + "','" + txtTrailerAxles.Text + "',@notes, @photo)", conn);
                    MemoryStream ms = new MemoryStream();
                    pbTrailerPhoto.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();
                    cmd.Parameters.AddWithValue("photo", aByte);
                    cmd.Parameters.AddWithValue("notes", txtTrailerNotes.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Datos guardados");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }

                dgvTrucks.DataSource = conectandose.Consultar(TblName);
                btnAddTrailer.Enabled = false;
                btnUpdTrailer.Enabled = true;
                btnDelTrailer.Enabled = true;
            }
            else MessageBox.Show("Lack data, check that have PHOTO");
        }

        private void btnDelTrailer_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnCleanTrailer_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Record Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvTrailers.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpdTrailer_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update trailersprofiles set name='" + txtTrailerOwner.Text + "',Trailernumber='" + txtTrailerId.Text + "',vinnumber='" + txtTrailerVin.Text + "',tag='" + txtTrailerTag.Text + "',pmmileage='" + txtTrailerPmMileage.Text + "',year='" + txtTrailerYear.Text + "',make='" + txtTrailerMake.Text + "',model='" + txtTrailerModel.Text + "',color='" + txtTrailerColor.Text + "',tiresize='" + txtTrailerTire.Text + "',axels='" + txtTrailerAxles.Text + "',notes=@notes, photo=@photo" + " where id=" + codigo, conn);
                MemoryStream ms = new MemoryStream();
                pbTrailerPhoto.Image.Save(ms, ImageFormat.Jpeg);
                byte[] aByte = ms.ToArray();
                cmd.Parameters.AddWithValue("photo", aByte);
                cmd.Parameters.AddWithValue("notes", txtTrailerNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correcto");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            dgvTrailers.DataSource = conectandose.Consultar(TblName);
        }

        private void btnSelPhotoTrailer_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbTrailerPhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void btnCatalogs_Click(object sender, EventArgs e)
        {
            frmPrintCatalogs catalogs = new frmPrintCatalogs();
            catalogs.ShowDialog();
        }
    }
}
