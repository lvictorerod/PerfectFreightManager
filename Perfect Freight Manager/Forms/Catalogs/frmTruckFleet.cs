using Npgsql;
using Perfect_Freight_Manager.Forms;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Mantenimiento;
using Perfect_Freight_Manager.Forms.Utilities;
using Perfect_Freight_Manager.Models;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Catalogs
{
    public partial class frmTruckFleet : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string TblName = "trucksprofiles";
        int codigo;
        private int sgtetruck = 0, cuentatruck = 0;
        private int sgtetrailer = 0, cuentatrailer = 0;
        private int sgteapu = 0, cuentaapu = 0;

        public string V { get; }

        public frmTruckFleet()
        {
            InitializeComponent();
            //Point location = Location;
            //location.X = 1200;
            //location.Y = 1200;

            btnDelTruck.Enabled = false;
            btnUpdTruck.Enabled = false;
            btnDelTrailer.Enabled = false;
            btnUpdTrailer.Enabled = false;
            btnDelApu.Enabled = false;
            btnUpdApu.Enabled = false;

            btnTruckFirst.Enabled = false;
            btnTruckPrevious.Enabled = false;
            btnTruckNext.Enabled = false;
            btnTruckEnd.Enabled = false;

            btnTrailerFirst.Enabled = false;
            btnTrailerPrevious.Enabled = false;
            btnTrailerNext.Enabled = false;
            btnTrailerEnd.Enabled = false;

            btnApuFirst.Enabled = false;
            btnApuPrevious.Enabled = false;
            btnApuNext.Enabled = false;
            btnApuEnd.Enabled = false;

            dgvMtoTR.DataSource = conectandose.Consultar("adminmaintenances");
            dgvTrucks.DataSource = conectandose.Consultar(TblName);
            cbTruckType.Items.Clear();
            string cadena = "select type from trucktypes order by id";
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                cbTruckType.Items.Add(dr["type"].ToString());
            }
            conn.Close();
            cuentatruck = dgvTrucks.Rows.GetRowCount(0);
            lbRecord.Text = "Record " + (sgtetruck) + " of  " + cuentatruck;
            if (cuentatruck != 0)
            {
                btnTruckFirst.Enabled = true;
                btnTruckPrevious.Enabled = true;
                btnTruckNext.Enabled = true;
                btnTruckEnd.Enabled = true;
            }
        }

        public frmTruckFleet(string v)
        {
            V = v;
        }

        private Point UserControlDashboard()
        {
            throw new NotImplementedException();
        }

        public string comillas_simples(string cadena)
        {
            return "'" + cadena + "'";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabTrucks")
            {
                TblName = "trucksprofiles";
                cuentatruck = dgvTrucks.Rows.GetLastRow(0);
                if (cuentatruck != 0)
                {
                    btnTruckFirst.Enabled = true;
                    btnTruckPrevious.Enabled = true;
                    btnTruckNext.Enabled = true;
                    btnTruckEnd.Enabled = true;
                }
                dgvMtoTR.DataSource = conectandose.Consultar("adminmaintenances");
                cbTruckType.Items.Clear();
                string cadena = "select type from trucktypes order by id";
                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    cbTruckType.Items.Add(dr["type"].ToString());
                }
                conn.Close();
            }
            if (tabControl1.SelectedTab.Name == "tabTrailers")
            {
                TblName = "trailersprofiles";
                dgvMtoTL.DataSource = conectandose.Consultar("adminmaintenances");
                if (txtTrailerOwner.Text == "")
                {
                    dgvTrailers.DataSource = conectandose.Consultar(TblName);
                    lbRecordtl.Text = "Record " + sgtetrailer + " of  " + cuentatrailer;
                }else lbRecordtl.Text = "Record " + (sgtetrailer+1) + " of  " + cuentatrailer;

                cuentatrailer = dgvTrailers.Rows.GetRowCount(0);
                if (cuentatrailer != 0)
                {
                    btnTrailerFirst.Enabled = true;
                    btnTrailerPrevious.Enabled = true;
                    btnTrailerNext.Enabled = true;
                    btnTrailerEnd.Enabled = true;
                }
                cbTrailerType.Items.Clear();
                string cadena = "select type from trailertypes order by id";
                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    cbTrailerType.Items.Add(dr["type"].ToString());
                }
                conn.Close();
            }
            if (tabControl1.SelectedTab.Name == "tabApu")
            {
                TblName = "apuprofiles";
                dgvMtoAPU.DataSource = conectandose.Consultar("adminmaintenances");
                cuentaapu = dgvApu.Rows.GetFirstRow(0);
                lbRecord.Text = "Record " + sgteapu + " of  " + cuentaapu;
                dgvApu.DataSource = conectandose.Consultar(TblName);
                if (cuentaapu != 0)
                {
                    btnApuFirst.Enabled = true;
                    btnApuPrevious.Enabled = true;
                    btnApuNext.Enabled = true;
                    btnApuEnd.Enabled = true;
                }
            }
        }

        /// <summary>//////////////////////////////////////
        /// TRUCKS PROFILES
        /// </summary>/////////////////////////////////////
        ///
        private void btnTruckFirst_Click(object sender, EventArgs e)
        {
            cuentatruck = dgvTrucks.Rows.GetRowCount(0);
            sgtetruck = dgvTrucks.Rows.GetFirstRow(0);
            dgvTrucks_RowEnter(sender, e);
            rellenatruck();
        }

        private void btnTruckPrevios_Click(object sender, EventArgs e)
        {
            cuentatruck = dgvTrucks.Rows.GetRowCount(0);
            sgtetruck = dgvTrucks.Rows.GetPreviousRow(sgtetruck, 0);
            if (sgtetruck == -1) sgtetruck = cuentatruck - 1;
            if (sgtetruck <= cuentatruck && sgtetruck >= 0)
            {
                dgvTrucks_RowEnter(sender, e);
                rellenatruck();
            }
        }

        private void btnTruckNext_Click(object sender, EventArgs e)
        {
            cuentatruck = dgvTrucks.Rows.GetRowCount(0);
            sgtetruck = dgvTrucks.Rows.GetNextRow(sgtetruck, 0);
            if (sgtetruck == -1) sgtetruck = 0;
            if (sgtetruck <= cuentatruck && sgtetruck >= 0)
            {
                dgvTrucks_RowEnter(sender, e);
                rellenatruck();
            }
        }

        private void btnTruckEnd_Click(object sender, EventArgs e)
        {
            cuentatruck = dgvTrucks.Rows.GetRowCount(0);
            sgtetruck = dgvTrucks.Rows.GetLastRow(0);
            dgvTrucks_RowEnter(sender, e);
            rellenatruck();
        }

        private void dgvTrucks_RowEnter(object sender, EventArgs e)
        {
            dgvTrucks.ClearSelection();
            dgvTrucks.Rows[sgtetruck].Selected = true;
            dgvTrucks.FirstDisplayedScrollingRowIndex = dgvTrucks.Rows.GetNextRow(sgtetruck - 1, 0);
        }
        private void rellenatruck()
        {
            btnAddTruck.Enabled = false;
            btnUpdTruck.Enabled = true;
            btnDelTruck.Enabled = true;

            double totalmiles = 0;
            double truckinippm = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[1].Value);
            double truckstoppm = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[2].Value);

            double truckinipt2 = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[3].Value);
            double truckstopt2 = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[4].Value);

            double truckinipt3 = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[5].Value);
            double truckstopt3 = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[6].Value);

            codigo = Convert.ToInt32(dgvTrucks.Rows[sgtetruck].Cells[0].Value);

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
            pbTruckPhoto.Image = Image.FromStream(ms);
            conn.Close();


            txtTruckCompany.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[1].Value);
            txtTruckOwner.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[2].Value);
            txtTruckNumber.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[3].Value);
            txtTruckVin.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[4].Value);
            txtTruckYear.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[5].Value);
            txtTruckMake.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[6].Value);
            txtTruckModel.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[7].Value);
            txtTruckTag.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[8].Value);
            txtTruckPmMileage.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[9].Value);
            txtTruckColor.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[10].Value);

            txtTruckTire.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[11].Value);
            txtTruckAxles.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[12].Value);
            txtTruckEngineMake.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[13].Value);
            txtTruckEnginePower.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[14].Value);
            txtTruckEngineSn.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[15].Value);
            txtTruckTranspType.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[16].Value);
            txtTruckEmptyWgt.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[17].Value);
            txtTruckFuelTank.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[18].Value);
            txtTruckNotes.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[19].Value);
            dtLicenseTruck.Value = Convert.ToDateTime(dgvTrucks.Rows[sgtetruck].Cells[21].Value);
            dtLicenseExpireTruck.Value = Convert.ToDateTime(dgvTrucks.Rows[sgtetruck].Cells[22].Value);
            txtTruckTotalMiles.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[23].Value);
            cbTruckType.Text = Convert.ToString(dgvTrucks.Rows[sgtetruck].Cells[25].Value);
            totalmiles = Convert.ToDouble(dgvTrucks.Rows[sgtetruck].Cells[23].Value);
            if (totalmiles <= truckinippm || totalmiles <= truckinipt2)
            {
                pbTRGreen.BackColor = Color.LimeGreen;
                pbTRYellow.BackColor = Color.Gray;
                pbTRRed.BackColor = Color.Gray;
                lblStatus.Text = "PM";
            }
            else if(totalmiles <= truckstoppm || totalmiles <= truckstopt2)
            {
                pbTRGreen.BackColor = Color.Gray;
                pbTRYellow.BackColor = Color.Gold;
                pbTRRed.BackColor = Color.Gray;
                lblStatus.Text = "T2";
            }
            else if (totalmiles >= truckinipt3)
            {
                pbTRGreen.BackColor = Color.Gray;
                pbTRYellow.BackColor = Color.Gold;
                pbTRRed.BackColor = Color.Gray;
                lblStatus.Text = "T3";
            }
            else
            {
                pbTRGreen.BackColor = Color.Gray;
                pbTRYellow.BackColor = Color.Gray;
                pbTRRed.BackColor = Color.Red;
                lblStatus.Text = "BAD";
            }



            lbRecord.Text = "Record " + (sgtetruck + 1) + " of  " + cuentatruck;
            btnMtoTruck.Text = "Add Maintenance";

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
            cbTruckType.Text = "";

            txtTruckTire.Text = "";
            txtTruckAxles.Text = "";
            txtTruckEngineMake.Text = "";
            txtTruckEnginePower.Text = "";
            txtTruckEngineSn.Text = "";
            txtTruckTranspType.Text = "";
            txtTruckEmptyWgt.Text = "";
            txtTruckFuelTank.Text = "";
            txtTruckNotes.Text = "";
            pbTruckPhoto.Image = null;
            dtLicenseTruck.Value = DateTime.Today;
            dtLicenseExpireTruck.Value = DateTime.Today;
            txtTruckTotalMiles.Text = "0";
            btnMtoTruck.Text = "Checkpoint Maintenance";
            pbTRGreen.BackColor = Color.Gray;
            pbTRYellow.BackColor = Color.Gray;
            pbTRRed.BackColor = Color.Gray;

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
            if (txtTruckCompany.Text != "" && pbTruckPhoto.Image != null && txtTruckOwner.Text != "" && txtTruckNumber.Text != "" && dtLicenseTruck.Value != null && dtLicenseExpireTruck.Value != null)
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into trucksprofiles (name,ownername,trucknumber,vinnumber,year,make,model,tag,pmmileage,truckcolor,tiresize,axles,                    enginemake,enginepower,enginesn,transtype,emptywgt,fueltank,notes,photo,licensedate,licensedateexpire,totalmiles,equipment) values ('" + txtTruckCompany.Text + "','" + txtTruckOwner.Text + "','" + txtTruckNumber.Text + "','" + txtTruckVin.Text + "','" + txtTruckYear.Text + "','" + txtTruckMake.Text + "','" + txtTruckModel.Text + "','" + txtTruckTag.Text + "','" + txtTruckPmMileage.Text + "','" + txtTruckColor.Text + "','" + txtTruckTire.Text + "','" + txtTruckAxles.Text + "','" + txtTruckEngineMake.Text + "','" + txtTruckEnginePower.Text + "','" + txtTruckEngineSn.Text + "','" + txtTruckTranspType.Text + "','" + txtTruckEmptyWgt.Text + "','" + txtTruckFuelTank.Text + "',@notes, @photo,'" + dtLicenseTruck.Value + "','" + dtLicenseExpireTruck.Value + "','" + txtTruckTotalMiles.Text + "','" + cbTruckType.Text + "')", conn);
                    MemoryStream ms = new MemoryStream();
                    pbTruckPhoto.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();
                    cmd.Parameters.AddWithValue("photo", aByte);
                    cmd.Parameters.AddWithValue("notes", txtTruckNotes.Text);
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
            else MessageBox.Show("Lack data, check that have:\nCompany, Owner, #Truck, License Truck, License Date Expire and Photo", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvTrucks.DataSource = conectandose.Consultar(TblName);
            btnAddTruck.Enabled = false;
            btnUpdTruck.Enabled = true;
            btnDelTruck.Enabled = true;
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
                NpgsqlCommand cmd = new NpgsqlCommand("update trucksprofiles set name='" + txtTruckCompany.Text + "',ownername='" + txtTruckOwner.Text + "',trucknumber='" + txtTruckNumber.Text + "',vinnumber='" + txtTruckVin.Text + "',year='" + txtTruckYear.Text + "',make='" + txtTruckMake.Text + "',model='" + txtTruckModel.Text + "',tag='" + txtTruckTag.Text + "',pmmileage='" + txtTruckPmMileage.Text + "',truckcolor='" + txtTruckColor.Text + "',tiresize='" + txtTruckTire.Text + "',axles='" + txtTruckAxles.Text + "',enginemake='" + txtTruckEngineMake.Text + "',enginepower='" + txtTruckEnginePower.Text + "',enginesn='" + txtTruckEngineSn.Text + "',transtype='" + txtTruckTranspType.Text + "',emptywgt='" + txtTruckEmptyWgt.Text + "',fueltank='" + txtTruckFuelTank.Text + "',notes=@notes, photo=@photo, licensedate='" + dtLicenseTruck.Value + "', licensedateexpire='" + dtLicenseExpireTruck.Value + "',totalmiles='" + txtTruckTotalMiles.Text + "',equipment='" + cbTruckType.Text + "'" + " where id=" + codigo, conn);
                MemoryStream ms = new MemoryStream();
                pbTruckPhoto.Image.Save(ms, ImageFormat.Jpeg);
                byte[] aByte = ms.ToArray();
                cmd.Parameters.AddWithValue("photo", aByte);
                cmd.Parameters.AddWithValue("notes", txtTruckNotes.Text);
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
            //dgvTrucks.DataSource = conectandose.Consultar(TblName);
        }
        
        /// <summary>////////////////////////////////////////
        /// TRAILERS PROFILES
        /// </summary>///////////////////////////////////////
        ////
        private void btnTrailerFirst_Click(object sender, EventArgs e)
        {
            cuentatrailer = dgvTrailers.Rows.GetRowCount(0);
            sgtetrailer = dgvTrailers.Rows.GetFirstRow(0);
            dgvTrailers_RowEnter(sender, e);
            rellenatrailer();
        }

        private void btnTrailerPrevious_Click(object sender, EventArgs e)
        {
            cuentatrailer = dgvTrailers.Rows.GetRowCount(0);
            sgtetrailer = dgvTrailers.Rows.GetPreviousRow(sgtetrailer, 0);
            if (sgtetrailer == -1) sgtetrailer = cuentatrailer - 1;
            if (sgtetrailer <= cuentatrailer && sgtetrailer >= 0)
            {
                dgvTrailers_RowEnter(sender, e);
                rellenatrailer();
            }
        }

        private void btnTrailerNext_Click(object sender, EventArgs e)
        {
            cuentatrailer = dgvTrailers.Rows.GetRowCount(0);
            sgtetrailer = dgvTrailers.Rows.GetNextRow(sgtetrailer, 0);
            if (sgtetrailer == -1) sgtetrailer = 0;
            if (sgtetrailer <= cuentatrailer && sgtetrailer >= 0)
            {
                dgvTrailers_RowEnter(sender, e);
                rellenatrailer();
            }
        }

        private void btnTrailerEnd_Click(object sender, EventArgs e)
        {
            cuentatrailer = dgvTrailers.Rows.GetRowCount(0);
            sgtetrailer = dgvTrailers.Rows.GetLastRow(0);
            dgvTrailers_RowEnter(sender, e);
            rellenatrailer();
        }
        private void dgvTrailers_RowEnter(object sender, EventArgs e)
        {
            dgvTrailers.ClearSelection();
            dgvTrailers.Rows[sgtetrailer].Selected = true;
            dgvTrailers.FirstDisplayedScrollingRowIndex = dgvTrailers.Rows.GetNextRow(sgtetrailer - 1, 0);
        }

        private void rellenatrailer()
        {
            btnAddTrailer.Enabled = false;
            btnUpdTrailer.Enabled = true;
            btnDelTrailer.Enabled = true;

            double totalmiles = 0;
            double tlinippm = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[7].Value);
            double tlstoppm = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[8].Value);

            codigo = Convert.ToInt32(dgvTrailers.Rows[sgtetrailer].Cells[0].Value);

            conn.Open();
            string query2 = "select photo from " + TblName + " where id = " + codigo;
            NpgsqlCommand cmd2 = new NpgsqlCommand(query2, conn);
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "img");

            byte[] datos2 = new byte[0];
            DataRow dr2 = ds2.Tables["img"].Rows[0];
            datos2 = (byte[])dr2["photo"];
            MemoryStream ms2 = new MemoryStream(datos2);
            pbTrailerPhoto.Image = System.Drawing.Bitmap.FromStream(ms2);
            conn.Close();

            txtTrailerOwner.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[1].Value);
            txtTrailerId.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[2].Value);
            txtTrailerVin.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[3].Value);
            txtTrailerTag.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[4].Value);
            txtTrailerPmMileage.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[5].Value);

            txtTrailerYear.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[6].Value);
            txtTrailerMake.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[7].Value);
            txtTrailerModel.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[8].Value);
            txtTrailerColor.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[9].Value);
            txtTrailerTire.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[10].Value);
            txtTrailerAxles.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[11].Value);
            txtTrailerNotes.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[12].Value);
            dtLicenseTrailer.Value = Convert.ToDateTime(dgvTrailers.Rows[sgtetrailer].Cells[14].Value);
            dtLicenseExpireTrailer.Value = Convert.ToDateTime(dgvTrailers.Rows[sgtetrailer].Cells[15].Value);
            txtTrailerTotalMiles.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[16].Value);
            cbTrailerType.Text = Convert.ToString(dgvTrailers.Rows[sgtetrailer].Cells[18].Value);
            totalmiles = Convert.ToDouble(dgvTrailers.Rows[sgtetrailer].Cells[16].Value);
            if (totalmiles <= tlinippm)
            {
                pbTLGreen.BackColor = Color.LimeGreen;
                pbTLYellow.BackColor = Color.Gray;
                pbTLRed.BackColor = Color.Gray;
                lblStatusTL.Text = "OK";
            }
            else if (totalmiles <= tlstoppm)
            {
                pbTLGreen.BackColor = Color.Gray;
                pbTLYellow.BackColor = Color.Gold;
                pbTLRed.BackColor = Color.Gray;
                lblStatusTL.Text = "PM";
            }
            else
            {
                pbTLGreen.BackColor = Color.Gray;
                pbTLYellow.BackColor = Color.Gray;
                pbTLRed.BackColor = Color.Red;
                lblStatusTL.Text = "BAD";
            }
            lbRecordtl.Text = "Record " + (sgtetrailer + 1) + " of  " + cuentatrailer;
            btnMtoTrailer.Text = "Add Maintenance";
        }

        private void btnCleanTrailer_Click(object sender, EventArgs e)
        {
            txtTrailerOwner.Text = "";
            txtTrailerId.Text = "";
            cbTrailerType.Text = "";
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
            pbTrailerPhoto.Image = null;
            dtLicenseTrailer.Value = DateTime.Today;
            dtLicenseExpireTrailer.Value = DateTime.Today;
            txtTrailerTotalMiles.Text = "0";
            cuentatrailer = dgvTrailers.Rows.GetRowCount(0);
            pbTLGreen.BackColor = Color.Gray;
            pbTLYellow.BackColor = Color.Gray;
            pbTLRed.BackColor = Color.Gray;

            sgtetrailer = 0;
            lbRecordtl.Text = "Record " + (sgtetrailer + 1) + " of  " + cuentatrailer;
            btnAddTrailer.Enabled = true;
            btnDelTrailer.Enabled = false;
            btnUpdTrailer.Enabled = false;
            btnMtoTrailer.Text = "Checkpoint Maintenance";
        }

        private void btnAddTrailer_Click(object sender, EventArgs e)
        {
            if (txtTrailerOwner.Text != "" && pbTrailerPhoto.Image != null && txtTrailerId.Text != "" && dtLicenseTrailer.Value != null && dtLicenseExpireTrailer.Value != null)
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into trailersprofiles (name,trailernumber,vinnumber,tag,pmmileage,year,make,model,color,tiresize,axles,@notes,@photo,licensedate,licensedateexpire,totalmiles,equipment) values ('" + txtTrailerOwner.Text + "','" + txtTrailerId.Text + "','" + txtTrailerVin.Text + "','" + txtTrailerTag.Text + "','" + txtTrailerPmMileage.Text + "','" + txtTrailerYear.Text + "','" + txtTrailerMake.Text + "','" + txtTrailerModel.Text + "','" + txtTrailerColor.Text + "','" + txtTrailerTire.Text + "','" + txtTrailerAxles.Text + "',@notes, @photo,'" + dtLicenseTrailer.Value + "','" + dtLicenseExpireTrailer.Value + "','" + txtTrailerTotalMiles.Text + "','" + cbTrailerType.Text + "')", conn);
                    MemoryStream ms = new MemoryStream();
                    pbTrailerPhoto.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();
                    cmd.Parameters.AddWithValue("photo", aByte);
                    cmd.Parameters.AddWithValue("notes", txtTrailerNotes.Text);
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
            else MessageBox.Show("Lack data, check that have:\nOwner, #Trailer, License Trailer, License Date Expire and Photo", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvTrucks.DataSource = conectandose.Consultar(TblName);
            btnAddTrailer.Enabled = false;
            btnUpdTrailer.Enabled = true;
            btnDelTrailer.Enabled = true;
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
                NpgsqlCommand cmd = new NpgsqlCommand("update trailersprofiles set name='" + txtTrailerOwner.Text + "',Trailernumber='" + txtTrailerId.Text + "',vinnumber='" + txtTrailerVin.Text + "',tag='" + txtTrailerTag.Text + "',pmmileage='" + txtTrailerPmMileage.Text + "',year='" + txtTrailerYear.Text + "',make='" + txtTrailerMake.Text + "',model='" + txtTrailerModel.Text + "',color='" + txtTrailerColor.Text + "',tiresize='" + txtTrailerTire.Text + "',axels='" + txtTrailerAxles.Text + "',notes=@notes, photo=@photo,licensedate='" + dtLicenseTrailer.Value + "',licensedateexpire='" + dtLicenseExpireTrailer.Value + "',totalmiles='" + txtTrailerTotalMiles.Text + "',equipment='" + cbTrailerType.Text + "'" + " where id=" + codigo, conn);
                MemoryStream ms = new MemoryStream();
                pbTrailerPhoto.Image.Save(ms, ImageFormat.Jpeg);
                byte[] aByte = ms.ToArray();
                cmd.Parameters.AddWithValue("photo", aByte);
                cmd.Parameters.AddWithValue("notes", txtTrailerNotes.Text);
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
        /// <summary>////////////////////////
        /// APU
        /// </summary>///////////////////////
        /// 
        private void btnCleanApu_Click(object sender, EventArgs e)
        {
            txtOwnerApu.Text = "";
            txtTruckApu.Text = "";
            txtNumberApu.Text = "";
            txtVinApu.Text = "";
            txtYearApu.Text = "";
            txtMakeApu.Text = "";
            txtModelApu.Text = "";
            txtColorApu.Text = "";
            txtTrailerTire.Text = "";
            txtApuHours.Text = "0";
            txtNotesApu.Text = "";
            pbApuPhoto.Image = null;
            pbAPUGreen.BackColor = Color.Gray;
            pbAPUYellow.BackColor = Color.Gray;
            pbAPURed.BackColor = Color.Gray;
            cuentaapu = dgvApu.Rows.GetRowCount(0);
            sgteapu = 0;
            lblApu.Text = "Record " + (sgteapu + 1) + " of  " + cuentaapu;
            btnMtoAPU.Text = "Checkpoint Maintenance";

            btnAddApu.Enabled = true;
            btnDelApu.Enabled = false;
            btnUpdApu.Enabled = false;
        }

        private void btnApuFirst_Click(object sender, EventArgs e)
        {
            cuentaapu = dgvApu.Rows.GetRowCount(0);
            sgteapu = dgvApu.Rows.GetFirstRow(0);
            dgvApu_RowEnter(sender, e);
            rellenaapu();
        }

        private void btnApuPrevious_Click(object sender, EventArgs e)
        {
            cuentaapu = dgvApu.Rows.GetRowCount(0);
            sgteapu = dgvApu.Rows.GetPreviousRow(sgteapu, 0);
            if (sgteapu == -1) sgteapu = cuentaapu - 1;
            if (sgteapu <= cuentaapu && sgteapu >= 0)
            {
                dgvApu_RowEnter(sender, e);
                rellenaapu();
            }
        }

        private void btnApuNext_Click(object sender, EventArgs e)
        {
            cuentaapu = dgvApu.Rows.GetRowCount(0);
            sgteapu = dgvApu.Rows.GetNextRow(sgteapu, 0);
            if (sgteapu == -1) sgteapu = 0;
            if (sgteapu <= cuentaapu && sgteapu >= 0)
            {
                dgvApu_RowEnter(sender, e);
                rellenaapu();
            }
        }

        private void btnApuEnd_Click(object sender, EventArgs e)
        {
            cuentaapu = dgvApu.Rows.GetRowCount(0);
            sgteapu = dgvApu.Rows.GetLastRow(0);
            dgvApu_RowEnter(sender, e);
            rellenaapu();
        }

        private void dgvApu_RowEnter(object sender, EventArgs e)
        {
            dgvApu.ClearSelection();
            dgvApu.Rows[sgteapu].Selected = true;
            dgvApu.FirstDisplayedScrollingRowIndex = dgvApu.Rows.GetNextRow(sgteapu - 1, 0);
        }

        private void rellenaapu()
        {
            btnAddApu.Enabled = false;
            btnUpdApu.Enabled = true;
            btnDelApu.Enabled = true;

            double totalhours = 0;
            double apuinippm = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[13].Value);
            double apustoppm = Convert.ToDouble(dgvMtoTR.Rows[0].Cells[14].Value);

            codigo = Convert.ToInt32(dgvApu.Rows[sgteapu].Cells[0].Value);

            conn.Open();
            string query3 = "select photo from " + TblName + " where id = " + codigo;
            NpgsqlCommand cmd3 = new NpgsqlCommand(query3, conn);
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "img");

            byte[] datos3 = new byte[0];
            DataRow dr3 = ds3.Tables["img"].Rows[0];
            datos3 = (byte[])dr3["photo"];
            MemoryStream ms3 = new MemoryStream(datos3);
            pbApuPhoto.Image = System.Drawing.Bitmap.FromStream(ms3);
            conn.Close();

            txtOwnerApu.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[1].Value);
            txtNumberApu.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[2].Value);
            txtVinApu.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[3].Value);
            txtYearApu.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[6].Value);
            txtMakeApu.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[7].Value);
            txtModelApu.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[8].Value);
            txtColorApu.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[9].Value);
            txtApuHours.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[10].Value);
            txtNotesApu.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[12].Value);
            txtTruckApu.Text = Convert.ToString(dgvApu.Rows[sgteapu].Cells[13].Value);
            totalhours = Convert.ToDouble(dgvApu.Rows[sgteapu].Cells[10].Value);
            if (totalhours <= apuinippm )
            {
                pbAPUGreen.BackColor = Color.LimeGreen;
                pbAPUYellow.BackColor = Color.Gray;
                pbAPURed.BackColor = Color.Gray;
                lblStatusAPU.Text = "OK";
            }
            else if (totalhours <= apustoppm)
            {
                pbAPUGreen.BackColor = Color.Gray;
                pbAPUYellow.BackColor = Color.Gold;
                pbAPURed.BackColor = Color.Gray;
                lblStatusAPU.Text = "PM";
            }
            else
            {
                pbAPUGreen.BackColor = Color.Gray;
                pbAPUYellow.BackColor = Color.Gray;
                pbAPURed.BackColor = Color.Red;
                lblStatusAPU.Text = "BAD";
            }
            btnMtoAPU.Text = "Add Maintenance";

        }

        private void btnAddApu_Click(object sender, EventArgs e)
        {
            if (txtOwnerApu.Text != "" && pbApuPhoto.Image != null)
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into apuprofiles (owner,apunumber,vinnumber,year,make,model,color,totalhours,photo,notes,trucknumber) values ('" + txtOwnerApu.Text + "','" + txtNumberApu.Text + "','" + txtVinApu.Text + "','" + txtYearApu.Text + "','" + txtMakeApu.Text + "','" + txtModelApu.Text + "','" + txtColorApu.Text + "','" + txtApuHours.Text + "', @photo,@notes,'" + txtTruckApu.Text + "')", conn);
                    MemoryStream ms = new MemoryStream();
                    pbApuPhoto.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] aByte = ms.ToArray();
                    cmd.Parameters.AddWithValue("photo", aByte);
                    cmd.Parameters.AddWithValue("notes", txtNotesApu.Text);
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
            else MessageBox.Show("Lack data, check that have:\nOwner, #Apu, License Apu, License Date Expire and Photo", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvApu.DataSource = conectandose.Consultar(TblName);
            btnAddApu.Enabled = false;
            btnUpdApu.Enabled = true;
            btnDelApu.Enabled = true;
        }

        private void btnDelApu_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnCleanApu_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Record Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvApu.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpdApu_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update apuprofiles set owner='" + txtOwnerApu.Text + "',apunumber='" + txtNumberApu.Text + "',vinnumber='" + txtVinApu.Text + "',year='" + txtYearApu.Text + "',make='" + txtMakeApu.Text + "',model='" + txtModelApu.Text + "',color='" + txtColorApu.Text + "',totalhours='" + txtApuHours.Text + "', photo=@photo,notes=@notes,trucknumber='" + txtTruckApu.Text + "'" + " where id=" + codigo, conn);
                MemoryStream ms = new MemoryStream();
                pbApuPhoto.Image.Save(ms, ImageFormat.Jpeg);
                byte[] aByte = ms.ToArray();
                cmd.Parameters.AddWithValue("photo", aByte);
                cmd.Parameters.AddWithValue("notes", txtNotesApu.Text);
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
            dgvApu.DataSource = conectandose.Consultar(TblName);
        }

        private void btnSelPhotoApu_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbApuPhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        /// <summary>///////////////////////////////
        /// GENERALES
        /// </summary>//////////////////////////////
        /// 
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTruckCompany_Leave(object sender, EventArgs e)
        {
            txtTruckCompany.Text = (txtTruckCompany.Text).ToUpper();
        }

        private void txtTruckOwner_Leave(object sender, EventArgs e)
        {
            txtTruckOwner.Text = (txtTruckOwner.Text).ToUpper();
        }

        private void txtTruckVin_Leave(object sender, EventArgs e)
        {
            txtTruckVin.Text = (txtTruckVin.Text).ToUpper();
        }

        private void txtTrailerOwner_Leave(object sender, EventArgs e)
        {
            txtTrailerOwner.Text = (txtTrailerOwner.Text).ToUpper();
        }

        private void txtTrailerVin_Leave(object sender, EventArgs e)
        {
            txtTrailerVin.Text = (txtTrailerVin.Text).ToUpper();
        }

        private void btnMtoTruck_Click(object sender, EventArgs e)
        {
            MttoTrucks mtoTrucks = new MttoTrucks(txtTruckNumber.Text, txtTruckTotalMiles.Text, txtTruckOwner.Text);
            mtoTrucks.Show();
        }

        private void btnAddMtoTruck_Click(object sender, EventArgs e)
        {
            MttoTrucks mtoTrucks = new MttoTrucks(txtTruckNumber.Text, txtTruckTotalMiles.Text, txtTruckOwner.Text);
            mtoTrucks.Show();
        }

        private void btnMtoTrailer_Click(object sender, EventArgs e)
        {
            MttoTrailer mtoTrailer = new MttoTrailer(txtTrailerId.Text, txtTrailerTotalMiles.Text, txtTrailerOwner.Text);
            mtoTrailer.Show();
        }

        private void dgvTrailers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMtoAPU_Click(object sender, EventArgs e)
        {
            MttoAPU mtoAPU = new MttoAPU(txtNumberApu.Text, txtApuHours.Text, txtOwnerApu.Text);
            mtoAPU.Show();
        }

        private void txtTruckCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTrailerOwner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtOwnerApu_Leave(object sender, EventArgs e)
        {
            txtOwnerApu.Text = (txtOwnerApu.Text).ToUpper();
        }

        private void txtMakeApu_Leave(object sender, EventArgs e)
        {
            txtMakeApu.Text = (txtMakeApu.Text).ToUpper();
        }

        private void txtModelApu_Leave(object sender, EventArgs e)
        {
            txtModelApu.Text = (txtModelApu.Text).ToUpper();
        }

        private void txtColorApu_Leave(object sender, EventArgs e)
        {
            txtColorApu.Text = (txtColorApu.Text).ToUpper();
        }

        private void dgvTrucks_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchTR_TextChanged(object sender, EventArgs e)
        {
            btnAddTruck.Enabled = false;
            btnUpdTruck.Enabled = true;
            btnDelTruck.Enabled = true;
            string search = (txtSearchTR.Text).ToUpper();
            if (txtSearchTR.Text != "")
            {
                if (rbTROwner.Checked == true)
                {
                    dgvTrucks.DataSource = conectandose.ConsultarTROwner(TblName, search);
                    sgtetruck = 0;
                    cuentatruck = dgvTrucks.Rows.GetRowCount(0);
                    if (cuentatruck != 0)
                        rellenatruck();
                }else if (rbTRNumber.Checked == true)
                {
                    dgvTrucks.DataSource = conectandose.ConsultarTrucks(TblName, search);
                    sgtetruck = 0;
                    cuentatruck = dgvTrucks.Rows.GetRowCount(0);
                    if (cuentatruck != 0)
                        rellenatruck();
                }
                else if (rbTRVin.Checked == true)
                {
                    dgvTrucks.DataSource = conectandose.ConsultarTRVin(TblName, search);
                    sgtetruck = 0;
                    cuentatruck = dgvTrucks.Rows.GetRowCount(0);
                    if (cuentatruck != 0)
                        rellenatruck();
                }
            }
            else
            {
                dgvTrucks.DataSource = conectandose.Consultar(TblName);
                cuentatruck = dgvTrucks.Rows.GetLastRow(0);
            }
        }

        private void txtSearchTL_TextChanged(object sender, EventArgs e)
        {
            btnAddTrailer.Enabled = false;
            btnUpdTrailer.Enabled = true;
            btnDelTrailer.Enabled = true;
            string search = (txtSearchTL.Text).ToUpper();
            if (txtSearchTL.Text != "")
            {
                if (rbTLOwner.Checked == true)
                {
                    dgvTrailers.DataSource = conectandose.ConsultarTLOwner(TblName, search);
                    sgtetrailer = 0;
                    cuentatrailer = dgvTrailers.Rows.GetRowCount(0);
                    if (cuentatrailer != 0)
                        rellenatrailer();
                }
                else if (rbTLNumber.Checked == true)
                {
                    dgvTrailers.DataSource = conectandose.ConsultarTrailers(TblName, search);
                    sgtetrailer = 0;
                    cuentatrailer = dgvTrailers.Rows.GetRowCount(0);
                    if (cuentatrailer != 0)
                        rellenatrailer();
                }
                else if (rbTLVin.Checked == true)
                {
                    dgvTrailers.DataSource = conectandose.ConsultarTLVin(TblName, search);
                    sgtetrailer = 0;
                    cuentatrailer = dgvTrailers.Rows.GetRowCount(0);
                    if (cuentatrailer != 0)
                        rellenatrailer();
                }
            }
            else
            {
                dgvTrailers.DataSource = conectandose.Consultar(TblName);
                cuentatrailer = dgvTrailers.Rows.GetLastRow(0);
            }
        }

        private void txtSearchApu_TextChanged(object sender, EventArgs e)
        {
            btnAddApu.Enabled = false;
            btnUpdApu.Enabled = true;
            btnDelApu.Enabled = true;
            string search = (txtSearchApu.Text).ToUpper();
            if (txtSearchApu.Text != "")
            {
                if (rbApuOwner.Checked == true)
                {
                    dgvApu.DataSource = conectandose.ConsultarApuOwner(TblName, search);
                    sgteapu = 0;
                    cuentaapu = dgvApu.Rows.GetRowCount(0);
                    if (cuentaapu != 0)
                        rellenaapu();
                }
                else if (rbApuNumber.Checked == true)
                {
                    dgvApu.DataSource = conectandose.ConsultarApus(TblName, search);
                    sgteapu = 0;
                    cuentaapu = dgvApu.Rows.GetRowCount(0);
                    if (cuentaapu != 0)
                        rellenaapu();
                }
                else if (rbApuVin.Checked == true)
                {
                    dgvApu.DataSource = conectandose.ConsultarApuVin(TblName, search);
                    sgteapu = 0;
                    cuentaapu = dgvApu.Rows.GetRowCount(0);
                    if (cuentaapu != 0)
                        rellenaapu();
                }
            }
            else
            {
                dgvApu.DataSource = conectandose.Consultar(TblName);
                cuentaapu = dgvApu.Rows.GetLastRow(0);
            }
        }

        private void btnTruckType_Click(object sender, EventArgs e)
        {
            frmTRType trucktype = new frmTRType();
            trucktype.Show();
        }

        private void btnTrailerType_Click(object sender, EventArgs e)
        {
            frmTLType trailertype = new frmTLType();
            trailertype.Show();
        }

        private void btnTruckType_MouseHover(object sender, EventArgs e)
        {
            lblTruckType.Visible = true;
        }

        private void btnTruckType_MouseLeave(object sender, EventArgs e)
        {
            lblTruckType.Visible = false;
        }

        private void btnTrailerType_MouseHover(object sender, EventArgs e)
        {
            lablTrailerType.Visible = true;
        }

        private void btnTrailerType_MouseLeave(object sender, EventArgs e)
        {
            lablTrailerType.Visible = false;
        }

        private void txtOwnerApu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnCatalogs_Click(object sender, EventArgs e)
        {
            frmPrintCatalogs catalogs = new frmPrintCatalogs();
            catalogs.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpTruckFleet helpTruckFleet = new frmHelpTruckFleet();
            helpTruckFleet.Show();
        }
    }
}
