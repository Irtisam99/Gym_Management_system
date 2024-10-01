using Gym_Management_system.Administratoruc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_system
{
    public partial class Welcome1 : Form
    {
        public Welcome1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uchome1.Visible=true;
            uchome1.BringToFront(); 
        }

        private void Welcome1_Load(object sender, EventArgs e)
        {
            uchome1.Visible = false;
            aboutus1.Visible = false;
            vission1.Visible = false;
            mission1.Visible = false;   
            contact_US1.Visible = false;   
            buyproduct1.Visible = false;    

            guna2Button1.PerformClick();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            mission1.Visible=true;
            mission1.BringToFront();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            contact_US1.Visible=true;   
            contact_US1.BringToFront();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            vission1.Visible=true;  
            vission1.BringToFront();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            aboutus1.Visible=true;
            aboutus1.BringToFront();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uchome1_Load(object sender, EventArgs e)
        {

        }

        private void contact_US1_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            buyproduct1.Visible=true;
            buyproduct1.BringToFront(); 
        }

        private void buyproduct1_Load(object sender, EventArgs e)
        {

        }
    }
}
