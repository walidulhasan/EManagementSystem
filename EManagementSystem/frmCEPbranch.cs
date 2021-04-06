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
    public partial class frmCEPbranch : Form
    {
        public frmCEPbranch()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Branch code DEMO : BC01\n Branch Name: [District latter 2 / SubDistrict latter 2 with poition BC]","Demo of Data Entry",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("District Name:Bhola\n SubDistrict Name: Charfasson\n Address: Cf Bazar AbPlaza 6th f,R4,5,6", "Branch Location DEMO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            txtBaddress.Text = "";
            txtBcode.Text = "";
            txtBDname.Text = "";
            txtBname.Text = "";
            txtBSDname.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
