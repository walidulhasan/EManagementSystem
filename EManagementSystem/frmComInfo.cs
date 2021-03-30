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
    public partial class frmComInfo : Form
    {

        public frmComInfo()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            frmdashboard dsb = new frmdashboard();
            dsb.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(uccIpage11);
            bunifuTransition1.ShowSync(uccIpage1);
            bunifuTransition1.HideSync(ucclpageM1);
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(uccIpage11);
            bunifuTransition1.HideSync(uccIpage1);
            bunifuTransition2.ShowSync(ucclpageM1);
        }

        private void btnOffice_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(uccIpage11);
            bunifuTransition3.ShowSync(uccIpage1);
            bunifuTransition1.HideSync(ucclpageM1);
        }

        private void btnTechNo_Click(object sender, EventArgs e)
        {
            bunifuTransition3.HideSync(uccIpage1);
            bunifuTransition2.ShowSync(uccIpage11);
            bunifuTransition2.HideSync(ucclpageM1);
        }

        private void btnFramwork_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(uccIpage11);
            bunifuTransition1.ShowSync(uccIpage1);
            bunifuTransition1.HideSync(ucclpageM1);
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(uccIpage11);
            bunifuTransition1.HideSync(uccIpage1);
            bunifuTransition2.ShowSync(ucclpageM1);
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            bunifuTransition3.ShowSync(uccIpage11);
            bunifuTransition1.HideSync(uccIpage1);
            bunifuTransition1.HideSync(ucclpageM1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
