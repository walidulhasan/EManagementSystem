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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int startpoing = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoing += 2;
            progressbr.Value = startpoing;
            if (progressbr.Value == 100)
            {
                progressbr.Value = 0;
                timer1.Stop();
                frmLogin log = new frmLogin();
                this.Hide();
                log.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
