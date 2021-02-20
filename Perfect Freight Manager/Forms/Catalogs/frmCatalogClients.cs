using iText.IO.Image;
using Npgsql;
using Perfect_Freight_Manager.Forms;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Catalogs
{
    public partial class frmCatalogClient : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        private string TblName = "brokers";
        private int codigo;
        private string idBroker, nameBroker;

        private int sgtebr = 0, cuentabr = 0;
        private int sgteag = 0, cuentaag = 0;
        private int sgtect = 0, cuentact = 0;
        private string raiz = "";
        private bool mensaje = false, refresh = false;
        public frmCatalogClient()
        {
            InitializeComponent();
            btnAdiciona.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            dgvBroker.DataSource = conectandose.Consultar(TblName);
            cuentabr = dgvBroker.Rows.GetRowCount(0);
            lbRecord.Text = "Record " + sgtebr + " of " + cuentabr;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabBrokers")
            {
                TblName = "brokers";
                dgvBroker.DataSource = conectandose.Consultar(TblName);
            }
            if (tabControl1.SelectedTab.Name == "tabAgents")
            {
                TblName = "agents";
                dgvAgents.DataSource = conectandose.Consultar(TblName);
                cuentaag = dgvAgents.Rows.GetRowCount(0);
                lbRecordAgents.Text = "Record " + sgteag + " of  " + cuentaag;
                string cadena = "select name from brokers order by id"; // + idClient;
                conn2.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn2);
                NpgsqlDataReader dr = comando.ExecuteReader();
                
                while (dr.Read())
                {
                    cbBrockers.Items.Add(Convert.ToString(dr["name"]));
                }

                conn2.Close();
            }
            if (tabControl1.SelectedTab.Name == "tabClients")
            {
                TblName = "clients";
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
                cuentact = dgvConsulta.Rows.GetRowCount(0);
                lbRecordCustomer.Text = "Record " + sgtect + " of  " + cuentact;
            }

        }
        /// <summary>//////////////////////////////////
        /// BROKERS
        /// </summary>/////////////////////////////////
        ///  
        private void btnTBrokerFirst_Click(object sender, EventArgs e)
        {
            cuentabr = dgvBroker.Rows.GetRowCount(0);
            sgtebr = dgvBroker.Rows.GetFirstRow(0);
            dgvBroker_RowEnter(sender, e);
            rellenabr();
        }

        private void btnBrokerPrevios_Click(object sender, EventArgs e)
        {
            cuentabr = dgvBroker.Rows.GetRowCount(0);
            sgtebr = dgvBroker.Rows.GetPreviousRow(sgtebr, 0);
            if (sgtebr == -1) sgtebr = cuentabr - 1;
            if (sgtebr <= cuentabr && sgtebr >= 0)
            {
                dgvBroker_RowEnter(sender, e);
                rellenabr();
            }
        }

        private void btnBrokerNext_Click(object sender, EventArgs e)
        {
            cuentabr = dgvBroker.Rows.GetRowCount(0);
            sgtebr = dgvBroker.Rows.GetNextRow(sgtebr, 0);
            if (sgtebr == -1) sgtebr = 0;
            if (sgtebr <= cuentabr && sgtebr >= 0)
            {
                dgvBroker_RowEnter(sender, e);
                rellenabr();
            }
        }
        private void btnBrokerEnd_Click(object sender, EventArgs e)
        {
            cuentabr = dgvBroker.Rows.GetRowCount(0);
            sgtebr = dgvBroker.Rows.GetLastRow(0);
            dgvBroker_RowEnter(sender, e);
            rellenabr();
        }
        private void dgvBroker_RowEnter(object sender, EventArgs e)
        {
            dgvBroker.ClearSelection();
            dgvBroker.Rows[sgtebr].Selected = true;
            dgvBroker.FirstDisplayedScrollingRowIndex = dgvBroker.Rows.GetNextRow(sgtebr - 1, 0);
        }
        private void txtBrokerSearch_TextChanged(object sender, EventArgs e)
        {
            btnBorkerAdd.Enabled = false;
            btnBorkerUpd.Enabled = true;
            btnBorkerDel.Enabled = true;

            string search = (txtBrokerSearch.Text).ToUpper();
            if (txtBrokerSearch.Text != "")
            {
                dgvBroker.DataSource = conectandose.ConsultarWith(TblName, search);
                sgtebr = 0;
                cuentabr = dgvBroker.Rows.GetRowCount(0);
                if (cuentabr != 0)
                    rellenabr();
            }
            
        }
        private void rellenabr()
        {
            btnBorkerAdd.Enabled = false;
            btnBorkerDel.Enabled = true;
            btnBorkerUpd.Enabled = true;

            codigo = Convert.ToInt32(dgvBroker.Rows[sgtebr].Cells[0].Value);

            txtBrokerName.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[1].Value);
            txtBrokerAddress.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[2].Value);
            txtBrokerAddress2.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[3].Value);
            txtBrokerCity.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[4].Value);
            txtBrokerState.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[5].Value);
            txtBrokerZip.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[6].Value);
            txtBrokerPhone.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[7].Value);
            txtBrokerPhoneToll.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[8].Value);
            txtBrokerCellPhone.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[9].Value);
            txtBrokerCellService.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[10].Value);
            txtBrokerFax.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[11].Value);
            txtBrokerEmergency.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[12].Value);
            txtBrokerNotes.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[13].Value);
            txtBrokerMC.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[14].Value);
            txtBrokerDOT.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[15].Value);
            txtBrokerEmail.Text = Convert.ToString(dgvBroker.Rows[sgtebr].Cells[16].Value);

            lbRecord.Text = "Record " + (sgtebr + 1) + " of  " + cuentabr;
            //Calificacion del Broker
            string cadena3 = "select * from adminsystems";
            conn2.Open();
            NpgsqlCommand comando3 = new NpgsqlCommand(cadena3, conn2);
            NpgsqlDataReader dr3 = comando3.ExecuteReader();
            while (dr3.Read())
            {
                raiz = dr3["rprogram"].ToString();
            }
            conn2.Close();
            string cadena2 = "select client, factorydate, factorypaid from revenues where client like '" + txtBrokerName.Text + "'";
            conn2.Open();
            NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
            NpgsqlDataReader dr2 = comando2.ExecuteReader();
            double cuantos, bueno, rate;
            cuantos = 0; bueno = 0; rate = 0;
            while (dr2.Read())
            {
                string broker = dr2["client"].ToString();
                DateTime fechadate = Convert.ToDateTime(dr2["factorydate"]);
                DateTime fechapaid = Convert.ToDateTime(dr2["factorypaid"]);
                TimeSpan tspan = fechapaid - fechadate;
                int dias = tspan.Days;
                if (dias <= 1)
                    bueno++;
                cuantos++;
            }
            conn2.Close();
            if (cuantos != 0)
            {
                double good = (bueno / cuantos)*100;
                rate = (bueno / cuantos) * 5;
                if (good == 0)
                {
                    pb1.Image = Image.FromFile(raiz + @"icon0.png");
                    pb2.Image = Image.FromFile(raiz + @"icon0.png");
                    pb3.Image = Image.FromFile(raiz + @"icon0.png");
                    pb4.Image = Image.FromFile(raiz + @"icon0.png");
                    pb5.Image = Image.FromFile(raiz + @"icon0.png");
                    lblValor.Text = rate.ToString();
                }
                else if (good > 0 && good <= 40)
                {
                    pb1.Image = Image.FromFile(raiz + @"icon100.png");
                    pb2.Image = Image.FromFile(raiz + @"icon25.png");
                    pb3.Image = Image.FromFile(raiz + @"icon0.png");
                    pb4.Image = Image.FromFile(raiz + @"icon0.png");
                    pb5.Image = Image.FromFile(raiz + @"icon0.png");
                    lblValor.Text = rate.ToString();
                }
                else if(good > 40 && good <= 60)
                {
                    pb1.Image = Image.FromFile(raiz + @"icon100.png");
                    pb2.Image = Image.FromFile(raiz + @"icon100.png");
                    pb3.Image = Image.FromFile(raiz + @"icon25.png");
                    pb4.Image = Image.FromFile(raiz + @"icon0.png");
                    pb5.Image = Image.FromFile(raiz + @"icon0.png");
                    lblValor.Text = rate.ToString();
                }
                else if(good > 60 && good <= 80)
                {
                    pb1.Image = Image.FromFile(raiz + @"icon100.png");
                    pb2.Image = Image.FromFile(raiz + @"icon100.png");
                    pb3.Image = Image.FromFile(raiz + @"icon100.png");
                    pb4.Image = Image.FromFile(raiz + @"icon25.png");
                    pb5.Image = Image.FromFile(raiz + @"icon0.png");
                    lblValor.Text = rate.ToString();
                }
                else if (good > 80 && good < 100)
                {
                    pb1.Image = Image.FromFile(raiz + @"icon100.png");
                    pb2.Image = Image.FromFile(raiz + @"icon100.png");
                    pb3.Image = Image.FromFile(raiz + @"icon100.png");
                    pb4.Image = Image.FromFile(raiz + @"icon100.png");
                    pb5.Image = Image.FromFile(raiz + @"icon25.png");
                    lblValor.Text = rate.ToString();
                }
                else
                {
                    pb1.Image = Image.FromFile(raiz + @"icon100.png");
                    pb2.Image = Image.FromFile(raiz + @"icon100.png");
                    pb3.Image = Image.FromFile(raiz + @"icon100.png");
                    pb4.Image = Image.FromFile(raiz + @"icon100.png");
                    pb5.Image = Image.FromFile(raiz + @"icon100.png");
                    lblValor.Text = rate.ToString();
                }
            }
            else
            {
                pb1.Image = Image.FromFile(raiz + @"icon0.png");
                pb2.Image = Image.FromFile(raiz + @"icon0.png");
                pb3.Image = Image.FromFile(raiz + @"icon0.png");
                pb4.Image = Image.FromFile(raiz + @"icon0.png");
                pb5.Image = Image.FromFile(raiz + @"icon0.png");
                lblValor.Text = rate.ToString();
            }
        }
        private void btnClearBroker_Click(object sender, EventArgs e)
        {
            btnBorkerAdd.Enabled = true;
            btnBorkerDel.Enabled = false;
            btnBorkerUpd.Enabled = false;

            txtBrokerName.Text = "";
            txtBrokerAddress.Text = "";
            txtBrokerAddress2.Text = "";
            txtBrokerCity.Text = "";
            txtBrokerState.Text = "";
            txtBrokerZip.Text = "";
            txtBrokerPhone.Text = "";
            txtBrokerPhoneToll.Text = "";
            txtBrokerCellPhone.Text = "";
            txtBrokerCellService.Text = "";
            txtBrokerFax.Text = "";
            txtBrokerEmergency.Text = "";
            txtBrokerNotes.Text = "";
            txtBrokerMC.Text = "";
            txtBrokerDOT.Text = "";
            txtBrokerEmail.Text = "";
            txtBrokerSearch.Text = "";
            dgvBroker.DataSource = conectandose.Consultar(TblName);
            cuentabr = dgvBroker.Rows.GetRowCount(0);
            sgtebr = 0;
            lbRecord.Text = "Record " + (sgtebr) + " of  " + cuentabr;

        }
        private void btnBorkerAdd_Click(object sender, EventArgs e)
        {
            if (txtBrokerName.Text != "" && txtBrokerAddress.Text != "" && txtBrokerPhone.Text != "")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into brokers (name,address,address2,city,state,codezip,phonelocal,phonetollfree,cellphone,cellservice,fax,emegencynumber,notes,mcnumber,usddot,email) values ('" + txtBrokerName.Text + "','" + txtBrokerAddress.Text + "','" + txtBrokerAddress2.Text + "' ,'" + txtBrokerCity.Text + "','" + txtBrokerState.Text + "','" + txtBrokerZip.Text + "','" + txtBrokerPhone.Text + "','" + txtBrokerPhoneToll.Text + "','" + txtBrokerCellPhone.Text + "','" + txtBrokerCellService.Text + "'," + txtBrokerFax.Text + "','" + txtBrokerEmergency.Text + "','@notes,'" + txtBrokerMC.Text + "','" + txtBrokerDOT.Text + "','" + txtBrokerEmail.Text + "')", conn);
                    cmd.Parameters.AddWithValue("notes", txtBrokerNotes.Text);
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
            else MessageBox.Show("Lack data, check that have:\nBroker, Address and Phone", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvBroker.DataSource = conectandose.Consultar(TblName);
            btnBorkerAdd.Enabled = false;
            btnBorkerDel.Enabled = true;
            btnBorkerUpd.Enabled = true;
        }
        private void btnBorkerDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnClearBroker_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvBroker.DataSource = conectandose.Consultar(TblName);
            }
        }
        private void btnBorkerUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update brokers set name='" + txtBrokerName.Text + "',address='"+ txtBrokerAddress.Text + "',address2='"+ txtBrokerAddress2.Text + "',city='"+ txtBrokerCity.Text + "',state='"+ txtBrokerState.Text + "',codezip='"+ txtBrokerZip.Text + "',phonelocal='"+ txtBrokerPhone.Text + "',phonetollfree='"+ txtBrokerPhoneToll.Text + "',cellphone='"+ txtBrokerCellPhone.Text + "',cellservice='"+ txtBrokerCellService.Text + "',fax='"+ txtBrokerFax.Text + "',emergencynumber='"+ txtBrokerEmergency.Text + "',notes=@notes,mcnumber='"+ txtBrokerMC.Text + "',usddot='"+ txtBrokerDOT.Text + "',email='" + txtBrokerEmail.Text + "'" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("notes", txtBrokerNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correct");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close(); throw;
            }
            dgvBroker.DataSource = conectandose.Consultar(TblName);
        }

        ////////////////////////////
        /// AGENTS
        ////////////////////////////
        ////
        private void btnAgentFrist_Click(object sender, EventArgs e)
        {
            cuentaag = dgvAgents.Rows.GetRowCount(0);
            sgteag = dgvAgents.Rows.GetFirstRow(0);
            dgvAgents_RowEnter(sender, e);
            rellenaag();
        }

        private void btnAgentPrevious_Click(object sender, EventArgs e)
        {
            cuentaag = dgvAgents.Rows.GetRowCount(0);
            sgteag = dgvAgents.Rows.GetPreviousRow(sgteag, 0);
            if (sgteag == -1) sgteag = cuentaag - 1;
            if (sgteag <= cuentaag && sgteag >= 0)
            {
                dgvAgents_RowEnter(sender, e);
                rellenaag();
            }
        }

        private void btnAgentNext_Click(object sender, EventArgs e)
        {
            cuentaag = dgvAgents.Rows.GetRowCount(0);
            sgteag = dgvAgents.Rows.GetNextRow(sgteag, 0);
            if (sgteag == -1) sgteag = 0;
            if (sgteag <= cuentaag && sgteag >= 0)
            {
                dgvAgents_RowEnter(sender, e);
                rellenaag();
            }
        }

        private void btnAgentEnd_Click(object sender, EventArgs e)
        {
            cuentaag = dgvAgents.Rows.GetRowCount(0);
            sgteag = dgvAgents.Rows.GetLastRow(0);
            dgvAgents_RowEnter(sender, e);
            rellenaag();
        }
        private void dgvAgents_RowEnter(object sender, EventArgs e)
        {
            dgvAgents.ClearSelection();
            dgvAgents.Rows[sgteag].Selected = true;
            dgvAgents.FirstDisplayedScrollingRowIndex = dgvAgents.Rows.GetNextRow(sgteag - 1, 0);
        }
        private void txtAgentsSearch_TextChanged(object sender, EventArgs e)
        {
            btnAgentAdd.Enabled = false;
            btnAgentUpd.Enabled = true;
            btnAgentDel.Enabled = true;

            string search = (txtAgentsSearch.Text).ToUpper();
            if (txtAgentsSearch.Text != "")
            {
                dgvAgents.DataSource = conectandose.ConsultarWith(TblName, search);
                sgteag = 0;
                cuentaag = dgvAgents.Rows.GetRowCount(0);
                if (cuentaag != 0)
                    rellenaag();
            }
            
        }
        private void rellenaag()
        {
            btnAgentAdd.Enabled = false;
            btnAgentDel.Enabled = true;
            btnAgentUpd.Enabled = true;

            codigo = Convert.ToInt32(dgvAgents.Rows[sgteag].Cells[0].Value);

            txtContact.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[1].Value);
            cbBrockers.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[2].Value);
            
            //lbCombo.Text=
            txtDeparment.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[3].Value);
            
            txtContactPhone.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[4].Value);
            txtContactExt.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[5].Value);
            txtContactCell.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[6].Value);
            txtContactFax.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[7].Value);
            txtContactEmail.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[8].Value);
            cbCategory.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[9].Value);
            dtAgrDate.Value = Convert.ToDateTime(dgvAgents.Rows[sgteag].Cells[10].Value);
            txtDetentionPay.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[11].Value);

            if (Convert.ToString(dgvAgents.Rows[sgteag].Cells[12].Value) == "True")
                chkBanned.Checked = true;
            else chkBanned.Checked = false;
            if (Convert.ToString(dgvAgents.Rows[sgteag].Cells[13].Value) == "True")
                chkInactive.Checked = true;
            else chkInactive.Checked = false;
            
            
            dtStartTime.Value = Convert.ToDateTime(dgvAgents.Rows[sgteag].Cells[14].Value);
            txtUsdDot.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[15].Value);
            txtMc.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[16].Value);
            cbAgency.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[17].Value);
            txtPolicy.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[18].Value);
            txtCargo.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[19].Value);
            txtLiability.Text = Convert.ToString(dgvAgents.Rows[sgteag].Cells[20].Value);
            dtExpirationDate.Value = Convert.ToDateTime(dgvAgents.Rows[sgteag].Cells[21].Value);

            lbRecordAgents.Text = "Record " + (sgteag + 1) + " of  " + cuentaag;
        }
        private void btnClearAgent_Click(object sender, EventArgs e)
        {
            btnAgentAdd.Enabled = true;
            btnAgentDel.Enabled = false;
            btnAgentUpd.Enabled = false;

            txtContact.Text = "";
            cbBrockers.Text = "Select Brokers";
            txtDeparment.Text = "";
            cbCategory.Text = "";
            txtContactPhone.Text = "";
            txtContactExt.Text = "";
            txtContactCell.Text = "";
            txtContactFax.Text = "";
            txtContactEmail.Text = "";
            dtAgrDate.Text = "";
            chkBanned.Checked = false;
            chkInactive.Checked = false;
            txtDetentionPay.Text = "";
            dtStartTime.Text = "";
            txtUsdDot.Text = "";
            txtMc.Text = "";
            cbAgency.Text = "";
            txtPolicy.Text = "";
            txtCargo.Text = "";
            txtLiability.Text = "";
            dtExpirationDate.Text = "";
            txtAgentsSearch.Text = "";
            dgvAgents.DataSource = conectandose.Consultar(TblName);
            cuentaag = dgvAgents.Rows.GetRowCount(0);
            sgteag = 0;
            lbRecord.Text = "Record " + (sgteag) + " of  " + cuentaag;
        }

        private void btnAgentAdd_Click(object sender, EventArgs e)
        {
            if (txtContact.Text != "" && cbBrockers.Text != "" && txtContactPhone.Text !="")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into agents (name,idclient,department,phonenumber,extnumber,celphonenumber,faxnumber,email,agreementdate,detentionpay,banned,inactive,startime,usddotnumber,mcnumber,insuranceagency,policynumber,cargoamount,liabilityamount,expirationdate) values ('" + txtContact.Text + "','" + nameBroker + "','"+ txtDeparment.Text + "','"+ txtContactPhone.Text + "','"+ txtContactExt.Text + "','"+ txtContactCell.Text+ "','"+ txtContactFax.Text + "','"+ txtContactEmail.Text + "','"+ dtAgrDate.Value+ "','" + txtDetentionPay.Text + "','" + chkBanned.Checked+ "','"+ chkInactive.Checked + "','"+ dtStartTime.Value + "','"+ txtUsdDot.Text + "','"+ txtMc.Text + "','"+ cbAgency.Text + "','"+ txtPolicy.Text + "','"+ txtCargo.Text + "','"+ txtLiability.Text + "','"+ dtExpirationDate.Value + "')", conn);
                    //cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successfully");
                    refresh = true;
                    //description,paycategory,payamount,
                    //'" + txtDescription.Text + "','" + cbCategory.Text + "','" + txtPayAmount.Text + "',
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
                btnAdiciona.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else MessageBox.Show("Lack data, check that have:\nName Broker, Name Contact and Phone", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAgentDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    refresh = true;
                    btnClearAgent_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvAgents.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnAgentUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update agents set name='" + txtContact.Text + "',idclient='" + nameBroker + "',department='" + txtDeparment.Text + "'," + "phonenumber='" + txtContactPhone.Text + "',extnumber='" + txtContactExt.Text + "',celphonenumber='" + txtContactCell.Text + "',faxnumber='" + txtContactFax.Text + "',email='" + txtContactEmail.Text + "',dptcategory='" + cbCategory.Text + "',agreementdate='" + dtAgrDate.Value + "',detentionpay='" + txtDetentionPay.Text + "',banned='" + chkBanned.Text + "',inactive='" + chkInactive.Text + "',startime='" + dtStartTime.Value + "',usddotnumber='" + txtUsdDot.Text + "',mcnumber='" + txtMc.Text + "',insuranceagency='" + cbAgency.Text + "',policynumber='" + txtPolicy.Text + "',cargoamount='" + txtCargo.Text + "',liabilityamount='" + txtLiability.Text + "',expirationdate='" + dtExpirationDate.Value + "'" + " where id=" + codigo, conn);
                //cmd.Parameters.AddWithValue("notes", txtBrokerNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correct");
                refresh = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close(); throw;
            }
            dgvAgents.DataSource = conectandose.Consultar(TblName);
        }

        /// <summary>//////////////////////////////////
        /// CUSTOMERS
        /// </summary>/////////////////////////////////
        /// 
        private void btnCustomerFirst_Click(object sender, EventArgs e)
        {
            cuentact = dgvConsulta.Rows.GetRowCount(0);
            sgtect = dgvConsulta.Rows.GetFirstRow(0);
            dgvConsulta_RowEnter(sender, e);
            rellenact();
        }

        private void btnCustomerPrevious_Click(object sender, EventArgs e)
        {
            cuentact = dgvConsulta.Rows.GetRowCount(0);
            sgtect = dgvConsulta.Rows.GetPreviousRow(sgtect, 0);
            if (sgtect == -1) sgtect = cuentact - 1;
            if (sgtect <= cuentact && sgtect >= 0)
            {
                dgvConsulta_RowEnter(sender, e);
                rellenact();
            }
        }

        private void btnCustomerNext_Click(object sender, EventArgs e)
        {
            cuentact = dgvConsulta.Rows.GetRowCount(0);
            sgtect = dgvConsulta.Rows.GetNextRow(sgtect, 0);
            if (sgtect == -1) sgtect = 0;
            if (sgtect <= cuentact && sgtect >= 0)
            {
                dgvConsulta_RowEnter(sender, e);
                rellenact();
            }
        }

        private void btnCustomerEnd_Click(object sender, EventArgs e)
        {
            cuentact = dgvConsulta.Rows.GetRowCount(0);
            sgtect = dgvConsulta.Rows.GetLastRow(0);
            dgvConsulta_RowEnter(sender, e);
            rellenact();
        }
        private void dgvConsulta_RowEnter(object sender, EventArgs e)
        {
            dgvConsulta.ClearSelection();
            dgvConsulta.Rows[sgtect].Selected = true;
            dgvConsulta.FirstDisplayedScrollingRowIndex = dgvConsulta.Rows.GetNextRow(sgtect - 1, 0);
        }
        private void rellenact()
        {
            btnAdiciona.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            codigo = Convert.ToInt32(dgvConsulta.Rows[sgtect].Cells[0].Value);

            txtCompany.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[1].Value);
            txtOwner.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[2].Value);
            txtAddress.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[3].Value);
            txtAddress2.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[4].Value);
            txtCity.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[5].Value);
            txtState.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[6].Value);
            txtZip.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[7].Value);
            txtPhone.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[8].Value);
            txtOffice.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[9].Value);
            txtWebsite.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[10].Value);
            txtEmail.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[11].Value);
            txtFaxNumber.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[12].Value);
            txtNotes.Text = Convert.ToString(dgvConsulta.Rows[sgtect].Cells[13].Value);

            lbRecordCustomer.Text = "Record " + (sgtect + 1) + " of  " + cuentact;
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpCustomer helpCustomer = new frmHelpCustomer();
            helpCustomer.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClientClean_Click(object sender, EventArgs e)
        {
            txtCompany.Text = "";
            txtOwner.Text = "";
            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";

            txtPhone.Text = "";
            txtOffice.Text = "";
            txtWebsite.Text = "";
            txtEmail.Text = "";
            txtFaxNumber.Text = "";
            txtNotes.Text = "";
            txtClientsSearch.Text = "";

            dgvConsulta.DataSource = conectandose.Consultar(TblName);
            cuentact = dgvConsulta.Rows.GetRowCount(0);
            sgtect = 0;
            lbRecord.Text = "Record " + (sgtect) + " of  " + cuentact;

            btnAdiciona.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

       
        private void btnAdiciona_Click_1(object sender, EventArgs e)
        {
            if (txtCompany.Text != "" && txtOwner.Text != "" && txtAddress.Text != "" && txtPhone.Text != "")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into clients (name,ownername,address,address2,city,state,codezip,mainphonenumber,officedayhours,website,emailaddress,faxnumber,notes) values ('" + txtCompany.Text + "','" + txtOwner.Text + "','" + txtAddress.Text + "','" + txtAddress2.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZip.Text + "','" + txtPhone.Text + "','" + txtOffice.Text + "','" + txtWebsite.Text + "','" + txtEmail.Text + "','" + txtFaxNumber.Text + "',@notes)", conn);
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
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
                btnAdiciona.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else MessageBox.Show("Lack data, check that have:\nCompany, Owner, Address and Phone", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnClientClean_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvConsulta.DataSource = conectandose.Consultar(TblName);
            }
        }
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update clients set name='" + txtCompany.Text + "',ownername='" + txtOwner.Text + "',address='" + txtAddress.Text + "',address2='" + txtAddress2.Text + "',city='" + txtCity.Text + "',state='" + txtState.Text + "',codezip='" + txtZip.Text + "',mainphonenumber='" + txtPhone.Text + "',officedayhours='" + txtOffice.Text + "',website='" + txtWebsite.Text + "',emailaddress='" + txtEmail.Text + "',faxnumber='" + txtFaxNumber.Text + "',notes=@notes" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correct");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close(); throw;
            }
            dgvConsulta.DataSource = conectandose.Consultar(TblName);
        }

        //////////////////////////////////////////
        /// ACCESO A MAPAS
        /// 
        //////////////////////////////////////////
        ///
        private void button13_Click(object sender, EventArgs e)
        {
            frmCatalogInsurance insurenca = new frmCatalogInsurance();
            insurenca.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //IWebDriver driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("http://www.mapquest.com/?q=,,++");
            //driver.Manage().Window.Maximize();

            //driver.Close();

            frmWebServicio servicio = new frmWebServicio("http://www.mapquest.com/?q=,,++");
            servicio.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //IWebDriver driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("https://www.bing.com/maps/?q=,+,+++");
            //driver.Manage().Window.Maximize();

            //driver.Close();

            frmWebServicio servicio = new frmWebServicio("https://www.bing.com/maps/?q=,+,+++");
            servicio.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //IWebDriver driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("https://www.google.com/maps/place/,+,+++");
            //driver.Manage().Window.Maximize();

            //driver.Close();

            frmWebServicio servicio = new frmWebServicio("https://www.google.com/maps/place/,+,+++");
            servicio.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //IWebDriver driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("https://www.weather.com/weather/today/l/");
            //driver.Manage().Window.Maximize();

            //driver.Close();

            frmWebServicio servicio = new frmWebServicio("https://www.weather.com/weather/today/l/");
            servicio.ShowDialog();
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            frmMail nuevomail = new frmMail(txtContactEmail.Text, "");
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

        private void btnWebsiteGo_Click(object sender, EventArgs e)
        {

        }

        private void btnFinfCSZ_MouseHover(object sender, EventArgs e)
        {
            lblCSZ.Visible = true;
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbBrockers_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvBroker.DataSource = conectandose.ConsultarWith("brokers", cbBrockers.Text);
            idBroker = Convert.ToString(dgvBroker.Rows[0].Cells[0].Value);
            nameBroker = Convert.ToString(dgvBroker.Rows[0].Cells[1].Value);
            lblIndice.Text = idBroker.ToString();
        }

        private void btnFindCSZ_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("codezips", "");
            search.ShowDialog();
            txtBrokerCity.Text = search.Nombre;
            txtBrokerState.Text = search.Estado;
            txtBrokerZip.Text = search.Zip;
        }

        private void btnFindCSZ_MouseHover(object sender, EventArgs e)
        {
            label30.Visible = true;
        }

        private void btnFindCSZ_MouseLeave(object sender, EventArgs e)
        {
            label30.Visible = false;
        }
        public bool Mensaje
        {
            get { return mensaje; }
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mensaje = refresh;
            this.Close();
        }

        private void txtClientsSearch_TextChanged(object sender, EventArgs e)
        {
            btnAdiciona.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            string search = (txtClientsSearch.Text).ToUpper();
            if (txtClientsSearch.Text != "")
            {
                dgvConsulta.DataSource = conectandose.ConsultarWith(TblName, search);
                sgtect = 0;
                cuentact = dgvConsulta.Rows.GetRowCount(0);
                if (cuentact != 0)
                    rellenact();
            }
            
        }

        private void txtContact_Leave(object sender, EventArgs e)
        {
            txtContact.Text = (txtContact.Text).ToUpper();
        }

        private void txtBrokerName_Leave(object sender, EventArgs e)
        {
            txtBrokerName.Text = (txtBrokerName.Text).ToUpper();
        }

        private void txtBrokerAddress_Leave(object sender, EventArgs e)
        {
            txtBrokerAddress.Text = (txtBrokerAddress.Text).ToUpper();
        }

        private void txtBrokerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCompany_Leave(object sender, EventArgs e)
        {
            txtCompany.Text = (txtCompany.Text).ToUpper();
        }

        private void txtOwner_Leave(object sender, EventArgs e)
        {
            txtOwner.Text = (txtOwner.Text).ToUpper();
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtAddress.Text = (txtAddress.Text).ToUpper();
        }

        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBrokerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFinfCSZ_MouseLeave(object sender, EventArgs e)
        {
            lblCSZ.Visible = false;
        }

        private void btnCatalogs_Click(object sender, EventArgs e)
        {
            frmPrintCatalogs catalogs = new frmPrintCatalogs();
            catalogs.Show();
        }

        private void tabClients_Click(object sender, EventArgs e)
        {

        }

        
    }
}
