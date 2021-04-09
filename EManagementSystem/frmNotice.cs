using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace EManagementSystem
{
    public partial class frmNotice : Form
    {
        public frmNotice()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public Point mouseLocation; //part of Mouse drag and droup

        private void mouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mm = new MailMessage("isdbbisewesadcs@gmail.com", textBox3.Text);
                mm.Subject = textBox1.Text;
                mm.Body = textBox2.Text;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                System.Net.NetworkCredential nc = new NetworkCredential("isdbbisewesadcs@gmail.com", "password");
                smtp.Credentials = nc;
                smtp.EnableSsl = true;
                smtp.Send(mm);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                MessageBox.Show(a);
                if (a.Length>1)
                {

                }
                else
                {
                    MessageBox.Show("Email Send Successfull", "Email Sending", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmdashboard db = new frmdashboard();
            db.Show();
            this.Hide();
        }
    }
}
