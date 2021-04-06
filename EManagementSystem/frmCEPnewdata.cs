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
    public partial class frmCEPnewdata : Form
    {
        Connection c = new Connection();
        public frmCEPnewdata()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region OFFICE WITH OTHER TAB SECTION
        private void btnOFclear_Click(object sender, EventArgs e)
        {
            OfallClear();
        }

        private void OfallClear()
        {
            txtOFbranch.Text = "";
            txtOFbrCode.Text = "";
            txtOFprePosition.Text = "";
            txtOFpresPosition.Text = "";
            txtOFproPosition.Text = "";
            txtFOid.Text = "";
        }

        private void tabOfficial_load()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblOfficial");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridOF.DataSource = dt;
        }

        private void btnOFshow_Click(object sender, EventArgs e)
        {
            try
            {
                tabOfficial_load();
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnOFsave_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "INSERT INTO tblOfficial VALUES('" + txtOFbrCode.Text + "','" + txtOFprePosition.Text + "','" + txtOFpresPosition.Text + "','" + txtOFproPosition.Text + "','" + txtOFbranch.Text + "')";
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OfallClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void btnOFsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdtxt = "SELECT * FROM tblOfficial WHERE eoId='" +txtFOid.Text+ "'";
                SqlDataAdapter sda = new SqlDataAdapter(cmdtxt, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int rowcount = dt.Rows.Count;
                if (rowcount == 1)
                {
                    txtOFbrCode.Text = dt.Rows[0][1].ToString();
                    txtOFprePosition.Text = dt.Rows[0][2].ToString();
                    txtOFpresPosition.Text = dt.Rows[0][3].ToString();
                    txtOFproPosition.Text = dt.Rows[0][4].ToString();
                    txtOFbranch.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    MessageBox.Show("Data Not Found !!!\n Proide Correct ID","Searching",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void btnOFupdate_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "UPDATE tblOfficial SET eoBcode='"+ txtOFbrCode.Text + "',eoPrePosition='"+ txtOFprePosition.Text + "',eoPresPosition='"+ txtOFpresPosition.Text + "',eoPromPosition='"+ txtOFproPosition.Text + "',eoBranch='"+ txtOFbranch.Text + "' WHERE eoId='"+txtFOid.Text+"'";
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Data Successfully Updated!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OfallClear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnOFdelete_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "DELETE FROM tblOfficial WHERE eoId=" + txtFOid.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show($"Data Delete Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OfallClear();

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
        #endregion
    }
}
