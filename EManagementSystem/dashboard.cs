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
    public partial class frmdashboard : Form
    {
        public Point mouseLocation; //part of Mouse drag and droup
        public frmdashboard()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #region mouse drag and droup
        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
        #endregion

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin log = new frmLogin();
            log.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are Now in HOME !!!!","HOME",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            
            frmComInfo cinfo = new frmComInfo();
            cinfo.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmEmployeePage emp = new frmEmployeePage();
            emp.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmReportForm rf = new frmReportForm();
            rf.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            frmAbout fa = new frmAbout();
            fa.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmview fv = new frmview();
            fv.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            frmNotice no = new frmNotice();
            no.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            frmCEPsearching ser = new frmCEPsearching();
            ser.Show();
        }

        private void picSalary_Click(object sender, EventArgs e)
        {
            frmSalary sa = new frmSalary();
            sa.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmBLocation lo = new frmBLocation();
            lo.Show();
        }
    }
}
