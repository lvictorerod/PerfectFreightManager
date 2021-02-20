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
    public partial class MttoAPU : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        private string TblName = "maintenanceapus";
        private int sgte = 0, cuenta = 0;
        private int codigo, codigoapu;
        public MttoAPU(string apuid, string hours, string owner)
        {
            InitializeComponent();
            lblAPU.Text = apuid;
            lblAPUHours.Text = hours;
            lblAPUDriver.Text = owner;
            lblAPUOrder.Text = "";
            chkAPUOrder.SetItemChecked(0, true);
            dgvApu.DataSource = conectandose.Consultar(TblName);
            lbRecord.Text = "Record " + (sgte) + " of  " + cuenta;
            if (lblAPU.Text != "")
            {
                btnAdd.Enabled = true;
                btnUpd.Enabled = false;
                btnDel.Enabled = false;
                btnApuOrder.Enabled = false;
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
                btnApuOrder.Enabled = true;
                btnPrint.Enabled = true;

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
            lblAPU.Text = "";
            lblAPUHours.Text = "";
            lblAPUOrder.Text = "";
            dtApuStart.Text = "";
            dtApuEnd.Text = "";
            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                checkedListBox1.SetItemChecked(count, false);
            }
            txtApuIncidense.Text = "";
            txtApuExpense.Text = "";
            lblAPUDriver.Text = "";
            for (int count = 0; count < chkAPUOrder.Items.Count; count++)
            {
                chkAPUOrder.SetItemChecked(count, false);
            }

            btnAdd.Enabled = true;
            btnUpd.Enabled = false;
            btnDel.Enabled = false;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            cuenta = dgvApu.Rows.GetLastRow(0) + 1;
            if (cuenta != 0)
            {
                sgte = dgvApu.Rows.GetFirstRow(0);
                dgvApu_RowEnter(sender, e);
                //sgtepd += 1;
                rellena();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            cuenta = dgvApu.Rows.GetLastRow(0) + 1;
            if (cuenta != 0)
            {
                sgte = dgvApu.Rows.GetPreviousRow(sgte, 0);
                if (sgte == -1) sgte = cuenta - 1;
                if (sgte <= cuenta && sgte >= 0)
                {
                    dgvApu_RowEnter(sender, e);
                    rellena();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cuenta = dgvApu.Rows.GetLastRow(0) + 1;
            if (cuenta != 0)
            {
                sgte = dgvApu.Rows.GetNextRow(sgte, 0);
                if (sgte == -1) sgte = 0;
                if (sgte <= cuenta && sgte >= 0)
                {
                    dgvApu_RowEnter(sender, e);
                    rellena();
                }
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            cuenta = dgvApu.Rows.GetLastRow(0) + 1;
            if (cuenta != 0)
            {
                sgte = dgvApu.Rows.GetLastRow(0);
                dgvApu_RowEnter(sender, e);
                rellena();
            }
        }
        private void dgvApu_RowEnter(object sender, EventArgs e)
        {
            dgvApu.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvApu.Rows[sgte].Selected = true;
            dgvApu.FirstDisplayedScrollingRowIndex = dgvApu.Rows.GetNextRow(sgte - 1, 0);
        }

        private void rellena()
        {
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;

            codigo = Convert.ToInt32(dgvApu.Rows[sgte].Cells[0].Value);
            
            lblAPU.Text = Convert.ToString(dgvApu.Rows[sgte].Cells[1].Value);
            lblAPUHours.Text = Convert.ToString(dgvApu.Rows[sgte].Cells[2].Value);
            lblAPUOrder.Text = Convert.ToString(dgvApu.Rows[sgte].Cells[13].Value); ;
            dtApuStart.Value = Convert.ToDateTime(dgvApu.Rows[sgte].Cells[3].Value);
            dtApuEnd.Value = Convert.ToDateTime(dgvApu.Rows[sgte].Cells[4].Value);

            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                checkedListBox1.SetItemChecked(count, false);
                if (Convert.ToInt32(dgvApu.Rows[sgte].Cells[count + 5].Value) != 100)
                    checkedListBox1.SetItemChecked(Convert.ToInt32(dgvApu.Rows[sgte].Cells[count + 5].Value), true);
            }
            txtApuIncidense.Text = Convert.ToString(dgvApu.Rows[sgte].Cells[10].Value);
            txtApuExpense.Text = Convert.ToString(dgvApu.Rows[sgte].Cells[11].Value);
            lblAPUDriver.Text = Convert.ToString(dgvApu.Rows[sgte].Cells[12].Value);
            for (int count = 0; count < chkAPUOrder.Items.Count; count++)
            {
                chkAPUOrder.SetItemChecked(count, false);
            }
            chkAPUOrder.SetItemChecked(Convert.ToInt32(dgvApu.Rows[sgte].Cells[14].Value), true);

            dgvAPUMto.DataSource = conectandose.ConsultarApus("apuprofiles", lblAPU.Text);
            codigoapu = Convert.ToInt32(dgvAPUMto.Rows[0].Cells[0].Value);

            lbRecord.Text = "Record " + (sgte + 1) + " of  " + cuenta;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            string zyear = DateTime.Today.Year.ToString();
            if (!(dtApuStart.Text == "" || dtApuEnd.Text == "" || lblAPU.Text == "" || chkAPUOrder.GetItemChecked(0) == false))
            {

                cuenta = dgvApu.Rows.GetLastRow(0) + 2;
                lblAPUOrder.Text = "APU - " + cuenta.ToString() + "/" + zyear;
                List<string> checkList = new List<string>();
                //Llenando el CheckListBox 
                for (int count = 0; count < checkedListBox1.Items.Count; count++)
                {
                    if (checkedListBox1.GetItemChecked(count) == true)
                        checkList.Add(count.ToString());
                    else checkList.Add("100");
                }
                for (int count = 0; count < chkAPUOrder.Items.Count; count++)
                {
                    if (chkAPUOrder.GetItemChecked(count) == true)
                    {
                        statusorder = count.ToString();
                        break;
                    }
                }
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into maintenanceapus (apuid,hourstotal,dateinitial,dateend,apu1,apu2,apu3,apu4,apu5,incidense,expense,drivername,numberorder,statusorder)  values ('" + lblAPU.Text + "', '" + lblAPUHours.Text + "', '" + dtApuStart.Value + "', '" + dtApuEnd.Value + "',@apu1,@apu2,@apu3,@apu4,@apu5,@incidense,@expense, '" + lblAPUDriver.Text + "', '" + lblAPUOrder.Text + "',@statusorder)", conn);
                    cmd.Parameters.AddWithValue("apu1", checkList[0]);
                    cmd.Parameters.AddWithValue("apu2", checkList[1]);
                    cmd.Parameters.AddWithValue("apu3", checkList[2]);
                    cmd.Parameters.AddWithValue("apu4", checkList[3]);
                    cmd.Parameters.AddWithValue("apu5", checkList[4]);
                    cmd.Parameters.AddWithValue("statusorder", statusorder);
                    cmd.Parameters.AddWithValue("incidense", txtApuIncidense.Text);
                    cmd.Parameters.AddWithValue("expense", txtApuExpense.Text);
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
                btnApuOrder.Enabled = true;
                btnPrint.Enabled = true;

                btnClear.Enabled = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnEnd.Enabled = true;
                dgvApu.DataSource = conectandose.Consultar(TblName);
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
                dgvApu.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            string statusorder = "";
            List<string> checkList = new List<string>();
            //Llenando los PRT, POPT y RR 29,28,27
            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                if (checkedListBox1.GetItemChecked(count) == true)
                    checkList.Add(count.ToString());
                else checkList.Add("100");
            }
            for (int count = 0; count < chkAPUOrder.Items.Count; count++)
            { 
                if (chkAPUOrder.GetItemChecked(count) == true)
                {
                    statusorder = count.ToString();
                    break;
                }
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update maintenanceapus set dateinitial='" + dtApuStart.Value + "',dateend='" + dtApuEnd.Value + "',apu1=@apu1,apu2=@apu2,apu3=@apu3,apu4=@apu4,apu5=@apu5,incidense=@incidense,expense=@expense,statusorder=@statusorder" + " where id=" + codigo, conn);
                cmd.Parameters.AddWithValue("apu1", checkList[0]);
                cmd.Parameters.AddWithValue("apu2", checkList[1]);
                cmd.Parameters.AddWithValue("apu3", checkList[2]);
                cmd.Parameters.AddWithValue("apu4", checkList[3]);
                cmd.Parameters.AddWithValue("apu5", checkList[4]);
                cmd.Parameters.AddWithValue("statusorder", statusorder);
                cmd.Parameters.AddWithValue("incidense", txtApuIncidense.Text);
                cmd.Parameters.AddWithValue("expense", txtApuExpense.Text);

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
            dgvApu.DataSource = conectandose.Consultar(TblName);
        }

        private void btnApuOrder_Click(object sender, EventArgs e)
        {
            if (!(lblAPU.Text == ""))
            {
                APUPrint apuorder = new APUPrint(lblAPU.Text, lblAPUHours.Text, lblAPUDriver.Text, codigo, lblAPUOrder.Text, 0);
                apuorder.Show();
            }
            else
                MessageBox.Show("Select a Record!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkAPUOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = chkAPUOrder.SelectedIndex;
            if ((chkAPUOrder.GetItemChecked(0) == true || chkAPUOrder.GetItemChecked(1) == true))
            {

                if (indice != -1)
                {
                    switch (indice)
                    {
                        case 0: //Flat Rate
                            chkAPUOrder.SetItemChecked(1, false);
                            break;
                        case 1: // Mileage
                            chkAPUOrder.SetItemChecked(0, false);
                            dgvAPUMto.DataSource = conectandose.ConsultarApus("apuprofiles", lblAPU.Text);
                            codigoapu = Convert.ToInt32(dgvAPUMto.Rows[0].Cells[0].Value);
                            string hours = "0";
                            NpgsqlCommand cmd = new NpgsqlCommand("update apuprofiles set totalhours='" + hours + "'" + " where id=" + codigoapu, conn);
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
            if (!(chkAPUOrder.GetItemChecked(1) == true))
                MessageBox.Show("Order not Closed!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                APUPrint apuprint = new APUPrint(lblAPU.Text, lblAPUHours.Text, lblAPUDriver.Text, codigo, lblAPUOrder.Text, 1);
                apuprint.Show();
            }

        }

    }
}
