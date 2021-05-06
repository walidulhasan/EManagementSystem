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
using System.IO;

namespace EManagementSystem
{
    public partial class frmCEPnewdata : Form
    {
        Connection c = new Connection();
        
        public frmCEPnewdata()
        {
            InitializeComponent();
            tabOfficial_load();
            tabAcademic_load();
            tabPersonal_info_load();
            academic_load();
            Branchcode_load();
            OfallClear();
            pegrideview();
            ofgrideview();
        }
        private void pegrideview()
        {
            dataGridViewPersonal.BorderStyle = BorderStyle.None;
            dataGridViewPersonal.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridViewPersonal.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewPersonal.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewPersonal.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewPersonal.BackgroundColor = Color.White;

            dataGridViewPersonal.EnableHeadersVisualStyles = false;
            dataGridViewPersonal.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewPersonal.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridViewPersonal.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void ofgrideview()
        {
            dataGridOF.BorderStyle = BorderStyle.None;
            dataGridOF.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridOF.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridOF.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridOF.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridOF.BackgroundColor = Color.White;

            dataGridOF.EnableHeadersVisualStyles = false;
            dataGridOF.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridOF.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridOF.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
            frmdashboard db = (frmdashboard)Application.OpenForms["frmdashboard"];
            db.WindowState = FormWindowState.Normal;
        }
        #region OFFICE WITH OTHER TAB SECTION
        private void btnOFclear_Click(object sender, EventArgs e)
        {
            OfallClear();
        }

        private void OfallClear()
        {
            txtOFbranch.Text = "";
            comboBoxOFBC.SelectedIndex = -1;
            comboBoxOFPre.SelectedIndex = -1;
            comboBoxOFPri.SelectedIndex = -1;
            comboBoxOFPro.SelectedIndex = -1;
            txtOfid.Clear();
            txtFOid.Clear();
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
        private void btnOFsave_Click(object sender, EventArgs e)
        {
           
            //try
            //{
                
                c.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "INSERT INTO tblOfficial VALUES('"+txtOfid.Text+"','" + comboBoxOFPri.Text + "','" + comboBoxOFPre.Text + "','" + comboBoxOFPro.Text + "','" + comboBoxOFBC.Text + "','" +txtOFbranch.Text+ "')";
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OfallClear();
                tabOfficial_load();
            //}
            //catch (Exception)
            //{
            //    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //    MessageBox.Show("string of Null can't accepeted");
            //}
            
        }

        private void btnOFsearch_Click(object sender, EventArgs e)
        {
            pictureBoxofshow.Visible = true;
            try
            {
                string cmdtxt = "SELECT * FROM tblOfficial WHERE eoId='" +txtFOid.Text+ "'";
                SqlDataAdapter sda = new SqlDataAdapter(cmdtxt, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int rowcount = dt.Rows.Count;
                if (rowcount == 1)
                {
                    txtOfid.Visible = false;
                    comboBoxOFPri.Text = dt.Rows[0][1].ToString();
                    comboBoxOFPre.Text = dt.Rows[0][2].ToString();
                    comboBoxOFPro.Text = dt.Rows[0][3].ToString();
                    comboBoxOFBC.Text = dt.Rows[0][4].ToString();
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
                cmd.CommandText = "UPDATE tblOfficial SET eoPrePosition='"+ comboBoxOFPri.Text+ "',eoPresPosition='"+ comboBoxOFPre.Text + "',eoPromPosition='"+ comboBoxOFPro.Text+ "',bId='"+comboBoxOFBC.Text+ "',eoBranch='"+ txtOFbranch.Text+ "' WHERE eoId='"+txtFOid.Text+"'";
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Data Successfully Updated!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OfallClear();
                tabOfficial_load();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnOFdelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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
                    tabOfficial_load();

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
        #endregion

        #region ACADEMIC INFORMATION TAB SECTION
        private void ACallclear()
        {
            txtaid.Clear();
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
            txtACid.Clear();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Formet will be...\n\nJsc:A+\nSsc:A+\nHsc:A+\nHon's:1st Class[3.80 out of 4.00]\nMaster's:1st Class[3.95 out of 4.00]\nSpecial:Your Result", "Academic Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        private void tabAcademic_load()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblAcademic");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridAC.DataSource = dt;
        }

        private void btnACsave_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "INSERT INTO tblAcademic VALUES ('"+txtaid.Text+"','"+ comboBoxAcOlevel.Text+ "','"+ txtACOresult.Text+ "','"+ comboBoxACalevel.Text+ "','"+ txtACaresult.Text+ "','"+ comboBoxIlevel.Text+ "','"+ txtACiresult.Text+ "','"+ comboBoxAChonus.Text+ "','"+ txtACHresult.Text+ "','"+ comboBoxACmasters.Text+ "','"+ txtACmresult.Text+ "','"+ txtACspecialvalue.Text+ "','"+ txtACsresult.Text+ "')";
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ACallclear();
                tabAcademic_load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnACsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdtxt = "SELECT * FROM tblAcademic WHERE eaId='" + txtACid.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(cmdtxt, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int rowcount = dt.Rows.Count;
                if (rowcount == 1)
                {
                    txtaid.Visible = false;
                    comboBoxAcOlevel.Text = dt.Rows[0][1].ToString();
                    txtACOresult.Text = dt.Rows[0][2].ToString();
                    comboBoxACalevel.Text = dt.Rows[0][3].ToString();
                    txtACaresult.Text = dt.Rows[0][4].ToString();
                    comboBoxIlevel.Text = dt.Rows[0][5].ToString();
                    txtACiresult.Text = dt.Rows[0][6].ToString();
                    comboBoxAChonus.Text = dt.Rows[0][7].ToString();
                    txtACHresult.Text = dt.Rows[0][8].ToString();
                    comboBoxACmasters.Text = dt.Rows[0][9].ToString();
                    txtACmresult.Text = dt.Rows[0][10].ToString();
                    txtACspecialvalue.Text = dt.Rows[0][11].ToString();
                    txtACsresult.Text = dt.Rows[0][12].ToString();
                }
                else
                {
                    MessageBox.Show("Data Not Found !!!\n Provide Correct ID", "Searching", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnACupdate_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "UPDATE tblAcademic SET O_level='"+ comboBoxAcOlevel.Text+ "',O_result='"+ txtACOresult.Text+ "',A_level='"+ comboBoxACalevel.Text+ "',A_result='"+ txtACaresult.Text+ "',Intermediate_level='"+ comboBoxIlevel.Text+ "',Intermediate_result='"+ txtACiresult.Text+ "',eaHons='"+ comboBoxAChonus.Text+ "',Hons_result='"+ txtACHresult.Text+ "',eaMast='"+ comboBoxACmasters.Text+ "',Mast_result='"+ txtACmresult.Text+ "',eaSpecial='"+ txtACspecialvalue.Text+ "',Special_result='"+ txtACsresult.Text+ "' WHERE eaId='"+txtACid.Text+"'";
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Data Successfully Updated!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ACallclear();
                tabAcademic_load();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnACdelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    c.con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = c.con;
                    cmd.CommandText = "DELETE FROM tblAcademic WHERE eaId=" + txtACid.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Data Delete Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ACallclear();
                    tabAcademic_load();

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
        private void btnACclear_Click(object sender, EventArgs e)
        {
            ACallclear();
        }

        #endregion

        private void btnPEClear_Click(object sender, EventArgs e)
        {
            PEallclearbox();
        }

        #region Personal TAB information Clear Method
        private void PEallclearbox()
        {
            txtPEEmail.Clear();
            txtPEFatherName.Clear();
            txtPEName.Clear();
            txtPENid.Clear();
            txtPEPhone.Clear();
            txtPESocialId.Clear();
            comboBox2PEid.SelectedIndex = -1;
            comboBoxPEId.SelectedIndex = -1;
            PEcomboBoxMstatus.SelectedIndex = -1;
            PEcomboBoxTitle.SelectedIndex = -1;
            PEpicShow.Image = null;
            txid.Clear();
            picU.Visible = false;
            btnPESave.Enabled = true;
        }
        #endregion

        private void tabPersonal_info_load()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblEpersonla");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewPersonal.DataSource = dt;
        }

        private void btnPEUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
                dlg.Title = "Select Employee Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgloc = dlg.FileName.ToString();
                    PEpicShow.ImageLocation = imgloc;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        #region PicNIDinfo with PicSearchinfo
        private void picNIDinfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your NID will be 13 digit Like\n 1993123323456","NID info...",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void picSearchinfor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("For retrive data use ID Red TextBox", "Search info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Academic and Official ID load
        private void academic_load()
        {
            try
            {
                c.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT eaId FROM tblAcademic", c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                c.con.Close();
                comboBoxPEId.DisplayMember = "eaId";
                comboBoxPEId.ValueMember = "eaId";
                comboBoxPEId.DataSource = dt;

                c.con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter("SELECT eoId FROM tblOfficial", c.con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                c.con.Close();
                comboBox2PEid.DisplayMember = "eoId";
                comboBox2PEid.ValueMember = "eoId";
                comboBox2PEid.DataSource = dt1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        #endregion

        string imgloc = "";
        string gnd = "";
        string nid;

        private void btnPESave_Click(object sender, EventArgs e)
        {
            if (txtPENid.TextLength==13 && txtPEName.Text!=null && txtPEFatherName.Text!=null && txtPEPhone.Text!=null && PEcomboBoxMstatus.Text!=null && comboBoxPEId.Text!=null && comboBox2PEid.Text!=null)
            {
                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    if (rdMale.Checked == true)
                    {
                        gnd = "Male";
                    }
                    else if (rdFemale.Checked == true)
                    {
                        gnd = "Female";
                    }
                    else
                    {
                        MessageBox.Show("Can't Select Gender!!");
                    }

                    if (txtPENid.TextLength == 13)
                    {
                        nid = txtPENid.Text;
                    }
                    else
                    {
                        MessageBox.Show("Your NID will be 13 digit Like\n 1993123323456", "NID info...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO tblEpersonla VALUES(@Title,@Name,@Dateofbirth,@FatherName,@Gender,@Nid,@Phone,@Email,@SocialId,@MaritalS,@Joindate,@Img,@Acid,@Ofid)", c.con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Title", PEcomboBoxTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtPEName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Dateofbirth", PEdateTimeDateofBirth.Value);
                    cmd.Parameters.AddWithValue("@FatherName", txtPEFatherName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", gnd);
                    cmd.Parameters.AddWithValue("@Nid", nid);
                    cmd.Parameters.AddWithValue("@Phone", txtPEPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtPEEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@SocialId", txtPESocialId.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaritalS", PEcomboBoxMstatus.Text.Trim());
                    cmd.Parameters.AddWithValue("@Joindate", PEdateTimeJoinDate.Value);
                    cmd.Parameters.AddWithValue("@Img", img);
                    cmd.Parameters.AddWithValue("@Acid", comboBoxPEId.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ofid", comboBox2PEid.Text.Trim());
                    c.con.Open();
                    cmd.ExecuteNonQuery();
                    c.con.Close();
                    MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabPersonal_info_load();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    c.con.Close();
                }
            }
            else
            {
                MessageBox.Show("Can't taken Null and NID will must be 13 digits");
            }

        }

        private void btnPEsearch_Click(object sender, EventArgs e)
        {
            try
            {
                picU.Visible = true;
                btnPESave.Enabled = false;
                c.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblEpersonla WHERE eId=@ID",c.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", txid.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    PEcomboBoxTitle.Text = dr[1].ToString();
                    txtPEName.Text = dr[2].ToString();
                    PEdateTimeDateofBirth.Value = (DateTime)dr[3];
                    txtPEFatherName.Text = dr[4].ToString();
                    txtPENid.Text = dr[6].ToString();
                    txtPEPhone.Text = dr[7].ToString();
                    txtPEEmail.Text = dr[8].ToString();
                    txtPESocialId.Text = dr[9].ToString();
                    PEcomboBoxMstatus.Text = dr[10].ToString();
                    PEdateTimeJoinDate.Value = (DateTime)dr[11];
                    byte[] img = (byte[])(dr[12]);
                    if (img == null)
                    {
                        PEpicShow.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        PEpicShow.Image = Image.FromStream(ms);
                    }
                    comboBoxPEId.Text = dr[13].ToString();
                    comboBox2PEid.Text = dr[14].ToString();
                    if (dr[5].ToString() == "Male")
                    {
                        rdMale.Checked = true;


                    }
                    else if (dr[5].ToString() == "Female")
                    {
                        rdFemale.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("There are no records");

                    }
                    c.con.Close();
                }
                
                else
                {
                    MessageBox.Show("Data Not Found !!!\n Proide Correct ID", "Searching", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                c.con.Close();
            }
        }
        private void picU_Click(object sender, EventArgs e)
        {
            
             try
             {
                 c.con.Open();
                 byte[] img = null;
                 FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                 BinaryReader br = new BinaryReader(fs);
                 img = br.ReadBytes((int)fs.Length);
                 SqlCommand cmd = new SqlCommand("UPDATE tblEpersonla SET eImage=@Img WHERE eId=@mid", c.con);
                 cmd.CommandType = CommandType.Text;
                 cmd.Parameters.AddWithValue("@mid", txid.Text.Trim());
                 cmd.Parameters.AddWithValue("@Img", img);
                 cmd.ExecuteNonQuery();
                 tabPersonal_info_load();
                c.con.Close();
                MessageBox.Show("Picture Updated Successful!!");
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
                 c.con.Close();
             }
            

        } 

        private void btnPEupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdMale.Checked == true)
                {
                    gnd = "Male";
                }
                else if (rdFemale.Checked == true)
                {
                    gnd = "Female";
                }
                else
                {
                    MessageBox.Show("Can't Select Gender!!");
                }
                c.con.Open();
                //byte[] img = null;
                //FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                //BinaryReader br = new BinaryReader(fs);
                //img = br.ReadBytes((int)fs.Length);
           
                SqlCommand cmd = new SqlCommand("UPDATE tblEpersonla SET eTitle=@Title,eName=@Name,eDob=@Dateofbirth,eFatherName=@FatherName,eGender=@Gender,eNationalIdNo=@Nid,ePhoneNo=@Phone,eEmail=@Email,eSocialId=@SocialId,eMeritals=@MaritalS,eJoinDate=@Joindate,eaId=@Acid,eoId=@Ofid WHERE eId=@mid", c.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@mid", txid.Text.Trim());

                cmd.Parameters.AddWithValue("@Title", PEcomboBoxTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", txtPEName.Text.Trim());
                cmd.Parameters.AddWithValue("@Dateofbirth", PEdateTimeDateofBirth.Value);
                cmd.Parameters.AddWithValue("@FatherName", txtPEFatherName.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", gnd);
                cmd.Parameters.AddWithValue("@Nid", txtPENid.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", txtPEPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtPEEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@SocialId", txtPESocialId.Text.Trim());
                cmd.Parameters.AddWithValue("@MaritalS", PEcomboBoxMstatus.Text.Trim());
                cmd.Parameters.AddWithValue("@Joindate", PEdateTimeJoinDate.Value);
                //cmd.Parameters.AddWithValue("@Img", img);
                cmd.Parameters.AddWithValue("@Acid", comboBoxPEId.Text.Trim());
                cmd.Parameters.AddWithValue("@Ofid", comboBox2PEid.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Update Successfully");
                tabPersonal_info_load();
                PEallclearbox(); 
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

        private void btnPEdelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    c.con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblEpersonla WHERE eId=@ID", c.con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", txid.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabPersonal_info_load();
                    PEallclearbox();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtaid.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txtOfid.Visible = true;
            pictureBoxofshow.Visible = false;
        }

        private void txtPENid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(label30, "Allow Only Number Values!!!");
                label30.Text = "Allow Only Number Values!!!";
            }
            else
            {
                errorProvider1.SetError(label30, "");
                label30.Text = "";
            }
        }
    }
}
