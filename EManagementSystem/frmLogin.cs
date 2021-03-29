using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EManagementSystem
{
    public partial class frmLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=WALIDULHASAN\MAHMUDSABUJ;Initial Catalog=EMS;Integrated Security=True");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister reg = new frmRegister();
            reg.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmForgotPasswordUser ffu = new frmForgotPasswordUser();
            ffu.Show();
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM loginInfo WHERE userName='"+txtUsername.Text+"' and userPassword='"+txtPassword.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()== true)
            {
                frmdashboard fdb = new frmdashboard();
                fdb.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password,Please Correct data provide","Login Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                dataclear();
                con.Close();
            }
            
        }
        private void dataclear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataclear();

        }
    }
}
