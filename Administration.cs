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
    public partial class Administration : Form
    {
        public Administration()
        {
            InitializeComponent();
            
        }
        public Administration(String user)
        {
            InitializeComponent();
            userNameLabel.Text = user;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_dashboard1.Visible = true;
            uC_dashboard1.BringToFront();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
              
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uC_manage_user1.Visible= true;
            uC_manage_user1.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            uC_viewuser1.Visible= true;
            uC_viewuser1.BringToFront();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            addtrainer1.Visible = true;
            addtrainer1.BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            viewTrainer1.Visible = true;    
            viewTrainer1.BringToFront();    
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Login userlogin = new Login();
            userlogin.Show();
            this.Hide();    
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            uC_dashboard1.Visible = false;
            uC_manage_user1.Visible = false; 
           uC_viewuser1.Visible = false;    
            addtrainer1.Visible=false;  
            addAdmin1.Visible=false;   
            viewTrainer1.Visible=false;    
            addEquipment1.Visible=false;    
           viewEqui1.Visible=false;    
            manageclass1.Visible=false; 
            manageAttendence1.Visible=false;
            viewPayments1.Visible=false;   
            managedietplan1.Visible=false; 
            vieworder1.Visible=false;       
            btndashboard.PerformClick();
        }

        private void uC_viewuser1_Load(object sender, EventArgs e)
        {

        }

        private void uC_dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            addAdmin1.Visible=true;
           addAdmin1.BringToFront();
        }

        private void addAdmin1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            addEquipment1.Visible=true; 
            addEquipment1.BringToFront();   
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            viewEqui1.Visible=true;
            viewEqui1.BringToFront();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            manageclass1.Visible = true;
           manageclass1.BringToFront();
        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            manageAttendence1.Visible=true;
            manageAttendence1.BringToFront();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            ViewFeedback viewFeedback = new ViewFeedback(userNameLabel.Text);
            viewFeedback.Show();
            this.Hide();    
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            viewPayments1.Visible=true;
            viewPayments1.BringToFront();   
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            managedietplan1.Visible=true;
            managedietplan1.BringToFront();    
        }

        private void managedietplan1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            vieworder1.Visible=true;
            vieworder1.BringToFront(); 
        }
    }
}
