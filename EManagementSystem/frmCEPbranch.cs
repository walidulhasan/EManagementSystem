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
    public partial class frmCEPbranch : Form
    {
        Connection c = new Connection();
        public frmCEPbranch()
        {
            InitializeComponent();
            tblbranch_info_load();
            branchid_load();
            comboBox1.SelectedIndex = -1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Branch code DEMO : BC01\n Branch Name: [Head Office code latter 2 / Type Of bank latter 2 with poition BC]","Demo of Data Entry",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("District Name:Bhola\n SubDistrict Name: Charfasson\n Address: Cf Bazar AbPlaza 6th f,R4,5,6", "Branch Location DEMO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        private void picBZname_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DEMO: BHCHCBBC001\nBranch Zone Name Willbe:District 2 latter\nSubDistrict 2 latter\n With Branch Code", "Branch Zone Name", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            txtBaddress.Text = "";
            txtBcode.Text = "";
            txtBDname.Text = "";
            txtBname.Text = "";
            txtBSDname.Text = "";
            comboBox1.Visible = false;
            comboBox1.SelectedIndex = -1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void tblbranch_info_load()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblBranch");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void branchid_load()
        {
            c.con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT bId FROM tblBranch", c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            c.con.Close();
            comboBox1.ValueMember = "bId";
            comboBox1.DisplayMember = "bId";
            comboBox1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdtxt = "SELECT * FROM tblBranch WHERE bId='" + comboBox1.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(cmdtxt, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int rowcount = dt.Rows.Count;
                if (rowcount == 1)
                {
                    txtBcode.Text = dt.Rows[0][1].ToString();
                    txtBname.Text = dt.Rows[0][2].ToString();
                    txtBDname.Text = dt.Rows[0][3].ToString();
                    txtBSDname.Text = dt.Rows[0][4].ToString();
                    txtBaddress.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    MessageBox.Show("Data Not Found !!!\n Proide Correct ID", "Searching", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "UPDATE tblBranch SET bCode='"+txtBcode.Text+"',bNameCode='"+ txtBname.Text + "',bDistrictName='"+ txtBDname.Text + "',bSubDistrict='"+ txtBSDname.Text + "',bAddress='"+ txtBaddress.Text + "' WHERE bId='"+comboBox1.Text+"'";
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Data Successfully Updated!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tblbranch_info_load();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    c.con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = c.con;
                    cmd.CommandText = "DELETE FROM tblBranch WHERE bId=" + comboBox1.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Data Delete Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tblbranch_info_load();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    c.con.Close();

                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                c.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "INSERT INTO tblBranch VALUES('"+ txtBcode.Text + "','"+ txtBname.Text + "','"+ txtBDname.Text + "','"+ txtBSDname.Text + "','"+ txtBaddress.Text + "')";
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tblbranch_info_load();
                clear();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                MessageBox.Show("string of Null can't accepeted");
            }
        }

        private void frmCEPbranch_Load(object sender, EventArgs e)
        {
            WindowsMediaPlayer wp = new WindowsMediaPlayer();
            wp.URL = "dashboard.wav";
            wp.controls.play();
        }
    }
}
