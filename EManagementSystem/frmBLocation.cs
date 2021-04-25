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
    public partial class frmBLocation : Form
    {
        public frmBLocation()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtState.Text == "" && txtCity.Text == "" && txtStreet.Text == "")
                {
                    MessageBox.Show("You can't search Empty textbox", "Search Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    panel1.Visible = false;

                    string street = txtStreet.Text;
                    string city = txtCity.Text;
                    string state = txtState.Text;
                    string zipCode = txtZip.Text;
                    StringBuilder qyarrtAddress = new StringBuilder();
                    qyarrtAddress.Append("https://maps.google.com/maps?q=");
                    if (street != string.Empty)
                    {
                        qyarrtAddress.Append(street + "," + "+");
                    }
                    //else
                    //{
                    //    MessageBox.Show("Street is Empty");
                    //}
                    if (city != string.Empty)
                    {
                        qyarrtAddress.Append(city + "," + "+");
                    }
                    if (state != string.Empty)
                    {
                        qyarrtAddress.Append(state + "," + "+");
                    }
                    if (zipCode != string.Empty)
                    {
                        qyarrtAddress.Append(zipCode + "," + "+");
                    }
                    webBrowser1.Navigate(qyarrtAddress.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
        public Point mouseLocation;
        private void mouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
