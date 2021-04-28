using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EManagementSystem
{
    public partial class frmReportForm : Form
    {
        public frmReportForm()
        {
            InitializeComponent();
        }

        private void branchJonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //jodays jd = new jodays();
            //jd.MdiParent = this;
            //jd.Show();
        }

        private void salaryRpeortInMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            rpMsalary ms = new rpMsalary();
            ms.MdiParent = this;
            ms.Show();
        }

        private void employeeSalaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            AllSalaryReports sr = new AllSalaryReports();
            sr.MdiParent = this;
            sr.Show();
        }

        private void salaryReportIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            frmCEPsearching iv = new frmCEPsearching();
            iv.MdiParent = this;
            iv.Show();
        }
    }
}
