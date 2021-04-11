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
    public partial class frmSalary : Form
    {
        Connection c = new Connection();
        public frmSalary()
        {
            InitializeComponent();
            tblESalary_load();
            tblEmployeeId_load();
            salarydataclear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        public Point mouseLocation;
        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
        private void tblESalary_load()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblESalary");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        #region Inotice
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Basic Salary will be equal OR up to 8000");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Of crouse!!!\nHouse Rent will be less then  Basic Pay");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Medical Allowance Will be equal OR less then 1500");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Travle Allowance Will be equal OR less then 2000");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Children Allowance Will be equal OR less then 500");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Provide you Loan Amount!!!");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How much deposit do you want\nOn top of this money you can't any interest\nbut you can get company share");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fill in this Date otherwise it took\nautomatically current date and time");
        }
        #endregion

        private void tblEmployeeId_load()
        {
            try
            {
                c.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT eId FROM tblEpersonla", c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                c.con.Close();
                comboBox.DisplayMember = "eId";
                comboBox.ValueMember = "eId";
                comboBox.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            salarydataclear();
            btnSave.Enabled = true;
        }

        private void salarydataclear()
        {
            txtBasicPay.Clear();
            txtChildAllow.Clear();
            txtGpfCpf.Clear();
            txtHouseRent.Clear();
            txtLon.Clear();
            txtMedAllow.Clear();
            txtTravAllow.Clear();
            comboBox.SelectedIndex = -1;
            pictureBox1.ImageLocation = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtBasicPay.Text)<=7999)
                {
                    MessageBox.Show("Basic Salary will be equal OR Greater then 8000");
                }
                else if (Convert.ToInt32(txtHouseRent.Text) >= Convert.ToInt32(txtBasicPay.Text))
                {
                    MessageBox.Show("Of crouse!!!\nHouse Rent will be less then  Basic Pay");
                }
                else if (Convert.ToInt32(txtMedAllow.Text) > 1500)
                {
                    MessageBox.Show("Medical Allowance Will be equal OR less then 1500");
                }
                else if (Convert.ToInt32(txtTravAllow.Text) > 2000)
                {
                    MessageBox.Show("Travle Allowance Will be equal OR less then 2000");
                }
                else if (Convert.ToInt32(txtChildAllow.Text) > 500)
                {
                    MessageBox.Show("Children Allowance Will be equal OR less then 500");
                }
                else
                {
                    c.con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = c.con;
                    cmd.CommandText = "INSERT INTO tblESalary values ('" + Convert.ToInt32(txtBasicPay.Text) + "','" + Convert.ToInt32(txtHouseRent.Text) + "','" + Convert.ToInt32(txtMedAllow.Text) + "','" + Convert.ToInt32(txtTravAllow.Text) + "','" + Convert.ToInt32(txtChildAllow.Text) + "','" + Convert.ToInt32(txtLon.Text) + "','" + Convert.ToInt32(txtGpfCpf.Text) + "','" + Convert.ToDateTime(dateTimePicker.Text) + "','" + comboBox.Text + "')";
                    cmd.ExecuteNonQuery();
                    c.con.Close();
                    tblESalary_load();
                    MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void picsearch_Click(object sender, EventArgs e)
        {
            
            try
            {
                string cmdtxt = "SELECT * FROM tblESalary WHERE salaryId='" + textBoxSearch.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(cmdtxt, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int rowcount = dt.Rows.Count;
                if (rowcount == 1)
                {
                    txtBasicPay.Text = dt.Rows[0][1].ToString().Trim();
                    txtHouseRent.Text = dt.Rows[0][2].ToString();
                    txtMedAllow.Text = dt.Rows[0][3].ToString();
                    txtTravAllow.Text = dt.Rows[0][4].ToString();
                    txtChildAllow.Text = dt.Rows[0][5].ToString();
                    txtLon.Text = dt.Rows[0][7].ToString();
                    txtGpfCpf.Text = dt.Rows[0][8].ToString();
                    dateTimePicker.Value = (DateTime)dt.Rows[0][9];
                    comboBox.Text = dt.Rows[0][10].ToString();
                    MessageBox.Show("Data reterive successfully!!!","Data Searching",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtBasicPay.Enabled = false;
                    txtHouseRent.Enabled = false;
                    txtMedAllow.Enabled = false;
                    txtTravAllow.Enabled = false;
                    txtChildAllow.Enabled = false;
                    txtLon.Enabled = false;
                    txtGpfCpf.Enabled = false;
                    dateTimePicker.Enabled = false;
                    comboBox.Enabled = false;
                    btnSave.Enabled = false;
                    btnEditing.Visible = true;
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

        private void btnEditing_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            txtBasicPay.Enabled = true;
            txtHouseRent.Enabled = true;
            txtMedAllow.Enabled = true;
            txtTravAllow.Enabled = true;
            txtChildAllow.Enabled = true;
            txtLon.Enabled = true;
            txtGpfCpf.Enabled = true;
            dateTimePicker.Enabled = true;
            comboBox.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tblESalary WHERE salaryId=@ID", c.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", textBoxSearch.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                salarydataclear();
                tblESalary_load();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                c.con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtBasicPay.Text) <= 7999)
                {
                    MessageBox.Show("Basic Salary will be equal OR Greater then 8000");
                }
                else if (Convert.ToInt32(txtHouseRent.Text) >= Convert.ToInt32(txtBasicPay.Text))
                {
                    MessageBox.Show("Of crouse!!!\nHouse Rent will be less then  Basic Pay");
                }
                else if (Convert.ToInt32(txtMedAllow.Text) > 1500)
                {
                    MessageBox.Show("Medical Allowance Will be equal OR less then 1500");
                }
                else if (Convert.ToInt32(txtTravAllow.Text) > 2000)
                {
                    MessageBox.Show("Travle Allowance Will be equal OR less then 2000");
                }
                else if (Convert.ToInt32(txtChildAllow.Text) > 500)
                {
                    MessageBox.Show("Children Allowance Will be equal OR less then 500");
                }
                else
                {
                    c.con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tblESalary SET basicPay=@basic,houseRent=@house,medicalAllowance=@medical,travle_allowance=@travle,childrenEallwanc=@children,loan=@loans,Gpf_Cpf=@Gpf,salaryDate=@Datet,eId=@empId WHERE salaryId=@mid", c.con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@mid", textBoxSearch.Text.Trim());
                    cmd.Parameters.AddWithValue("@basic", Convert.ToInt32(txtBasicPay.Text));
                    cmd.Parameters.AddWithValue("@house", Convert.ToInt32(txtHouseRent.Text));
                    cmd.Parameters.AddWithValue("@medical", Convert.ToInt32(txtMedAllow.Text));
                    cmd.Parameters.AddWithValue("@travle", Convert.ToInt32(txtTravAllow.Text));
                    cmd.Parameters.AddWithValue("@children", Convert.ToInt32(txtChildAllow.Text));
                    cmd.Parameters.AddWithValue("@loans", Convert.ToInt32(txtLon.Text));
                    cmd.Parameters.AddWithValue("@Gpf", Convert.ToInt32(txtGpfCpf.Text));
                    cmd.Parameters.AddWithValue("@Datet", Convert.ToDateTime(dateTimePicker.Text));
                    cmd.Parameters.AddWithValue("@empId", comboBox.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Date Successfully Updated!!");
                    salarydataclear();
                    tblESalary_load();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                c.con.Close();
            }
            
        }
    }
}
