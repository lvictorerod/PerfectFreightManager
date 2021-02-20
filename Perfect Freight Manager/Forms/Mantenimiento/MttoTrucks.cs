using iText.StyledXmlParser.Jsoup.Parser;
using Npgsql;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Reports;
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

namespace Perfect_Freight_Manager.Forms.Mantenimiento
{
    public partial class MttoTrucks : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        private string TblName = "maintenancetruckpms";
        private string TruckId, TruckOdoIni, TruckDriver;
        
        private int sgtepm = 0, cuentapm = 0;
        private int contador = 1, recordCount = 1;
        private int sgtet2 = 0, cuentat2 = 0;
        private int sgtet3 = 0, cuentat3 = 0;
        private int sgtesm = 0, cuentasm = 0;
        private int sgtewt = 0, cuentawt = 0;
        private int codigo, codigot3;
        private bool CheckPoint;

        public MttoTrucks(string truckId,string truckOdoIni, string truckdriver)//, bool checkpoint
        {
            InitializeComponent();
            //CheckPoint = checkpoint;
            //if (checkpoint) //Estoy adicionando
            //{
            TruckId = truckId;
            TruckOdoIni = truckOdoIni;
            TruckDriver = truckdriver;
            lblPMDriver.Text = truckdriver;
            lblSMDriver.Text = truckdriver;
            lblT2Driver.Text = truckdriver;
            lblT3Driver.Text = truckdriver;
            lblWTDriver.Text = truckdriver;

            lblPM.Text = truckId;
            lblT2.Text = truckId;
            lblT3.Text = truckId;
            lblSM.Text = truckId;
            lblWT.Text = truckId;
            lblOdoIniI.Text = truckOdoIni;
            lblOdoIni2.Text = truckOdoIni;
            lblOdoIni3.Text = truckOdoIni;

            lblPMOrder.Text = "";
            lblT2Order.Text = truckId;
            lblT3Order.Text = truckId;
            lblSMOrder.Text = truckId;
            lblWTOrder.Text = truckId;

            chkPMOrder.SetItemChecked(0, true);
            chkT2Order.SetItemChecked(0, true);
            chkT3Order.SetItemChecked(0, true);
            chkSMOrder.SetItemChecked(0, true);
            chkWTOrder.SetItemChecked(0, true);
            //}

            lbRecordPM.Text = "Record " + sgtepm + " of  " + cuentapm;
            if (lblPM.Text != "")
            {
                btnPMAdd.Enabled = true;
                btnPMUpd.Enabled = false;
                btnPMDel.Enabled = false;
                btnPMOrder.Enabled = false;
                btnPMPrint.Enabled = false;

                btnPMClear.Enabled = false;
                btnPMFirst.Enabled = false;
                btnPMPrevious.Enabled = false;
                btnPMNext.Enabled = false;
                btnPMEnd.Enabled = false;
            }
            else
            {
                btnPMAdd.Enabled = false;
                btnPMUpd.Enabled = true;
                btnPMDel.Enabled = true;
                btnPMOrder.Enabled = true;
                btnPMPrint.Enabled = true;

                btnPMClear.Enabled = true;
                btnPMFirst.Enabled = true;
                btnPMPrevious.Enabled = true;
                btnPMNext.Enabled = true;
                btnPMEnd.Enabled = true;
            }

            for (int i = 0; i < 17; i++)
            {
                checkedListBox6.Items.Add("prt" + (i + 1), false);
            }
            for (int i = 0; i < 17; i++)
            {
                checkedListBox6.Items.Add("pot" + (i + 1), false);
            }
            checkedListBox6.Items.Add("1.Air Compressor", false);
            checkedListBox6.Items.Add("2.Air Lines", false);
            checkedListBox6.Items.Add("3.Battery", false);
            checkedListBox6.Items.Add("4.Belts & Hoses", false);
            checkedListBox6.Items.Add("5.Body", false);
            checkedListBox6.Items.Add("6.Brake Accessories", false);
            checkedListBox6.Items.Add("7.Brakers, Patking", false);
            checkedListBox6.Items.Add("8.Brakers, Service", false);
            checkedListBox6.Items.Add("9.Clutch", false);
            checkedListBox6.Items.Add("10.Coupling Devices", false);
            checkedListBox6.Items.Add("11.Defroster/Heater", false);
            checkedListBox6.Items.Add("12.Drive Line", false);
            checkedListBox6.Items.Add("13.Engine", false);
            checkedListBox6.Items.Add("14.Exhaust", false);
            checkedListBox6.Items.Add("15.Fith Wheel", false);
            checkedListBox6.Items.Add("16.Fluid Level", false);
            checkedListBox6.Items.Add("17.Frame & Assembly", false);

            for (int i = 0; i < 14; i++)
            {
                checkedListBox7.Items.Add("prt" + (i + 18).ToString(), false);
            }
            for (int i = 0; i < 14; i++)
            {
                checkedListBox7.Items.Add("pot" + (i + 18).ToString(), false);
            }
            checkedListBox7.Items.Add("18.Front Axle", false);
            checkedListBox7.Items.Add("19.Fuel Tank", false);
            checkedListBox7.Items.Add("20.Generator", false);
            checkedListBox7.Items.Add("21.Horn", false);
            checkedListBox7.Items.Add("22.Lights", false);
            checkedListBox7.Items.Add("23.Head-Stop", false);
            checkedListBox7.Items.Add("24.Tail-Dash", false);
            checkedListBox7.Items.Add("25.Tum Indicators", false);
            checkedListBox7.Items.Add("26.Mirros", false);
            checkedListBox7.Items.Add("27.Mufflers", false);
            checkedListBox7.Items.Add("28.Oil Level", false);
            checkedListBox7.Items.Add("29.Radiador Level", false);
            checkedListBox7.Items.Add("30.Rear End", false);
            checkedListBox7.Items.Add("31.Reflectors", false);

            for (int i = 0; i < 17; i++)
            {
                checkedListBox8.Items.Add("prt" + (i + 32).ToString(), false);
            }
            for (int i = 0; i < 17; i++)
            {
                checkedListBox8.Items.Add("pot" + (i + 32).ToString(), false);
            }
            checkedListBox8.Items.Add("32.Safely Equipment", false);
            checkedListBox8.Items.Add("33.Fire Extinguisher", false);
            checkedListBox8.Items.Add("34.Flags-Flares-Fusses", false);
            checkedListBox8.Items.Add("35.Reflective Triangles", false);
            checkedListBox8.Items.Add("36.Spare Bulbs &Fuses", false);
            checkedListBox8.Items.Add("37.Spare Seal Beam", false);
            checkedListBox8.Items.Add("38.Starter", false);
            checkedListBox8.Items.Add("39.Steering", false);
            checkedListBox8.Items.Add("40.Suspension System", false);
            checkedListBox8.Items.Add("41.Tire Chains", false);
            checkedListBox8.Items.Add("42.Tires", false);
            checkedListBox8.Items.Add("43.Transmission", false);
            checkedListBox8.Items.Add("44.Trip Recorder", false);
            checkedListBox8.Items.Add("45.Wheels & Rims", false);
            checkedListBox8.Items.Add("46.Windows", false);
            checkedListBox8.Items.Add("47.Windshield", false);
            checkedListBox8.Items.Add("48.Other", false);

            for (int i = 0; i < 16; i++)
            {
                checkedListBox9.Items.Add("prt" + (i + 49).ToString(), false);
            }
            for (int i = 0; i < 16; i++)
            {
                checkedListBox9.Items.Add("pot" + (i + 49).ToString(), false);
            }
            checkedListBox9.Items.Add("49.Brake Connection", false);
            checkedListBox9.Items.Add("50.Brakers", false);
            checkedListBox9.Items.Add("51.Coupling Devices", false);
            checkedListBox9.Items.Add("52.Coupling(King) Pin", false);
            checkedListBox9.Items.Add("53.Door", false);
            checkedListBox9.Items.Add("54.Hitch", false);
            checkedListBox9.Items.Add("55.Landing Gear", false);
            checkedListBox9.Items.Add("56.Lights-All", false);
            checkedListBox9.Items.Add("57.Reflectros/Reflective Tape", false);
            checkedListBox9.Items.Add("58.Roof", false);
            checkedListBox9.Items.Add("59.Starp", false);
            checkedListBox9.Items.Add("60.Suspension System", false);
            checkedListBox9.Items.Add("61.Tarpaulin", false);
            checkedListBox9.Items.Add("62.Tires", false);
            checkedListBox9.Items.Add("63.Wheels & Rims", false);
            checkedListBox9.Items.Add("64.Other", false);
            dgvTruckT2.DataSource = conectandose.Consultar("maintenancetrucktipo2s");
            btnPMAdd.Enabled = true;
            btnPMUpd.Enabled = false;
            btnPMDel.Enabled = false;
            dgvPms.DataSource = conectandose.Consultar(TblName);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpMttoTrucks mttoTrucks = new HelpMttoTrucks();
            mttoTrucks.Show();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabTipo1")
            {
                TblName = "maintenancetruckpms";
                //lblPM.Text = TruckId;
                //lblOdoIniI.Text = TruckOdoIni;
                //lblPMDriver.Text = TruckDriver;
                dgvPms.DataSource = conectandose.Consultar(TblName);
            }
            else if (tabControl1.SelectedTab.Name == "tabTipo2")
            {
                TblName = "maintenancetrucktipo2s";
                lbRecordT2.Text = "Record " + sgtet2 + " of  " + cuentat2;
                if (TruckId != "")
                {
                    btnT2Add.Enabled = true;
                    btnT2Upd.Enabled = false;
                    btnT2Del.Enabled = false;
                    btnT2Order.Enabled = false;
                    btnT2Print.Enabled = false;

                    btnT2Clear.Enabled = false;
                    btnT2First.Enabled = false;
                    btnT2Previous.Enabled = false;
                    btnT2Next.Enabled = false;
                    btnT2End.Enabled = false;
                }
                else
                {
                    btnT2Add.Enabled = false;
                    btnT2Upd.Enabled = true;
                    btnT2Del.Enabled = true;
                    btnT2Order.Enabled = true;
                    btnT2Print.Enabled = false;

                    btnT2Clear.Enabled = true;
                    btnT2First.Enabled = true;
                    btnT2Previous.Enabled = true;
                    btnT2Next.Enabled = true;
                    btnT2End.Enabled = true;
                }
                dgvTruckT2.DataSource = conectandose.Consultar(TblName);
            }
            else if (tabControl1.SelectedTab.Name == "tabTipo3")
            {
                TblName = "maintenancetrucktipo3s"; 
                lbRecordT3.Text = "Record " + sgtet3 + " of  " + cuentat3;
                if (TruckId != "")
                {
                    btnT3Add.Enabled = true;
                    btnT3Upd.Enabled = false;
                    btnT3Del.Enabled = false;
                    btnT3Order.Enabled = false;
                    btnT3Print.Enabled = false;

                    btnT3Clear.Enabled = false;
                    btnT3First.Enabled = false;
                    btnT3Previous.Enabled = false;
                    btnT3Next.Enabled = false;
                    btnT3End.Enabled = false;
                }
                else
                {
                    btnT3Add.Enabled = false;
                    btnT3Upd.Enabled = true;
                    btnT3Del.Enabled = true;
                    btnT3Order.Enabled = true;
                    btnT3Print.Enabled = true;

                    btnT3Clear.Enabled = true;
                    btnT3First.Enabled = true;
                    btnT3Previous.Enabled = true;
                    btnT3Next.Enabled = true;
                    btnT3End.Enabled = true;
                }
                dgvTruckT3.DataSource = conectandose.Consultar(TblName);
            }
            else if (tabControl1.SelectedTab.Name == "tabTipo4")
            {
                TblName = "maintenancesummers";
                lbRecordSM.Text = "Record " + sgtesm + " of  " + cuentasm;
                if (TruckId != "")
                {
                    btnSMAdd.Enabled = true;
                    btnSMUpd.Enabled = false;
                    btnSMDel.Enabled = false;
                    btnSMOrder.Enabled = false;
                    btnSMPrint.Enabled = false;

                    btnSMClear.Enabled = false;
                    btnSMFirst.Enabled = false;
                    btnSMPrevious.Enabled = false;
                    btnSMNext.Enabled = false;
                    btnSMEnd.Enabled = false;
                }
                else
                {
                    btnSMAdd.Enabled = false;
                    btnSMUpd.Enabled = true;
                    btnSMDel.Enabled = true;
                    btnSMOrder.Enabled = true;
                    btnSMPrint.Enabled = true;

                    btnSMClear.Enabled = true;
                    btnSMFirst.Enabled = true;
                    btnSMPrevious.Enabled = true;
                    btnSMNext.Enabled = true;
                    btnSMEnd.Enabled = true;
                }
                dgvSummer.DataSource = conectandose.Consultar(TblName);
            }

            else if (tabControl1.SelectedTab.Name == "tabTipo5")
            {
                TblName = "maintenancewinters";
                lbRecordWT.Text = "Record " + sgtewt + " of  " + cuentawt;
                if (TruckId != "")
                {
                    btnWTAdd.Enabled = true;
                    btnWTUpd.Enabled = false;
                    btnWTDel.Enabled = false;
                    btnWTOrder.Enabled = false;
                    btnWTPrint.Enabled = false;

                    btnWTClear.Enabled = false;
                    btnWTFirst.Enabled = false;
                    btnWTPrevious.Enabled = false;
                    btnWTNext.Enabled = false;
                    btnWTEnd.Enabled = false;
                }
                else
                {
                    btnWTAdd.Enabled = false;
                    btnWTUpd.Enabled = true;
                    btnWTDel.Enabled = true;
                    btnWTOrder.Enabled = true;
                    btnWTPrint.Enabled = true;

                    btnWTClear.Enabled = true;
                    btnWTFirst.Enabled = true;
                    btnWTPrevious.Enabled = true;
                    btnWTNext.Enabled = true;
                    btnWTEnd.Enabled = true;
                }
                dgvWinter.DataSource = conectandose.Consultar(TblName);
            }
        }

        /// <summary>///////////////////////
        /// PM
        /// </summary>//////////////////////
        private void btnPMClear_Click(object sender, EventArgs e)
        {
            dtPMStart.Text = "";
            dtPMEnd.Text = "";
            lblPMDriver.Text = "";
            lblPMOrder.Text = "";
            txtPMIncidense.Text = "";
            txtPMExpense.Text = "";
            for (int count = 0; count < checkedListBox5.Items.Count; count++)
            {
                checkedListBox5.SetItemChecked(count, false);
            }

            btnPMAdd.Enabled = true;
            btnPMUpd.Enabled = false;
            btnPMDel.Enabled = false;
        }
        private void btnPMFirst_Click(object sender, EventArgs e)
        {
            cuentapm = dgvPms.Rows.GetLastRow(0) + 1;
            if (cuentapm != 0)
            {
                sgtepm = dgvPms.Rows.GetFirstRow(0);
                dgvPms_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaPM();
            }
        }

        private void btnPMPrevious_Click(object sender, EventArgs e)
        {
            if (cuentapm != 0)
            {
                sgtepm = dgvPms.Rows.GetPreviousRow(sgtepm, 0);
                if (sgtepm == -1) sgtepm = cuentapm - 1;
                if (sgtepm <= cuentapm && sgtepm >= 0)
                {
                    dgvPms_RowEnter(sender, e);
                    rellenaPM();
                }
            }
        }
        private void btnPMNext_Click(object sender, EventArgs e)
        {
            cuentapm = dgvPms.Rows.GetLastRow(0) + 1;
            if (cuentapm != 0)
            {
                sgtepm = dgvPms.Rows.GetNextRow(sgtepm, 0);
                if (sgtepm == -1) sgtepm = 0;
                if (sgtepm <= cuentapm && sgtepm >= 0)
                {
                    dgvPms_RowEnter(sender, e);
                    rellenaPM();
                }
            }
        }

        private void btnPMEnd_Click(object sender, EventArgs e)
        {
            cuentapm = dgvPms.Rows.GetLastRow(0) + 1;
            if (cuentapm != 0)
            {
                sgtepm = dgvPms.Rows.GetLastRow(0);
                dgvPms_RowEnter(sender, e);
                rellenaPM();
            }
        }
        private void dgvPms_RowEnter(object sender, EventArgs e)
        {
            dgvPms.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvPms.Rows[sgtepm].Selected = true;
            dgvPms.FirstDisplayedScrollingRowIndex = dgvPms.Rows.GetNextRow(sgtepm - 1, 0);
        }
        private void rellenaPM()
        {
            btnPMAdd.Enabled = false;
            btnPMUpd.Enabled = true;
            btnPMDel.Enabled = true;

            codigo = Convert.ToInt32(dgvPms.Rows[sgtepm].Cells[0].Value);
            lblPM.Text = Convert.ToString(dgvPms.Rows[sgtepm].Cells[1].Value);
            //TruckId = lblPM.Text;
            lblOdoIniI.Text = Convert.ToString(dgvPms.Rows[sgtepm].Cells[2].Value);
            lblPMOrder.Text = Convert.ToString(dgvPms.Rows[sgtepm].Cells[30].Value);
            dtPMStart.Value = Convert.ToDateTime(dgvPms.Rows[sgtepm].Cells[3].Value);
            dtPMEnd.Value = Convert.ToDateTime(dgvPms.Rows[sgtepm].Cells[4].Value);
            lblPMDriver.Text = Convert.ToString(dgvPms.Rows[sgtepm].Cells[5].Value);
            for (int count = 0; count < chkPMOrder.Items.Count; count++)
            {
                chkPMOrder.SetItemChecked(count, false);
            }
            chkPMOrder.SetItemChecked(Convert.ToInt32(dgvPms.Rows[sgtepm].Cells[31].Value), true);

            for (int count = 0; count < checkedListBox5.Items.Count; count++)
            {
                checkedListBox5.SetItemChecked(count, false);
                if(Convert.ToInt32(dgvPms.Rows[sgtepm].Cells[count + 6].Value)!=100)
                    checkedListBox5.SetItemChecked(Convert.ToInt32(dgvPms.Rows[sgtepm].Cells[count + 6].Value), true);
            }
            txtPMIncidense.Text = Convert.ToString(dgvPms.Rows[sgtepm].Cells[28].Value);
            txtPMExpense.Text = Convert.ToString(dgvPms.Rows[sgtepm].Cells[29].Value);

            lbRecordPM.Text = "Record " + (sgtepm + 1) + " of  " + cuentapm;
        }
        
        private void btnPMAdd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            string zyear = DateTime.Today.Year.ToString();
            if (!(dtPMStart.Text == "" || dtPMEnd.Text == "" || lblPM.Text == "" || chkPMOrder.GetItemChecked(0) == false))
            {
                List<string> checkList = new List<string>();
                for (int count = 0; count < checkedListBox5.Items.Count; count++)
                {
                    if (checkedListBox5.GetItemChecked(count) == true)
                        checkList.Add(count.ToString());
                    else checkList.Add("100");
                }
                cuentapm = dgvPms.Rows.GetLastRow(0) + 2;
                lblPMOrder.Text = "TRPM - " + cuentapm.ToString() + "/" + zyear;
                for (int count = 0; count < chkPMOrder.Items.Count; count++)
                {
                    if (chkPMOrder.GetItemChecked(count) == true)
                    {
                        statusorder = count.ToString();
                        break;
                    }
                }
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into maintenancetruckpms (truckid,milestotal,dateinitial,dateend,drivername,pm1,pm2,pm3,pm4,pm5,pm6,pm7,pm8,pm9,pm10,pm11,pm12,pm13,pm14,pm15,pm16,pm17,pm18,pm19,pm20,pm21,pm22,incidense,expense,numberorder,statusorder) values('" + lblPM.Text + "','" + lblOdoIniI.Text + "','" + dtPMStart.Value + "','" + dtPMEnd.Value + "','" + lblPMDriver.Text + "',@pm1,@pm2,@pm3,@pm4,@pm5,@pm6,@pm7,@pm8,@pm9,@pm10,@pm11,@pm12,@pm13,@pm14,@pm15,@pm16,@pm17,@pm18,@pm19,@pm20,@pm21,@pm22,@incidense,@expense,'" + lblPMOrder.Text + "',@statusorder)", conn);
                    cmd.Parameters.AddWithValue("pm1", checkList[0]);
                    cmd.Parameters.AddWithValue("pm2", checkList[1]);
                    cmd.Parameters.AddWithValue("pm3", checkList[2]);
                    cmd.Parameters.AddWithValue("pm4", checkList[3]);
                    cmd.Parameters.AddWithValue("pm5", checkList[4]);
                    cmd.Parameters.AddWithValue("pm6", checkList[5]);
                    cmd.Parameters.AddWithValue("pm7", checkList[6]);
                    cmd.Parameters.AddWithValue("pm8", checkList[7]);
                    cmd.Parameters.AddWithValue("pm9", checkList[8]);
                    cmd.Parameters.AddWithValue("pm10", checkList[9]);
                    cmd.Parameters.AddWithValue("pm11", checkList[10]);
                    cmd.Parameters.AddWithValue("pm12", checkList[11]);
                    cmd.Parameters.AddWithValue("pm13", checkList[12]);
                    cmd.Parameters.AddWithValue("pm14", checkList[13]);
                    cmd.Parameters.AddWithValue("pm15", checkList[14]);
                    cmd.Parameters.AddWithValue("pm16", checkList[15]);
                    cmd.Parameters.AddWithValue("pm17", checkList[16]);
                    cmd.Parameters.AddWithValue("pm18", checkList[17]);
                    cmd.Parameters.AddWithValue("pm19", checkList[18]);
                    cmd.Parameters.AddWithValue("pm20", checkList[19]);
                    cmd.Parameters.AddWithValue("pm21", checkList[20]);
                    cmd.Parameters.AddWithValue("pm22", checkList[21]);
                    cmd.Parameters.AddWithValue("incidense", txtPMIncidense.Text);
                    cmd.Parameters.AddWithValue("expense", txtPMExpense.Text);
                    cmd.Parameters.AddWithValue("statusorder", statusorder);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successfully");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                btnPMAdd.Enabled = false;
                btnPMUpd.Enabled = true;
                btnPMDel.Enabled = true;
                btnPMOrder.Enabled = true;
                btnPMPrint.Enabled = true;

                btnPMClear.Enabled = true;
                btnPMFirst.Enabled = true;
                btnPMPrevious.Enabled = true;
                btnPMNext.Enabled = true;
                btnPMEnd.Enabled = true;
                dgvPms.DataSource = conectandose.Consultar(TblName);
            }
            else
                MessageBox.Show("Lack data, check that have:\n Date Start, Date End, Check Status, APU Id", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPMDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnPMClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvPms.DataSource = conectandose.Consultar(TblName);
            }
        }
        private void btnPMUpd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            if (!(dtPMStart.Text == "" || dtPMEnd.Text == "" ))
            {
                List<string> checkList = new List<string>();
                for (int count = 0; count < chkPMOrder.Items.Count; count++)
                {
                    if (chkPMOrder.GetItemChecked(count) == true)
                    {
                        statusorder = count.ToString();
                        break;
                    }
                }
                for (int count = 0; count < checkedListBox5.Items.Count; count++)
                {
                    if (checkedListBox5.GetItemChecked(count) == true)
                        checkList.Add(count.ToString());
                    else checkList.Add("100");
                }
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("update maintenancetruckpms set dateinitial='" + dtPMStart.Value + "', dateend='" + dtPMEnd.Value + "',pm1=@pm1,pm2=@pm2,pm3=@pm3,pm4=@pm4,pm5=@pm5,pm6=@pm6,pm7=@pm7,pm8=@pm8,pm9=@pm9,pm10=@pm10,pm11=@pm11,pm12=@pm12,pm13=@pm13,pm14=@pm14,pm15=@pm15,pm16=@pm16,pm17=@pm17,pm18=@pm18,pm19=@pm19,pm20=@pm20,pm21=@pm21,pm22=@pm22,incidense=@incidense,expense=@expense,statusorder=@statusorder" + " where id=" + codigo, conn);
                    cmd.Parameters.AddWithValue("pm1", checkList[0]);
                    cmd.Parameters.AddWithValue("pm2", checkList[1]);
                    cmd.Parameters.AddWithValue("pm3", checkList[2]);
                    cmd.Parameters.AddWithValue("pm4", checkList[3]);
                    cmd.Parameters.AddWithValue("pm5", checkList[4]);
                    cmd.Parameters.AddWithValue("pm6", checkList[5]);
                    cmd.Parameters.AddWithValue("pm7", checkList[6]);
                    cmd.Parameters.AddWithValue("pm8", checkList[7]);
                    cmd.Parameters.AddWithValue("pm9", checkList[8]);
                    cmd.Parameters.AddWithValue("pm10", checkList[9]);
                    cmd.Parameters.AddWithValue("pm11", checkList[10]);
                    cmd.Parameters.AddWithValue("pm12", checkList[11]);
                    cmd.Parameters.AddWithValue("pm13", checkList[12]);
                    cmd.Parameters.AddWithValue("pm14", checkList[13]);
                    cmd.Parameters.AddWithValue("pm15", checkList[14]);
                    cmd.Parameters.AddWithValue("pm16", checkList[15]);
                    cmd.Parameters.AddWithValue("pm17", checkList[16]);
                    cmd.Parameters.AddWithValue("pm18", checkList[17]);
                    cmd.Parameters.AddWithValue("pm19", checkList[18]);
                    cmd.Parameters.AddWithValue("pm20", checkList[19]);
                    cmd.Parameters.AddWithValue("pm21", checkList[20]);
                    cmd.Parameters.AddWithValue("pm22", checkList[21]);
                    cmd.Parameters.AddWithValue("incidense", txtPMIncidense.Text);
                    cmd.Parameters.AddWithValue("expense", txtPMExpense.Text);
                    cmd.Parameters.AddWithValue("statusorder", statusorder);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Update successfully");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvPms.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnPrintWT_Click(object sender, EventArgs e)
        {
            if(!(chkWTOrder.GetItemChecked(1)==true))
                MessageBox.Show("Order not Closed!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Prepare the Print with paper A4 (8.5 pulg. x 14 pulg.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TruckPrint truckorderwt = new TruckPrint(lblWT.Text, "", lblWTDriver.Text, codigo, lblWTOrder.Text, 5, 1);
                truckorderwt.Show();
            }
        }

        /// <summary>/////////////////////////////
        /// TIPOII
        /// </summary>////////////////////////////
        private void btnT2Clear_Click(object sender, EventArgs e)
        {
            lblT2.Text = "";
            lblOdoIni2.Text = "";
            lblT2Driver.Text = "";
            lblT2Order.Text = "";
            dtT2Start.Text = "";
            dtT2End.Text = "";
            for (int count = 0; count < checkedListBox6.Items.Count; count++)
            {
                checkedListBox6.SetItemChecked(count, false);
            }
            for (int count = 0; count < checkedListBox7.Items.Count; count++)
            {
                checkedListBox7.SetItemChecked(count, false);
            }
            for (int count = 0; count < checkedListBox8.Items.Count; count++)
            {
                checkedListBox8.SetItemChecked(count, false);
            }
            for (int count = 0; count < checkedListBox9.Items.Count; count++)
            {
                checkedListBox9.SetItemChecked(count, false);
            }

            txtT2Notes.Text = "";
            
        }
        private void btnT2First_Click(object sender, EventArgs e)
        {
            cuentat2 = dgvTruckT2.Rows.GetLastRow(0) + 1;
            if (cuentat2 != 0)
            {
                sgtet2 = dgvTruckT2.Rows.GetFirstRow(0);
                dgvTruckT2_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaT2();
            }
        }

        private void btnT2Previous_Click(object sender, EventArgs e)
        {
            cuentat2 = dgvTruckT2.Rows.GetLastRow(0) + 1;
            if (cuentat2 != 0)
            {
                sgtet2 = dgvTruckT2.Rows.GetPreviousRow(sgtet2, 0);
                if (sgtet2 == -1) sgtet2 = cuentat2 - 1;
                if (sgtet2 <= cuentat2 && sgtet2 >= 0)
                {
                    dgvTruckT2_RowEnter(sender, e);
                    rellenaT2();
                }
            }
        }

        private void btnT2Next_Click(object sender, EventArgs e)
        {
            cuentat2 = dgvTruckT2.Rows.GetLastRow(0) + 1;
            if (cuentat2 != 0)
            {
                sgtet2 = dgvTruckT2.Rows.GetNextRow(sgtet2, 0);
                if (sgtet2 == -1) sgtet2 = 0;
                if (sgtet2 <= cuentat2 && sgtet2 >= 0)
                {
                    dgvTruckT2_RowEnter(sender, e);
                    rellenaT2();
                }
            }
        }

        private void btnT2End_Click(object sender, EventArgs e)
        {
            cuentat2 = dgvTruckT2.Rows.GetLastRow(0) + 1;
            if (cuentat2 != 0)
            {
                sgtet2 = dgvTruckT2.Rows.GetLastRow(0);
                dgvTruckT2_RowEnter(sender, e);
                rellenaT2();
            }
        }
        private void dgvTruckT2_RowEnter(object sender, EventArgs e)
        {
            dgvTruckT2.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvTruckT2.Rows[sgtet2].Selected = true;
            dgvTruckT2.FirstDisplayedScrollingRowIndex = dgvTruckT2.Rows.GetNextRow(sgtet2 - 1, 0);
        }
        private void rellenaT2()
        {
            btnT2Add.Enabled = false;
            btnT2Upd.Enabled = true;
            btnT2Del.Enabled = true;

            codigo = Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[0].Value);
            lblT2.Text = Convert.ToString(dgvTruckT2.Rows[sgtet2].Cells[1].Value);
            //TruckId = lblT2.Text;
            lblOdoIni2.Text = Convert.ToString(dgvTruckT2.Rows[sgtet2].Cells[2].Value);
            dtT2Start.Value = Convert.ToDateTime(dgvTruckT2.Rows[sgtet2].Cells[3].Value);
            dtT2End.Value = Convert.ToDateTime(dgvTruckT2.Rows[sgtet2].Cells[4].Value);
            lblT2Driver.Text = Convert.ToString(dgvTruckT2.Rows[sgtet2].Cells[5].Value);
            lblT2Order.Text = Convert.ToString(dgvTruckT2.Rows[sgtet2].Cells[199].Value);
            for (int count = 0; count < chkT2Order.Items.Count; count++)
            {
                chkT2Order.SetItemChecked(count, false);
            }
            chkT2Order.SetItemChecked(Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[200].Value), true);

            //Llenando los PRT, POPT y RR 29,28,27
            for (int count = 0; count < checkedListBox6.Items.Count; count++)
            {
                checkedListBox6.SetItemChecked(count, false);
                if(Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[count + 6].Value)!=100)
                    checkedListBox6.SetItemChecked(Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[count + 6].Value), true);
            }
            for (int count = 0; count < checkedListBox7.Items.Count; count++)
            {
                checkedListBox7.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[count + 57].Value) != 100)
                    checkedListBox7.SetItemChecked(Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[count + 57].Value), true);
            }
            for (int count = 0; count < checkedListBox8.Items.Count; count++)
            {
                checkedListBox8.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[count + 99].Value) != 100)
                    checkedListBox8.SetItemChecked(Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[count + 99].Value), true);
            }
            for (int count = 0; count < checkedListBox9.Items.Count; count++)
            {
                checkedListBox9.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[count + 150].Value) != 100)
                    checkedListBox9.SetItemChecked(Convert.ToInt32(dgvTruckT2.Rows[sgtet2].Cells[count + 150].Value), true);
            }
            txtT2Notes.Text = Convert.ToString(dgvTruckT2.Rows[sgtet2].Cells[198].Value);

            lbRecordT2.Text = "Record " + (sgtet2 + 1) + " of  " + cuentat2;
        }
        private void btnT2Add_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            string zyear = DateTime.Today.Year.ToString();
            if (!(dtT2Start.Text == "" || dtT2End.Text == "" || lblT2.Text == "" || chkT2Order.GetItemChecked(0) == false))
            {
                List<string> checkList = new List<string>();
                List<string> checkList2 = new List<string>();
                List<string> checkList3 = new List<string>();
                List<string> checkList4 = new List<string>();
                cuentat2 = dgvTruckT2.Rows.GetLastRow(0) + 2;
                lblT2Order.Text = "TRT2 - " + cuentat2.ToString() + "/" + zyear;
                for (int count = 0; count < chkT2Order.Items.Count; count++)
                {
                    if (chkT2Order.GetItemChecked(count) == true)
                    {
                        statusorder = count.ToString();
                        break;
                    }
                }
                //Llenando los PRT, POPT y RR 29,28,27
                for (int count = 0; count < checkedListBox6.Items.Count; count++)
                {
                    if (checkedListBox6.GetItemChecked(count) == true)
                        checkList.Add(count.ToString());
                    else checkList.Add("100");
                }
                for (int count = 0; count < checkedListBox7.Items.Count; count++)
                {
                    if (checkedListBox7.GetItemChecked(count) == true)
                        checkList2.Add((count).ToString());
                    else checkList2.Add("100");
                }
                for (int count = 0; count < checkedListBox8.Items.Count; count++)
                {
                    if (checkedListBox8.GetItemChecked(count) == true)
                        checkList3.Add(count.ToString());
                    else checkList3.Add("100");
                }
                for (int count = 0; count < checkedListBox9.Items.Count; count++)
                {
                    if (checkedListBox9.GetItemChecked(count) == true)
                        checkList4.Add(count.ToString());
                    else checkList4.Add("100");
                }
                //
                //
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into maintenancetrucktipo2s (truckid,milestotal,dateinitial,dateend,drivername,prt1,prt2,prt3,prt4,prt5,prt6,prt7,prt8,prt9,prt10,prt11,prt12,prt13,prt14,prt15,prt16,prt17,pot1,pot2,pot3,pot4,pot5,pot6,pot7,pot8,pot9,pot10,pot11,pot12,pot13,pot14,pot15,pot16,pot17,rr1,rr2,rr3,rr4,rr5,rr6,rr7,rr8,rr9,rr10,rr11,rr12,rr13,rr14,rr15,rr16,rr17,prt18,prt19,prt20,prt21,prt22,prt23,prt24,prt25,prt26,prt27,prt28,prt29,prt30,prt31,pot18,pot19,pot20,pot21,pot22,pot23,pot24,pot25,pot26,pot27,pot28,pot29,pot30,pot31,rr18,rr19,rr20,rr21,rr22,rr23,rr24,rr25,rr26,rr27,rr28,rr29,rr30,rr31,prt32,prt33,prt34,prt35,prt36,prt37,prt38,prt39,prt40,prt41,prt42,prt43,prt44,prt45,prt46,prt47,prt48,pot32,pot33,pot34,pot35,pot36,pot37,pot38,pot39,pot40,pot41,pot42,pot43,pot44,pot45,pot46,pot47,pot48,rr32,rr33,rr34,rr35,rr36,rr37,rr38,rr39,rr40,rr41,rr42,rr43,rr44,rr45,rr46,rr47,rr48,prt49,prt50,prt51,prt52,prt53,prt54,prt55,prt56,prt57,prt58,prt59,prt60,prt61,prt62,prt63,prt64,pot49,pot50,pot51,pot52,pot53,pot54,pot55,pot56,pot57,pot58,pot59,pot60,pot61,pot62,pot63,pot64,rr49,rr50,rr51,rr52,rr53,rr54,rr55,rr56,rr57,rr58,rr59,rr60,rr61,rr62,rr63,rr64,notes,numberorder,statusorder) values('" + lblT2.Text + "','" + lblOdoIni2.Text + "','" + dtT2Start.Value + "','" + dtT2End.Value + "','" + lblT2Driver.Text + "',@prt1,@prt2,@prt3,@prt4,@prt5,@prt6,@prt7,@prt8,@prt9,@prt10,@prt11,@prt12,@prt13,@prt14,@prt15,@prt16,@prt17,@pot1,@pot2,@pot3,@pot4,@pot5,@pot6,@pot7,@pot8,@pot9,@pot10,@pot11,@pot12,@pot13,@pot14,@pot15,@pot16,@pot17,@rr1,@rr2,@rr3,@rr4,@rr5,@rr6,@rr7,@rr8,@rr9,@rr10,@rr11,@rr12,@rr13,@rr14,@rr15,@rr16,@rr17,@prt18,@prt19,@prt20,@prt21,@prt22,@prt23,@prt24,@prt25,@prt26,@prt27,@prt28,@prt29,@prt30,@prt31,@pot18,@pot19,@pot20,@pot21,@pot22,@pot23,@pot24,@pot25,@pot26,@pot27,@pot28,@pot29,@pot30,@pot31,@rr18,@rr19,@rr20,@rr21,@rr22,@rr23,@rr24,@rr25,@rr26,@rr27,@rr28,@rr29,@rr30,@rr31,@prt32,@prt33,@prt34,@prt35,@prt36,@prt37,@prt38,@prt39,@prt40,@prt41,@prt42,@prt43,@prt44,@prt45,@prt46,@prt47,@prt48,@pot32,@pot33,@pot34,@pot35,@pot36,@pot37,@pot38,@pot39,@pot40,@pot41,@pot42,@pot43,@pot44,@pot45,@pot46,@pot47,@pot48,@rr32,@rr33,@rr34,@rr35,@rr36,@rr37,@rr38,@rr39,@rr40,@rr41,@rr42,@rr43,@rr44,@rr45,@rr46,@rr47,@rr48,@prt49,@prt50,@prt51,@prt52,@prt53,@prt54,@prt55,@prt56,@prt57,@prt58,@prt59,@prt60,@prt61,@prt62,@prt63,@prt64,@pot49,@pot50,@pot51,@pot52,@pot53,@pot54,@pot55,@pot56,@pot57,@pot58,@pot59,@pot60,@pot61,@pot62,@pot63,@pot64,@rr49,@rr50,@rr51,@rr52,@rr53,@rr54,@rr55,@rr56,@rr57,@rr58,@rr59,@rr60,@rr61,@rr62,@rr63,@rr64,@notes,'" + lblT2Order.Text + "',@statusorder)", conn);
                    cmd.Parameters.AddWithValue("prt1", checkList[0]);
                    cmd.Parameters.AddWithValue("prt2", checkList[1]);
                    cmd.Parameters.AddWithValue("prt3", checkList[2]);
                    cmd.Parameters.AddWithValue("prt4", checkList[3]);
                    cmd.Parameters.AddWithValue("prt5", checkList[4]);
                    cmd.Parameters.AddWithValue("prt6", checkList[5]);
                    cmd.Parameters.AddWithValue("prt7", checkList[6]);
                    cmd.Parameters.AddWithValue("prt8", checkList[7]);
                    cmd.Parameters.AddWithValue("prt9", checkList[8]);
                    cmd.Parameters.AddWithValue("prt10", checkList[9]);
                    cmd.Parameters.AddWithValue("prt11", checkList[10]);
                    cmd.Parameters.AddWithValue("prt12", checkList[11]);
                    cmd.Parameters.AddWithValue("prt13", checkList[12]);
                    cmd.Parameters.AddWithValue("prt14", checkList[13]);
                    cmd.Parameters.AddWithValue("prt15", checkList[14]);
                    cmd.Parameters.AddWithValue("prt16", checkList[15]);
                    cmd.Parameters.AddWithValue("prt17", checkList[16]);
                    cmd.Parameters.AddWithValue("pot1", checkList[17]);
                    cmd.Parameters.AddWithValue("pot2", checkList[18]);
                    cmd.Parameters.AddWithValue("pot3", checkList[19]);
                    cmd.Parameters.AddWithValue("pot4", checkList[20]);
                    cmd.Parameters.AddWithValue("pot5", checkList[21]);
                    cmd.Parameters.AddWithValue("pot6", checkList[22]);
                    cmd.Parameters.AddWithValue("pot7", checkList[23]);
                    cmd.Parameters.AddWithValue("pot8", checkList[24]);
                    cmd.Parameters.AddWithValue("pot9", checkList[25]);
                    cmd.Parameters.AddWithValue("pot10", checkList[26]);
                    cmd.Parameters.AddWithValue("pot11", checkList[27]);
                    cmd.Parameters.AddWithValue("pot12", checkList[28]);
                    cmd.Parameters.AddWithValue("pot13", checkList[29]);
                    cmd.Parameters.AddWithValue("pot14", checkList[30]);
                    cmd.Parameters.AddWithValue("pot15", checkList[31]);
                    cmd.Parameters.AddWithValue("pot16", checkList[32]);
                    cmd.Parameters.AddWithValue("pot17", checkList[33]);
                    cmd.Parameters.AddWithValue("rr1", checkList[34]);
                    cmd.Parameters.AddWithValue("rr2", checkList[35]);
                    cmd.Parameters.AddWithValue("rr3", checkList[36]);
                    cmd.Parameters.AddWithValue("rr4", checkList[37]);
                    cmd.Parameters.AddWithValue("rr5", checkList[38]);
                    cmd.Parameters.AddWithValue("rr6", checkList[39]);
                    cmd.Parameters.AddWithValue("rr7", checkList[40]);
                    cmd.Parameters.AddWithValue("rr8", checkList[41]);
                    cmd.Parameters.AddWithValue("rr9", checkList[42]);
                    cmd.Parameters.AddWithValue("rr10", checkList[43]);
                    cmd.Parameters.AddWithValue("rr11", checkList[44]);
                    cmd.Parameters.AddWithValue("rr12", checkList[45]);
                    cmd.Parameters.AddWithValue("rr13", checkList[46]);
                    cmd.Parameters.AddWithValue("rr14", checkList[47]);
                    cmd.Parameters.AddWithValue("rr15", checkList[48]);
                    cmd.Parameters.AddWithValue("rr16", checkList[49]);
                    cmd.Parameters.AddWithValue("rr17", checkList[50]);//51

                    cmd.Parameters.AddWithValue("prt18", checkList2[0]);
                    cmd.Parameters.AddWithValue("prt19", checkList2[1]);
                    cmd.Parameters.AddWithValue("prt20", checkList2[2]);
                    cmd.Parameters.AddWithValue("prt21", checkList2[3]);
                    cmd.Parameters.AddWithValue("prt22", checkList2[4]);
                    cmd.Parameters.AddWithValue("prt23", checkList2[5]);
                    cmd.Parameters.AddWithValue("prt24", checkList2[6]);
                    cmd.Parameters.AddWithValue("prt25", checkList2[7]);
                    cmd.Parameters.AddWithValue("prt26", checkList2[8]);
                    cmd.Parameters.AddWithValue("prt27", checkList2[9]);
                    cmd.Parameters.AddWithValue("prt28", checkList2[10]);
                    cmd.Parameters.AddWithValue("prt29", checkList2[11]);
                    cmd.Parameters.AddWithValue("prt30", checkList2[12]);
                    cmd.Parameters.AddWithValue("prt31", checkList2[13]);
                    cmd.Parameters.AddWithValue("pot18", checkList2[14]);
                    cmd.Parameters.AddWithValue("pot19", checkList2[15]);
                    cmd.Parameters.AddWithValue("pot20", checkList2[16]);
                    cmd.Parameters.AddWithValue("pot21", checkList2[17]);
                    cmd.Parameters.AddWithValue("pot22", checkList2[18]);
                    cmd.Parameters.AddWithValue("pot23", checkList2[19]);
                    cmd.Parameters.AddWithValue("pot24", checkList2[20]);
                    cmd.Parameters.AddWithValue("pot25", checkList2[21]);
                    cmd.Parameters.AddWithValue("pot26", checkList2[22]);
                    cmd.Parameters.AddWithValue("pot27", checkList2[23]);
                    cmd.Parameters.AddWithValue("pot28", checkList2[24]);
                    cmd.Parameters.AddWithValue("pot29", checkList2[25]);
                    cmd.Parameters.AddWithValue("pot30", checkList2[26]);
                    cmd.Parameters.AddWithValue("pot31", checkList2[27]);
                    cmd.Parameters.AddWithValue("rr18", checkList2[28]);
                    cmd.Parameters.AddWithValue("rr19", checkList2[29]);
                    cmd.Parameters.AddWithValue("rr20", checkList2[30]);
                    cmd.Parameters.AddWithValue("rr21", checkList2[31]);
                    cmd.Parameters.AddWithValue("rr22", checkList2[32]);
                    cmd.Parameters.AddWithValue("rr23", checkList2[33]);
                    cmd.Parameters.AddWithValue("rr24", checkList2[34]);
                    cmd.Parameters.AddWithValue("rr25", checkList2[35]);
                    cmd.Parameters.AddWithValue("rr26", checkList2[36]);
                    cmd.Parameters.AddWithValue("rr27", checkList2[37]);
                    cmd.Parameters.AddWithValue("rr28", checkList2[38]);
                    cmd.Parameters.AddWithValue("rr29", checkList2[39]);
                    cmd.Parameters.AddWithValue("rr30", checkList2[40]);
                    cmd.Parameters.AddWithValue("rr31", checkList2[41]);//42, 93

                    cmd.Parameters.AddWithValue("prt32", checkList3[0]);
                    cmd.Parameters.AddWithValue("prt33", checkList3[1]);
                    cmd.Parameters.AddWithValue("prt34", checkList3[2]);
                    cmd.Parameters.AddWithValue("prt35", checkList3[3]);
                    cmd.Parameters.AddWithValue("prt36", checkList3[4]);
                    cmd.Parameters.AddWithValue("prt37", checkList3[5]);
                    cmd.Parameters.AddWithValue("prt38", checkList3[6]);
                    cmd.Parameters.AddWithValue("prt39", checkList3[7]);
                    cmd.Parameters.AddWithValue("prt40", checkList3[8]);
                    cmd.Parameters.AddWithValue("prt41", checkList3[9]);
                    cmd.Parameters.AddWithValue("prt42", checkList3[10]);
                    cmd.Parameters.AddWithValue("prt43", checkList3[11]);
                    cmd.Parameters.AddWithValue("prt44", checkList3[12]);
                    cmd.Parameters.AddWithValue("prt45", checkList3[13]);
                    cmd.Parameters.AddWithValue("prt46", checkList3[14]);
                    cmd.Parameters.AddWithValue("prt47", checkList3[15]);
                    cmd.Parameters.AddWithValue("prt48", checkList3[16]);
                    cmd.Parameters.AddWithValue("pot32", checkList3[17]);
                    cmd.Parameters.AddWithValue("pot33", checkList3[18]);
                    cmd.Parameters.AddWithValue("pot34", checkList3[19]);
                    cmd.Parameters.AddWithValue("pot35", checkList3[20]);
                    cmd.Parameters.AddWithValue("pot36", checkList3[21]);
                    cmd.Parameters.AddWithValue("pot37", checkList3[22]);
                    cmd.Parameters.AddWithValue("pot38", checkList3[23]);
                    cmd.Parameters.AddWithValue("pot39", checkList3[24]);
                    cmd.Parameters.AddWithValue("pot40", checkList3[25]);
                    cmd.Parameters.AddWithValue("pot41", checkList3[26]);
                    cmd.Parameters.AddWithValue("pot42", checkList3[27]);
                    cmd.Parameters.AddWithValue("pot43", checkList3[28]);
                    cmd.Parameters.AddWithValue("pot44", checkList3[29]);
                    cmd.Parameters.AddWithValue("pot45", checkList3[30]);
                    cmd.Parameters.AddWithValue("pot46", checkList3[31]);
                    cmd.Parameters.AddWithValue("pot47", checkList3[32]);
                    cmd.Parameters.AddWithValue("pot48", checkList3[33]);
                    cmd.Parameters.AddWithValue("rr32", checkList3[34]);
                    cmd.Parameters.AddWithValue("rr33", checkList3[35]);
                    cmd.Parameters.AddWithValue("rr34", checkList3[36]);
                    cmd.Parameters.AddWithValue("rr35", checkList3[37]);
                    cmd.Parameters.AddWithValue("rr36", checkList3[38]);
                    cmd.Parameters.AddWithValue("rr37", checkList3[39]);
                    cmd.Parameters.AddWithValue("rr38", checkList3[40]);
                    cmd.Parameters.AddWithValue("rr39", checkList3[41]);
                    cmd.Parameters.AddWithValue("rr40", checkList3[42]);
                    cmd.Parameters.AddWithValue("rr41", checkList3[43]);
                    cmd.Parameters.AddWithValue("rr42", checkList3[44]);
                    cmd.Parameters.AddWithValue("rr43", checkList3[45]);
                    cmd.Parameters.AddWithValue("rr44", checkList3[46]);
                    cmd.Parameters.AddWithValue("rr45", checkList3[47]);
                    cmd.Parameters.AddWithValue("rr46", checkList3[48]);
                    cmd.Parameters.AddWithValue("rr47", checkList3[49]);
                    cmd.Parameters.AddWithValue("rr48", checkList3[50]);//51, 144

                    cmd.Parameters.AddWithValue("prt49", checkList4[0]);
                    cmd.Parameters.AddWithValue("prt50", checkList4[1]);
                    cmd.Parameters.AddWithValue("prt51", checkList4[2]);
                    cmd.Parameters.AddWithValue("prt52", checkList4[3]);
                    cmd.Parameters.AddWithValue("prt53", checkList4[4]);
                    cmd.Parameters.AddWithValue("prt54", checkList4[5]);
                    cmd.Parameters.AddWithValue("prt55", checkList4[6]);
                    cmd.Parameters.AddWithValue("prt56", checkList4[7]);
                    cmd.Parameters.AddWithValue("prt57", checkList4[8]);
                    cmd.Parameters.AddWithValue("prt58", checkList4[9]);
                    cmd.Parameters.AddWithValue("prt59", checkList4[10]);
                    cmd.Parameters.AddWithValue("prt60", checkList4[11]);
                    cmd.Parameters.AddWithValue("prt61", checkList4[12]);
                    cmd.Parameters.AddWithValue("prt62", checkList4[13]);
                    cmd.Parameters.AddWithValue("prt63", checkList4[14]);
                    cmd.Parameters.AddWithValue("prt64", checkList4[15]);
                    cmd.Parameters.AddWithValue("pot49", checkList4[16]);
                    cmd.Parameters.AddWithValue("pot50", checkList4[17]);
                    cmd.Parameters.AddWithValue("pot51", checkList4[18]);
                    cmd.Parameters.AddWithValue("pot52", checkList4[19]);
                    cmd.Parameters.AddWithValue("pot53", checkList4[20]);
                    cmd.Parameters.AddWithValue("pot54", checkList4[21]);
                    cmd.Parameters.AddWithValue("pot55", checkList4[22]);
                    cmd.Parameters.AddWithValue("pot56", checkList4[23]);
                    cmd.Parameters.AddWithValue("pot57", checkList4[24]);
                    cmd.Parameters.AddWithValue("pot58", checkList4[25]);
                    cmd.Parameters.AddWithValue("pot59", checkList4[26]);
                    cmd.Parameters.AddWithValue("pot60", checkList4[27]);
                    cmd.Parameters.AddWithValue("pot61", checkList4[28]);
                    cmd.Parameters.AddWithValue("pot62", checkList4[29]);
                    cmd.Parameters.AddWithValue("pot63", checkList4[30]);
                    cmd.Parameters.AddWithValue("pot64", checkList4[31]);
                    cmd.Parameters.AddWithValue("rr49", checkList4[32]);
                    cmd.Parameters.AddWithValue("rr50", checkList4[33]);
                    cmd.Parameters.AddWithValue("rr51", checkList4[34]);
                    cmd.Parameters.AddWithValue("rr52", checkList4[35]);
                    cmd.Parameters.AddWithValue("rr53", checkList4[36]);
                    cmd.Parameters.AddWithValue("rr54", checkList4[37]);
                    cmd.Parameters.AddWithValue("rr55", checkList4[38]);
                    cmd.Parameters.AddWithValue("rr56", checkList4[39]);
                    cmd.Parameters.AddWithValue("rr57", checkList4[40]);
                    cmd.Parameters.AddWithValue("rr58", checkList4[41]);
                    cmd.Parameters.AddWithValue("rr59", checkList4[42]);
                    cmd.Parameters.AddWithValue("rr60", checkList4[43]);
                    cmd.Parameters.AddWithValue("rr61", checkList4[44]);
                    cmd.Parameters.AddWithValue("rr62", checkList4[45]);
                    cmd.Parameters.AddWithValue("rr63", checkList4[46]);
                    cmd.Parameters.AddWithValue("rr64", checkList4[47]);
                    cmd.Parameters.AddWithValue("notes", txtT2Notes.Text);
                    cmd.Parameters.AddWithValue("statusorder", statusorder);
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
                btnT2Add.Enabled = false;
                btnT2Upd.Enabled = true;
                btnT2Del.Enabled = true;
                btnT2Order.Enabled = true;
                btnT2Print.Enabled = false;

                btnT2Clear.Enabled = true;
                btnT2First.Enabled = true;
                btnT2Previous.Enabled = true;
                btnT2Next.Enabled = true;
                btnT2End.Enabled = true;
                dgvTruckT2.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnT2Del_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnT2Clear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvTruckT2.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnT2Upd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            List<string> checkList = new List<string>();
            List<string> checkList2 = new List<string>();
            List<string> checkList3 = new List<string>();
            List<string> checkList4 = new List<string>();
            for (int count = 0; count < chkT2Order.Items.Count; count++)
            {
                if (chkT2Order.GetItemChecked(count) == true)
                {
                    statusorder = count.ToString();
                    break;
                }
            }
            //Llenando los PRT, POPT y RR 29,28,27
            for (int count = 0; count < checkedListBox6.Items.Count; count++)
            {
                if (checkedListBox6.GetItemChecked(count) == true)
                    checkList.Add(count.ToString());
                else checkList.Add("100");
            }
            for (int count = 0; count < checkedListBox7.Items.Count; count++)
            {
                if (checkedListBox7.GetItemChecked(count) == true)
                    checkList2.Add((count).ToString());
                else checkList2.Add("100");
            }
            for (int count = 0; count < checkedListBox8.Items.Count; count++)
            {
                if (checkedListBox8.GetItemChecked(count) == true)
                    checkList3.Add(count.ToString());
                else checkList3.Add("100");
            }
            for (int count = 0; count < checkedListBox9.Items.Count; count++)
            {
                if (checkedListBox9.GetItemChecked(count) == true)
                    checkList4.Add(count.ToString());
                else checkList4.Add("100");
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update maintenancetrucktipo2s set dateinitial='" + dtT2Start.Value + "',dateend='" + dtT2End.Value + "',prt1=@prt1,prt2=@prt2,prt3=@prt3,prt4=@prt4,prt5=@prt5,prt6=@prt6,prt7=@prt7,prt8=@prt8,prt9=@prt9,prt10=@prt10,prt11=@prt11,prt12=@prt12,prt13=@prt13,prt14=@prt14,prt15=@prt15,prt16=@prt16,prt17=@prt17,pot1=@pot1,pot2=@pot2,pot3=@pot3,pot4=@pot4,pot5=@pot5,pot6=@pot6,pot7=@pot7,pot8=@pot8,pot9=@pot9,pot10=@pot10,pot11=@pot11,pot12=@pot12,pot13=@pot13,pot14=@pot14,pot15=@pot15,pot16=@pot16,pot17=@pot17,rr1=@rr1,rr2=@rr2,rr3=@rr3,rr4=@rr4,rr5=@rr5,rr6=@rr6,rr7=@rr7,rr8=@rr8,rr9=@rr9,rr10=@rr10,rr11=@rr11,rr12=@rr12,rr13=@rr13,rr14=@rr14,rr15=@rr15,rr16=@rr16,rr17=@rr17,prt18=@prt18,prt19=@prt19,prt20=@prt20,prt21=@prt21,prt22=@prt22,prt23=@prt23,prt24=@prt24,prt25=@prt25,prt26=@prt26,prt27=@prt27,prt28=@prt28,prt29=@prt29,prt30=@prt30,prt31=@prt31,pot18=@pot18,pot19=@pot19,pot20=@pot20,pot21=@pot21,pot22=@pot22,pot23=@pot23,pot24=@pot24,pot25=@pot25,pot26=@pot26,pot27=@pot27,pot28=@pot28,pot29=@pot29,pot30=@pot30,pot31=@pot31,rr18=@rr18,rr19=@rr19,rr20=@rr20,rr21=@rr21,rr22=@rr22,rr23=@rr23,rr24=@rr24,rr25=@rr25,rr26=@rr26,rr27=@rr27,rr28=@rr28,rr29=@rr29,rr30=@rr30,rr31=@rr31,prt32=@prt32,prt33=@prt33,prt34=@prt34,prt35=@prt35,prt36=@prt36,prt37=@prt37,prt38=@prt38,prt39=@prt39,prt40=@prt40,prt41=@prt41,prt42=@prt42,prt43=@prt43,prt44=@prt44,prt45=@prt45,prt46=@prt46,prt47=@prt47,prt48=@prt48,pot32=@pot32,pot33=@pot33,pot34=@pot34,pot35=@pot35,pot36=@pot36,pot37=@pot37,pot38=@pot38,pot39=@pot39,pot40=@pot40,pot41=@pot41,pot42=@pot42,pot43=@pot43,pot44=@pot44,pot45=@pot45,pot46=@pot46,pot47=@pot47,pot48=@pot48,rr32=@rr32,rr33=@rr33,rr34=@rr34,rr35=@rr35,rr36=@rr36,rr37=@rr37,rr38=@rr38,rr39=@rr39,rr40=@rr40,rr41=@rr41,rr42=@rr42,rr43=@rr43,rr44=@rr44,rr45=@rr45,rr46=@rr46,rr47=@rr47,rr48=@rr48,prt49=@prt49,prt50=@prt50,prt51=@prt51,prt52=@prt52,prt53=@prt53,prt54=@prt54,prt55=@prt55,prt56=@prt56,prt57=@prt57,prt58=@prt58,prt59=@prt59,prt60=@prt60,prt61=@prt61,prt62=@prt62,prt63=@prt63,prt64=@prt64,pot49=@pot49,pot50=@pot50,pot51=@pot51,pot52=@pot52,pot53=@pot53,pot54=@pot54,pot55=@pot55,pot56=@pot56,pot57=@pot57,pot58=@pot58,pot59=@pot59,pot60=@pot60,pot61=@pot61,pot62=@pot62,pot63=@pot63,pot64=@pot64,rr49=@rr49,rr50=@rr50,rr51=@rr51,rr52=@rr52,rr53=@rr53,rr54=@rr54,rr55=@rr55,rr56=@rr56,rr57=@rr57,rr58=@rr58,rr59=@rr59,rr60=@rr60,rr61=@rr61,rr62=@rr62,rr63=@rr63,rr64=@rr64,notes=@notes,statusorder=@statusorder" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("prt1", checkList[0]);
                cmd.Parameters.AddWithValue("prt2", checkList[1]);
                cmd.Parameters.AddWithValue("prt3", checkList[2]);
                cmd.Parameters.AddWithValue("prt4", checkList[3]);
                cmd.Parameters.AddWithValue("prt5", checkList[4]);
                cmd.Parameters.AddWithValue("prt6", checkList[5]);
                cmd.Parameters.AddWithValue("prt7", checkList[6]);
                cmd.Parameters.AddWithValue("prt8", checkList[7]);
                cmd.Parameters.AddWithValue("prt9", checkList[8]);
                cmd.Parameters.AddWithValue("prt10", checkList[9]);
                cmd.Parameters.AddWithValue("prt11", checkList[10]);
                cmd.Parameters.AddWithValue("prt12", checkList[11]);
                cmd.Parameters.AddWithValue("prt13", checkList[12]);
                cmd.Parameters.AddWithValue("prt14", checkList[13]);
                cmd.Parameters.AddWithValue("prt15", checkList[14]);
                cmd.Parameters.AddWithValue("prt16", checkList[15]);
                cmd.Parameters.AddWithValue("prt17", checkList[16]);
                cmd.Parameters.AddWithValue("pot1", checkList[17]);
                cmd.Parameters.AddWithValue("pot2", checkList[18]);
                cmd.Parameters.AddWithValue("pot3", checkList[19]);
                cmd.Parameters.AddWithValue("pot4", checkList[20]);
                cmd.Parameters.AddWithValue("pot5", checkList[21]);
                cmd.Parameters.AddWithValue("pot6", checkList[22]);
                cmd.Parameters.AddWithValue("pot7", checkList[23]);
                cmd.Parameters.AddWithValue("pot8", checkList[24]);
                cmd.Parameters.AddWithValue("pot9", checkList[25]);
                cmd.Parameters.AddWithValue("pot10", checkList[26]);
                cmd.Parameters.AddWithValue("pot11", checkList[27]);
                cmd.Parameters.AddWithValue("pot12", checkList[28]);
                cmd.Parameters.AddWithValue("pot13", checkList[29]);
                cmd.Parameters.AddWithValue("pot14", checkList[30]);
                cmd.Parameters.AddWithValue("pot15", checkList[31]);
                cmd.Parameters.AddWithValue("pot16", checkList[32]);
                cmd.Parameters.AddWithValue("pot17", checkList[33]);
                cmd.Parameters.AddWithValue("rr1", checkList[34]);
                cmd.Parameters.AddWithValue("rr2", checkList[35]);
                cmd.Parameters.AddWithValue("rr3", checkList[36]);
                cmd.Parameters.AddWithValue("rr4", checkList[37]);
                cmd.Parameters.AddWithValue("rr5", checkList[38]);
                cmd.Parameters.AddWithValue("rr6", checkList[39]);
                cmd.Parameters.AddWithValue("rr7", checkList[40]);
                cmd.Parameters.AddWithValue("rr8", checkList[41]);
                cmd.Parameters.AddWithValue("rr9", checkList[42]);
                cmd.Parameters.AddWithValue("rr10", checkList[43]);
                cmd.Parameters.AddWithValue("rr11", checkList[44]);
                cmd.Parameters.AddWithValue("rr12", checkList[45]);
                cmd.Parameters.AddWithValue("rr13", checkList[46]);
                cmd.Parameters.AddWithValue("rr14", checkList[47]);
                cmd.Parameters.AddWithValue("rr15", checkList[48]);
                cmd.Parameters.AddWithValue("rr16", checkList[49]);
                cmd.Parameters.AddWithValue("rr17", checkList[50]);//51

                cmd.Parameters.AddWithValue("prt18", checkList2[0]);
                cmd.Parameters.AddWithValue("prt19", checkList2[1]);
                cmd.Parameters.AddWithValue("prt20", checkList2[2]);
                cmd.Parameters.AddWithValue("prt21", checkList2[3]);
                cmd.Parameters.AddWithValue("prt22", checkList2[4]);
                cmd.Parameters.AddWithValue("prt23", checkList2[5]);
                cmd.Parameters.AddWithValue("prt24", checkList2[6]);
                cmd.Parameters.AddWithValue("prt25", checkList2[7]);
                cmd.Parameters.AddWithValue("prt26", checkList2[8]);
                cmd.Parameters.AddWithValue("prt27", checkList2[9]);
                cmd.Parameters.AddWithValue("prt28", checkList2[10]);
                cmd.Parameters.AddWithValue("prt29", checkList2[11]);
                cmd.Parameters.AddWithValue("prt30", checkList2[12]);
                cmd.Parameters.AddWithValue("prt31", checkList2[13]);
                cmd.Parameters.AddWithValue("pot18", checkList2[14]);
                cmd.Parameters.AddWithValue("pot19", checkList2[15]);
                cmd.Parameters.AddWithValue("pot20", checkList2[16]);
                cmd.Parameters.AddWithValue("pot21", checkList2[17]);
                cmd.Parameters.AddWithValue("pot22", checkList2[18]);
                cmd.Parameters.AddWithValue("pot23", checkList2[19]);
                cmd.Parameters.AddWithValue("pot24", checkList2[20]);
                cmd.Parameters.AddWithValue("pot25", checkList2[21]);
                cmd.Parameters.AddWithValue("pot26", checkList2[22]);
                cmd.Parameters.AddWithValue("pot27", checkList2[23]);
                cmd.Parameters.AddWithValue("pot28", checkList2[24]);
                cmd.Parameters.AddWithValue("pot29", checkList2[25]);
                cmd.Parameters.AddWithValue("pot30", checkList2[26]);
                cmd.Parameters.AddWithValue("pot31", checkList2[27]);
                cmd.Parameters.AddWithValue("rr18", checkList2[28]);
                cmd.Parameters.AddWithValue("rr19", checkList2[29]);
                cmd.Parameters.AddWithValue("rr20", checkList2[30]);
                cmd.Parameters.AddWithValue("rr21", checkList2[31]);
                cmd.Parameters.AddWithValue("rr22", checkList2[32]);
                cmd.Parameters.AddWithValue("rr23", checkList2[33]);
                cmd.Parameters.AddWithValue("rr24", checkList2[34]);
                cmd.Parameters.AddWithValue("rr25", checkList2[35]);
                cmd.Parameters.AddWithValue("rr26", checkList2[36]);
                cmd.Parameters.AddWithValue("rr27", checkList2[37]);
                cmd.Parameters.AddWithValue("rr28", checkList2[38]);
                cmd.Parameters.AddWithValue("rr29", checkList2[39]);
                cmd.Parameters.AddWithValue("rr30", checkList2[40]);
                cmd.Parameters.AddWithValue("rr31", checkList2[41]);//42, 93

                cmd.Parameters.AddWithValue("prt32", checkList3[0]);
                cmd.Parameters.AddWithValue("prt33", checkList3[1]);
                cmd.Parameters.AddWithValue("prt34", checkList3[2]);
                cmd.Parameters.AddWithValue("prt35", checkList3[3]);
                cmd.Parameters.AddWithValue("prt36", checkList3[4]);
                cmd.Parameters.AddWithValue("prt37", checkList3[5]);
                cmd.Parameters.AddWithValue("prt38", checkList3[6]);
                cmd.Parameters.AddWithValue("prt39", checkList3[7]);
                cmd.Parameters.AddWithValue("prt40", checkList3[8]);
                cmd.Parameters.AddWithValue("prt41", checkList3[9]);
                cmd.Parameters.AddWithValue("prt42", checkList3[10]);
                cmd.Parameters.AddWithValue("prt43", checkList3[11]);
                cmd.Parameters.AddWithValue("prt44", checkList3[12]);
                cmd.Parameters.AddWithValue("prt45", checkList3[13]);
                cmd.Parameters.AddWithValue("prt46", checkList3[14]);
                cmd.Parameters.AddWithValue("prt47", checkList3[15]);
                cmd.Parameters.AddWithValue("prt48", checkList3[16]);
                cmd.Parameters.AddWithValue("pot32", checkList3[17]);
                cmd.Parameters.AddWithValue("pot33", checkList3[18]);
                cmd.Parameters.AddWithValue("pot34", checkList3[19]);
                cmd.Parameters.AddWithValue("pot35", checkList3[20]);
                cmd.Parameters.AddWithValue("pot36", checkList3[21]);
                cmd.Parameters.AddWithValue("pot37", checkList3[22]);
                cmd.Parameters.AddWithValue("pot38", checkList3[23]);
                cmd.Parameters.AddWithValue("pot39", checkList3[24]);
                cmd.Parameters.AddWithValue("pot40", checkList3[25]);
                cmd.Parameters.AddWithValue("pot41", checkList3[26]);
                cmd.Parameters.AddWithValue("pot42", checkList3[27]);
                cmd.Parameters.AddWithValue("pot43", checkList3[28]);
                cmd.Parameters.AddWithValue("pot44", checkList3[29]);
                cmd.Parameters.AddWithValue("pot45", checkList3[30]);
                cmd.Parameters.AddWithValue("pot46", checkList3[31]);
                cmd.Parameters.AddWithValue("pot47", checkList3[32]);
                cmd.Parameters.AddWithValue("pot48", checkList3[33]);
                cmd.Parameters.AddWithValue("rr32", checkList3[34]);
                cmd.Parameters.AddWithValue("rr33", checkList3[35]);
                cmd.Parameters.AddWithValue("rr34", checkList3[36]);
                cmd.Parameters.AddWithValue("rr35", checkList3[37]);
                cmd.Parameters.AddWithValue("rr36", checkList3[38]);
                cmd.Parameters.AddWithValue("rr37", checkList3[39]);
                cmd.Parameters.AddWithValue("rr38", checkList3[40]);
                cmd.Parameters.AddWithValue("rr39", checkList3[41]);
                cmd.Parameters.AddWithValue("rr40", checkList3[42]);
                cmd.Parameters.AddWithValue("rr41", checkList3[43]);
                cmd.Parameters.AddWithValue("rr42", checkList3[44]);
                cmd.Parameters.AddWithValue("rr43", checkList3[45]);
                cmd.Parameters.AddWithValue("rr44", checkList3[46]);
                cmd.Parameters.AddWithValue("rr45", checkList3[47]);
                cmd.Parameters.AddWithValue("rr46", checkList3[48]);
                cmd.Parameters.AddWithValue("rr47", checkList3[49]);
                cmd.Parameters.AddWithValue("rr48", checkList3[50]);//51, 144

                cmd.Parameters.AddWithValue("prt49", checkList4[0]);
                cmd.Parameters.AddWithValue("prt50", checkList4[1]);
                cmd.Parameters.AddWithValue("prt51", checkList4[2]);
                cmd.Parameters.AddWithValue("prt52", checkList4[3]);
                cmd.Parameters.AddWithValue("prt53", checkList4[4]);
                cmd.Parameters.AddWithValue("prt54", checkList4[5]);
                cmd.Parameters.AddWithValue("prt55", checkList4[6]);
                cmd.Parameters.AddWithValue("prt56", checkList4[7]);
                cmd.Parameters.AddWithValue("prt57", checkList4[8]);
                cmd.Parameters.AddWithValue("prt58", checkList4[9]);
                cmd.Parameters.AddWithValue("prt59", checkList4[10]);
                cmd.Parameters.AddWithValue("prt60", checkList4[11]);
                cmd.Parameters.AddWithValue("prt61", checkList4[12]);
                cmd.Parameters.AddWithValue("prt62", checkList4[13]);
                cmd.Parameters.AddWithValue("prt63", checkList4[14]);
                cmd.Parameters.AddWithValue("prt64", checkList4[15]);
                cmd.Parameters.AddWithValue("pot49", checkList4[16]);
                cmd.Parameters.AddWithValue("pot50", checkList4[17]);
                cmd.Parameters.AddWithValue("pot51", checkList4[18]);
                cmd.Parameters.AddWithValue("pot52", checkList4[19]);
                cmd.Parameters.AddWithValue("pot53", checkList4[20]);
                cmd.Parameters.AddWithValue("pot54", checkList4[21]);
                cmd.Parameters.AddWithValue("pot55", checkList4[22]);
                cmd.Parameters.AddWithValue("pot56", checkList4[23]);
                cmd.Parameters.AddWithValue("pot57", checkList4[24]);
                cmd.Parameters.AddWithValue("pot58", checkList4[25]);
                cmd.Parameters.AddWithValue("pot59", checkList4[26]);
                cmd.Parameters.AddWithValue("pot60", checkList4[27]);
                cmd.Parameters.AddWithValue("pot61", checkList4[28]);
                cmd.Parameters.AddWithValue("pot62", checkList4[29]);
                cmd.Parameters.AddWithValue("pot63", checkList4[30]);
                cmd.Parameters.AddWithValue("pot64", checkList4[31]);
                cmd.Parameters.AddWithValue("rr49", checkList4[32]);
                cmd.Parameters.AddWithValue("rr50", checkList4[33]);
                cmd.Parameters.AddWithValue("rr51", checkList4[34]);
                cmd.Parameters.AddWithValue("rr52", checkList4[35]);
                cmd.Parameters.AddWithValue("rr53", checkList4[36]);
                cmd.Parameters.AddWithValue("rr54", checkList4[37]);
                cmd.Parameters.AddWithValue("rr55", checkList4[38]);
                cmd.Parameters.AddWithValue("rr56", checkList4[39]);
                cmd.Parameters.AddWithValue("rr57", checkList4[40]);
                cmd.Parameters.AddWithValue("rr58", checkList4[41]);
                cmd.Parameters.AddWithValue("rr59", checkList4[42]);
                cmd.Parameters.AddWithValue("rr60", checkList4[43]);
                cmd.Parameters.AddWithValue("rr61", checkList4[44]);
                cmd.Parameters.AddWithValue("rr62", checkList4[45]);
                cmd.Parameters.AddWithValue("rr63", checkList4[46]);
                cmd.Parameters.AddWithValue("rr64", checkList4[47]);
                cmd.Parameters.AddWithValue("notes", txtT2Notes.Text);
                cmd.Parameters.AddWithValue("statusorder", statusorder);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            dgvTruckT2.DataSource = conectandose.Consultar(TblName);
        }

        /// <summary>////////////////////////////
        /// TIPO III
        /// </summary>///////////////////////////
        private void btnT3Clear_Click(object sender, EventArgs e)
        {

            lblT3.Text = "";
            lblOdoIni3.Text = "";
            lblT3Driver.Text = "";
            lblT3Order.Text = "";
            dtT3Start.Text = "";
            dtT3End.Text = "";
            for (int count = 0; count < checkedListBox4.Items.Count; count++)
            {
                checkedListBox4.SetItemChecked(count, false);
            }
            txtT3Incidense.Text = "";
            txtT3Expense.Text = "";
        }
        private void btnT3First_Click(object sender, EventArgs e)
        {
            cuentat3 = dgvTruckT3.Rows.GetLastRow(0) + 1;
            if (cuentat3 != 0)
            {
                sgtet3 = dgvTruckT3.Rows.GetFirstRow(0);
                dgvTruckT3_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaT3();
            }
        }

        private void btnT3Previous_Click(object sender, EventArgs e)
        {
            if (cuentat3 != 0)
            {
                sgtet3 = dgvTruckT3.Rows.GetPreviousRow(sgtet3, 0);
                if (sgtet3 == -1) sgtet3 = cuentat3 - 1;
                if (sgtet3 <= cuentat3 && sgtet3 >= 0)
                {
                    dgvTruckT3_RowEnter(sender, e);
                    rellenaT3();
                }
            }
        }

        private void btnT3Next_Click(object sender, EventArgs e)
        {
            cuentat3 = dgvTruckT3.Rows.GetLastRow(0) + 1;
            if (cuentat3 != 0)
            {
                sgtet3 = dgvTruckT3.Rows.GetNextRow(sgtet3, 0);
                if (sgtet3 == -1) sgtet3 = 0;
                if (sgtet3 <= cuentat3 && sgtet3 >= 0)
                {
                    dgvTruckT3_RowEnter(sender, e);
                    rellenaT3();
                }
            }
        }

        private void btnT3End_Click(object sender, EventArgs e)
        {
            cuentat3 = dgvTruckT3.Rows.GetLastRow(0) + 1;
            if (cuentat3 != 0)
            {
                sgtet3 = dgvTruckT3.Rows.GetLastRow(0);
                dgvTruckT3_RowEnter(sender, e);
                rellenaT3();
            }
        }
        private void dgvTruckT3_RowEnter(object sender, EventArgs e)
        {
            dgvTruckT3.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvTruckT3.Rows[sgtet3].Selected = true;
            dgvTruckT3.FirstDisplayedScrollingRowIndex = dgvTruckT3.Rows.GetNextRow(sgtet3 - 1, 0);
        }
        private void rellenaT3()
        {
            btnT3Add.Enabled = false;
            btnT3Upd.Enabled = true;
            btnT3Del.Enabled = true;

            codigo = Convert.ToInt32(dgvTruckT3.Rows[sgtet3].Cells[0].Value);
            lblT3.Text = Convert.ToString(dgvTruckT3.Rows[sgtet3].Cells[1].Value);
            //TruckId = lblT3.Text;
            lblOdoIni3.Text = Convert.ToString(dgvTruckT3.Rows[sgtet3].Cells[2].Value);
            dtT3Start.Value = Convert.ToDateTime(dgvTruckT3.Rows[sgtet3].Cells[3].Value);
            dtT3End.Value = Convert.ToDateTime(dgvTruckT3.Rows[sgtet3].Cells[4].Value);
            lblT3Driver.Text = Convert.ToString(dgvTruckT3.Rows[sgtet3].Cells[5].Value);
            lblT3Order.Text = Convert.ToString(dgvTruckT3.Rows[sgtet3].Cells[15].Value);
            for (int count = 0; count < chkT3Order.Items.Count; count++)
            {
                chkT3Order.SetItemChecked(count, false);
            }
            chkT3Order.SetItemChecked(Convert.ToInt32(dgvTruckT3.Rows[sgtet3].Cells[16].Value), true);
            for (int count = 0; count < checkedListBox4.Items.Count; count++)
            {
                checkedListBox4.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTruckT3.Rows[sgtet3].Cells[count + 6].Value) != 100)
                    checkedListBox4.SetItemChecked(Convert.ToInt32(dgvTruckT3.Rows[sgtet3].Cells[count + 6].Value), true);
            }
            txtT3Incidense.Text = Convert.ToString(dgvTruckT3.Rows[sgtet3].Cells[13].Value);
            txtT3Expense.Text = Convert.ToString(dgvTruckT3.Rows[sgtet3].Cells[14].Value);

            dgvT3Mto.DataSource = conectandose.ConsultarTrucks("trucksprofiles", lblT3.Text);
            codigot3 = Convert.ToInt32(dgvT3Mto.Rows[0].Cells[0].Value);

            lbRecordT3.Text = "Record " + (sgtet3 + 1) + " of  " + cuentat3;
        }
        private void btnT3Add_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            string zyear = DateTime.Today.Year.ToString();
            List<string> checkList = new List<string>();
            cuentat3 = dgvTruckT3.Rows.GetLastRow(0) + 2;
            lblT3Order.Text = "TRT3 - " + cuentat3.ToString() + "/" + zyear;
            for (int count = 0; count < chkT3Order.Items.Count; count++)
            {
                if (chkT3Order.GetItemChecked(count) == true)
                {
                    statusorder = count.ToString();
                    break;
                }
            }
            for (int count = 0; count < checkedListBox4.Items.Count; count++)
            {
                if (checkedListBox4.GetItemChecked(count) == true)
                    checkList.Add(count.ToString());
                else checkList.Add("100");
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into maintenancetrucktipo3s (truckid,milestotal,dateinitial,dateend,drivername,t3p1,t3p2,t3p3,t3p4,t3p5,t3p6,t3p7,incidense,expense,numberorder,statusorder) values ('" + lblT3.Text + "','" + lblOdoIni3 .Text + "','" + dtT3Start.Value + "','" + dtT3End.Value + "','" + lblT3Driver.Text + "',@t3p1,@t3p2,@t3p3,@t3p4,@t3p5,@t3p6,@t3p7,@incidense,@expense,'" + lblT3Order.Text + "',@statusorder)", conn);
                cmd.Parameters.AddWithValue("t3p1", checkList[0]);
                cmd.Parameters.AddWithValue("t3p2", checkList[1]);
                cmd.Parameters.AddWithValue("t3p3", checkList[2]);
                cmd.Parameters.AddWithValue("t3p4", checkList[3]);
                cmd.Parameters.AddWithValue("t3p5", checkList[4]);
                cmd.Parameters.AddWithValue("t3p6", checkList[5]);
                cmd.Parameters.AddWithValue("t3p7", checkList[6]);
                cmd.Parameters.AddWithValue("incidense", txtT3Incidense.Text);
                cmd.Parameters.AddWithValue("expense", txtT3Expense.Text);
                cmd.Parameters.AddWithValue("statusorder", statusorder);
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
            btnT3Add.Enabled = false;
            btnT3Upd.Enabled = true;
            btnT3Del.Enabled = true;
            btnT3Order.Enabled = true;
            btnT3Print.Enabled = true;

            btnT3Clear.Enabled = true;
            btnT3First.Enabled = true;
            btnT3Previous.Enabled = true;
            btnT3Next.Enabled = true;
            btnT3End.Enabled = true;
            dgvTruckT3.DataSource = conectandose.Consultar(TblName);
        }

        private void btnT3Del_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnT3Clear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvTruckT3.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnT3Upd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            List<string> checkList = new List<string>();
            for (int count = 0; count < chkT3Order.Items.Count; count++)
            {
                if (chkT3Order.GetItemChecked(count) == true)
                {
                    statusorder = count.ToString();
                    break;
                }
            }
            for (int count = 0; count < checkedListBox4.Items.Count; count++)
            {
                if (checkedListBox4.GetItemChecked(count) == true)
                    checkList.Add(count.ToString());
                else checkList.Add("100");
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update maintenancetrucktipo3s set dateinitial='" + dtT3Start.Text + "',dateend='" + dtT3End.Text + "',drivername='" + lblT3Driver.Text + "',t3p1=@t3p1,t3p2=@t3p2,t3p3=@t3p3,t3p4=@t3p4,t3p5=@t3p5,t3p6=@t3p6,t3p7=@t3p7,incidense=@incidense,expense=@expense,statusorder=@statusorder" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("t3p1", checkList[0]);
                cmd.Parameters.AddWithValue("t3p2", checkList[1]);
                cmd.Parameters.AddWithValue("t3p3", checkList[2]);
                cmd.Parameters.AddWithValue("t3p4", checkList[3]);
                cmd.Parameters.AddWithValue("t3p5", checkList[4]);
                cmd.Parameters.AddWithValue("t3p6", checkList[5]);
                cmd.Parameters.AddWithValue("t3p7", checkList[6]);
                cmd.Parameters.AddWithValue("incidense", txtT3Incidense.Text);
                cmd.Parameters.AddWithValue("expense", txtT3Expense.Text);
                cmd.Parameters.AddWithValue("statusorder",statusorder); 
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
            dgvTruckT3.DataSource = conectandose.Consultar(TblName);
        }
        private void btnT3Order_Click(object sender, EventArgs e)
        {
            if (!(lblT3.Text == ""))
            {
                TruckPrint truckordert3 = new TruckPrint(lblT3.Text, lblOdoIni3.Text, lblT3Driver.Text, codigo, lblT3Order.Text, 3, 0);
                truckordert3.Show();
            }
            else
                MessageBox.Show("Select a Record!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnT3Print_Click(object sender, EventArgs e)
        {
            if (!(chkT3Order.GetItemChecked(1) == true))
                MessageBox.Show("Order not Closed!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                TruckPrint truckordert3 = new TruckPrint(lblT3.Text, lblOdoIni3.Text, lblT3Driver.Text, codigo, lblT3Order.Text, 3, 1);
                truckordert3.Show();
            }
        }
        /// <summary>//////////////////////////
        /// SUMMER
        /// </summary>/////////////////////////
        private void btnSMClear_Click(object sender, EventArgs e)
        {
            lblSM.Text = "";
            lblSMDriver.Text = "";
            lblSMOrder.Text = "";
            dtSMStart.Text = "";
            dtSMEnd.Text = "";
            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                checkedListBox1.SetItemChecked(count, false);
            }
            for (int count = 0; count < checkedListBox2.Items.Count; count++)
            {
                checkedListBox2.SetItemChecked(count, false);
            }
            txtSMNotes.Text = "";
        }
        private void btnSMFirst_Click(object sender, EventArgs e)
        {
            cuentasm = dgvSummer.Rows.GetLastRow(0) + 1;
            if (cuentasm != 0)
            {
                sgtesm = dgvSummer.Rows.GetFirstRow(0);
                dgvSummer_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaSM();
            }
        }
        private void btnSMPrevious_Click(object sender, EventArgs e)
        {
            if (cuentasm != 0)
            {
                sgtesm = dgvSummer.Rows.GetPreviousRow(sgtesm, 0);
                if (sgtesm == -1) sgtesm = cuentasm - 1;
                if (sgtesm <= cuentasm && sgtesm >= 0)
                {
                    dgvSummer_RowEnter(sender, e);
                    rellenaSM();
                }
            }
        }

        private void btnSMNext_Click(object sender, EventArgs e)
        {
            cuentasm = dgvSummer.Rows.GetLastRow(0) + 1;
            if (cuentasm != 0)
            {
                sgtesm = dgvSummer.Rows.GetNextRow(sgtesm, 0);
                if (sgtesm == -1) sgtesm = 0;
                if (sgtesm <= cuentasm && sgtesm >= 0)
                {
                    dgvSummer_RowEnter(sender, e);
                    rellenaSM();
                }
            }
        }

        private void btnSMEnd_Click(object sender, EventArgs e)
        {
            cuentasm = dgvSummer.Rows.GetLastRow(0) + 1;
            if (cuentasm != 0)
            {
                sgtesm = dgvSummer.Rows.GetLastRow(0);
                dgvSummer_RowEnter(sender, e);
                rellenaSM();
            }
        }
        private void dgvSummer_RowEnter(object sender, EventArgs e)
        {
            dgvSummer.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvSummer.Rows[sgtesm].Selected = true;
            dgvSummer.FirstDisplayedScrollingRowIndex = dgvSummer.Rows.GetNextRow(sgtesm - 1, 0);
        }
        private void rellenaSM()
        {
            btnSMAdd.Enabled = false;
            btnSMUpd.Enabled = true;
            btnSMDel.Enabled = true;

            codigo = Convert.ToInt32(dgvSummer.Rows[sgtesm].Cells[0].Value);
            lblSM.Text = Convert.ToString(dgvSummer.Rows[sgtesm].Cells[1].Value);
            //TruckId = lblSummer.Text;
            dtSMStart.Value = Convert.ToDateTime(dgvSummer.Rows[sgtesm].Cells[2].Value);
            dtSMEnd.Value = Convert.ToDateTime(dgvSummer.Rows[sgtesm].Cells[3].Value);
            lblSMDriver.Text = Convert.ToString(dgvSummer.Rows[sgtesm].Cells[4].Value);
            lblSMOrder.Text = Convert.ToString(dgvSummer.Rows[sgtesm].Cells[20].Value);
            for (int count = 0; count < chkSMOrder.Items.Count; count++)
            {
                chkSMOrder.SetItemChecked(count, false);
            }
            chkSMOrder.SetItemChecked(Convert.ToInt32(dgvSummer.Rows[sgtesm].Cells[21].Value), true);
            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                checkedListBox1.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvSummer.Rows[sgtesm].Cells[count + 5].Value) != 100)
                    checkedListBox1.SetItemChecked(Convert.ToInt32(dgvSummer.Rows[sgtesm].Cells[count+5].Value), true);
            }
            int valor = 0;
            for (int count = 0; count < checkedListBox2.Items.Count; count++)
            {
                valor = 0;
                valor = Convert.ToInt32(dgvSummer.Rows[sgtesm].Cells[count+13].Value);
                if (valor - 8 < 0)
                    valor = 8;
                checkedListBox2.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvSummer.Rows[sgtesm].Cells[count + 13].Value) != 100)
                    checkedListBox2.SetItemChecked(valor-8, true);
            }
            txtSMNotes.Text = Convert.ToString(dgvSummer.Rows[sgtesm].Cells[19].Value);

            lbRecordSM.Text = "Record " + (sgtesm + 1) + " of  " + cuentasm;
        }
        private void btnSMAdd_Click(object sender, EventArgs e)
        {
            int cuenta =  0;
            string statusorder = "";
            string zyear = DateTime.Today.Year.ToString();
            List<string> checkList = new List<string>();
            cuentasm = dgvSummer.Rows.GetLastRow(0) + 2;
            lblSMOrder.Text = "TRSM - " + cuentasm.ToString() + "/" + zyear;
            for (int count = 0; count < chkSMOrder.Items.Count; count++)
            {
                if (chkSMOrder.GetItemChecked(count) == true)
                {
                    statusorder = count.ToString();
                    break;
                }
            }
            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                if (checkedListBox1.GetItemChecked(count) == true)
                    checkList.Add(count.ToString());
                else checkList.Add("100");
                cuenta++;
            }

            for (int count = 0; count < checkedListBox2.Items.Count; count++)
            {
                if (checkedListBox2.GetItemChecked(count) == true)
                    checkList.Add(cuenta.ToString());
                else checkList.Add("100");
                cuenta++;
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into maintenancesummers (truckid,dateinitial,dateend,drivername,sm1,sm2,sm3,sm4,sm5,sm6,sm7,sm8,sm9,sm10,sm11,sm12,sm13,notes,numberorder,statusorder) values ('" + lblSM.Text + "','" + dtSMStart.Value + "','" + dtSMEnd.Value + "','" + lblSMDriver.Text + "',@sm1,@sm2,@sm3,@sm4,@sm5,@sm6,@sm7,@sm8,@sm9,@sm10,@sm11,@sm12,@sm13,@notes,'" + lblSMOrder.Text + "',@statusorder)", conn);
                cmd.Parameters.AddWithValue("sm1", checkList[0]);
                cmd.Parameters.AddWithValue("sm2", checkList[1]);
                cmd.Parameters.AddWithValue("sm3", checkList[2]);
                cmd.Parameters.AddWithValue("sm4", checkList[3]);
                cmd.Parameters.AddWithValue("sm5", checkList[4]);
                cmd.Parameters.AddWithValue("sm6", checkList[5]);
                cmd.Parameters.AddWithValue("sm7", checkList[6]);
                cmd.Parameters.AddWithValue("sm8", checkList[7]);
                cmd.Parameters.AddWithValue("sm9", checkList[8]);
                cmd.Parameters.AddWithValue("sm10", checkList[9]);
                cmd.Parameters.AddWithValue("sm11", checkList[10]);
                cmd.Parameters.AddWithValue("sm12", checkList[11]);
                cmd.Parameters.AddWithValue("sm13", checkList[12]);
                cmd.Parameters.AddWithValue("notes", txtSMNotes.Text);
                cmd.Parameters.AddWithValue("statusorder", statusorder);
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
            btnSMAdd.Enabled = false;
            btnSMUpd.Enabled = true;
            btnSMDel.Enabled = true;
            btnSMOrder.Enabled = true;
            btnSMPrint.Enabled = true;

            btnSMClear.Enabled = true;
            btnSMFirst.Enabled = true;
            btnSMPrevious.Enabled = true;
            btnSMNext.Enabled = true;
            btnSMEnd.Enabled = true;
            dgvSummer.DataSource = conectandose.Consultar(TblName);
        }

        private void btnSMDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnSMClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvSummer.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnSMUpd_Click(object sender, EventArgs e)
        {
            int cuenta = 0;
            string statusorder = "";
            List<string> checkList = new List<string>();
            for (int count = 0; count < chkSMOrder.Items.Count; count++)
            {
                if (chkSMOrder.GetItemChecked(count) == true)
                {
                    statusorder = count.ToString();
                    break;
                }
            }
            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                if (checkedListBox1.GetItemChecked(count) == true)
                    checkList.Add(count.ToString());
                else checkList.Add("100");
                cuenta++;
            }

            for (int count = 0; count < checkedListBox2.Items.Count; count++)
            {
                if (checkedListBox2.GetItemChecked(count) == true)
                    checkList.Add(cuenta.ToString());
                else checkList.Add("100");
                cuenta++;
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update maintenancesummers set dateinitial='" + dtSMStart.Text + "',dateend='" + dtSMEnd.Text + "',drivername='" + lblSMDriver.Text + "',sm1=@sm1,sm2=@sm2,sm3=@sm3,sm4=@sm4,sm5=@sm5,sm6=@sm6,sm7=@sm7,sm8=@sm8,sm9=@sm9,sm10=@sm10,sm11=@sm11,sm12=@sm12,sm13=@sm13,notes=@notes,statusorder=@statusorder" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("sm1", checkList[0]);
                cmd.Parameters.AddWithValue("sm2", checkList[1]);
                cmd.Parameters.AddWithValue("sm3", checkList[2]);
                cmd.Parameters.AddWithValue("sm4", checkList[3]);
                cmd.Parameters.AddWithValue("sm5", checkList[4]);
                cmd.Parameters.AddWithValue("sm6", checkList[5]);
                cmd.Parameters.AddWithValue("sm7", checkList[6]);
                cmd.Parameters.AddWithValue("sm8", checkList[7]);
                cmd.Parameters.AddWithValue("sm9", checkList[8]);
                cmd.Parameters.AddWithValue("sm10", checkList[9]);
                cmd.Parameters.AddWithValue("sm11", checkList[10]);
                cmd.Parameters.AddWithValue("sm12", checkList[11]);
                cmd.Parameters.AddWithValue("sm13", checkList[12]);
                cmd.Parameters.AddWithValue("notes", txtSMNotes.Text);
                cmd.Parameters.AddWithValue("statusorder", statusorder);
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
            dgvSummer.DataSource = conectandose.Consultar(TblName);
        }

        /// <summary>////////////////////////
        /// WINTER
        /// </summary>///////////////////////\
        /// 
        private void btnWTClear_Click(object sender, EventArgs e)
        {
            lblWT.Text = "";
            lblWTDriver.Text = "";
            lblWTOrder.Text = "";
            dtWTStart.Text = "";
            dtWTEnd.Text = "";
            for (int count = 0; count < checkedListBox3.Items.Count; count++)
            {
                checkedListBox3.SetItemChecked(count, false);
            }
            txtWTNotes.Text = "";
        }
        private void btnWTFirst_Click(object sender, EventArgs e)
        {
            cuentawt = dgvWinter.Rows.GetLastRow(0) + 1;
            if (cuentawt != 0)
            {
                sgtewt = dgvWinter.Rows.GetFirstRow(0);
                dgvWinter_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaWT();
            }
        }

        private void btnPMOrder_Click(object sender, EventArgs e)
        {
            if (!(lblPM.Text == ""))
            {
                TruckPrint truckorderpm = new TruckPrint(lblPM.Text, lblOdoIniI.Text, lblPMDriver.Text, codigo, lblPMOrder.Text, 1, 0);
                truckorderpm.Show();
            }
            else
                MessageBox.Show("Select a Record!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnT2Order_Click(object sender, EventArgs e)
        {
            if (!(lblT2.Text == ""))
            {
                MessageBox.Show("Prepare the Print with paper A4 (8.5 pulg. x 14 pulg.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TruckPrint truckordert2 = new TruckPrint(lblT2.Text, lblOdoIni2.Text, lblT2Driver.Text, codigo, lblT2Order.Text, 2, 0);
                truckordert2.Show();
            }
            else
                MessageBox.Show("Select a Record!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private void btnSMOrder_Click(object sender, EventArgs e)
        {
            if (!(lblSM.Text == ""))
            {
                TruckPrint truckordersm = new TruckPrint(lblSM.Text, "", lblSMDriver.Text, codigo, lblSMOrder.Text, 4, 0);
                truckordersm.Show();
            }
            else
                MessageBox.Show("Select a Record!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnWTOrder_Click(object sender, EventArgs e)
        {
            if (!(lblWT.Text == ""))
            {
                TruckPrint truckorderwt = new TruckPrint(lblWT.Text, "", lblWTDriver.Text, codigo, lblWTOrder.Text, 5, 0);
                truckorderwt.Show();
            }
            else
                MessageBox.Show("Select a Record!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkPMOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = chkPMOrder.SelectedIndex;
            if ((chkPMOrder.GetItemChecked(0) == true || chkPMOrder.GetItemChecked(1) == true))
            {

                if (indice != -1)
                {
                    switch (indice)
                    {
                        case 0: //Flat Rate
                            chkPMOrder.SetItemChecked(1, false);
                            break;
                        case 1: // Mileage
                            chkPMOrder.SetItemChecked(0, false);
                            break;
                    }
                }
            }
        }

        private void chkT2Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = chkT2Order.SelectedIndex;
            if ((chkT2Order.GetItemChecked(0) == true || chkT2Order.GetItemChecked(1) == true))
            {

                if (indice != -1)
                {
                    switch (indice)
                    {
                        case 0: //Flat Rate
                            chkT2Order.SetItemChecked(1, false);
                            break;
                        case 1: // Mileage
                            chkT2Order.SetItemChecked(0, false);
                            break;
                    }
                }
            }
        }

        private void chkT3Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = chkT3Order.SelectedIndex;
            if ((chkT3Order.GetItemChecked(0) == true || chkT3Order.GetItemChecked(1) == true))
            {
                if (indice != -1)
                {
                    switch (indice)
                    {
                        case 0: //Open
                            chkT3Order.SetItemChecked(1, false);
                            break;
                        case 1: // Close
                            chkT3Order.SetItemChecked(0, false);
                            dgvT3Mto.DataSource = conectandose.ConsultarTrucks("trucksprofiles", lblT3.Text);
                            codigot3 = Convert.ToInt32(dgvT3Mto.Rows[0].Cells[0].Value);
                            string miles = "0";
                            NpgsqlCommand cmd = new NpgsqlCommand("update trucksprofiles set totalmiles='" + miles + "'" + " where id=" + codigot3, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            break;
                    }
                }
            }
        }

        private void chkSMOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = chkSMOrder.SelectedIndex;
            if ((chkSMOrder.GetItemChecked(0) == true || chkSMOrder.GetItemChecked(1) == true))
            {

                if (indice != -1)
                {
                    switch (indice)
                    {
                        case 0: //Flat Rate
                            chkSMOrder.SetItemChecked(1, false);
                            break;
                        case 1: // Mileage
                            chkSMOrder.SetItemChecked(0, false);
                            break;
                    }
                }
            }
        }

        private void chkWTOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = chkWTOrder.SelectedIndex;
            if ((chkWTOrder.GetItemChecked(0) == true || chkWTOrder.GetItemChecked(1) == true))
            {

                if (indice != -1)
                {
                    switch (indice)
                    {
                        case 0: //Flat Rate
                            chkWTOrder.SetItemChecked(1, false);
                            break;
                        case 1: // Mileage
                            chkWTOrder.SetItemChecked(0, false);
                            break;
                    }
                }
            }
        }

        private void btnSMPrint_Click(object sender, EventArgs e)
        {
            if (!(chkSMOrder.GetItemChecked(1) == true))
                MessageBox.Show("Order not Closed!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                TruckPrint truckordersm = new TruckPrint(lblSM.Text, "", lblSMDriver.Text, codigo, lblSMOrder.Text, 4, 1);
                truckordersm.Show();
            }
        }

        private void btnPMPrint_Click(object sender, EventArgs e)
        {
            if (!(chkPMOrder.GetItemChecked(1) == true))
                MessageBox.Show("Order not Closed!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                TruckPrint truckorderpm = new TruckPrint(lblPM.Text, lblOdoIniI.Text, lblPMDriver.Text, codigo, lblPMOrder.Text, 1, 1);
                truckorderpm.Show();
            }
        }

        private void btnT2Print_Click(object sender, EventArgs e)
        {
            if(!(chkT2Order.GetItemChecked(1)==true))
                MessageBox.Show("Order not Closed!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Prepare the Print with paper A4 (8.5 pulg. x 14 pulg.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TruckPrint truckorderwt = new TruckPrint(lblT2.Text, lblOdoIni2.Text, lblT2Driver.Text, codigo, lblT2Order.Text, 2, 1);
                truckorderwt.Show();
            }
        }

        private void btnWTPrevious_Click(object sender, EventArgs e)
        {
            if (cuentawt != 0)
            {
                sgtewt = dgvWinter.Rows.GetPreviousRow(sgtewt, 0);
                if (sgtewt == -1) sgtewt = cuentawt - 1;
                if (sgtewt <= cuentawt && sgtewt >= 0)
                {
                    dgvWinter_RowEnter(sender, e);
                    rellenaWT();
                }
            }
        }

        private void btnWTNext_Click(object sender, EventArgs e)
        {
            cuentawt = dgvWinter.Rows.GetLastRow(0) + 1;
            if (cuentawt != 0)
            {
                sgtewt = dgvWinter.Rows.GetNextRow(sgtewt, 0);
                if (sgtewt == -1) sgtewt = 0;
                if (sgtewt <= cuentawt && sgtewt >= 0)
                {
                    dgvWinter_RowEnter(sender, e);
                    rellenaWT();
                }
            }
        }

        private void btnWTEnd_Click(object sender, EventArgs e)
        {
            cuentawt = dgvWinter.Rows.GetLastRow(0) + 1;
            if (cuentawt != 0)
            {
                sgtewt = dgvWinter.Rows.GetLastRow(0);
                dgvWinter_RowEnter(sender, e);
                rellenaWT();
            }
        }
        private void dgvWinter_RowEnter(object sender, EventArgs e)
        {
            dgvWinter.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvWinter.Rows[sgtewt].Selected = true;
            dgvWinter.FirstDisplayedScrollingRowIndex = dgvWinter.Rows.GetNextRow(sgtewt - 1, 0);
        }
        private void rellenaWT()
        {
            btnWTAdd.Enabled = false;
            btnWTUpd.Enabled = true;
            btnWTDel.Enabled = true;

            codigo = Convert.ToInt32(dgvWinter.Rows[sgtewt].Cells[0].Value);
            lblWT.Text = Convert.ToString(dgvWinter.Rows[sgtewt].Cells[1].Value);
            //TruckId = lblWinter.Text;
            lblWTOrder.Text = Convert.ToString(dgvWinter.Rows[sgtewt].Cells[25].Value);
            dtWTStart.Value = Convert.ToDateTime(dgvWinter.Rows[sgtewt].Cells[2].Value);
            dtWTEnd.Value = Convert.ToDateTime(dgvWinter.Rows[sgtewt].Cells[3].Value);
            lblWTDriver.Text = Convert.ToString(dgvWinter.Rows[sgtewt].Cells[4].Value);
            for (int count = 0; count < chkWTOrder.Items.Count; count++)
            {
                chkWTOrder.SetItemChecked(count, false);
            }
            chkWTOrder.SetItemChecked(Convert.ToInt32(dgvWinter.Rows[sgtewt].Cells[26].Value), true);
            for (int count = 0; count < checkedListBox3.Items.Count; count++)
            {
                checkedListBox3.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvWinter.Rows[sgtewt].Cells[count + 5].Value) != 100)
                    checkedListBox3.SetItemChecked(Convert.ToInt32(dgvWinter.Rows[sgtewt].Cells[count+5].Value), true);
            }
            
            txtWTNotes.Text = Convert.ToString(dgvWinter.Rows[sgtewt].Cells[24].Value);

            lbRecordWT.Text = "Record " + (sgtewt + 1) + " of  " + cuentawt;
        }
        private void btnWTAdd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            string zyear = DateTime.Today.Year.ToString();
            List<string> checkList = new List<string>();
            cuentawt = dgvWinter.Rows.GetLastRow(0) + 2;
            lblWTOrder.Text = "TRWT - " + cuentawt.ToString() + "/" + zyear;
            for (int count = 0; count < chkWTOrder.Items.Count; count++)
            {
                if (chkWTOrder.GetItemChecked(count) == true)
                {
                    statusorder = count.ToString();
                    break;
                }
            }
            for (int count = 0; count < checkedListBox3.Items.Count; count++)
            {
                if (checkedListBox3.GetItemChecked(count) == true)
                    checkList.Add(count.ToString());
                else checkList.Add("100");
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into maintenancewinters (truckid,dateinitial,dateend,drivername,wt1,wt2,wt3,wt4,wt5,wt6,wt7,wt8,wt9,wt10,wt11,wt12,wt13,wt14,wt15,wt16,wt17,wt18,wt19,notes,numberorder,statusorder) values ('" + lblWTOrder.Text + "','" + dtWTStart.Value + "','" + dtWTEnd.Value + "','" + lblWTDriver.Text + "',@wt1,@wt2,@wt3,@wt4,@wt5,@wt6,@wt7,@wt8,@wt9,@wt10,@wt11,@wt12,@wt13,@wt14,@wt15,@wt16,@wt17,@wt18,@wt19,@notes,'" + lblSMOrder.Text + "',@statusorder)", conn);
                cmd.Parameters.AddWithValue("wt1", checkList[0]);
                cmd.Parameters.AddWithValue("wt2", checkList[1]);
                cmd.Parameters.AddWithValue("wt3", checkList[2]);
                cmd.Parameters.AddWithValue("wt4", checkList[3]);
                cmd.Parameters.AddWithValue("wt5", checkList[4]);
                cmd.Parameters.AddWithValue("wt6", checkList[5]);
                cmd.Parameters.AddWithValue("wt7", checkList[6]);
                cmd.Parameters.AddWithValue("wt8", checkList[7]);
                cmd.Parameters.AddWithValue("wt9", checkList[8]);
                cmd.Parameters.AddWithValue("wt10", checkList[9]);
                cmd.Parameters.AddWithValue("wt11", checkList[10]);
                cmd.Parameters.AddWithValue("wt12", checkList[11]);
                cmd.Parameters.AddWithValue("wt13", checkList[12]);
                cmd.Parameters.AddWithValue("wt14", checkList[13]);
                cmd.Parameters.AddWithValue("wt15", checkList[14]);
                cmd.Parameters.AddWithValue("wt16", checkList[15]);
                cmd.Parameters.AddWithValue("wt17", checkList[16]);
                cmd.Parameters.AddWithValue("wt18", checkList[17]);
                cmd.Parameters.AddWithValue("wt19", checkList[18]);
                cmd.Parameters.AddWithValue("notes", txtWTNotes.Text);
                cmd.Parameters.AddWithValue("statusorder", statusorder);
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
            btnWTAdd.Enabled = false;
            btnWTUpd.Enabled = true;
            btnWTDel.Enabled = true;
            btnWTOrder.Enabled = true;
            btnWTPrint.Enabled = true;

            btnWTClear.Enabled = true;
            btnWTFirst.Enabled = true;
            btnWTPrevious.Enabled = true;
            btnWTNext.Enabled = true;
            btnWTEnd.Enabled = true;
            dgvWinter.DataSource = conectandose.Consultar(TblName);
        }

        private void btnWTDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnWTClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvWinter.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnWTUpd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            List<string> checkList = new List<string>();
            for (int count = 0; count < chkWTOrder.Items.Count; count++)
            {
                if (chkWTOrder.GetItemChecked(count) == true)
                {
                    statusorder = count.ToString();
                    break;
                }
            }
            for (int count = 0; count < checkedListBox3.Items.Count; count++)
            {
                if (checkedListBox3.GetItemChecked(count) == true)
                    checkList.Add(count.ToString());
                else checkList.Add("100");
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update maintenancewinters set dateinitial='" + dtWTStart.Text + "',dateend='" + dtWTEnd.Text + "',drivername='" + lblWTDriver.Text + "',wt1=@wt1,wt2=@wt2,wt3=@wt3,wt4=@wt4,wt5=@wt5,wt6=@wt6,wt7=@wt7,wt8=@wt8,wt9=@wt9,wt10=@wt10,wt11=@wt11,wt12=@wt12,wt13=@wt13,wt14=@wt14,wt15=@wt15,wt16=@wt16,wt17=@wt17,wt18=@wt18,wt19=@wt19,notes=@notes,statusorder=@statusorder" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("wt1", checkList[0]);
                cmd.Parameters.AddWithValue("wt2", checkList[1]);
                cmd.Parameters.AddWithValue("wt3", checkList[2]);
                cmd.Parameters.AddWithValue("wt4", checkList[3]);
                cmd.Parameters.AddWithValue("wt5", checkList[4]);
                cmd.Parameters.AddWithValue("wt6", checkList[5]);
                cmd.Parameters.AddWithValue("wt7", checkList[6]);
                cmd.Parameters.AddWithValue("wt8", checkList[7]);
                cmd.Parameters.AddWithValue("wt9", checkList[8]);
                cmd.Parameters.AddWithValue("wt10", checkList[9]);
                cmd.Parameters.AddWithValue("wt11", checkList[10]);
                cmd.Parameters.AddWithValue("wt12", checkList[11]);
                cmd.Parameters.AddWithValue("wt13", checkList[12]);
                cmd.Parameters.AddWithValue("wt14", checkList[13]);
                cmd.Parameters.AddWithValue("wt15", checkList[14]);
                cmd.Parameters.AddWithValue("wt16", checkList[15]);
                cmd.Parameters.AddWithValue("wt17", checkList[16]);
                cmd.Parameters.AddWithValue("wt18", checkList[17]);
                cmd.Parameters.AddWithValue("wt19", checkList[18]);
                cmd.Parameters.AddWithValue("notes", txtWTNotes.Text);
                cmd.Parameters.AddWithValue("statusorder", statusorder);
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
            dgvWinter.DataSource = conectandose.Consultar(TblName);
        }
    }
}
