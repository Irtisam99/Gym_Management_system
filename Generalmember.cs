using Gym_Management_system.MemberUC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace Gym_Management_system
{
    public partial class Generalmember : Form
    {
        private int userid;
        String user = "";
        public Generalmember()
        {
            InitializeComponent();
        }
      

        public string ID
        {
            get { return user.ToString(); }

        }
       


        public Generalmember(String hello)
        {
            InitializeComponent();
            labelmembername.Text = hello;
           user = hello;
            manageProfile1.ID = ID;
           

        }
      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            memberDasboard1.Visible=true;
            memberDasboard1.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            manageProfile1.Visible = true;
            manageProfile1.BringToFront();  
        }
        
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            classesuc1.Visible = true;
            classesuc1.BringToFront();
           
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            trainer1.Visible = true;

            trainer1.BringToFront();    
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Feedbackuser feedbackuser = new Feedbackuser(labelmembername.Text);
            feedbackuser.Show();
            this.Hide();
        }

        private void Generalmember_Load(object sender, EventArgs e)
        {

            memberDasboard1.Visible = false;
            manageProfile1.Visible=false;
            classesuc1.Visible=false;   
            trainer1.Visible=false; 
           
            guna2Btndashmember.PerformClick();  
            
        }

        private void labelmembername_Click(object sender, EventArgs e)
        {

        }

        private void manageProfile1_Load(object sender, EventArgs e)
        {

        }

        private void classesuc1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void attendence1_Load(object sender, EventArgs e)
        {

        }

        private void trainer1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Makepayment makepayment = new Makepayment(labelmembername.Text);    
            makepayment.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ViewDietplans viewDietplans = new ViewDietplans(labelmembername.Text);
            viewDietplans.Show();   
            this.Hide();    
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Userlogin userlogin = new Userlogin();
            userlogin.Show  (); 
            this.Hide();    
        }
    }
}
