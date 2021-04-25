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
    public partial class frmview : Form
    {
        Connection c = new Connection();
        public frmview()
        {
            InitializeComponent();
            allDataShow();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Point mouseLocation; //part of Mouse drag and droup
        private void mousedown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mousemove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
        private void allDataShow()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT  EP.eId AS 'Employee Id',EP.eTitle AS Title,EP.eName AS Name,EP.eDob AS 'Date of Birth',EP.eFatherName AS 'Father Name',EP.eGender AS Gender,EP.ePhoneNo AS 'Phone No',EP.eNationalIdNo AS 'National ID',EP.eEmail AS Email,EP.eSocialId AS 'Social Id',EP.eMeritals AS 'Merital Status',
            EP.eJoinDate AS 'Join Date',EP.eImage AS 'Image',FO.eoPresPosition AS Position,FO.eoPrePosition AS 'Previous Position',AC.eaMast AS 'Academic Exam',AC.Mast_result AS 'Result',AC.eaSpecial AS 'Special Exam',AC.Special_result AS Result,BR.bNameCode AS 'Branch Code',SA.basicPay AS 'Salary Basic',
            SA.houseRent AS 'House Rent',SA.medicalAllowance AS 'Medical Allowance',SA.travle_allowance AS 'Travle Allowance',SA.childrenEallwanc AS 'Children Allowance'
            ,SA.grossSalary AS 'Gross Salary',SA.loan AS Load,SA.Gpf_Cpf AS 'GP Fund',SA.salaryDate AS 'Salary Date',SA.Cut_from_GrossSalary AS 'Cut From Salary',SA.Net_Salary_Paid AS 'Salary Paid'   FROM tblEpersonla EP 
            INNER JOIN tblAcademic AC ON EP.eaId=AC.eaId
            INNER JOIN tblOfficial FO ON EP.eoId=FO.eoId
            INNER JOIN tblESalary SA ON EP.eId=SA.eId
            INNER JOIN tblBranch BR ON FO.bId=BR.bId");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dtview.DataSource = dt;

        }

        private void frmview_Load(object sender, EventArgs e)
        {
            dtview.BorderStyle = BorderStyle.None;
            dtview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtview.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtview.BackgroundColor = Color.White;

            dtview.EnableHeadersVisualStyles = false;
            dtview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
