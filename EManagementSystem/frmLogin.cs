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
using WMPLib;

namespace EManagementSystem
{
    public partial class frmLogin : Form
    {
        int count = 1;
        public Point mouseLocation;
        //SqlConnection con = new SqlConnection(@"Data Source=WALIDULHASAN\MAHMUDSABUJ;Initial Catalog=EMS;Integrated Security=True");
        Connection c = new Connection();
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
            try
            {
                if (count < 4)
                {
                    c.con.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM loginInfo WHERE userName='" + txtUsername.Text + "' and userPassword='" + txtPassword.Text + "'", c.con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Do You Want Login ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            frmdashboard fdb = new frmdashboard();
                            fdb.Show();
                            this.Close();
                        }
                        else
                        {
                            c.con.Close();
                            MessageBox.Show("As your Wish");
                        }

                    }
                    else
                    {
                        //MessageBox.Show("Invalid Username or Password,Please Correct data provide", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show("Try again and the no. of attempt is" + count, "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //dataclear();
                        c.con.Close();
                    }
                }
                else if (count == 4)
                {
                    MessageBox.Show("Login attemtp exceed");
                    c.con.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE loginInfo SET userPassword='admin' WHERE userName='" + txtUsername.Text + "'", c.con);
                    cmd.ExecuteNonQuery();
                    c.con.Close();
                    pictureBox4.Visible = true;
                }
                count++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X,-e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername,"Please enter your user name !!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername,null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtPassword, "Please enter your user name !!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            WindowsMediaPlayer wp = new WindowsMediaPlayer();
            wp.URL = "dashboard.wav";
            wp.controls.play();
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
            frmForgotPasswordUser fps = new frmForgotPasswordUser();
            fps.lblbl.Enabled = false;
            fps.label3.Visible = true;
            fps.ShowDialog();
        }
    }
}
