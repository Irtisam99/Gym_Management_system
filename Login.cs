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

namespace Gym_Management_system
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False");

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter DA = new SqlDataAdapter();
        private void button1_Click(object sender, EventArgs e)


        {

            con.Open();


            string login = "SELECT * FROM admin WHERE admin_name= '" + txtadmin.Text + "' and pass='" + txtpassword.Text + "'";
            cmd = new SqlCommand(login, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {

                Administration ad= new Administration(txtadmin.Text);    
                ad.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Invalid Username or Password,Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtadmin.Text = "";
                txtpassword.Text = "";
                txtadmin.Focus();
            }
            con.Close();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Userlogin userlogin = new Userlogin();  
            userlogin.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
