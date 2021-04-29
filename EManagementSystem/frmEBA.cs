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
    public partial class frmEBA : Form
    {
        Connection c = new Connection();
        public frmEBA()
        {
            InitializeComponent();
        }

        private void frmEBA_Load(object sender, EventArgs e)
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

            SqlCommand cmd = new SqlCommand(@"SELECT  EP.eId AS 'Employee Id',AC.eaId AS 'Academic ID',FO.eoId AS 'Official ID',EP.eTitle AS Title,EP.eName AS Name,EP.eDob AS 'Date of Birth',EP.eFatherName AS 'Father Name',EP.eGender AS Gender,EP.ePhoneNo AS 'Phone No',EP.eNationalIdNo AS 'National ID',EP.eEmail AS Email,EP.eSocialId AS 'Social Id',EP.eMeritals AS 'Merital Status',
             EP.eJoinDate AS 'Join Date',EP.eImage AS 'Image',FO.eoPresPosition AS Position,FO.eoPrePosition AS 'Previous Position',AC.eaMast AS 'Academic Exam',AC.Mast_result AS 'Result',AC.eaSpecial AS 'Special Exam',AC.Special_result AS Result,BR.bNameCode AS 'Branch Code' FROM tblEpersonla EP 
            INNER JOIN tblAcademic AC ON EP.eaId=AC.eaId
            INNER JOIN tblOfficial FO ON EP.eoId=FO.eoId
             INNER JOIN tblBranch BR ON FO.bId=BR.bId");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dtview.DataSource = dt;

        }
    }
}
