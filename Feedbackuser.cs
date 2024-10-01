using Gym_Management_system.MemberUC;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Feedbackuser : Form
    {

        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
        private string username; 

        public Feedbackuser()
        {
            InitializeComponent();
        }
        public Feedbackuser(String username)
        {
            InitializeComponent();
            this.username = username;
            labelfeed.Text = username;  



        }
        private int GetUserIDByUsername(string username)
        {
            string query = "SELECT MID FROM NewMember WHERE Fname = @Fname";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Fname", username);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
        }
        private void Feedbackuser_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFeedback.Text))
            {
                MessageBox.Show("Please enter your feedback.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int userID = GetUserIDByUsername(username);  // Get the user ID from the username

                string query = "INSERT INTO Feedback (MID, SID, FeedbackText, Date) VALUES (@MID, @SID, @FeedbackText, @Date)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MID", userID);
                    cmd.Parameters.AddWithValue("@SID", string.IsNullOrEmpty(txtTrainerID.Text) ? DBNull.Value : (object)txtTrainerID.Text);
                    cmd.Parameters.AddWithValue("@FeedbackText", txtFeedback.Text);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Feedback submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFeedback.Clear();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Generalmember generalmember = new Generalmember(labelfeed.Text);  
            generalmember.Show();
            this.Hide();    
        }

        private void txtFeedback_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelfeed_Click(object sender, EventArgs e)
        {

        }
    }
}


