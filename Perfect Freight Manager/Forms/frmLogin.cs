using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Perfect_Freight_Manager.Models;
using Npgsql;

namespace Perfect_Freight_Manager.Forms
{
    public partial class frmLogin : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        string user,nick,passw;
        private string mensaje;
        string TblName = "adminusers";
        public frmLogin()
        {
            InitializeComponent();
            lblCopy.Text = "\u00A9 Perfect Freight Inc.";
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwd, int wmsg, int wparam, int lparam);
        private void btnLogin_Click(object sender, EventArgs e)
        {
            dgvUsers.DataSource = conectandose.ConsultarUsers(TblName,txtNick.Text);
            if (dgvUsers.Rows.GetRowCount(0) > 0)
            {
                user = Convert.ToString(dgvUsers.Rows[0].Cells[1].Value);
                nick = Convert.ToString(dgvUsers.Rows[0].Cells[6].Value);
                passw= Convert.ToString(dgvUsers.Rows[0].Cells[7].Value);
                if (txtNick.Text.CompareTo(nick)==0)
                {
                    nick = (txtNick.Text).ToUpper();
                    if (txtClave.Text.CompareTo(passw) == 0)
                    {
                        //usuario = txtNick.Text;
                        this.Hide();
                        Welcome welcome = new Welcome(user);
                        welcome.ShowDialog();
                        mensaje = user;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        msgError("Incorrect username or password entered\n      Please entry again.");
                        txtClave.Text = "";
                        txtNick.Focus();
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            if (txtNick.Text == "admin")
            {
                user = "YASSEL VALDES";
                if (txtClave.Text == "admin")
                {
                    //usuario = txtNick.Text;
                    this.Hide();
                    Welcome welcome = new Welcome(user);
                    welcome.ShowDialog();
                    mensaje = user;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    msgError("Please enter password vaild.");
                    txtClave.Text = "";
                    txtClave.Focus();
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                msgError("Incorrect username or password entered\n      Please entry again.");
                txtNick.Text = "";
                txtClave.Text = "";
                txtNick.Focus();
                this.DialogResult = DialogResult.None;
            }
        }

        public string Mensaje
        {
            get { return mensaje; }
        }

        private void txtNick_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

        private void pbEnd_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
