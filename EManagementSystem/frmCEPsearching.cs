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
    public partial class frmCEPsearching : Form
    {
        Connection c = new Connection();
        public frmCEPsearching()
        {
            InitializeComponent();
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tbldata_load()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT EP.eId AS 'Employee Id',EP.eName AS Name,EP.eDob AS 'Date of Brith',EP.eJoinDate AS 'Joining Date',EP.eGender AS Gender,EP.eEmail AS Email,FO.eoPresPosition AS 'Post Position',AC.eaMast AS 'Education',BR.bNameCode AS 'Branch Name Code',SA.Cut_from_GrossSalary,SA.grossSalary FROM tblEpersonla EP 
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
                string comdtext = @"SET CONCAT_NULL_YIELDS_NULL OFF SELECT EP.eId AS 'Employee Id',EP.eName AS Name,EP.eDob AS 'Date of Brith',EP.eJoinDate AS 'Joining Date',EP.eGender AS Gender,EP.eEmail AS Email,FO.eoPresPosition AS 'Post Position',AC.eaMast AS 'Education',BR.bNameCode AS 'Branch Name Code',SA.Cut_from_GrossSalary,SA.grossSalary FROM tblEpersonla EP 
                INNER JOIN tblAcademic AC ON EP.eaId = AC.eaId
                INNER JOIN tblOfficial FO ON EP.eoId = FO.eoId
                INNER JOIN tblESalary SA ON EP.eId = SA.eId
                INNER JOIN tblBranch BR ON FO.bId = BR.bId where EP.eId='" + txtidsearch.Text + "' SET CONCAT_NULL_YIELDS_NULL ON";
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
            tbldata_load();
        }
    }
}
