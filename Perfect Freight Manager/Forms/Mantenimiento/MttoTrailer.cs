using Npgsql;
using Perfect_Freight_Manager.Forms.Reports;
using Perfect_Freight_Manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Mantenimiento
{
    public partial class MttoTrailer : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        private string TblName = "maintenancetrailers";
        private int sgte = 0, cuenta = 0;
        private int codigo, codigotl;
        public MttoTrailer(string trailerId, string trailerOdoIni, string trailerDriver)
        {
            InitializeComponent();
            lblId.Text = trailerId;
            lblOdoIni.Text = trailerOdoIni;
            lblDriver.Text = trailerDriver;
            lblOrder.Text = "";
            chkOrder.SetItemChecked(0, true);

            for (int i = 0; i < 5; i++)
            {
                checkedListBox1.Items.Add("InOk" + (i + 1), false);
            }
            for (int i = 0; i < 5; i++)
            {
                checkedListBox1.Items.Add("InNR" + (i + 1), false);
            }
            for (int i = 0; i < 5; i++)
            {
                checkedListBox1.Items.Add("OutOk" + (i + 1), false);
            }
            for (int i = 0; i < 5; i++)
            {
                checkedListBox1.Items.Add("OutNR" + (i + 1), false);
            }

            for (int i = 5; i < 12; i++)
            {
                checkedListBox2.Items.Add("InOk" + (i + 1), false);
            }
            for (int i = 5; i < 12; i++)
            {
                checkedListBox2.Items.Add("InNR" + (i + 1), false);
            }
            for (int i = 5; i < 12; i++)
            {
                checkedListBox2.Items.Add("OutOk" + (i + 1), false);
            }
            for (int i = 5; i < 12; i++)
            {
                checkedListBox2.Items.Add("OutNR" + (i + 1), false);
            }

            for (int i = 12; i < 19; i++)
            {
                checkedListBox3.Items.Add("InOk" + (i + 1), false);
            }
            for (int i = 12; i < 19; i++)
            {
                checkedListBox3.Items.Add("InNR" + (i + 1), false);
            }
            for (int i = 12; i < 19; i++)
            {
                checkedListBox3.Items.Add("OutOk" + (i + 1), false);
            }
            for (int i = 12; i < 19; i++)
            {
                checkedListBox3.Items.Add("OutNR" + (i + 1), false);
            }

            for (int i = 19; i < 24; i++)
            {
                checkedListBox4.Items.Add("InOk" + (i + 1), false);
            }
            for (int i = 19; i < 24; i++)
            {
                checkedListBox4.Items.Add("InNR" + (i + 1), false);
            }
            for (int i = 19; i < 24; i++)
            {
                checkedListBox4.Items.Add("OutOk" + (i + 1), false);
            }
            for (int i = 19; i < 24; i++)
            {
                checkedListBox4.Items.Add("OutNR" + (i + 1), false);
            }
            ////
            ///
            ///////////////
            for (int i = 24; i < 31; i++)
            {
                checkedListBox5.Items.Add("InOk" + (i + 1), false);
            }
            for (int i = 24; i < 31; i++)
            {
                checkedListBox5.Items.Add("InNR" + (i + 1), false);
            }
            for (int i = 24; i < 31; i++)
            {
                checkedListBox5.Items.Add("OutOk" + (i + 1), false);
            }
            for (int i = 24; i < 31; i++)
            {
                checkedListBox5.Items.Add("OutNR" + (i + 1), false);
            }

            for (int i = 31; i < 38; i++)
            {
                checkedListBox6.Items.Add("InOk" + (i + 1), false);
            }
            for (int i = 31; i < 38; i++)
            {
                checkedListBox6.Items.Add("InNR" + (i + 1), false);
            }
            for (int i = 31; i < 38; i++)
            {
                checkedListBox6.Items.Add("OutOk" + (i + 1), false);
            }
            for (int i = 31; i < 38; i++)
            {
                checkedListBox6.Items.Add("OutNR" + (i + 1), false);
            }

            for (int i = 38; i < 43; i++)
            {
                checkedListBox7.Items.Add("InOk" + (i + 1), false);
            }
            for (int i = 38; i < 43; i++)
            {
                checkedListBox7.Items.Add("InNR" + (i + 1), false);
            }
            for (int i = 38; i < 43; i++)
            {
                checkedListBox7.Items.Add("OutOk" + (i + 1), false);
            }
            for (int i = 38; i < 43; i++)
            {
                checkedListBox7.Items.Add("OutNR" + (i + 1), false);
            }

            for (int i = 43; i < 48; i++)
            {
                checkedListBox8.Items.Add("InOk" + (i + 1), false);
            }
            for (int i = 43; i < 48; i++)
            {
                checkedListBox8.Items.Add("InNR" + (i + 1), false);
            }
            for (int i = 43; i < 48; i++)
            {
                checkedListBox8.Items.Add("OutOk" + (i + 1), false);
            }
            for (int i = 43; i < 48; i++)
            {
                checkedListBox8.Items.Add("OutNR" + (i + 1), false);
            }
            dgvTrailer.DataSource = conectandose.Consultar(TblName);
            lbRecord.Text = "Record " + sgte + " of  " + cuenta;
            if (lblId.Text != "")
            {
                btnAdd.Enabled = true;
                btnUpd.Enabled = false;
                btnDel.Enabled = false;
                btnOrder.Enabled = false;
                btnPrint.Enabled = false;

                btnClear.Enabled = false;
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnEnd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnUpd.Enabled = true;
                btnDel.Enabled = true;
                btnOrder.Enabled = true;
                btnPrint.Enabled = false;

                btnClear.Enabled = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnEnd.Enabled = true;
            }
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblId.Text = "";
            lblOdoIni.Text = "";
            lblDriver.Text = "";
            lblOrder.Text = "";
            dtDateStart.Text = "";
            dtDateEnd.Text = "";
            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                checkedListBox1.SetItemChecked(count, false);
            }
            for (int count = 0; count < checkedListBox2.Items.Count; count++)
            {
                checkedListBox2.SetItemChecked(count, false);
            }
            for (int count = 0; count < checkedListBox3.Items.Count; count++)
            {
                checkedListBox3.SetItemChecked(count, false);
            }
            for (int count = 0; count < checkedListBox4.Items.Count; count++)
            {
                checkedListBox4.SetItemChecked(count, false);
            }
            for (int count = 0; count < checkedListBox5.Items.Count; count++)
            {
                checkedListBox5.SetItemChecked(count, false);
            }
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
            txtNotes.Text = "";

            btnAdd.Enabled = true;
            btnUpd.Enabled = false;
            btnDel.Enabled = false;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            cuenta = dgvTrailer.Rows.GetLastRow(0) + 1;
            if (cuenta != 0)
            {
                sgte = dgvTrailer.Rows.GetFirstRow(0);
                dgvTrailer_RowEnter(sender, e);
                //sgtepd += 1;
                rellena();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            cuenta = dgvTrailer.Rows.GetLastRow(0) + 1;
            if (cuenta != 0)
            {
                sgte = dgvTrailer.Rows.GetPreviousRow(sgte, 0);
                if (sgte == -1) sgte = cuenta - 1;
                if (sgte <= cuenta && sgte >= 0)
                {
                    dgvTrailer_RowEnter(sender, e);
                    rellena();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cuenta = dgvTrailer.Rows.GetLastRow(0) + 1;
            if (cuenta != 0)
            {
                sgte = dgvTrailer.Rows.GetNextRow(sgte, 0);
                if (sgte == -1) sgte = 0;
                if (sgte <= cuenta && sgte >= 0)
                {
                    dgvTrailer_RowEnter(sender, e);
                    rellena();
                }
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            cuenta = dgvTrailer.Rows.GetLastRow(0) + 1;
            if (cuenta != 0)
            {
                sgte = dgvTrailer.Rows.GetLastRow(0);
                dgvTrailer_RowEnter(sender, e);
                rellena();
            }
        }
        private void dgvTrailer_RowEnter(object sender, EventArgs e)
        {
            dgvTrailer.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvTrailer.Rows[sgte].Selected = true;
            dgvTrailer.FirstDisplayedScrollingRowIndex = dgvTrailer.Rows.GetNextRow(sgte - 1, 0);
        }
        private void rellena()
        {
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;

            string zyear = DateTime.Today.Year.ToString();

            codigo = Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[0].Value);
            lblId.Text = Convert.ToString(dgvTrailer.Rows[sgte].Cells[1].Value);
            lblOdoIni.Text = Convert.ToString(dgvTrailer.Rows[sgte].Cells[2].Value);
            lblOrder.Text = Convert.ToString(dgvTrailer.Rows[sgte].Cells[199].Value);
            cuenta = dgvTrailer.Rows.GetLastRow(0) + 2;
            dtDateStart.Value = Convert.ToDateTime(dgvTrailer.Rows[sgte].Cells[3].Value);
            dtDateEnd.Value = Convert.ToDateTime(dgvTrailer.Rows[sgte].Cells[4].Value);
            lblDriver.Text = Convert.ToString(dgvTrailer.Rows[sgte].Cells[5].Value);
            for (int count = 0; count < chkOrder.Items.Count; count++)
            {
                chkOrder.SetItemChecked(count, false);
            }
            chkOrder.SetItemChecked(Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[200].Value), true);

            for (int count = 0; count < chkOrder.Items.Count; count++)
            {
                checkedListBox1.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 6].Value) != 100)
                    checkedListBox1.SetItemChecked(Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 6].Value), true);
            }
            for (int count = 0; count < checkedListBox2.Items.Count; count++)
            {
                checkedListBox2.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 26].Value) != 100)
                    checkedListBox2.SetItemChecked(Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 26].Value), true);
            }
            for (int count = 0; count < checkedListBox3.Items.Count; count++)
            {
                checkedListBox3.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 54].Value) != 100)
                    checkedListBox3.SetItemChecked(Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 54].Value), true);
            }
            for (int count = 0; count < checkedListBox4.Items.Count; count++)
            {
                checkedListBox4.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 82].Value) != 100)
                    checkedListBox4.SetItemChecked(Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 82].Value), true);
            }

            for (int count = 0; count < checkedListBox5.Items.Count; count++)
            {
                checkedListBox5.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 102].Value) != 100)
                    checkedListBox5.SetItemChecked(Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 102].Value), true);
            }
            for (int count = 0; count < checkedListBox6.Items.Count; count++)
            {
                checkedListBox6.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 130].Value) != 100)
                    checkedListBox6.SetItemChecked(Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 130].Value), true);
            }
            for (int count = 0; count < checkedListBox7.Items.Count; count++)
            {
                checkedListBox7.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 158].Value) != 100)
                    checkedListBox7.SetItemChecked(Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 158].Value), true);
            }
            for (int count = 0; count < checkedListBox8.Items.Count; count++)
            {
                checkedListBox8.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 178].Value) != 100)
                    checkedListBox8.SetItemChecked(Convert.ToInt32(dgvTrailer.Rows[sgte].Cells[count + 178].Value), true);
            }
            txtNotes.Text = Convert.ToString(dgvTrailer.Rows[sgte].Cells[198].Value);

            dgvTLMto.DataSource = conectandose.ConsultarTrailers("trailersprofiles", lblId.Text);//trailersprofiles
            codigotl = Convert.ToInt32(dgvTLMto.Rows[0].Cells[0].Value);

            lbRecord.Text = "Record " + (sgte + 1) + " of  " + cuenta;
        }
    

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            string zyear = DateTime.Today.Year.ToString();
            if (!(dtDateStart.Text == "" || dtDateEnd.Text == "" || lblId.Text == "" || chkOrder.GetItemChecked(0) == false))
            {
                List<string> checkList = new List<string>();
                List<string> checkList2 = new List<string>();
                List<string> checkList3 = new List<string>();
                List<string> checkList4 = new List<string>();
                List<string> checkList5 = new List<string>();
                List<string> checkList6 = new List<string>();
                List<string> checkList7 = new List<string>();
                List<string> checkList8 = new List<string>();

                cuenta = dgvTrailer.Rows.GetLastRow(0) + 2;
                lblOrder.Text = "TL - " + cuenta.ToString() + "/" + zyear;
                for (int count = 0; count < chkOrder.Items.Count; count++)
                {
                    if (chkOrder.GetItemChecked(count) == true)
                    {
                        statusorder = count.ToString();
                        break;
                    }
                }
                //Llenando los PRT, POPT y RR 29,28,27
                for (int count = 0; count < checkedListBox1.Items.Count; count++)
                {
                    if (checkedListBox1.GetItemChecked(count) == true)
                        checkList.Add(count.ToString());
                    else checkList.Add("100");
                }
                for (int count = 0; count < checkedListBox2.Items.Count; count++)
                {
                    if (checkedListBox2.GetItemChecked(count) == true)
                        checkList2.Add((count).ToString());
                    else checkList2.Add("100");
                }
                for (int count = 0; count < checkedListBox3.Items.Count; count++)
                {
                    if (checkedListBox3.GetItemChecked(count) == true)
                        checkList3.Add(count.ToString());
                    else checkList3.Add("100");
                }
                for (int count = 0; count < checkedListBox4.Items.Count; count++)
                {
                    if (checkedListBox4.GetItemChecked(count) == true)
                        checkList4.Add(count.ToString());
                    else checkList4.Add("100");
                }

                for (int count = 0; count < checkedListBox5.Items.Count; count++)
                {
                    if (checkedListBox5.GetItemChecked(count) == true)
                        checkList5.Add(count.ToString());
                    else checkList5.Add("100");
                }
                for (int count = 0; count < checkedListBox6.Items.Count; count++)
                {
                    if (checkedListBox6.GetItemChecked(count) == true)
                        checkList6.Add((count).ToString());
                    else checkList6.Add("100");
                }
                for (int count = 0; count < checkedListBox7.Items.Count; count++)
                {
                    if (checkedListBox7.GetItemChecked(count) == true)
                        checkList7.Add(count.ToString());
                    else checkList7.Add("100");
                }
                for (int count = 0; count < checkedListBox8.Items.Count; count++)
                {
                    if (checkedListBox8.GetItemChecked(count) == true)
                        checkList8.Add(count.ToString());
                    else checkList8.Add("100");
                }

                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into maintenancetrailers (trailerid,milestotal,dateinitial,dateend,drivername,inok1,inok2,inok3,inok4,inok5,innr1,innr2,innr3,innr4,innr5,outok1,outok2,outok3,outok4,outok5,outnr1,outnr2,outnr3,outnr4,outnr5,inok6,inok7,inok8,inok9,inok10,inok11,inok12,innr6,innr7,innr8,innr9,innr10,innr11,innr12,outok6,outok7,outok8,outok9,outok10,outok11,outok12,outnr6,outnr7,outnr8,outnr9,outnr10,outnr11,outnr12,inok13,inok14,inok15,inok16,inok17,inok18,inok19,innr13,innr14,innr15,innr16,innr17,innr18,innr19,outok13,outok14,outok15,outok16,outok17,outok18,outok19,outnr13,outnr14,outnr15,outnr16,outnr17,outnr18,outnr19,inok20,inok21,inok22,inok23,inok24,innr20,innr21,innr22,innr23,innr24,outok20,outok21,outok22,outok23,outok24,outnr20,outnr21,outnr22,outnr23,outnr24,inok25,inok26,inok27,inok28,inok29,inok30,inok31,innr25,innr26,innr27,innr28,innr29,innr30,innr31,outok25,outok26,outok27,outok28,outok29,outok30,outok31,outnr25,outnr26,outnr27,outnr28,outnr29,outnr30,outnr31,inok32,inok33,inok34,inok35,inok36,inok37,inok38,innr32,innr33,innr34,innr35,innr36,innr37,innr38,outok32,outok33,outok34,outok35,outok36,outok37,outok38,outnr32,outnr33,outnr34,outnr35,outnr36,outnr37,outnr38,inok39,inok40,inok41,inok42,inok43,innr39,innr40,innr41,innr42,innr43,outok39,outok40,outok41,outok42,outok43,outnr39,outnr40,outnr41,outnr42,outnr43,inok44,inok45,inok46,inok47,inok48,innr44,innr45,innr46,innr47,innr48,outok44,outok45,outok46,outok47,outok48,outnr44,outnr45,outnr46,outnr47,outnr48,notes,numberorder,statusorder) values ('" + lblId.Text + "', '" + lblOdoIni.Text + "', '" + dtDateStart.Value + "', '" + dtDateEnd.Value + "', '" + lblDriver.Text + "',@inok1,@inok2,@inok3,@inok4,@inok5,@innr1,@innr2,@innr3,@innr4,@innr5,@outok1,@outok2,@outok3,@outok4,@outok5,@outnr1,@outnr2,@outnr3,@outnr4,@outnr5,@inok6,@inok7,@inok8,@inok9,@inok10,@inok11,@inok12,@innr6,@innr7,@innr8,@innr9,@innr10,@innr11,@innr12,@outok6,@outok7,@outok8,@outok9,@outok10,@outok11,@outok12,@outnr6,@outnr7,@outnr8,@outnr9,@outnr10,@outnr11,@outnr12,@inok13,@inok14,@inok15,@inok16,@inok17,@inok18,@inok19,@innr13,@innr14,@innr15,@innr16,@innr17,@innr18,@innr19,@outok13,@outok14,@outok15,@outok16,@outok17,@outok18,@outok19,@outnr13,@outnr14,@outnr15,@outnr16,@outnr17,@outnr18,@outnr19,@inok20,@inok21,@inok22,@inok23,@inok24,@innr20,@innr21,@innr22,@innr23,@innr24,@outok20,@outok21,@outok22,@outok23,@outok24,@outnr20,@outnr21,@outnr22,@outnr23,@outnr24,@inok25,@inok26,@inok27,@inok28,@inok29,@inok30,@inok31,@innr25,@innr26,@innr27,@innr28,@innr29,@innr30,@innr31,@outok25,@outok26,@outok27,@outok28,@outok29,@outok30,@outok31,@outnr25,@outnr26,@outnr27,@outnr28,@outnr29,@outnr30,@outnr31,@inok32,@inok33,@inok34,@inok35,@inok36,@inok37,@inok38,@innr32,@innr33,@innr34,@innr35,@innr36,@innr37,@innr38,@outok32,@outok33,@outok34,@outok35,@outok36,@outok37,@outok38,@outnr32,@outnr33,@outnr34,@outnr35,@outnr36,@outnr37,@outnr38,@inok39,@inok40,@inok41,@inok42,@inok43,@innr39,@innr40,@innr41,@innr42,@innr43,@outok39,@outok40,@outok41,@outok42,@outok43,@outnr39,@outnr40,@outnr41,@outnr42,@outnr43,@inok44,@inok45,@inok46,@inok47,@inok48,@innr44,@innr45,@innr46,@innr47,@innr48,@outok44,@outok45,@outok46,@outok47,@outok48,@outnr44,@outnr45,@outnr46,@outnr47,@outnr48,@notes,'" + lblOrder.Text + "',@statusorder)", conn);
                    cmd.Parameters.AddWithValue("inok1", checkList[0]);
                    cmd.Parameters.AddWithValue("inok2", checkList[1]);
                    cmd.Parameters.AddWithValue("inok3", checkList[2]);
                    cmd.Parameters.AddWithValue("inok4", checkList[3]);
                    cmd.Parameters.AddWithValue("inok5", checkList[4]);
                    cmd.Parameters.AddWithValue("innr1", checkList[5]);
                    cmd.Parameters.AddWithValue("innr2", checkList[6]);
                    cmd.Parameters.AddWithValue("innr3", checkList[7]);
                    cmd.Parameters.AddWithValue("innr4", checkList[8]);
                    cmd.Parameters.AddWithValue("innr5", checkList[9]);
                    cmd.Parameters.AddWithValue("outok1", checkList[10]);
                    cmd.Parameters.AddWithValue("outok2", checkList[11]);
                    cmd.Parameters.AddWithValue("outok3", checkList[12]);
                    cmd.Parameters.AddWithValue("outok4", checkList[13]);
                    cmd.Parameters.AddWithValue("outok5", checkList[14]);
                    cmd.Parameters.AddWithValue("outnr1", checkList[15]);
                    cmd.Parameters.AddWithValue("outnr2", checkList[16]);
                    cmd.Parameters.AddWithValue("outnr3", checkList[17]);
                    cmd.Parameters.AddWithValue("outnr4", checkList[18]);
                    cmd.Parameters.AddWithValue("outnr5", checkList[19]);

                    cmd.Parameters.AddWithValue("inok6", checkList2[0]);
                    cmd.Parameters.AddWithValue("inok7", checkList2[1]);
                    cmd.Parameters.AddWithValue("inok8", checkList2[2]);
                    cmd.Parameters.AddWithValue("inok9", checkList2[3]);
                    cmd.Parameters.AddWithValue("inok10", checkList2[4]);
                    cmd.Parameters.AddWithValue("inok11", checkList2[5]);
                    cmd.Parameters.AddWithValue("inok12", checkList2[6]);
                    cmd.Parameters.AddWithValue("innr6", checkList2[7]);
                    cmd.Parameters.AddWithValue("innr7", checkList2[8]);
                    cmd.Parameters.AddWithValue("innr8", checkList2[9]);
                    cmd.Parameters.AddWithValue("innr9", checkList2[10]);
                    cmd.Parameters.AddWithValue("innr10", checkList2[11]);
                    cmd.Parameters.AddWithValue("innr11", checkList2[12]);
                    cmd.Parameters.AddWithValue("innr12", checkList2[13]);
                    cmd.Parameters.AddWithValue("outok6", checkList2[14]);
                    cmd.Parameters.AddWithValue("outok7", checkList2[15]);
                    cmd.Parameters.AddWithValue("outok8", checkList2[16]);
                    cmd.Parameters.AddWithValue("outok9", checkList2[17]);
                    cmd.Parameters.AddWithValue("outok10", checkList2[18]);
                    cmd.Parameters.AddWithValue("outok11", checkList2[19]);
                    cmd.Parameters.AddWithValue("outok12", checkList2[20]);
                    cmd.Parameters.AddWithValue("outnr6", checkList2[21]);
                    cmd.Parameters.AddWithValue("outnr7", checkList2[22]);
                    cmd.Parameters.AddWithValue("outnr8", checkList2[23]);
                    cmd.Parameters.AddWithValue("outnr9", checkList2[24]);
                    cmd.Parameters.AddWithValue("outnr10", checkList2[25]);
                    cmd.Parameters.AddWithValue("outnr11", checkList2[26]);
                    cmd.Parameters.AddWithValue("outnr12", checkList2[27]);

                    cmd.Parameters.AddWithValue("inok13", checkList3[0]);
                    cmd.Parameters.AddWithValue("inok14", checkList3[1]);
                    cmd.Parameters.AddWithValue("inok15", checkList3[2]);
                    cmd.Parameters.AddWithValue("inok16", checkList3[3]);
                    cmd.Parameters.AddWithValue("inok17", checkList3[4]);
                    cmd.Parameters.AddWithValue("inok18", checkList3[5]);
                    cmd.Parameters.AddWithValue("inok19", checkList3[6]);
                    cmd.Parameters.AddWithValue("innr13", checkList3[7]);
                    cmd.Parameters.AddWithValue("innr14", checkList3[8]);
                    cmd.Parameters.AddWithValue("innr15", checkList3[9]);
                    cmd.Parameters.AddWithValue("innr16", checkList3[10]);
                    cmd.Parameters.AddWithValue("innr17", checkList3[11]);
                    cmd.Parameters.AddWithValue("innr18", checkList3[12]);
                    cmd.Parameters.AddWithValue("innr19", checkList3[13]);
                    cmd.Parameters.AddWithValue("outok13", checkList3[14]);
                    cmd.Parameters.AddWithValue("outok14", checkList3[15]);
                    cmd.Parameters.AddWithValue("outok15", checkList3[16]);
                    cmd.Parameters.AddWithValue("outok16", checkList3[17]);
                    cmd.Parameters.AddWithValue("outok17", checkList3[18]);
                    cmd.Parameters.AddWithValue("outok18", checkList3[19]);
                    cmd.Parameters.AddWithValue("outok19", checkList3[20]);
                    cmd.Parameters.AddWithValue("outnr13", checkList3[21]);
                    cmd.Parameters.AddWithValue("outnr14", checkList3[22]);
                    cmd.Parameters.AddWithValue("outnr15", checkList3[23]);
                    cmd.Parameters.AddWithValue("outnr16", checkList3[24]);
                    cmd.Parameters.AddWithValue("outnr17", checkList3[25]);
                    cmd.Parameters.AddWithValue("outnr18", checkList3[26]);
                    cmd.Parameters.AddWithValue("outnr19", checkList3[27]);

                    cmd.Parameters.AddWithValue("inok20", checkList4[0]);
                    cmd.Parameters.AddWithValue("inok21", checkList4[1]);
                    cmd.Parameters.AddWithValue("inok22", checkList4[2]);
                    cmd.Parameters.AddWithValue("inok23", checkList4[3]);
                    cmd.Parameters.AddWithValue("inok24", checkList4[4]);
                    cmd.Parameters.AddWithValue("innr20", checkList4[5]);
                    cmd.Parameters.AddWithValue("innr21", checkList4[6]);
                    cmd.Parameters.AddWithValue("innr22", checkList4[7]);
                    cmd.Parameters.AddWithValue("innr23", checkList4[8]);
                    cmd.Parameters.AddWithValue("innr24", checkList4[9]);
                    cmd.Parameters.AddWithValue("outok20", checkList4[10]);
                    cmd.Parameters.AddWithValue("outok21", checkList4[11]);
                    cmd.Parameters.AddWithValue("outok22", checkList4[12]);
                    cmd.Parameters.AddWithValue("outok23", checkList4[13]);
                    cmd.Parameters.AddWithValue("outok24", checkList4[14]);
                    cmd.Parameters.AddWithValue("outnr20", checkList4[15]);
                    cmd.Parameters.AddWithValue("outnr21", checkList4[16]);
                    cmd.Parameters.AddWithValue("outnr22", checkList4[17]);
                    cmd.Parameters.AddWithValue("outnr23", checkList4[18]);
                    cmd.Parameters.AddWithValue("outnr24", checkList4[19]);

                    cmd.Parameters.AddWithValue("inok25", checkList5[0]);
                    cmd.Parameters.AddWithValue("inok26", checkList5[1]);
                    cmd.Parameters.AddWithValue("inok27", checkList5[2]);
                    cmd.Parameters.AddWithValue("inok28", checkList5[3]);
                    cmd.Parameters.AddWithValue("inok29", checkList5[4]);
                    cmd.Parameters.AddWithValue("inok30", checkList5[5]);
                    cmd.Parameters.AddWithValue("inok31", checkList5[6]);
                    cmd.Parameters.AddWithValue("innr25", checkList5[7]);
                    cmd.Parameters.AddWithValue("innr26", checkList5[8]);
                    cmd.Parameters.AddWithValue("innr27", checkList5[9]);
                    cmd.Parameters.AddWithValue("innr28", checkList5[10]);
                    cmd.Parameters.AddWithValue("innr29", checkList5[11]);
                    cmd.Parameters.AddWithValue("innr30", checkList5[12]);
                    cmd.Parameters.AddWithValue("innr31", checkList5[13]);
                    cmd.Parameters.AddWithValue("outok25", checkList5[14]);
                    cmd.Parameters.AddWithValue("outok26", checkList5[15]);
                    cmd.Parameters.AddWithValue("outok27", checkList5[16]);
                    cmd.Parameters.AddWithValue("outok28", checkList5[17]);
                    cmd.Parameters.AddWithValue("outok29", checkList5[18]);
                    cmd.Parameters.AddWithValue("outok30", checkList5[19]);
                    cmd.Parameters.AddWithValue("outok31", checkList5[20]);
                    cmd.Parameters.AddWithValue("outnr25", checkList5[21]);
                    cmd.Parameters.AddWithValue("outnr26", checkList5[22]);
                    cmd.Parameters.AddWithValue("outnr27", checkList5[23]);
                    cmd.Parameters.AddWithValue("outnr28", checkList5[24]);
                    cmd.Parameters.AddWithValue("outnr29", checkList5[25]);
                    cmd.Parameters.AddWithValue("outnr30", checkList5[26]);
                    cmd.Parameters.AddWithValue("outnr31", checkList5[27]);

                    cmd.Parameters.AddWithValue("inok32", checkList6[0]);
                    cmd.Parameters.AddWithValue("inok33", checkList6[1]);
                    cmd.Parameters.AddWithValue("inok34", checkList6[2]);
                    cmd.Parameters.AddWithValue("inok35", checkList6[3]);
                    cmd.Parameters.AddWithValue("inok36", checkList6[4]);
                    cmd.Parameters.AddWithValue("inok37", checkList6[5]);
                    cmd.Parameters.AddWithValue("inok38", checkList6[6]);
                    cmd.Parameters.AddWithValue("innr32", checkList6[7]);
                    cmd.Parameters.AddWithValue("innr33", checkList6[8]);
                    cmd.Parameters.AddWithValue("innr34", checkList6[9]);
                    cmd.Parameters.AddWithValue("innr35", checkList6[10]);
                    cmd.Parameters.AddWithValue("innr36", checkList6[11]);
                    cmd.Parameters.AddWithValue("innr37", checkList6[12]);
                    cmd.Parameters.AddWithValue("innr38", checkList6[13]);
                    cmd.Parameters.AddWithValue("outok32", checkList6[14]);
                    cmd.Parameters.AddWithValue("outok33", checkList6[15]);
                    cmd.Parameters.AddWithValue("outok34", checkList6[16]);
                    cmd.Parameters.AddWithValue("outok35", checkList6[17]);
                    cmd.Parameters.AddWithValue("outok36", checkList6[18]);
                    cmd.Parameters.AddWithValue("outok37", checkList6[19]);
                    cmd.Parameters.AddWithValue("outok38", checkList6[20]);
                    cmd.Parameters.AddWithValue("outnr32", checkList6[21]);
                    cmd.Parameters.AddWithValue("outnr33", checkList6[22]);
                    cmd.Parameters.AddWithValue("outnr34", checkList6[23]);
                    cmd.Parameters.AddWithValue("outnr35", checkList6[24]);
                    cmd.Parameters.AddWithValue("outnr36", checkList6[25]);
                    cmd.Parameters.AddWithValue("outnr37", checkList6[26]);
                    cmd.Parameters.AddWithValue("outnr38", checkList6[27]);

                    cmd.Parameters.AddWithValue("inok39", checkList7[0]);
                    cmd.Parameters.AddWithValue("inok40", checkList7[1]);
                    cmd.Parameters.AddWithValue("inok41", checkList7[2]);
                    cmd.Parameters.AddWithValue("inok42", checkList7[3]);
                    cmd.Parameters.AddWithValue("inok43", checkList7[4]);
                    cmd.Parameters.AddWithValue("innr39", checkList7[5]);
                    cmd.Parameters.AddWithValue("innr40", checkList7[6]);
                    cmd.Parameters.AddWithValue("innr41", checkList7[7]);
                    cmd.Parameters.AddWithValue("innr42", checkList7[8]);
                    cmd.Parameters.AddWithValue("innr43", checkList7[9]);
                    cmd.Parameters.AddWithValue("outok39", checkList7[10]);
                    cmd.Parameters.AddWithValue("outok40", checkList7[11]);
                    cmd.Parameters.AddWithValue("outok41", checkList7[12]);
                    cmd.Parameters.AddWithValue("outok42", checkList7[13]);
                    cmd.Parameters.AddWithValue("outok43", checkList7[14]);
                    cmd.Parameters.AddWithValue("outnr39", checkList7[15]);
                    cmd.Parameters.AddWithValue("outnr40", checkList7[16]);
                    cmd.Parameters.AddWithValue("outnr41", checkList7[17]);
                    cmd.Parameters.AddWithValue("outnr42", checkList7[18]);
                    cmd.Parameters.AddWithValue("outnr43", checkList7[19]);

                    cmd.Parameters.AddWithValue("inok44", checkList8[0]);
                    cmd.Parameters.AddWithValue("inok45", checkList8[1]);
                    cmd.Parameters.AddWithValue("inok46", checkList8[2]);
                    cmd.Parameters.AddWithValue("inok47", checkList8[3]);
                    cmd.Parameters.AddWithValue("inok48", checkList8[4]);
                    cmd.Parameters.AddWithValue("innr44", checkList8[5]);
                    cmd.Parameters.AddWithValue("innr45", checkList8[6]);
                    cmd.Parameters.AddWithValue("innr46", checkList8[7]);
                    cmd.Parameters.AddWithValue("innr47", checkList8[8]);
                    cmd.Parameters.AddWithValue("innr48", checkList8[9]);
                    cmd.Parameters.AddWithValue("outok44", checkList8[10]);
                    cmd.Parameters.AddWithValue("outok45", checkList8[11]);
                    cmd.Parameters.AddWithValue("outok46", checkList8[12]);
                    cmd.Parameters.AddWithValue("outok47", checkList8[13]);
                    cmd.Parameters.AddWithValue("outok48", checkList8[14]);
                    cmd.Parameters.AddWithValue("outnr44", checkList8[15]);
                    cmd.Parameters.AddWithValue("outnr45", checkList8[16]);
                    cmd.Parameters.AddWithValue("outnr46", checkList8[17]);
                    cmd.Parameters.AddWithValue("outnr47", checkList8[18]);
                    cmd.Parameters.AddWithValue("outnr48", checkList8[19]);
                    cmd.Parameters.AddWithValue("notes", txtNotes.Text);
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
                btnAdd.Enabled = false;
                btnUpd.Enabled = true;
                btnDel.Enabled = true;
                btnOrder.Enabled = true;
                btnPrint.Enabled = false;

                btnClear.Enabled = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnEnd.Enabled = true;
                dgvTrailer.DataSource = conectandose.Consultar(TblName);
            }
            else
                MessageBox.Show("Lack data, check that have:\n Date Start, Date End, Check Status, APU Id", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    btnClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvTrailer.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            List<string> checkList = new List<string>();
            List<string> checkList2 = new List<string>();
            List<string> checkList3 = new List<string>();
            List<string> checkList4 = new List<string>();
            List<string> checkList5 = new List<string>();
            List<string> checkList6 = new List<string>();
            List<string> checkList7 = new List<string>();
            List<string> checkList8 = new List<string>();
            for (int count = 0; count < chkOrder.Items.Count; count++)
            {
                if (chkOrder.GetItemChecked(count) == true)
                {
                    statusorder = count.ToString();
                    break;
                }
            }
            //Llenando los PRT, POPT y RR 29,28,27
            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                if (checkedListBox1.GetItemChecked(count) == true)
                    checkList.Add(count.ToString());
                else checkList.Add("100");
            }
            for (int count = 0; count < checkedListBox2.Items.Count; count++)
            {
                if (checkedListBox2.GetItemChecked(count) == true)
                    checkList2.Add((count).ToString());
                else checkList2.Add("100");
            }
            for (int count = 0; count < checkedListBox3.Items.Count; count++)
            {
                if (checkedListBox3.GetItemChecked(count) == true)
                    checkList3.Add(count.ToString());
                else checkList3.Add("100");
            }
            for (int count = 0; count < checkedListBox4.Items.Count; count++)
            {
                if (checkedListBox4.GetItemChecked(count) == true)
                    checkList4.Add(count.ToString());
                else checkList4.Add("100");
            }

            for (int count = 0; count < checkedListBox5.Items.Count; count++)
            {
                if (checkedListBox5.GetItemChecked(count) == true)
                    checkList5.Add(count.ToString());
                else checkList5.Add("100");
            }
            for (int count = 0; count < checkedListBox6.Items.Count; count++)
            {
                if (checkedListBox6.GetItemChecked(count) == true)
                    checkList6.Add((count).ToString());
                else checkList6.Add("100");
            }
            for (int count = 0; count < checkedListBox7.Items.Count; count++)
            {
                if (checkedListBox7.GetItemChecked(count) == true)
                    checkList7.Add(count.ToString());
                else checkList7.Add("100");
            }
            for (int count = 0; count < checkedListBox8.Items.Count; count++)
            {
                if (checkedListBox8.GetItemChecked(count) == true)
                    checkList8.Add(count.ToString());
                else checkList8.Add("100");
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update maintenancetrailers set dateinitial='" + dtDateStart.Value + "',dateend='" + dtDateEnd.Value + "',inok1=@inok1,inok2=@inok2,inok3=@inok3,inok4=@inok4,inok5=@inok5,innr1=@innr1,innr2=@innr2,innr3=@innr3,innr4=@innr4,innr5=@innr5,outok1=@outok1,outok2=@outok2,outok3=@outok3,outok4=@outok4,outok5=@outok5,outnr1=@outnr1,outnr2=@outnr2,outnr3=@outnr3,outnr4=@outnr4,outnr5=@outnr5,inok6=@inok6,inok7=@inok7,inok8=@inok8,inok9=@inok9,inok10=@inok10,inok11=@inok11,inok12=@inok12,innr6=@innr6,innr7=@innr7,innr8=@innr8,innr9=@innr9,innr10=@innr10,innr11=@innr11,innr12=@innr12,outok6=@outok6,outok7=@outok7,outok8=@outok8,outok9=@outok9,outok10=@outok10,outok11=@outok11,outok12=@outok12,outnr6=@outnr6,outnr7=@outnr7,outnr8=@outnr8,outnr9=@outnr9,outnr10=@outnr10,outnr11=@outnr11,outnr12=@outnr12,inok13=@inok13,inok14=@inok14,inok15=@inok15,inok16=@inok16,inok17=@inok17,inok18=@inok18,inok19=@inok19,innr13=@innr13,innr14=@innr14,innr15=@innr15,innr16=@innr16,innr17=@innr17,innr18=@innr18,innr19=@innr19,outok13=@outok13,outok14=@outok14,outok15=@outok15,outok16=@outok16,outok17=@outok17,outok18=@outok18,outok19=@outok19,outnr13=@outnr13,outnr14=@outnr14,outnr15=@outnr15,outnr16=@outnr16,outnr17=@outnr17,outnr18=@outnr18,outnr19=@outnr19,inok20=@inok20,inok21=@inok21,inok22=@inok22,inok23=@inok23,inok24=@inok24,innr20=@innr20,innr21=@innr21,innr22=@innr22,innr23=@innr23,innr24=@innr24,outok20=@outok20,outok21=@outok21,outok22=@outok22,outok23=@outok23,outok24=@outok24,outnr20=@outnr20,outnr21=@outnr21,outnr22=@outnr22,outnr23=@outnr23,outnr24=@outnr24,inok25=@inok25,inok26=@inok26,inok27=@inok27,inok28=@inok28,inok29=@inok29,inok30=@inok30,inok31=@inok31,innr25=@innr25,innr26=@innr26,innr27=@innr27,innr28=@innr28,innr29=@innr29,innr30=@innr30,innr31=@innr31,outok25=@outok25,outok26=@outok26,outok27=@outok27,outok28=@outok28,outok29=@outok29,outok30=@outok30,outok31=@outok31,outnr25=@outnr25,outnr26=@outnr26,outnr27=@outnr27,outnr28=@outnr28,outnr29=@outnr29,outnr30=@outnr30,outnr31=@outnr31,inok32=@inok32,inok33=@inok33,inok34=@inok34,inok35=@inok35,inok36=@inok36,inok37=@inok37,inok38=@inok38,innr32=@innr32,innr33=@innr33,innr34=@innr34,innr35=@innr35,innr36=@innr36,innr37=@innr37,innr38=@innr38,outok32=@outok32,outok33=@outok33,outok34=@outok34,outok35=@outok35,outok36=@outok36,outok37=@outok37,outok38=@outok38,outnr32=@outnr32,outnr33=@outnr33,outnr34=@outnr34,outnr35=@outnr35,outnr36=@outnr36,outnr37=@outnr37,outnr38=@outnr38,inok39=@inok39,inok40=@inok40,inok41=@inok41,inok42=@inok42,inok43=@inok43,innr39=@innr39,innr40=@innr40,innr41=@innr41,innr42=@innr42,innr43=@innr43,outok39=@outok39,outok40=@outok40,outok41=@outok41,outok42=@outok42,outok43=@outok43,outnr39=@outnr39,outnr40=@outnr40,outnr41=@outnr41,outnr42=@outnr42,outnr43=@outnr43,inok44=@inok44,inok45=@inok45,inok46=@inok46,inok47=@inok47,inok48=@inok48,innr44=@innr44,innr45=@innr45,innr46=@innr46,innr47=@innr47,innr48=@innr48,outok44=@outok44,outok45=@outok45,outok46=@outok46,outok47=@outok47,outok48=@outok48,outnr44=@outnr44,outnr45=@outnr45,outnr46=@outnr46,outnr47=@outnr47,outnr48=@outnr48,notes=@notes,statusorder=@statusorder" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("inok1", checkList[0]);
                cmd.Parameters.AddWithValue("inok2", checkList[1]);
                cmd.Parameters.AddWithValue("inok3", checkList[2]);
                cmd.Parameters.AddWithValue("inok4", checkList[3]);
                cmd.Parameters.AddWithValue("inok5", checkList[4]);
                cmd.Parameters.AddWithValue("innr1", checkList[5]);
                cmd.Parameters.AddWithValue("innr2", checkList[6]);
                cmd.Parameters.AddWithValue("innr3", checkList[7]);
                cmd.Parameters.AddWithValue("innr4", checkList[8]);
                cmd.Parameters.AddWithValue("innr5", checkList[9]);
                cmd.Parameters.AddWithValue("outok1", checkList[10]);
                cmd.Parameters.AddWithValue("outok2", checkList[11]);
                cmd.Parameters.AddWithValue("outok3", checkList[12]);
                cmd.Parameters.AddWithValue("outok4", checkList[13]);
                cmd.Parameters.AddWithValue("outok5", checkList[14]);
                cmd.Parameters.AddWithValue("outnr1", checkList[15]);
                cmd.Parameters.AddWithValue("outnr2", checkList[16]);
                cmd.Parameters.AddWithValue("outnr3", checkList[17]);
                cmd.Parameters.AddWithValue("outnr4", checkList[18]);
                cmd.Parameters.AddWithValue("outnr5", checkList[19]);//26

                cmd.Parameters.AddWithValue("inok6", checkList2[0]);
                cmd.Parameters.AddWithValue("inok7", checkList2[1]);
                cmd.Parameters.AddWithValue("inok8", checkList2[2]);
                cmd.Parameters.AddWithValue("inok9", checkList2[3]);
                cmd.Parameters.AddWithValue("inok10", checkList2[4]);
                cmd.Parameters.AddWithValue("inok11", checkList2[5]);
                cmd.Parameters.AddWithValue("inok12", checkList2[6]);
                cmd.Parameters.AddWithValue("innr6", checkList2[7]);
                cmd.Parameters.AddWithValue("innr7", checkList2[8]);
                cmd.Parameters.AddWithValue("innr8", checkList2[9]);
                cmd.Parameters.AddWithValue("innr9", checkList2[10]);
                cmd.Parameters.AddWithValue("innr10", checkList2[11]);
                cmd.Parameters.AddWithValue("innr11", checkList2[12]);
                cmd.Parameters.AddWithValue("innr12", checkList2[13]);
                cmd.Parameters.AddWithValue("outok6", checkList2[14]);
                cmd.Parameters.AddWithValue("outok7", checkList2[15]);
                cmd.Parameters.AddWithValue("outok8", checkList2[16]);
                cmd.Parameters.AddWithValue("outok9", checkList2[17]);
                cmd.Parameters.AddWithValue("outok10", checkList2[18]);
                cmd.Parameters.AddWithValue("outok11", checkList2[19]);
                cmd.Parameters.AddWithValue("outok12", checkList2[20]);
                cmd.Parameters.AddWithValue("outnr6", checkList2[21]);
                cmd.Parameters.AddWithValue("outnr7", checkList2[22]);
                cmd.Parameters.AddWithValue("outnr8", checkList2[23]);
                cmd.Parameters.AddWithValue("outnr9", checkList2[24]);
                cmd.Parameters.AddWithValue("outnr10", checkList2[25]);
                cmd.Parameters.AddWithValue("outnr11", checkList2[26]);
                cmd.Parameters.AddWithValue("outnr12", checkList2[27]);//54

                cmd.Parameters.AddWithValue("inok13", checkList3[0]);
                cmd.Parameters.AddWithValue("inok14", checkList3[1]);
                cmd.Parameters.AddWithValue("inok15", checkList3[2]);
                cmd.Parameters.AddWithValue("inok16", checkList3[3]);
                cmd.Parameters.AddWithValue("inok17", checkList3[4]);
                cmd.Parameters.AddWithValue("inok18", checkList3[5]);
                cmd.Parameters.AddWithValue("inok19", checkList3[6]);
                cmd.Parameters.AddWithValue("innr13", checkList3[7]);
                cmd.Parameters.AddWithValue("innr14", checkList3[8]);
                cmd.Parameters.AddWithValue("innr15", checkList3[9]);
                cmd.Parameters.AddWithValue("innr16", checkList3[10]);
                cmd.Parameters.AddWithValue("innr17", checkList3[11]);
                cmd.Parameters.AddWithValue("innr18", checkList3[12]);
                cmd.Parameters.AddWithValue("innr19", checkList3[13]);
                cmd.Parameters.AddWithValue("outok13", checkList3[14]);
                cmd.Parameters.AddWithValue("outok14", checkList3[15]);
                cmd.Parameters.AddWithValue("outok15", checkList3[16]);
                cmd.Parameters.AddWithValue("outok16", checkList3[17]);
                cmd.Parameters.AddWithValue("outok17", checkList3[18]);
                cmd.Parameters.AddWithValue("outok18", checkList3[19]);
                cmd.Parameters.AddWithValue("outok19", checkList3[20]);
                cmd.Parameters.AddWithValue("outnr13", checkList3[21]);
                cmd.Parameters.AddWithValue("outnr14", checkList3[22]);
                cmd.Parameters.AddWithValue("outnr15", checkList3[23]);
                cmd.Parameters.AddWithValue("outnr16", checkList3[24]);
                cmd.Parameters.AddWithValue("outnr17", checkList3[25]);
                cmd.Parameters.AddWithValue("outnr18", checkList3[26]);
                cmd.Parameters.AddWithValue("outnr19", checkList3[27]);//82

                cmd.Parameters.AddWithValue("inok20", checkList4[0]);
                cmd.Parameters.AddWithValue("inok21", checkList4[1]);
                cmd.Parameters.AddWithValue("inok22", checkList4[2]);
                cmd.Parameters.AddWithValue("inok23", checkList4[3]);
                cmd.Parameters.AddWithValue("inok24", checkList4[4]);
                cmd.Parameters.AddWithValue("innr20", checkList4[5]);
                cmd.Parameters.AddWithValue("innr21", checkList4[6]);
                cmd.Parameters.AddWithValue("innr22", checkList4[7]);
                cmd.Parameters.AddWithValue("innr23", checkList4[8]);
                cmd.Parameters.AddWithValue("innr24", checkList4[9]);
                cmd.Parameters.AddWithValue("outok20", checkList4[10]);
                cmd.Parameters.AddWithValue("outok21", checkList4[11]);
                cmd.Parameters.AddWithValue("outok22", checkList4[12]);
                cmd.Parameters.AddWithValue("outok23", checkList4[13]);
                cmd.Parameters.AddWithValue("outok24", checkList4[14]);
                cmd.Parameters.AddWithValue("outnr20", checkList4[15]);
                cmd.Parameters.AddWithValue("outnr21", checkList4[16]);
                cmd.Parameters.AddWithValue("outnr22", checkList4[17]);
                cmd.Parameters.AddWithValue("outnr23", checkList4[18]);
                cmd.Parameters.AddWithValue("outnr24", checkList4[19]);//102

                cmd.Parameters.AddWithValue("inok25", checkList5[0]);
                cmd.Parameters.AddWithValue("inok26", checkList5[1]);
                cmd.Parameters.AddWithValue("inok27", checkList5[2]);
                cmd.Parameters.AddWithValue("inok28", checkList5[3]);
                cmd.Parameters.AddWithValue("inok29", checkList5[4]);
                cmd.Parameters.AddWithValue("inok30", checkList5[5]);
                cmd.Parameters.AddWithValue("inok31", checkList5[6]);
                cmd.Parameters.AddWithValue("innr25", checkList5[7]);
                cmd.Parameters.AddWithValue("innr26", checkList5[8]);
                cmd.Parameters.AddWithValue("innr27", checkList5[9]);
                cmd.Parameters.AddWithValue("innr28", checkList5[10]);
                cmd.Parameters.AddWithValue("innr29", checkList5[11]);
                cmd.Parameters.AddWithValue("innr30", checkList5[12]);
                cmd.Parameters.AddWithValue("innr31", checkList5[13]);
                cmd.Parameters.AddWithValue("outok25", checkList5[14]);
                cmd.Parameters.AddWithValue("outok26", checkList5[15]);
                cmd.Parameters.AddWithValue("outok27", checkList5[16]);
                cmd.Parameters.AddWithValue("outok28", checkList5[17]);
                cmd.Parameters.AddWithValue("outok29", checkList5[18]);
                cmd.Parameters.AddWithValue("outok30", checkList5[19]);
                cmd.Parameters.AddWithValue("outok31", checkList5[20]);
                cmd.Parameters.AddWithValue("outnr25", checkList5[21]);
                cmd.Parameters.AddWithValue("outnr26", checkList5[22]);
                cmd.Parameters.AddWithValue("outnr27", checkList5[23]);
                cmd.Parameters.AddWithValue("outnr28", checkList5[24]);
                cmd.Parameters.AddWithValue("outnr29", checkList5[25]);
                cmd.Parameters.AddWithValue("outnr30", checkList5[26]);
                cmd.Parameters.AddWithValue("outnr31", checkList5[27]);//130

                cmd.Parameters.AddWithValue("inok32", checkList6[0]);
                cmd.Parameters.AddWithValue("inok33", checkList6[1]);
                cmd.Parameters.AddWithValue("inok34", checkList6[2]);
                cmd.Parameters.AddWithValue("inok35", checkList6[3]);
                cmd.Parameters.AddWithValue("inok36", checkList6[4]);
                cmd.Parameters.AddWithValue("inok37", checkList6[5]);
                cmd.Parameters.AddWithValue("inok38", checkList6[6]);
                cmd.Parameters.AddWithValue("innr32", checkList6[7]);
                cmd.Parameters.AddWithValue("innr33", checkList6[8]);
                cmd.Parameters.AddWithValue("innr34", checkList6[9]);
                cmd.Parameters.AddWithValue("innr35", checkList6[10]);
                cmd.Parameters.AddWithValue("innr36", checkList6[11]);
                cmd.Parameters.AddWithValue("innr37", checkList6[12]);
                cmd.Parameters.AddWithValue("innr38", checkList6[13]);
                cmd.Parameters.AddWithValue("outok32", checkList6[14]);
                cmd.Parameters.AddWithValue("outok33", checkList6[15]);
                cmd.Parameters.AddWithValue("outok34", checkList6[16]);
                cmd.Parameters.AddWithValue("outok35", checkList6[17]);
                cmd.Parameters.AddWithValue("outok36", checkList6[18]);
                cmd.Parameters.AddWithValue("outok37", checkList6[19]);
                cmd.Parameters.AddWithValue("outok38", checkList6[20]);
                cmd.Parameters.AddWithValue("outnr32", checkList6[21]);
                cmd.Parameters.AddWithValue("outnr33", checkList6[22]);
                cmd.Parameters.AddWithValue("outnr34", checkList6[23]);
                cmd.Parameters.AddWithValue("outnr35", checkList6[24]);
                cmd.Parameters.AddWithValue("outnr36", checkList6[25]);
                cmd.Parameters.AddWithValue("outnr37", checkList6[26]);
                cmd.Parameters.AddWithValue("outnr38", checkList6[27]);//158

                cmd.Parameters.AddWithValue("inok39", checkList7[0]);
                cmd.Parameters.AddWithValue("inok40", checkList7[1]);
                cmd.Parameters.AddWithValue("inok41", checkList7[2]);
                cmd.Parameters.AddWithValue("inok42", checkList7[3]);
                cmd.Parameters.AddWithValue("inok43", checkList7[4]);
                cmd.Parameters.AddWithValue("innr39", checkList7[5]);
                cmd.Parameters.AddWithValue("innr40", checkList7[6]);
                cmd.Parameters.AddWithValue("innr41", checkList7[7]);
                cmd.Parameters.AddWithValue("innr42", checkList7[8]);
                cmd.Parameters.AddWithValue("innr43", checkList7[9]);
                cmd.Parameters.AddWithValue("outok39", checkList7[10]);
                cmd.Parameters.AddWithValue("outok40", checkList7[11]);
                cmd.Parameters.AddWithValue("outok41", checkList7[12]);
                cmd.Parameters.AddWithValue("outok42", checkList7[13]);
                cmd.Parameters.AddWithValue("outok43", checkList7[14]);
                cmd.Parameters.AddWithValue("outnr39", checkList7[15]);
                cmd.Parameters.AddWithValue("outnr40", checkList7[16]);
                cmd.Parameters.AddWithValue("outnr41", checkList7[17]);
                cmd.Parameters.AddWithValue("outnr42", checkList7[18]);
                cmd.Parameters.AddWithValue("outnr43", checkList7[19]);//178

                cmd.Parameters.AddWithValue("inok44", checkList8[0]);
                cmd.Parameters.AddWithValue("inok45", checkList8[1]);
                cmd.Parameters.AddWithValue("inok46", checkList8[2]);
                cmd.Parameters.AddWithValue("inok47", checkList8[3]);
                cmd.Parameters.AddWithValue("inok48", checkList8[4]);
                cmd.Parameters.AddWithValue("innr44", checkList8[5]);
                cmd.Parameters.AddWithValue("innr45", checkList8[6]);
                cmd.Parameters.AddWithValue("innr46", checkList8[7]);
                cmd.Parameters.AddWithValue("innr47", checkList8[8]);
                cmd.Parameters.AddWithValue("innr48", checkList8[9]);
                cmd.Parameters.AddWithValue("outok44", checkList8[10]);
                cmd.Parameters.AddWithValue("outok45", checkList8[11]);
                cmd.Parameters.AddWithValue("outok46", checkList8[12]);
                cmd.Parameters.AddWithValue("outok47", checkList8[13]);
                cmd.Parameters.AddWithValue("outok48", checkList8[14]);
                cmd.Parameters.AddWithValue("outnr44", checkList8[15]);
                cmd.Parameters.AddWithValue("outnr45", checkList8[16]);
                cmd.Parameters.AddWithValue("outnr46", checkList8[17]);
                cmd.Parameters.AddWithValue("outnr47", checkList8[18]);
                cmd.Parameters.AddWithValue("outnr48", checkList8[19]);//198
                cmd.Parameters.AddWithValue("notes", txtNotes.Text);
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
            dgvTrailer.DataSource = conectandose.Consultar(TblName);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (!(lblId.Text == ""))
            {
                MessageBox.Show("Prepare the Print with paper A4 (8.5 pulg. x 14 pulg.)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TrailerPrint trailerorders = new TrailerPrint(lblId.Text, lblOdoIni.Text, lblDriver.Text, codigo, lblOrder.Text, 0);
                trailerorders.Show();
            }
            else
                MessageBox.Show("Select a Record!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = chkOrder.SelectedIndex;
            if ((chkOrder.GetItemChecked(0) == true || chkOrder.GetItemChecked(1) == true))
            {

                if (indice != -1)
                {
                    switch (indice)
                    {
                        case 0: // Open
                            chkOrder.SetItemChecked(1, false);
                            break;
                        case 1: // Close
                            chkOrder.SetItemChecked(0, false);
                            dgvTLMto.DataSource = conectandose.ConsultarTrailers("trailersprofiles", lblId.Text);
                            codigotl = Convert.ToInt32(dgvTLMto.Rows[0].Cells[0].Value);
                            string miles = "0";
                            NpgsqlCommand cmd = new NpgsqlCommand("update trailersprofiles set totalmiles='" + miles + "'" + " where id=" + codigotl, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            break;
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!(chkOrder.GetItemChecked(1) == true))
                MessageBox.Show("Order not Closed!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                TrailerPrint apuprint = new TrailerPrint(lblId.Text, lblOdoIni.Text, lblDriver.Text, codigo, lblOrder.Text, 1);
                apuprint.Show();
            }
        }
    }
}
