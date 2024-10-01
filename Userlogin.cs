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

namespace Gym_Management_system
{
    public partial class Userlogin : Form
    {
        public Userlogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False");

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter DA = new SqlDataAdapter();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Userlogin_Load(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open(); 

            
            string login= "SELECT * FROM NewMember WHERE Fname= '" +guna2TextBox1.Text+"' and password='" + guna2TextBox2.Text + "'";
             cmd= new SqlCommand(login,con);
            SqlDataReader dr= cmd.ExecuteReader();
       
            if (dr.Read() == true)


            {
                
                Generalmember generalmember = new Generalmember(guna2TextBox1.Text);
               

                generalmember.Show();
               
                this.Hide();
            }
            else
            {

                MessageBox.Show("Invalid Username or Password,Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                guna2TextBox1.Focus();   
            }
            con.Close();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox1.Focus();
        }

        private void checkBoxshowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxshow.Checked)
            {
                guna2TextBox2.PasswordChar = '\0';
            }

            else
            {
                guna2TextBox2.PasswordChar = '•';
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
          new Signup().Show();  
            this .Hide();   
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ForgetPassword fp= new ForgetPassword();    

            this.Hide ();   
                fp.Show();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login login= new Login();   
            login.Show();   
            this.Hide();    

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2TextBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Welcome1 welcome1 = new Welcome1(); 
            welcome1.Show();
            this.Hide();
        }
    }
}
