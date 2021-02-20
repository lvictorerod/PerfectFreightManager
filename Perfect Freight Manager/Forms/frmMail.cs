using Npgsql;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Models;
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms
{
    public partial class frmMail : Form
    {
        private string host, passw, ssl;
        private int port;
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        public frmMail(string para, string adjunto)
        {
            InitializeComponent();
            txtTo.Text = "";
            txtAttacment.Text = "";
            txtTo.Text = para;
            txtAttacment.Text = adjunto;
            dgvConsulta.DataSource = conectandose.Consultar("emailsettings");
        }
        SmtpClient smtp = new SmtpClient();
        MailMessage mail = new MailMessage();
        Attachment attachment;

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                txtAttacment.Text = dialog.FileName;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!(txtTo.Text == "" || txtFrom.Text == ""))
            {
                smtp = new SmtpClient();
                mail = new MailMessage();


                smtp.Host = host;
                smtp.Port = port;
                if (ssl == "Apagado")
                    smtp.EnableSsl = false;
                else smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new System.Net.NetworkCredential(txtFrom.Text, passw);

                mail.From = new MailAddress(txtFrom.Text);
                //Validando el Campo To:
                if (!string.IsNullOrEmpty(txtTo.Text))
                {
                    mail.To.Add(new MailAddress(txtTo.Text));
                }
                else
                {
                    MessageBox.Show("To: is obligatory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!string.IsNullOrEmpty(txtCc.Text))
                {
                    mail.CC.Add(new MailAddress(txtCc.Text));

                    if (!string.IsNullOrEmpty(txtBcc.Text))
                        mail.Bcc.Add(new MailAddress(txtBcc.Text));
                }
                if (!string.IsNullOrEmpty(txtAttacment.Text))
                {
                    attachment = new Attachment(txtAttacment.Text);
                    mail.Attachments.Add(attachment);
                }
                mail.Subject = txtSubject.Text;
                mail.Body = txtMessage.Text;
                mail.IsBodyHtml = true;
                smtp.Send(mail);

                MessageBox.Show("E-Mail send correct", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCc_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("phonebooks", "");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(txtCc.Text))
                txtCc.Text = txtCc.Text + ", " + search.Nombre;
            else txtCc.Text = search.Nombre;
        }

        private void btnCco_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("phonebooks", "");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(txtBcc.Text))
                txtBcc.Text = txtBcc.Text + ", " + search.Nombre;
            else txtBcc.Text = search.Nombre;

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            host = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[5].Value);
            port = Convert.ToInt32(dgvConsulta.Rows[e.RowIndex].Cells[3].Value);
            passw = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[2].Value);
            txtFrom.Text = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[1].Value);
            ssl = Convert.ToString(dgvConsulta.Rows[e.RowIndex].Cells[6].Value);

        }


        private void btnCc_MouseHover(object sender, EventArgs e)
        {
            lblCc.Visible = true;
        }

        private void btnCc_MouseLeave(object sender, EventArgs e)
        {
            lblCc.Visible = false;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpMail helpMail = new frmHelpMail();
            helpMail.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCco_MouseHover(object sender, EventArgs e)
        {
            lblBcc.Visible = true;
        }

        private void btnCco_MouseLeave(object sender, EventArgs e)
        {
            lblBcc.Visible = false;
        }
    }
}
