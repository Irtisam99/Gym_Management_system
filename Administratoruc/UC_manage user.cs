using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_system.Administratoruc
{
    public partial class UC_manage_user : UserControl
    {
        public UC_manage_user()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {   
            String fname = guna2Textfname.Text; 
            String lname =guna2Textlastname.Text;   
           
         

            String gender = "";
            bool isChecked = guna2RadioButton1.Checked;
            if (isChecked)
            {
                gender = guna2RadioButton1.Text;

            }
            else
            {
                gender = guna2RadioButton2.Text;
            }

            String dob =guna2DateTimePickerdob.Text;    
            Int64 mobile = Int64.Parse(guna2Textmobile.Text);
            String email = guna2Textemail.Text;
            String joindate = guna2DateTimePickerdatejoin.Text; 
            String gymtime = guna2ComboBoxgymtime.Text; 
            String address = richTextBoxaddress.Text;   
            String membership = guna2ComboBoxmembershiptime.Text;   
            String userrole= guna2ComboBox1.Text;    
            String password=guna2TextBoxpassuser.Text;  

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into NewMember (Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,Gymtime,Maddress,MembershipTime,userRole,password) values ('" + fname + "','" + lname + "', '" + gender + "', '" + dob + "', '" + mobile + "', '" + email + "', '" + joindate + "', '" + gymtime + "', '" + address + "', '" + membership+"','" +userrole+ "','"+password+ "')";
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("data saved");
        }

        private void UC_manage_user_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Textfname.Clear();
            guna2Textlastname.Clear();

            guna2RadioButton1.Checked = false;
            guna2RadioButton2.Checked = false;

            guna2Textmobile.Clear();
            guna2Textemail.Clear();

            guna2ComboBoxgymtime.ResetText();
            guna2ComboBoxmembershiptime.ResetText();
            richTextBoxaddress.Clear();

            guna2DateTimePickerdob.Value = DateTime.Now;
            guna2DateTimePickerdatejoin.Value = DateTime.Now;

            guna2ComboBox1.ResetText(); 
        }

        private void btnViewuser_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBoxpassuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Textemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePickerdatejoin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBoxgymtime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Textfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Textlastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePickerdob_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Textmobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBoxmembershiptime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
