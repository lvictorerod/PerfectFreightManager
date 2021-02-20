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

namespace Perfect_Freight_Manager.Forms.Utilities
{
    public partial class frmPDType : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        private string TblName = "pickupdroptypes";
        private int codigo = 0;
        private bool mensaje = false, refresh = false;
        public frmPDType()
        {
            InitializeComponent();

            btnAdd.Enabled = true;
            btnUpd.Enabled = false;
            btnDel.Enabled = false;
            dgvType.DataSource = conectandose.Consultar(TblName);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into pickupdroptypes (type) values ('" + txtPDType.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Insert successfully");
                refresh = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvType.DataSource = conectandose.Consultar(TblName);
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigo);
                    refresh = true;
                    btnClear_Click_1(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvType.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpd_Click_1(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update pickupdroptypes set type='" + txtPDType.Text + "'" + " where id=" + codigo, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correct");
                refresh = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            dgvType.DataSource = conectandose.Consultar(TblName);
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnUpd.Enabled = false;
            btnDel.Enabled = false;
            txtPDType.Text = "";
        }

        private void dgvType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;

            codigo = Convert.ToInt32(dgvType.Rows[e.RowIndex].Cells[0].Value);

            txtPDType.Text = Convert.ToString(dgvType.Rows[e.RowIndex].Cells[1].Value);
        }
        public bool Mensaje
        {
            get { return mensaje; }
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mensaje = refresh;
            this.Close();
        }
    }
}
