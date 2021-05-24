using CrystalDecisions.CrystalReports.Engine;
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
using CrystalDecisions.Shared;

namespace EManagementSystem
{
    public partial class rpMsalary : Form
    {
        Connection c = new Connection();
        public rpMsalary()
        {
            InitializeComponent();
        }
        private void tblESalary_load()
        {
            SqlCommand cmd = new SqlCommand("SELECT salaryId AS ID,basicPay AS Basic,houseRent AS 'House Rent',medicalAllowance AS 'Medical Allowance',travle_allowance AS 'Travle Allowance',childrenEallwanc AS 'Children Allwance',grossSalary AS 'Gross Salary',loan AS Loan,Gpf_Cpf AS 'GPF or CPF',salaryDate AS 'Salary Date',eId AS 'Employee ID',Cut_from_GrossSalary AS 'Cut Salary',Net_Salary_Paid AS 'Pay Salary' FROM tblESalary");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dtview.DataSource = dt;
            label3.Text = "Total Records:" + dtview.RowCount;
        }

        private void rpMsalary_Load(object sender, EventArgs e)
        {
            tblESalary_load();
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

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = true;
            try
            {
                string comdtext = @"SELECT * FROM tblESalary WHERE salaryDate between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(comdtext, c.con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dtview.DataSource = ds.Tables[0];
                label4.Text = "Total Records:" + dtview.RowCount;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Text box need Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            tblESalary_load();
            label3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ReportDocument cryRpt = new ReportDocument();

            //cryRpt.Load(@"D:\Project\2.C#\Windows Form Application\EMS\EManagementSystem\Report\salarywithbonus.rpt");

            //crystalReportViewer1.ReportSource = cryRpt;

            //crystalReportViewer1.Refresh();

            //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ASD.pdf");

            //MessageBox.Show("Exported Successful");
        }
    }
}
