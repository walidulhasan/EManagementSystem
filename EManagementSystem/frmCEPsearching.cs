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
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace EManagementSystem
{
    public partial class frmCEPsearching : Form
    {
        Connection c = new Connection();
        public frmCEPsearching()
        {
            InitializeComponent();
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
            frmdashboard db = (frmdashboard)Application.OpenForms["frmdashboard"];
            db.WindowState = FormWindowState.Normal;
        }
        private void tbldata_load()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT SA.salaryId AS 'Salary Id',EP.eId AS 'Employee Id',EP.eName AS Name,EP.eDob AS 'Date of Brith',EP.eJoinDate AS 'Joining Date',EP.eGender AS Gender,EP.eEmail AS Email,FO.eoPresPosition AS 'Post Position',AC.eaMast AS 'Education',BR.bNameCode AS 'Branch Name Code',SA.Cut_from_GrossSalary,SA.grossSalary FROM tblEpersonla EP 
            INNER JOIN tblAcademic AC ON EP.eaId = AC.eaId
            INNER JOIN tblOfficial FO ON EP.eoId = FO.eoId
            INNER JOIN tblESalary SA ON EP.eId = SA.eId
            INNER JOIN tblBranch BR ON FO.bId = BR.bId");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void Searchresult()
        {
            try
            {
                string comdtext = @"SET CONCAT_NULL_YIELDS_NULL OFF SELECT SA.salaryId AS 'Salary ID',EP.eId AS 'Employee Id',EP.eName AS Name,EP.eDob AS 'Date of Brith',EP.eJoinDate AS 'Joining Date',EP.eGender AS Gender,EP.eEmail AS Email,FO.eoPresPosition AS 'Post Position',AC.eaMast AS 'Education',BR.bNameCode AS 'Branch Name Code',SA.Cut_from_GrossSalary,SA.grossSalary FROM tblEpersonla EP 
                INNER JOIN tblAcademic AC ON EP.eaId = AC.eaId
                INNER JOIN tblOfficial FO ON EP.eoId = FO.eoId
                INNER JOIN tblESalary SA ON EP.eId = SA.eId
                INNER JOIN tblBranch BR ON FO.bId = BR.bId where SA.salaryId='" + txtidsearch.Text + "' SET CONCAT_NULL_YIELDS_NULL ON";
                SqlDataAdapter sda = new SqlDataAdapter(comdtext, c.con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Text box need Employee ID",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void picsearch_Click(object sender, EventArgs e)
        {
            Searchresult();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtidsearch.Clear();
            tbldata_load();
        }

        private void frmCEPsearching_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        public Point mouseLocation; //part of Mouse drag and droup
        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            txtidsearch.Focus();
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    c.con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblESalary WHERE salaryId=@ID", c.con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", txtidsearch.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            //var c = new Choices();
            //var gb = new GrammarBuilder(c);
            //var g = new Grammar(gb);
            Grammar word = new DictationGrammar();

            sr.LoadGrammar(word);
            try
            {
                txtidsearch.Text = "Listening.......";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult result = sr.Recognize();
                txtidsearch.Clear();
                txtidsearch.Text = result.Text;
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                txtidsearch.Text = "";
                MessageBox.Show("Mic Not Found");
                MessageBox.Show(ex.Message);

            }
            finally
            {
                sr.UnloadAllGrammars();
            }


            //SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            //var c = new Choices();
            //for (var i = 0; i <= 100; i++)
            //    c.Add(i.ToString());
            //var gb = new GrammarBuilder(c);
            //var g = new Grammar(gb);
            //g.Priority = 127;
            //rec.SetInputToDefaultAudioDevice();

            //rec.LoadGrammar(g);
            //rec.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void txtidsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(label2, "Allow Only Number Values!!!");
                label2.Text = "Allow Only Number Values!!!";
            }
            else
            {
                errorProvider1.SetError(label2, "");
                label2.Text = "";
            }
        }
    }
}
