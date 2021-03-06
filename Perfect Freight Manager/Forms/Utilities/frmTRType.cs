﻿using Npgsql;
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
    public partial class frmTRType : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string TblName = "trucktypes";
        int codigo = 0;
        public frmTRType()
        {
            InitializeComponent();

            btnAdd.Enabled = true;
            btnUpd.Enabled = false;
            btnDel.Enabled = false;
            dgvTRType.DataSource = conectandose.Consultar(TblName);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into trucktypes (type) values ('" + txtTRType.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Insert successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvTRType.DataSource = conectandose.Consultar(TblName);
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
                dgvTRType.DataSource = conectandose.Consultar(TblName);
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update trucktypes set type='" + txtTRType.Text + "'" + " where id=" + codigo, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update correct");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
            dgvTRType.DataSource = conectandose.Consultar(TblName);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnUpd.Enabled = false;
            btnDel.Enabled = false;
            txtTRType.Text = "";
        }

        private void dgvType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnUpd.Enabled = true;
            btnDel.Enabled = true;

            codigo = Convert.ToInt32(dgvTRType.Rows[e.RowIndex].Cells[0].Value);

            txtTRType.Text = Convert.ToString(dgvTRType.Rows[e.RowIndex].Cells[1].Value);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
