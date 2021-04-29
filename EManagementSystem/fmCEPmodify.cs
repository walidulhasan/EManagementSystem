using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EManagementSystem
{
    public partial class frmModify : Form
    {
        Connection c = new Connection();
        string imgloc = "";
        public frmModify()
        {
            InitializeComponent();
            //academic_load();
            Branchcode_load();
        }
       
        private void Branchcode_load()
        {
            try
            {
                c.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT bId FROM tblBranch", c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                c.con.Close();
                comboBoxOFBC.DisplayMember = "bId";
                comboBoxOFBC.ValueMember = "bId";
                comboBoxOFBC.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Hide();
        }

        private void picInfoSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("At first Fillup P-ID/A-ID/O-ID","For Search Infromation",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ealldataclear();
            
        }
        #region All Date Clear 
        private void ealldataclear()
        {
            picU.Visible = false;
            comboBoxGender.SelectedIndex = -1;
            txtPEmail.Clear();
            txtPFatherName.Clear();
            txtPName.Clear();
            txtPNid.Clear();
            txtPPhone.Clear();
            txtPid.Clear();
            txtPSocialId.Clear();
            dateTimeDateofBirthP.Value = DateTime.Now;
            dateTimeJoinDateP.Value = DateTime.Now.AddDays(10);
            picShow.ImageLocation = null;
            comboBoxPTitle.SelectedIndex = -1;
            comboBoxMaritalStatusP.SelectedIndex = -1;
            txtAid.Text = "";
            txtOid.Text = "";
            txtACID.Clear();
            comboBoxAcOlevel.SelectedIndex = -1;
            txtACOresult.Clear();
            comboBoxACalevel.SelectedIndex = -1;
            txtACaresult.Clear();
            comboBoxIlevel.SelectedIndex = -1;
            txtACiresult.Clear();
            comboBoxAChonus.SelectedIndex = -1;
            txtACHresult.Clear();
            comboBoxACmasters.SelectedIndex = -1;
            txtACmresult.Clear();
            txtACspecialvalue.Clear();
            txtACsresult.Clear();
            txtOfid.Clear();
            comboBoxOFPri.SelectedIndex = -1;
            comboBoxOFPre.SelectedIndex = -1;
            comboBoxOFPro.SelectedIndex = -1;
            comboBoxOFBC.SelectedIndex = -1;
            txtOFbranch.Clear();
        }
        #endregion

        #region Search Notice 
        private void searchmessage()
        {
            MessageBox.Show("This txtBox connected with Search Button", "Search Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void picinfoNids_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your NID will be 13 digit Like\n 1993123323456", "NID info...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void picsearchA_Click(object sender, EventArgs e)
        {
            searchmessage();
        }

        private void picsearchO_Click(object sender, EventArgs e)
        {
            searchmessage();
        }
        #endregion

        //#region Academic and Official ID load
        //private void academic_load()
        //{
        //    try
        //    {
        //        c.con.Open();
        //        SqlDataAdapter sda = new SqlDataAdapter("SELECT eaId FROM tblAcademic", c.con);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        c.con.Close();
        //        comboBoxPEId.DisplayMember = "eaId";
        //        comboBoxPEId.ValueMember = "eaId";
        //        comboBoxPEId.DataSource = dt;

        //        c.con.Open();
        //        SqlDataAdapter sda1 = new SqlDataAdapter("SELECT eoId FROM tblOfficial", c.con);
        //        DataTable dt1 = new DataTable();
        //        sda1.Fill(dt1);
        //        c.con.Close();
        //        comboBoxOid.DisplayMember = "eoId";
        //        comboBoxOid.ValueMember = "eoId";
        //        comboBoxOid.DataSource = dt1;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }

        //}
        //#endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            picU.Visible = true;
            c.con.Open();
            SqlTransaction transaction = c.con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblEpersonla WHERE eId=@ID", c.con, transaction);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", txtPid.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    comboBoxPTitle.Text = dr[1].ToString();
                    txtPName.Text = dr[2].ToString();
                    dateTimeDateofBirthP.Value = (DateTime)dr[3];
                    txtPFatherName.Text = dr[4].ToString();
                    comboBoxGender.Text = dr[5].ToString();
                    txtPNid.Text = dr[6].ToString();
                    txtPPhone.Text = dr[7].ToString();
                    txtPEmail.Text = dr[8].ToString();
                    txtPSocialId.Text = dr[9].ToString();
                    comboBoxMaritalStatusP.Text = dr[10].ToString();
                    dateTimeJoinDateP.Value = (DateTime)dr[11];
                    byte[] img = (byte[])(dr[12]);
                    if (img == null)
                    {
                        picShow.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        picShow.Image = Image.FromStream(ms);
                    }
                    txtACID.Text = dr[13].ToString();
                    txtOfid.Text = dr[14].ToString();
                }
                else
                {
                    MessageBox.Show("Data Not Found !!!\n Provide Correct ID", "Personal ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dr.Close();

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblAcademic WHERE eaId=@ID", c.con, transaction);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@ID", txtAid.Text);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    comboBoxAcOlevel.Text = dr1[1].ToString();
                    txtACOresult.Text = dr1[2].ToString();
                    comboBoxACalevel.Text = dr1[3].ToString();
                    txtACaresult.Text = dr1[4].ToString();
                    comboBoxIlevel.Text = dr1[5].ToString();
                    txtACiresult.Text = dr1[6].ToString();
                    comboBoxAChonus.Text = dr1[7].ToString();
                    txtACHresult.Text = dr1[8].ToString();
                    comboBoxACmasters.Text = dr1[9].ToString();
                    txtACmresult.Text = dr1[10].ToString();
                    txtACspecialvalue.Text = dr1[11].ToString();
                    txtACsresult.Text = dr1[12].ToString();
                }
                else
                {
                    MessageBox.Show("Data Not Found !!!\n Provide Correct ID", "Academic ID", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                dr1.Close();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM tblOfficial WHERE eoId=@ID", c.con, transaction);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("@ID",txtOid.Text);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    comboBoxOFPri.Text = dr2[1].ToString();
                    comboBoxOFPre.Text = dr2[2].ToString();
                    comboBoxOFPro.Text = dr2[3].ToString();
                    comboBoxOFBC.Text = dr2[4].ToString();
                    txtOFbranch.Text = dr2[5].ToString();
                }
                else
                {
                    MessageBox.Show("Data Not Found !!!\n Provide Correct ID", "Official ID ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                dr2.Close();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                MessageBox.Show("ID is needed to make the search operation", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                c.con.Close();
            }


        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "Select Employee Picture";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imgloc = dlg.FileName.ToString();
                picShow.ImageLocation = imgloc;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            c.con.Open();
            SqlTransaction transaction = c.con.BeginTransaction();
            try
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO tblAcademic VALUES ('" + txtACID.Text + "','" + comboBoxAcOlevel.Text + "','" + txtACOresult.Text + "','" + comboBoxACalevel.Text + "','" + txtACaresult.Text + "','" + comboBoxIlevel.Text + "','" + txtACiresult.Text + "','" + comboBoxAChonus.Text + "','" + txtACHresult.Text + "','" + comboBoxACmasters.Text + "','" + txtACmresult.Text + "','" + txtACspecialvalue.Text + "','" + txtACsresult.Text + "')", c.con, transaction);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();

                byte[] img = null;
                FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                SqlCommand cmd2 = new SqlCommand("INSERT INTO tblOfficial VALUES('" + txtOfid.Text + "','" + comboBoxOFPri.Text + "','" + comboBoxOFPre.Text + "','" + comboBoxOFPro.Text + "','" + comboBoxOFBC.Text + "','" + txtOFbranch.Text + "')", c.con, transaction);
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();
                transaction.Commit();
                
                SqlCommand cmd = new SqlCommand("INSERT INTO tblEpersonla VALUES(@Title,@Name,@Dateofbirth,@FatherName,@Gender,@Nid,@Phone,@Email,@SocialId,@MaritalS,@Joindate,@Img,@Acid,@Ofid)", c.con, transaction);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Title", comboBoxPTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", txtPName.Text.Trim());
                cmd.Parameters.AddWithValue("@Dateofbirth", dateTimeDateofBirthP.Value);
                cmd.Parameters.AddWithValue("@FatherName", txtPFatherName.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", comboBoxGender.Text.Trim());
                cmd.Parameters.AddWithValue("@Nid", txtPNid.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", txtPPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtPEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@SocialId", txtPSocialId.Text.Trim());
                cmd.Parameters.AddWithValue("@MaritalS", comboBoxMaritalStatusP.Text.Trim());
                cmd.Parameters.AddWithValue("@Joindate", dateTimeJoinDateP.Value);
                cmd.Parameters.AddWithValue("@Img", img);
                cmd.Parameters.AddWithValue("@Acid", txtACID.Text);
                cmd.Parameters.AddWithValue("@Ofid", txtOfid.Text);
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Data Inserted Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ealldataclear();
                //academic_load();
            }
            catch (Exception)
            {
                //transaction.Rollback();
                MessageBox.Show("Insert Failed. Some data is already exists", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            c.con.Open();
            SqlTransaction transaction = c.con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(eId)+1 FROM tblEpersonla", c.con, transaction);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtPid.Text = dr[0].ToString();
                }
                else
                {
                    MessageBox.Show("Data not found", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                dr.Close();


                SqlCommand cmd1 = new SqlCommand("SELECT MAX(eaId)+1 FROM tblAcademic", c.con, transaction);
                cmd1.CommandType = CommandType.Text;
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    txtAid.Text = dr1[0].ToString();
                }
                else
                {
                    MessageBox.Show("Data not found", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                dr1.Close();


                SqlCommand cmd2 = new SqlCommand("SELECT MAX(eoId)+1 FROM tblOfficial", c.con, transaction);
                cmd2.CommandType = CommandType.Text;
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    txtOid.Text = dr2[0].ToString();
                }
                else
                {
                    MessageBox.Show("Data not found", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                dr2.Close();

            }
            catch (Exception)
            {

                transaction.Rollback();
                MessageBox.Show("You have to make sure all the tables have data for performing this operation. If no data found please Insert data first", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                c.con.Close();
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.con.Open();
            SqlTransaction transaction = c.con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblEpersonla WHERE eId=" + txtPid.Text, c.con, transaction);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("DELETE FROM tblAcademic WHERE eaId=" + txtAid.Text, c.con, transaction);
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE FROM tblOfficial WHERE eoId=" + txtOid.Text, c.con, transaction);
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Data Deleted", "Successfully!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ealldataclear();
                MessageBox.Show("Data Inserted Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                transaction.Rollback();
                MessageBox.Show("Invalid Data");
            }
            finally
            {
                c.con.Close();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            c.con.Open();
            SqlTransaction transaction = c.con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblOfficial SET eoPrePosition='" + comboBoxOFPri.Text + "',eoPresPosition='" + comboBoxOFPre.Text + "',eoPromPosition='" + comboBoxOFPro.Text + "',bId='" + comboBoxOFBC.Text + "',eoBranch='" + txtOFbranch.Text + "' WHERE eoId='" + txtOid.Text + "'", c.con, transaction);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("UPDATE tblAcademic SET O_level='" + comboBoxAcOlevel.Text + "',O_result='" + txtACOresult.Text + "',A_level='" + comboBoxACalevel.Text + "',A_result='" + txtACaresult.Text + "',Intermediate_level='" + comboBoxIlevel.Text + "',Intermediate_result='" + txtACiresult.Text + "',eaHons='" + comboBoxAChonus.Text + "',Hons_result='" + txtACHresult.Text + "',eaMast='" + comboBoxACmasters.Text + "',Mast_result='" + txtACmresult.Text + "',eaSpecial='" + txtACspecialvalue.Text + "',Special_result='" + txtACsresult.Text + "' WHERE eaId='" + txtAid.Text + "'", c.con, transaction);
                cmd1.ExecuteNonQuery();



                SqlCommand cmd2 = new SqlCommand("UPDATE tblEpersonla SET eTitle=@Title,eName=@Name,eDob=@Dateofbirth,eFatherName=@FatherName,eGender=@Gender,eNationalIdNo=@Nid,ePhoneNo=@Phone,eEmail=@Email,eSocialId=@SocialId,eMeritals=@MaritalS,eJoinDate=@Joindate,eaId=@Acid,eoId=@Ofid WHERE eId=@mid", c.con, transaction);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@mid", txtPid.Text);

                //byte[] img = null;
                //FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                //BinaryReader br = new BinaryReader(fs);
                //img = br.ReadBytes((int)fs.Length);
                cmd.Parameters.AddWithValue("@Title", comboBoxPTitle.Text);
                cmd.Parameters.AddWithValue("@Name", txtPName.Text);
                cmd.Parameters.AddWithValue("@Dateofbirth", dateTimeDateofBirthP.Value);
                cmd.Parameters.AddWithValue("@FatherName", txtPFatherName.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBoxGender.Text);
                cmd.Parameters.AddWithValue("@Nid", txtPNid.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtPEmail.Text);
                cmd.Parameters.AddWithValue("@SocialId", txtPSocialId.Text);
                cmd.Parameters.AddWithValue("@MaritalS", comboBoxMaritalStatusP.Text);
                cmd.Parameters.AddWithValue("@Joindate", dateTimeJoinDateP.Value);
                //cmd.Parameters.AddWithValue("@Img", img);
                cmd.Parameters.AddWithValue("@Acid", txtACID.Text);
                cmd.Parameters.AddWithValue("@Ofid", txtOfid.Text);
                cmd.ExecuteNonQuery();
                transaction.Commit();
                MessageBox.Show("Data Updated Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ealldataclear();
                
                
            }
            catch (Exception)
            {
                transaction.Rollback();
                MessageBox.Show("Invalid Data You can't change picture");
            }
            finally
            {
               c.con.Close();
            }
        }

        private void txtPNid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(label24, "Allow Only Number Values!!!");
                label24.Text = "Allow Only Number Values!!!";
            }
            else
            {
                errorProvider1.SetError(label24, "");
                label24.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEBA eba = new frmEBA();
            eba.Show();
        }

        private void picU_Click(object sender, EventArgs e)
        {
            c.con.Open();
            byte[] img = null;
            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            SqlCommand cmd = new SqlCommand("UPDATE tblEpersonla SET eImage=@Img WHERE eId=@mid", c.con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mid", txtPid.Text.Trim());
            cmd.Parameters.AddWithValue("@Img", img);
            cmd.ExecuteNonQuery();
            c.con.Close();
        }
    }
}
