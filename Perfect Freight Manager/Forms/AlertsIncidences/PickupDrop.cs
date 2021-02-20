using Npgsql;
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

namespace Perfect_Freight_Manager.Forms.AlertsIncidences
{
    public partial class PickupDrop : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        private string TblName = "rvpickupdrops";
        private int sgtepd = 0, cuentapd = 0;
        private int codigoPickup;

        public PickupDrop(string idrevenue, string broker)
        {
            InitializeComponent();
            cbPDType.Items.Clear();
            string cadena = "select type from pickupdroptypes order by id";
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                cbPDType.Items.Add(dr["type"].ToString());
            }
            conn.Close();
            lbLoadIdPickup.Text = idrevenue;
            lbSRPickup.Text = broker;
            //dtPDReceiverAppoinment.Value = dtEndDate.Value;
            TblName = "rvpickupdrops";
            if (!(idrevenue == ""))
                dgvPickup.DataSource = conectandose.ConsultarRevenue(TblName, idrevenue);
            cuentapd = dgvPickup.Rows.GetRowCount(0);
            //if (txtPDDriver.Text == "")
            //    txtPDDriver.Text = txtDriver.Text;
            lbRecordPD.Text = "Record " + (sgtepd + 1) + " of  " + cuentapd;
            btnPckupUpd.Enabled = false;
            btnPckupUpd.FlatStyle = FlatStyle.Standard;
            btnPckupDel.Enabled = false;
            btnPckupDel.FlatStyle = FlatStyle.Standard;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPDFirst_Click(object sender, EventArgs e)
        {
            cuentapd = dgvPickup.Rows.GetLastRow(0) + 1;
            if (cuentapd != 0)
            {
                sgtepd = dgvPickup.Rows.GetFirstRow(0);
                dgvPickup_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaPD();
            }
        }

        private void btnPDPrevious_Click(object sender, EventArgs e)
        {
            cuentapd = dgvPickup.Rows.GetLastRow(0) + 1;
            if (cuentapd != 0)
            {
                sgtepd = dgvPickup.Rows.GetPreviousRow(sgtepd, 0);
                if (sgtepd == -1) sgtepd = cuentapd - 1;
                if (sgtepd <= cuentapd && sgtepd >= 0)
                {
                    dgvPickup_RowEnter(sender, e);
                    rellenaPD();
                }
            }
        }

        private void btnPDNext_Click(object sender, EventArgs e)
        {
            cuentapd = dgvPickup.Rows.GetLastRow(0) + 1;
            if (cuentapd != 0)
            {
                sgtepd = dgvPickup.Rows.GetNextRow(sgtepd, 0);
                if (sgtepd == -1) sgtepd = 0;
                if (sgtepd <= cuentapd && sgtepd >= 0)
                {
                    dgvPickup_RowEnter(sender, e);
                    rellenaPD();
                }
            }
        }

        private void btnPDEnd_Click(object sender, EventArgs e)
        {
            cuentapd = dgvPickup.Rows.GetLastRow(0) + 1;
            if (cuentapd != 0)
            {
                sgtepd = dgvPickup.Rows.GetLastRow(0);
                dgvPickup_RowEnter(sender, e);
                rellenaPD();
            }
        }

        private void dgvPickup_RowEnter(object sender, EventArgs e)
        {
            dgvPickup.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvPickup.Rows[sgtepd].Selected = true;
            dgvPickup.FirstDisplayedScrollingRowIndex = dgvPickup.Rows.GetNextRow(sgtepd - 1, 0);
        }
        private void rellenaPD()
        {
            if (cuentapd > 0)
            {
                btnPckupUpd.Enabled = true;
                btnPckupUpd.FlatStyle = FlatStyle.Flat;
                btnPckupDel.Enabled = true;
                btnPckupDel.FlatStyle = FlatStyle.Flat;

                codigoPickup = Convert.ToInt32(dgvPickup.Rows[sgtepd].Cells[0].Value);

                cbPDType.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[2].Value);
                dtStartDate.Value = Convert.ToDateTime(dgvPickup.Rows[sgtepd].Cells[3].Value);
                txtPDStarCS.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[4].Value);
                dtArrivaDate.Value = Convert.ToDateTime(dgvPickup.Rows[sgtepd].Cells[5].Value);
                txtPDEndCS.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[6].Value);
                txtPDReceiver.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[7].Value);
                dtPDReceiverAppoinment.Value = Convert.ToDateTime(dgvPickup.Rows[sgtepd].Cells[8].Value);
                txtPDTotalTime.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[9].Value);
                txtNotes.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[10].Value);
                txtPDSealReceiver.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[12].Value);
                txtPDSealShipper.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[13].Value);
                txtPDShipper.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[14].Value);
                dtPDPickupAppoinment.Value = Convert.ToDateTime(dgvPickup.Rows[sgtepd].Cells[15].Value);
                txtPDPickupNumber.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[16].Value);
                txtpdPickupTime.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[17].Value);
                txtPDDeliveryNumber.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[18].Value);
                txtAPDeliveryNumber.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[19].Value);
                txtAPPickupNumber.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[20].Value);

                lbRecordPD.Text = "Record " + (sgtepd + 1) + " of  " + cuentapd;
                lbRuta.Text = "From: " + txtPDStarCS.Text + " < to > " + txtPDEndCS.Text;
            }
        }

        private void cbPDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPDType.Text == "Drop")
            {
                txtPDReceiver.Enabled = true;
                dtArrivaDate.Enabled = true;
                txtPDEndCS.Enabled = true;
                txtPDSealReceiver.Enabled = true;
                txtPDTotalTime.Enabled = true;
                txtPDDeliveryNumber.Enabled = true;
                txtAPDeliveryNumber.Enabled = true;
                dtPDReceiverAppoinment.Enabled = true;

                txtPDShipper.Enabled = false;
                dtStartDate.Enabled = false;
                txtPDStarCS.Enabled = false;
                txtPDSealShipper.Enabled = false;
                txtpdPickupTime.Enabled = false;
                txtPDPickupNumber.Enabled = false;
                txtAPPickupNumber.Enabled = false;
                dtPDPickupAppoinment.Enabled = false;

                txtPDReceiver.Focus();
            }
            else
            {
                txtPDReceiver.Enabled = false;
                dtArrivaDate.Enabled = false;
                txtPDEndCS.Enabled = false;
                txtPDSealReceiver.Enabled = false;
                txtPDTotalTime.Enabled = false;
                txtPDDeliveryNumber.Enabled = false;
                txtAPDeliveryNumber.Enabled = false;
                dtPDReceiverAppoinment.Enabled = false;

                txtPDShipper.Enabled = true;
                dtStartDate.Enabled = true;
                txtPDStarCS.Enabled = true;
                txtPDSealShipper.Enabled = true;
                txtpdPickupTime.Enabled = true;
                txtPDPickupNumber.Enabled = true;
                txtAPPickupNumber.Enabled = true;
                dtPDPickupAppoinment.Enabled = true;

                txtPDShipper.Focus();
            }
        }

        private void btnPckupUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update rvpickupdrops set idrevenue='" + lbLoadIdPickup.Text + "',pickdroptype='" + cbPDType.Text + "',startdate='" + dtStartDate.Value + "',startcs='" + txtPDStarCS.Text + "',arrivadate='" + dtArrivaDate.Value + "',endcs='" + txtPDEndCS.Text + "',customerliveload= '" + txtPDReceiver.Text + "',appoinmentdate='" + dtPDReceiverAppoinment.Value + "',totaltime='" + txtPDTotalTime.Text + "',notes=@notes,sealreceiver='" + txtPDSealReceiver.Text + "',sealshipper='" + txtPDSealShipper.Text + "',shipper='" + txtPDShipper.Text + "',pickupappoinment='" + dtPDPickupAppoinment.Value + "',pickupnumber='" + txtPDPickupNumber.Text + "',pickuptime='" + txtpdPickupTime.Text + "',deliverynumber='" + txtPDDeliveryNumber.Text + "',apptdeliverynumber='" + txtAPDeliveryNumber.Text + "',apptpickupnumber='" + txtAPPickupNumber.Text + "'" + " where id=" + codigoPickup, conn);
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
            dgvPickup.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdPickup.Text);
        }

        private void btnPckupDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoPickup);
                    btnClearPickup_Click(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvPickup.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdPickup.Text);
            }
        }

        private void btnClearPickup_Click(object sender, EventArgs e)
        {
            btnPckupUpd.Enabled = false;
            btnPckupUpd.FlatStyle = FlatStyle.Standard;
            btnPckupDel.Enabled = false;
            btnPckupDel.FlatStyle = FlatStyle.Standard;

            cbPDType.Text = "";
            txtPDShipper.Text = "";
            dtStartDate.Text = "";
            txtPDStarCS.Text = "";
            txtPDSealShipper.Text = "";

            dtArrivaDate.Text = "";
            txtPDEndCS.Text = "";
            txtPDReceiver.Text = "";
            dtPDReceiverAppoinment.Text = "";
            txtPDTotalTime.Text = "0";
            txtPDSealReceiver.Text = "";
            txtNotes.Text = "";

            txtpdPickupTime.Text = "";
            txtPDPickupNumber.Text = "";
            dtPDPickupAppoinment.Text = "";
            txtPDTotalTime.Text = "";
            txtPDDeliveryNumber.Text = "";
            txtAPPickupNumber.Text = "";
            txtAPDeliveryNumber.Text = "";
        }
    }
}
