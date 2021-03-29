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
using System.Configuration;

namespace EManagementSystem
{
    public partial class frmRegister : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=WALIDULHASAN\MAHMUDSABUJ;Initial Catalog=EMS;Integrated Security=True");
        public frmRegister()
        {
            InitializeComponent();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin log = new frmLogin();
            log.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmpassword.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty","Registration Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtConfirmpassword.Text)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO loginInfo VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "')",con);
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
                //this.Hide();
                //MessageBox.Show("Your Account has been Successfully Created","Registration Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //frmLogin log = new frmLogin();
                //log.Show();

                
            }
            else
            {
                MessageBox.Show("Password does not match, Please Re-enter","Registration Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                clear();
                txtPassword.Focus();
            }
        }
        private void clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmpassword.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            txtUsername.Focus();
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmpassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmpassword.PasswordChar = '*';
            }
        }
    }
}
