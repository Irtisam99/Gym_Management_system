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
    public partial class ViewFeedback : Form
    {
        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
        public ViewFeedback()
        {
            InitializeComponent();
            LoadFeedback();


        }
        private string username;
            
        public ViewFeedback(string user)
        {
            InitializeComponent();
            LoadFeedback();
            username = user;


        }

        private void LoadFeedback()
        {
            string query = @"
                SELECT f.FeedbackID, u.Fname, f.SID, f.FeedbackText, f.Date
                FROM Feedback f
                JOIN NewMember u ON f.MID = u.MID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewFeedback.DataSource = dt;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading feedback: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        


        private void ViewFeedback_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadFeedback();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Administration administration = new Administration(username);
            administration.Show();
            this.Hide();    
        }

        private void dataGridViewFeedback_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
