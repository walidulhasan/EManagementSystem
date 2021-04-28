using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace EManagementSystem
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer palyer = new WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            palyer.URL = "welcome.wav";
        }
        int startpoing = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoing += 1;
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
            palyer.controls.play();
            timer1.Start();
        }
    }
}
