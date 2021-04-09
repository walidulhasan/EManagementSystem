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
            if (dr.Read())
            {
                label2.Text = dr.GetValue(0).ToString()+"|"+dr.GetValue(1).ToString();
            }
            else
            {
                MessageBox.Show("Data Does not match","Please Provide Right Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            c.con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtRecover.Text = "";
            label2.Text = "";
        }
    }
}
