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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gym_Management_system
{
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False");
      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textchangepass1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query2 = "SELECT COUNT(*) FROM NewMember WHERE Fname = @Fname";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@Fname", textchangepass1.Text);

                int count = (int)cmd2.ExecuteScalar();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
               textchangepass1.Text != "" &&
               textchangepass2.Text != "" &&
               textchangepass3.Text != "")
            {
                string update = textchangepass1.Text;
                try
                {
                    con = new SqlConnection("Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False");
                    con.Open();

                    string query = "UPDATE NewMember SET password = @password WHERE Fname = @Fname";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@password", textchangepass3.Text);
                        cmd.Parameters.AddWithValue("@Fname", update);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Password updated!", "Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    this.Hide();
                    Userlogin userlogin = new Userlogin();
                    userlogin.Show();   
                }
            }
            else
            {
                //Anything other than fields are empty, can be a mix of empty and filled
                MessageBox.Show("Invalid Credentials!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void textchangepass3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textchangepass2.PasswordChar = '\0';
               textchangepass3.PasswordChar = '\0';
            }
            else
            {
                textchangepass2.PasswordChar = '•';
                textchangepass3.PasswordChar = '•';
            }
        }

        private void textchangepass2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Userlogin userlogin = new Userlogin();
            userlogin.Show();
            this.Hide();    
        }
    }
}

