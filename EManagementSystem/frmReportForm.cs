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

        private void employeeSalaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeSalaryReportForm esr = new frmEmployeeSalaryReportForm();
            esr.MdiParent = this;
            esr.Show();
        }

        private void branchJonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jodays jd = new jodays();
            jd.MdiParent = this;
            jd.Show();
        }
    }
}
