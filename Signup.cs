using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Reflection;
using System.Xml.Linq;
using System.Web.Security;

namespace Gym_Management_system
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False");
       
            SqlCommand cmd = new SqlCommand();
        SqlDataAdapter DA = new SqlDataAdapter();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxshowpass.Checked)
            {
                guna2TextBoxpassuser.PasswordChar = '\0';
                guna2confirmpass.PasswordChar = '\0';
            }
            else
            {
                guna2TextBoxpassuser.PasswordChar = '•';
                guna2confirmpass.PasswordChar = '•';
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)


        {

            String fname = guna2Textfname.Text;
            String lname =guna2Textlname.Text;



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

            String dob = guna2DateTimePickerdob.Text;
            Int64 mobile = Int64.Parse(guna2Textmobile.Text);
            String email = guna2Textemail.Text;
            String joindate = guna2DateTimePickerdatejoin.Text;
            String gymtime = guna2ComboBoxgymtime.Text;
            String address = richTextBoxaddress.Text;
            String membership = guna2ComboBoxmembershiptime.Text;
            String userrole = guna2ComboBoxuser.Text;
            String password = guna2TextBoxpassuser.Text;



            if (guna2ComboBoxuser.Text == "" && guna2TextBoxpassuser.Text =="" && guna2confirmpass.Text== "" )
            {
                MessageBox.Show("Username and passwords fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (guna2TextBoxpassuser.Text == guna2confirmpass.Text)
            {
                con.Open();
                string register = "insert into NewMember (Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,Gymtime,Maddress,MembershipTime,userRole,password) values ('" + fname + "','" + lname + "', '" + gender + "', '" + dob + "', '" + mobile + "', '" + email + "', '" + joindate + "', '" + gymtime + "', '" + address + "', '" + membership + "','" + userrole + "','" + password + "')";
                cmd = new SqlCommand(register,con); 
                cmd.ExecuteNonQuery();
                con.Close();

                guna2ComboBoxuser.Text = "";
                guna2TextBoxpassuser.Text = "";
                guna2confirmpass.Text = "";


                MessageBox.Show("Your account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Passwords do not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBoxuser.Text = "";
                guna2confirmpass.Text = "";
                guna2TextBoxpassuser.Focus();
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

           
           
            guna2ComboBoxuser.Text = "";
            guna2TextBoxpassuser.Text = "";
            guna2confirmpass.Text = "";
            guna2ComboBoxuser.Focus();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Userlogin().Show();
            this.Hide();    
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DateTimePickerdob_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2confirmpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
