using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_system.MemberUC
{
    public partial class ManageProfile : UserControl
    {

        function fn = new function();
        String query;

        public ManageProfile()
        {
            InitializeComponent();
        }

        public string ID
        {
            set { label1.Text = value; }
        }
        


        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        
        private void labelProfile_Click(object sender, EventArgs e)
        {

        }

        private void ManageProfile_Load(object sender, EventArgs e)
        {

        }

        private void ManageProfile_Enter(object sender, EventArgs e)
        {

            query = "select * from NewMember where Fname= '" + label1.Text + "'";
            DataSet ds = fn.getData(query);
            guna2Comboprofileuser.Text= ds.Tables[0].Rows[0][11].ToString();
            guna2Textfirst.Text = ds.Tables[0].Rows[0][1].ToString();
            guna2Textlastname.Text = ds.Tables[0].Rows[0][2].ToString();

          
           guna2DateTimePickerdob.Text = ds.Tables[0].Rows[0][4].ToString();
            guna2Textmobile.Text = ds.Tables[0].Rows[0][5].ToString();
            guna2Textemail.Text = ds.Tables[0].Rows[0][6].ToString();

            
            
            guna2ComboBoxgymtime.Text = ds.Tables[0].Rows[0][8].ToString();
           richTextBoxaddress.Text = ds.Tables[0].Rows[0][9].ToString();
           

            guna2TextBoxpassuser.Text = ds.Tables[0].Rows[0][12].ToString();



        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ManageProfile_Enter(this, null);
        }
        private void guna2Button1_Click(object sender, EventArgs e)

        {
            String role = guna2Comboprofileuser.Text;
            String fname = guna2Textfirst.Text;
            String lname = guna2Textlastname.Text;
            String DOB = guna2DateTimePickerdob.Text;
            Int64 mobile = Int64.Parse(guna2Textmobile.Text);
            String email = guna2Textemail.Text;
            String gymtim = guna2ComboBoxgymtime.Text;
            String address = richTextBoxaddress.Text;
            String pass = guna2TextBoxpassuser.Text;

            query = "update NewMember set Lname='" + lname + "',Dob = '" + DOB + "',Mobile = '" + mobile + "',Email = '" + email + "',Gymtime = '" + gymtim + "',Maddress = '" + address + "',password = '" + pass + "',userRole = '" + role + "' where Fname= '" + fname + "'";
            fn.setData(query, "profile updation successful.");
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBoxpassuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
