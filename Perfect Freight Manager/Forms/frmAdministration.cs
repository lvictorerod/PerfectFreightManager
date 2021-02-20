using Npgsql;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms
{
   
    public partial class frmAdministration : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        string TblName = "adminsystems";
        int codigo;
        string ruta;
        int timeout = 0;
        int cuantos = 0;
        float SizeDataBase = 0, SizeBackup = 0;
        private string raiz = "", route = "", backupdir = "", backupFile = "", restoredir = "";


        public frmAdministration(string usuario)
        {
            InitializeComponent();
            btnAddData.Enabled = true;
            btnDelData.Enabled = false;
            btnUpdData.Enabled = false;

            btnAddUser.Enabled = true;
            btnDelUser.Enabled = false;
            btnUpdUser.Enabled = false;

            btnAddAccess.Enabled = true;
            btnDelAccess.Enabled = false;
            btnUpdAccess.Enabled = false;

            btnBackup.Enabled = false;
            btnRestore.Enabled = false;
            dgvRoute.DataSource = conectandose.Consultar(TblName);

            string query = "SELECT pg_database_size('PerfectFreight')/1048576.0 AS size_in_mb;";
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(query, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                string valor = dr["size_in_mb"].ToString();
                SizeDataBase = (float)Convert.ToDouble(valor);
            }
            conn.Close();

            string cadena2 = "select * from adminsystems";

            conn.Open();
            NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn);
            NpgsqlDataReader dr2 = comando2.ExecuteReader();
            while (dr2.Read())
            {
                raiz = dr2["rphotodoc"].ToString();
                route = dr2["rprogram"].ToString();
            }
            conn.Close();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabRoute")
            {
                TblName = "adminsystems";
                dgvRoute.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tabUsers")
            {
                TblName = "adminusers";
                dgvUsers.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tabAccess")
            {
                cbUserAccess.Items.Clear();
                cbUserAccess.Text = "Select User";
                TblName = "adminaccess";
                string cadena = "select name from adminusers";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    cbUserAccess.Items.Add(dr["name"].ToString());
                }
                conn.Close();
                dgvAccess.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tabMtto")
            {
                TblName = "adminmaintenances";
                dgvAlertsMto.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tabCompany")
            {
                TblName = "admincompanys";
                dgvCompany.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tabConvert")
            {
                cbTables.Items.Clear();
                cbTables.Items.Add("adminaccess");
                cbTables.Items.Add("adminsystems");
                cbTables.Items.Add("adminusers");
                cbTables.Items.Add("-------------");
                cbTables.Items.Add("agents");
                cbTables.Items.Add("brokers");
                cbTables.Items.Add("citystates");
                cbTables.Items.Add("clients");
                cbTables.Items.Add("codezips");
                cbTables.Items.Add("companyprofiles");
                cbTables.Items.Add("driverprofiles");
                cbTables.Items.Add("insurances");
                cbTables.Items.Add("phonebooks");
                cbTables.Items.Add("vendors");
                cbTables.Items.Add("trailersprofiles");
                cbTables.Items.Add("trucksprofiles");
                cbTables.Items.Add("--------------");
                cbTables.Items.Add("revenues");
                cbTables.Items.Add("rvpickupdrops");
                cbTables.Items.Add("rvfuels");
                cbTables.Items.Add("rvroutes");
            }
            if (tabControl1.SelectedTab.Name == "tabBackup")
            {
                lblSizeDB.Text = lblSizeDB.Text + SizeDataBase + " MB";
                string rootPath = raiz + @"Documents\Backup";
                
                backupdir = rootPath + "\\";
                backupFile = backupdir + "Backup#" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd") + "_" + DateTime.Now.ToString("yyyy") + "_Time»" + DateTime.Now.ToString("HH") + "-" + DateTime.Now.ToString("mm") + ".backup";
                if (!Directory.Exists(rootPath))
                    Directory.CreateDirectory(rootPath);
                var files = Directory.GetFiles(rootPath, "*.backup", SearchOption.TopDirectoryOnly);
                listBackup.Items.Clear();
                listBackup.BeginUpdate();
                if (files.Length != 0)
                {
                    //listBackup.Items.Add("DRIVERS License Expire" + "(" + LicExpire.ToString() + ")");
                    listBackup.Items.Add("BACKUP Files Name\r\n");
                    listBackup.Items.Add(" ");
                    listBackup.Items.Add("You should select Last Backup File");
                    listBackup.Items.Add("for calculate rate");
                    listBackup.Items.Add(" ");
                    //Incidencias.Add(LicExpire);
                    foreach (string file in files)
                    {
                        listBackup.Items.Add(Path.GetFileName(file));
                    }
                }
                else
                {
                    listBackup.Items.Add("DO NOT EXIST BACKUP FILE YET");
                    listBackup.Items.Add(" ");
                    listBackup.Items.Add("Make your Backup...");
                }
                listBackup.EndUpdate();

            }
        }

        /// ///////////////////////////////////////////
        /// SYSTEM
        ///////////////////////////////////////////////
        /////////////
        private void btnSearchCdl_Click_1(object sender, EventArgs e)
        {
            ruta = findRoute();
            txtCDL.Text = ruta;
        }

        private void btnProgram_Click_1(object sender, EventArgs e)
        {
            ruta = findRoute();
            txtProgram.Text = ruta;
        }

        private string findRoute()
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            
            if (fd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ruta = fd.SelectedPath + "\\"; //fd.FileName;
                    //indice = ruta.LastIndexOf("\\");
                    //ruta = ruta.Remove(indice + 1);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "PerfectFreight Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ruta;
        }



        private void dgvRoute_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddData.Enabled = false;
            btnDelData.Enabled = true;
            btnUpdData.Enabled = true;

            codigo = Convert.ToInt32(dgvRoute.Rows[e.RowIndex].Cells[0].Value);

            txtCDL.Text = Convert.ToString(dgvRoute.Rows[e.RowIndex].Cells[1].Value);
            txtProgram.Text = Convert.ToString(dgvRoute.Rows[e.RowIndex].Cells[2].Value);
            cbBrowser.Text = Convert.ToString(dgvRoute.Rows[e.RowIndex].Cells[3].Value);
            txtDue.Text = Convert.ToString(dgvRoute.Rows[e.RowIndex].Cells[4].Value);
            txtPast.Text = Convert.ToString(dgvRoute.Rows[e.RowIndex].Cells[5].Value);
            txtOustanding.Text = Convert.ToString(dgvRoute.Rows[e.RowIndex].Cells[6].Value);

        }

        private void btnClearRoute_Click(object sender, EventArgs e)
        {
            txtCDL.Text = "";
            txtProgram.Text = "";
            cbBrowser.Text = "";
            txtDue.Text = "";
            txtPast.Text = "";
            txtOustanding.Text = "";
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            if (txtCDL.Text != "" && txtProgram.Text != "")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into adminsystems (rphotodoc,rprogram,browsepref,dueinvoice,pastinvoice,outinvoice) values ('" + txtCDL.Text + "','" + txtProgram.Text + "','" + cbBrowser.Text + "','" + txtDue.Text + "','" + txtPast.Text + "','" + txtOustanding.Text + "')", conn);
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
            else MessageBox.Show("Lack data, check that have:\nDocument, Program", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvRoute.DataSource = conectandose.Consultar(TblName);
            btnAddData.Enabled = false;
            btnDelData.Enabled = true;
            btnUpdData.Enabled = true;
        }

        private void btnDelData_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnClearRoute_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvRoute.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpdData_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update adminsystems set rphotodoc='" + txtCDL.Text + "',rprogram='" + txtProgram.Text + "',browsepref='" + cbBrowser.Text + "',dueinvoice='" + txtDue.Text + "',pastinvoice='" + txtPast.Text + "',outinvoice='" + txtOustanding.Text + "'" + " where id=" + codigo, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
                //description='" + txtDescription.Text + "',paycategory='" + cbCategory.Text + "',payamount='" + txtPayAmount.Text + "',
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvRoute.DataSource = conectandose.Consultar(TblName);
        }
        //////////////////////////////////////////////////
        /// USERS
        //////////////////////////////////////////////////
        ////////
        ///
        private void btnFindCSZ_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("codezips","");
            search.ShowDialog();
            txtCity.Text = search.Nombre;
            txtState.Text = search.Estado;
            txtZip.Text = search.Zip;
        }

        private void btnClearUser_Click(object sender, EventArgs e)
        {
            btnAddUser.Enabled = true;
            btnUpdUser.Enabled = false;
            btnDelUser.Enabled = false;

            txtName.Text = "";
            txtAdrress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtNick.Text = "";
            txtPassw.Text = "";
            txtNotes.Text = "";
            dtDateStart.Text = DateTime.Now.ToString();
            dtDateEnd.Text = DateTime.Now.ToString();
            pbUserPhoto.Image = null;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddUser.Enabled = false;
            btnUpdUser.Enabled = true;
            btnDelUser.Enabled = true;

            codigo = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells[0].Value);

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
            pbUserPhoto.Image = System.Drawing.Bitmap.FromStream(ms);
            conn.Close();

            txtName.Text = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells[1].Value);
            txtAdrress.Text = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells[2].Value);
            txtCity.Text = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells[3].Value);
            txtState.Text = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells[4].Value);
            txtZip.Text = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells[5].Value);
            txtNick.Text = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells[6].Value);
            txtPassw.Text = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells[7].Value);
            txtNotes.Text = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells[8].Value);
            dtDateStart.Value = Convert.ToDateTime(dgvUsers.Rows[e.RowIndex].Cells[9].Value);
            dtDateEnd.Value = Convert.ToDateTime(dgvUsers.Rows[e.RowIndex].Cells[10].Value);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!(txtName.Text == "" || txtNick.Text == "" || txtPassw.Text == "" || pbUserPhoto.Image == null))
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into adminusers (name,address,city,state,codezip,nick,password,notes,datestart,dateend,photo) values  ('" + txtName.Text + "','" + txtAdrress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZip.Text + "','" + txtNick.Text + "','" + txtPassw.Text + "',@notes,'" + dtDateStart.Value + "','" + dtDateEnd.Value + "', @photo)", conn);
                    MemoryStream ms = new MemoryStream();
                    pbUserPhoto.Image.Save(ms, ImageFormat.Jpeg);
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
            else MessageBox.Show("Lack data, check that have:\nName, Nick, Photo and Password", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvUsers.DataSource = conectandose.Consultar(TblName);
            btnAddUser.Enabled = false;
            btnUpdUser.Enabled = true;
            btnDelUser.Enabled = true;
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnClearUser_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Record Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvUsers.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpdUser_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update adminusers set name='" + txtName.Text + "',address='" + txtAdrress.Text + "',city='" + txtCity.Text + "',state='" + txtState.Text + "',codezip='" + txtZip.Text + "',nick='" + txtNick.Text + "',password='" + txtPassw.Text + "',notes=@notes,datestart='" + dtDateStart.Value + "',dateend='" + dtDateEnd.Value + "', photo=@photo" + " where id=" + codigo, conn);
                MemoryStream ms = new MemoryStream();
                pbUserPhoto.Image.Save(ms, ImageFormat.Jpeg);
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
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvUsers.DataSource = conectandose.Consultar(TblName);
        }

        private void btnSelDriverPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png; ";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbUserPhoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }
        //////////////////////////////////////////////////
        /// ACCESS
        //////////////////////////////////////////////////
        ////////
        private void btnClearAccess_Click(object sender, EventArgs e)
        {
            cbUserAccess.Items.Clear();
            cbUserAccess.Text = "Select User";
            TblName = "adminaccess";
            string cadena = "select name from adminusers";

            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                cbUserAccess.Items.Add(dr["name"].ToString());
            }
            conn.Close();

            for (int count = 0; count < chkSubLoad.Items.Count; count++)
            {
                chkSubLoad.SetItemChecked(count, false);
            }
            for (int count = 0; count < chkSubCatalogs.Items.Count; count++)
            {
                chkSubCatalogs.SetItemChecked(count, false);
            }

            chkSubExpense.Checked = false;
            chkSubTripPlanner.Checked = false;

        }
        private void dgvAccess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToString(dgvAccess.Rows[e.RowIndex].Cells[10].Value) == "True")
                chkSubExpense.Checked = true;
            else chkSubExpense.Checked = false;
            if (Convert.ToString(dgvAccess.Rows[e.RowIndex].Cells[10].Value) == "True")
                chkSubTripPlanner.Checked = true;
            else chkSubTripPlanner.Checked = false;
        }

        private void btnAddAccess_Click(object sender, EventArgs e)
        {
            if(cbUserAccess.Text != "")
            {

            }
            else MessageBox.Show("Lack data, check that have:\nUser", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelAccess_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdAccess_Click(object sender, EventArgs e)
        {

        }

        ////////////////////////////////////////////
        /// MANTENIMIENTO
        ////////////////////////////////////////////
        ////////
        private void dgvAlertsMto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddMto.Enabled = false;
            btnDelMto.Enabled = true;
            btnUpdMto.Enabled = true;

            codigo = Convert.ToInt32(dgvAlertsMto.Rows[e.RowIndex].Cells[0].Value);

            txtPMIni.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[1].Value);
            txtPMStop.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[2].Value);
            txtT2Ini.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[3].Value);
            txtT2STop.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[4].Value);
            txtT3Ini.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[5].Value);
            txtT3Stop.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[6].Value);
            txtTLIni.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[7].Value);
            txtTLStop.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[8].Value);
            //txtTL2Ini.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[9].Value);
            //txtTL2Stop.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[10].Value);
            //txtTL3Ini.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[11].Value);
            //txtTL3Stop.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[12].Value);
            txtAPUIni.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[13].Value);
            txtAPUStop.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[14].Value);
            txtAPURate.Text = Convert.ToString(dgvAlertsMto.Rows[e.RowIndex].Cells[15].Value);
            dtsummerfrom.Value = Convert.ToDateTime(dgvAlertsMto.Rows[e.RowIndex].Cells[16].Value);
            dtsummerto.Value = Convert.ToDateTime(dgvAlertsMto.Rows[e.RowIndex].Cells[17].Value);
            dtwinterfrom.Value = Convert.ToDateTime(dgvAlertsMto.Rows[e.RowIndex].Cells[18].Value);
            dtwinterto.Value = Convert.ToDateTime(dgvAlertsMto.Rows[e.RowIndex].Cells[19].Value);
        }
        private void btnClearMto_Click(object sender, EventArgs e)
        {
            txtPMIni.Text = "8000";
            txtPMStop.Text = "20000";
            txtT2Ini.Text = "13000";
            txtT2STop.Text = "20000";
            txtT3Ini.Text = "30000";
            txtT3Stop.Text = "60000";
            txtTLIni.Text = "13000";
            txtTLStop.Text = "20000";
            txtTL2Ini.Text = "0";
            txtTL2Stop.Text = "0";
            txtTL3Ini.Text = "0";
            txtTL3Stop.Text = "0";
            txtAPUIni.Text = "1500";
            txtAPUStop.Text = "2000";
            txtAPURate.Text = "30";
            dtsummerfrom.Text = "";
            dtsummerto.Text = "";
            dtwinterfrom.Text = "";
            dtwinterto.Text = "";

            btnAddMto.Enabled = true;
            btnDelMto.Enabled = false;
            btnUpdMto.Enabled = false;
        }

        private void btnAddMto_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into adminmaintenances (trucktipopm,truckstoppm,trucktipo2,truckstoptipo2,trucktipo3,truckstoptipo3,trailertipopm,trailerstoppm,apu,apustop,apurate,suumerfrom,summerto,winterfrom,winterto) values  ('" + txtPMIni.Text + "','" + txtPMStop.Text + "','" + txtT2Ini.Text + "','" + txtT2STop.Text + "','" + txtT3Ini.Text + "','" + txtT3Stop.Text + "','" + txtTL2Ini.Text + "','" + txtTL2Stop.Text + "','" + txtAPUIni.Text + "','" + txtAPUStop.Text + "','" + txtAPURate.Text + "','" + dtsummerfrom.Value + "','" + dtsummerto.Value + "','" + dtwinterfrom.Value + "','" + dtwinterto.Value + "',)", conn);
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
            dgvAlertsMto.DataSource = conectandose.Consultar(TblName);
            btnAddMto.Enabled = false;
            btnDelMto.Enabled = true;
            btnUpdMto.Enabled = true;
        }

        private void btnDelMto_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnClearUser_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Record Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvAlertsMto.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpdMto_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update adminmaintenances set trucktipopm='" + txtPMIni.Text + "',truckstoppm='" + txtPMStop.Text + "',trucktipo2='" + txtT2Ini.Text + "',truckstoptipo2='" + txtT2STop.Text + "',trucktipo3='" + txtT3Ini.Text + "',truckstoptipo3='" + txtT3Stop.Text + "',trailertipopm='" + txtTLIni.Text + "',trailerstoppm='" + txtTLStop.Text + "',apu='" + txtAPUIni.Text + "',apustop='" + txtAPUStop.Text + "',apurate='" + txtAPURate.Text + "',summerfrom='" + dtsummerfrom.Value + "',summerto='" + dtsummerto.Value + "',winterfrom='" + dtwinterfrom.Value + "',winterto='" + dtwinterto.Value + "'" + " where id=" + codigo, conn);
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
            dgvAlertsMto.DataSource = conectandose.Consultar(TblName);
        }

        ////////////////////////////////////////////
        /// GENERALES
        ////////////////////////////////////////////
        ///////
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpAdministration helpAdministration = new frmHelpAdministration();
            helpAdministration.Show();
        }

        private void btnSearchCdl_MouseHover(object sender, EventArgs e)
        {
            lblCdl.Visible = true;
        }

        private void btnSearchCdl_MouseLeave(object sender, EventArgs e)
        {
            lblCdl.Visible = false;
        }
        private void btnProgram_MouseHover(object sender, EventArgs e)
        {
            lblProgram.Visible = true;
        }
        private void btnProgram_MouseLeave(object sender, EventArgs e)
        {
            lblProgram.Visible = false;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            int valor = 0;
            cuantos = dgvConvert.Rows.Count;
            valor = cuantos;
            int sgte = 0;
            int column = (int)dgvConvert.Columns[txtColumn.Text].Index;

            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = valor;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Show();

            while (cuantos > 0)
            { 
                codigo = Convert.ToInt32(dgvConvert.Rows[sgte].Cells[0].Value);
                lblIndice.Text = codigo.ToString();
                string texto = Convert.ToString(dgvConvert.Rows[sgte].Cells[column].Value);
                if (texto.Contains("'"))
                {
                    int indice = texto.IndexOf("'");
                    texto = texto.Remove(indice,1);
                }
                texto = texto.ToUpper();
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("update " +  cbTables.Text + " set " + txtColumn.Text + " = '" + texto + "'" + " where id=" + codigo, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
                cuantos--;
                sgte++;
                if(circularProgressBar1.Value < circularProgressBar1.Maximum)
                    circularProgressBar1.Value += 1;
                circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            }
            circularProgressBar1.Hide();
            dgvConvert.DataSource = conectandose.Consultar(TblName);
        }

        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            TblName = cbTables.Text;
            dgvConvert.DataSource = conectandose.Consultar(TblName);
        }

        private void txtCDL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbUserAccess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtName.Text = (txtName.Text).ToUpper();
        }

        private void txtAdrress_Leave(object sender, EventArgs e)
        {
            txtAdrress.Text = (txtAdrress.Text).ToUpper();
        }

        private void txtPMIni_KeyPress(object sender, KeyPressEventArgs e)
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
        ///////////////////////////////////////////////////////////
        /// BACKUP & RESTORE
        /// </summary>
        ///////////////////////////////////////////////////////////
        
        public void btnBackup_Click(object sender, EventArgs e)
        {
            if (txtTimeOut.Text == "0")
            {
                txtTimeOut.Text = "120000";
                timeout = 120000;
            }
            BackupDatabase(
                "localhost",
                "5432",
                "postgres",
                "123456",
                "PerfectFreight",
                "C:\\Program Files\\PostgreSQL\\13\\bin\\");
            tabControl1_SelectedIndexChanged(sender, e);
        }

        private void listBackup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Selecciona el item de la lista
            string alerta = (string)listBackup.Items[listBackup.SelectedIndex];
            if (alerta == " " || alerta.Contains("BACKUP Files Name") || alerta.Contains("You should") || alerta.Contains("calculate"))
            {
                MessageBox.Show("This seleted is incorrect", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string file = backupdir + alerta;
                lblBckupSize.Text = "Size Last Backup = ";
                FileStream path = new FileStream(file, FileMode.Open, FileAccess.Read);
                SizeBackup = (float)path.Length / 1048576;
                path.Close();
                lblBckupSize.Text = lblBckupSize.Text + SizeBackup + " MB";
                float indice = SizeDataBase / SizeBackup / 3;
                timeout = Convert.ToInt32((indice * 120000));
                txtTimeOut.Text = Convert.ToInt32((indice * 120000)).ToString();
                restoredir = backupdir + alerta;
                btnBackup.Enabled = true;
                btnRestore.Enabled = true;
                txtSelected.Text = alerta;
                //MessageBox.Show("Backup selected: " + alerta);
            }
        }
        public void BackupDatabase(
            string server,
            string port,
            string user,
            string password,
            string dbname,
            string backupCommandDir)
        { 
            try
            {
                Environment.SetEnvironmentVariable("PGPASSWORD", password);

                //string backupFile = backupdir + backupFileName + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd") + "_" + DateTime.Now.ToString("yyyy") + "_Time»" + DateTime.Now.ToString("HH") + "-" + DateTime.Now.ToString("mm") + ".backup";

                string BackupString = " -U " + user + " -h " + server + " -p " + port + " -d " + dbname + " --format=c --blobs --verbose -f \"" + backupFile;

                using (Process proc = new Process())
                {
                    proc.StartInfo.FileName = backupCommandDir + "\\pg_dump.exe";

                    proc.StartInfo.Arguments = BackupString;

                    proc.StartInfo.RedirectStandardOutput = true;//for error checks BackupString
                    proc.StartInfo.RedirectStandardError = true;

                    proc.StartInfo.UseShellExecute = false;//use for not opening cmd screen
                    proc.StartInfo.CreateNoWindow = true;//use for not opening cmd screen

                    StringBuilder output = new StringBuilder();
                    StringBuilder error = new StringBuilder();

                    using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                    using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                    {
                        proc.OutputDataReceived += (sender, e) =>
                        {
                            if (e.Data == null)
                            {
                                outputWaitHandle.Set();
                            }
                            else
                            {
                                output.AppendLine(e.Data);
                            }
                        };
                        proc.ErrorDataReceived += (sender, e) =>
                        {
                            if (e.Data == null)
                            {
                                errorWaitHandle.Set();
                            }
                            else
                            {
                                error.AppendLine(e.Data);
                            }
                        };
                        proc.Start();
                        proc.BeginOutputReadLine(); 
                        
                        proc.BeginErrorReadLine();
                        if (proc.WaitForExit(timeout) &&
                        outputWaitHandle.WaitOne(timeout) &&
                        errorWaitHandle.WaitOne(timeout))
                        {
                            // Process completed. Check process.ExitCode here.
                            proc.WaitForExit();
                            proc.Close();

                            MessageBox.Show("Backup successfully created");
                            
                        }
                        else
                        {
                            MessageBox.Show("Backup > 30 minutes\r\n"+ "Consult with the system administrator");
                            // Timed out.Fil
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        ///////////////////////////////////////////
        /// RESTORE
        //////////////////////////////////////////
        ///
        
        private void btnRestore_Click(object sender, EventArgs e)
        {
            RestoreDatabase(
                "localhost",
                "5432",
                "postgres",
                "123456",
                "PerfectFreight",
                "C:\\Program Files\\PostgreSQL\\13\\bin\\");
        }

        //dropdb mydb
        //    pg_restore - C - d postgres db.dump
        public void RestoreDatabase(
        string server,
        string port,
        string user,
        string password,
        string dbname,
        string restoreCommandDir)
        {
            try
            {
                Environment.SetEnvironmentVariable("PGPASSWORD", password);

                string RestoreString = " -h " + server + " -p " + port + " -U " + user + " -d " + dbname + " --verbose " + restoredir;

                using (Process procrestore = new Process())
                {
                    procrestore.StartInfo.FileName = restoreCommandDir + "\\pg_restore.exe";
                    procrestore.StartInfo.Arguments = RestoreString;

                    procrestore.StartInfo.UseShellExecute = false;//use for not opening cmd screen
                    procrestore.StartInfo.CreateNoWindow = true;//use for not opening cmd screen

                    procrestore.StartInfo.RedirectStandardInput = true;//for error checks RestoreString
                    procrestore.StartInfo.RedirectStandardError = true;

                    StringBuilder input = new StringBuilder();
                    StringBuilder error = new StringBuilder();

                    using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                    {
                        procrestore.ErrorDataReceived += (sender, e) =>
                        {
                            if (e.Data == null)
                            {
                                errorWaitHandle.Set();
                            }
                            else
                            {
                                error.AppendLine(e.Data);
                            }
                        };
                        procrestore.Start();

                        procrestore.BeginErrorReadLine();
                        if (procrestore.WaitForExit(120000) &&
                        errorWaitHandle.WaitOne(120000))
                        {
                            // Process completed. Check process.ExitCode here.
                            procrestore.WaitForExit();
                            procrestore.Close();

                            MessageBox.Show("Restore successfully created");
                        }
                        else
                        {
                            MessageBox.Show("Restore > 30 minutes\r\n" + "Consult with the system administrator");
                            // Timed out.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
