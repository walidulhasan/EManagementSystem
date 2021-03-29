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

namespace EManagementSystem
{
    public partial class frmForgotPasswordUser : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=WALIDULHASAN\MAHMUDSABUJ;Initial Catalog=EMS;Integrated Security=True");
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
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM loginInfo WHERE userName='"+txtRecover.Text+"' or userPassword='"+txtRecover.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label2.Text = dr.GetValue(0).ToString()+"|"+dr.GetValue(1).ToString();
            }
            else
            {
                MessageBox.Show("Data Does not match","Please Provide Right Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtRecover.Text = "";
            label2.Text = "";
        }
    }
}
