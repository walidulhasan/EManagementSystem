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
    public partial class frmEmployeePage : Form
    {
        public Point mouseLocation; //part of Mouse drag and droup
        public frmEmployeePage()
        {
            InitializeComponent();
        }
        #region Home Button
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Exit application
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region For Child Form Load
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        private void btnNewData_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCEPnewdata());
        }

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            openChildForm(new frmModify());
        }

        private void btnverification_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCEPsearching());

        }

        private void btnlawPolicy_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Page Does not Work!!!!\nSystem UPGRADING","Working",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
            openChildForm(new frmCEPbranch());
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCEPabout());
        }
    }
}
