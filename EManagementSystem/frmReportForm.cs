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
            jodays jd = new jodays();
            jd.MdiParent = this;
            jd.Show();
        }

        private void salaryRpeortInMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalaryReportMonth srm = new frmSalaryReportMonth();
            srm.MdiParent = this;
            srm.Show();
        }

        private void employeeSalaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeSalaryReportForm emp = new frmEmployeeSalaryReportForm();
            emp.MdiParent = this;
            emp.Show();
        }

        private void salaryReportIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmIndividualsreport isr = new fmIndividualsreport();
            isr.MdiParent = this;
            isr.Show();
        }
    }
}
