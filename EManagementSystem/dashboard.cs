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
            GC.Collect();
            timer.Stop();
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
            WindowState = FormWindowState.Minimized;
            frmComInfo cinfo = new frmComInfo();
            cinfo.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            frmEmployeePage emp = new frmEmployeePage();
            emp.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            frmReportForm rf = new frmReportForm();
            rf.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            frmAbout fa = new frmAbout();
            fa.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            frmview fv = new frmview();
            fv.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            frmNotice no = new frmNotice();
            no.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            frmCEPsearching ser = new frmCEPsearching();
            ser.Show();
        }

        private void picSalary_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            frmSalary sa = new frmSalary();
            sa.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            frmBLocation lo = new frmBLocation();
            lo.Show();
        }

        private void frmdashboard_Load(object sender, EventArgs e)
        {
            timer.Start();
            timer1.Start();
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            //lblSecond.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
            //lblSecond.Location = new Point(lblTime.Location.X + lblTime.Width - 5, lblSecond.Location.Y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label15.Right==0)
            {
                label15.Left = Width;
                label16.Left = Width;
            }
            else
            {
                label15.Left -= 1;
                label16.Left -= 1;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("I'm here for COVID19");
            label16.Visible = true;

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            MonthCalender moc = new MonthCalender();
            moc.Show();
        }
    }
}
