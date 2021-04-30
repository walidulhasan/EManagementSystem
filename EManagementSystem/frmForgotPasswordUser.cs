using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace EManagementSystem
{
    public partial class frmForgotPasswordUser : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=WALIDULHASAN\MAHMUDSABUJ;Initial Catalog=EMS;Integrated Security=True");
        Connection c = new Connection();
        public frmForgotPasswordUser()
        {
            InitializeComponent();
        }

        private void lblbl_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin log = new frmLogin();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM loginInfo WHERE userEmail='"+txtRecover.Text+"'", c.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()==true)
            {
                if (textBox1.Text =="")
                {
                    textBox1.Text = dr.GetValue(0).ToString() + "||" + dr.GetValue(1).ToString();
                    lblbl.Visible = false;
                    label2.Visible = true;
                }
                else
                {
                    MessageBox.Show("Clear text box");
                }
            }
            else
            {
                MessageBox.Show("Data Does not match","Please Provide Right Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                pictureBox2.Visible = true;
            }
            c.con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtRecover.Text = "";
            textBox1.Text = "";
        }

        private void frmForgotPasswordUser_Load(object sender, EventArgs e)
        {
            WindowsMediaPlayer wp = new WindowsMediaPlayer();
            wp.URL = "dashboard.wav";
            wp.controls.play();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            
            frmLogin log = new frmLogin();
            log.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmNotice no = new frmNotice();
            no.pictureBox1.Visible = false;
            no.pictureBox2.Visible = false;
            no.pictureBox3.Visible = false;
            no.pictureBox5.Visible = false;
            no.pictureBox6.Visible = true;
            no.ShowDialog();
            this.Close();
        }
    }
}
