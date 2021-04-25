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
using System.Data.SqlClient;
using System.IO;

namespace EManagementSystem
{
    public partial class frmNotice : Form
    {
        Connection c = new Connection();
        public frmNotice()
        {
            InitializeComponent();
            datashow();
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
            clearall();
        }

        private void clearall()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            picsearch.ImageLocation = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mm = new MailMessage("tambazz@gmail.com", textBox3.Text);
                mm.Subject = textBox1.Text;
                mm.Body = textBox2.Text;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                System.Net.NetworkCredential nc = new NetworkCredential("tambazz.com@gmail.com", "hrfdahacwaaakfoj");
                smtp.Credentials = nc;
                smtp.EnableSsl = true;
                smtp.Send(mm);
                MessageBox.Show("Email Send Successfull", "Email Sending", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                if (a.Length>1)
                {
                    MessageBox.Show(a);
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void datashow()
        {
            SqlCommand cmd = new SqlCommand("SELECT eId AS ID,eName AS NAME,ePhoneNo AS 'PHONE NO',eEmail AS EMAIL FROM tblEpersonla");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void picsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "" && Convert.ToInt32(textBox4.Text)!=Convert.ToInt32(textBox4.Text))
                {
                    MessageBox.Show("Text cen't taken");
                }
                else
                {
                    c.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblEpersonla WHERE eId=@ID", c.con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", textBox4.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox3.Text = dr[8].ToString();
                        byte[] img = (byte[])(dr[12]);
                        if (img == null)
                        {
                            pictureBox4.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            pictureBox4.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There are no records");
                    }
                    c.con.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox4.Visible = true;
            dataGridView1.Visible = true;
            picsearch.Visible = true;
            pictureBox5.Visible = false;
        }

        private void frmNotice_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
