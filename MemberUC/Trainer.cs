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

namespace Gym_Management_system.MemberUC
{
    public partial class Trainer : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
        public Trainer()
        {
            InitializeComponent();
            LoadTrainers();
        }
        private void LoadTrainers()
        {

           
            DataTable dt = new DataTable();
            string query = "SELECT SID, Fname,Lname,Gender, Mobile,Email,Statee,City,CASE WHEN Availability=1 THEN 'Available' ELSE 'Booked' END AS Availability FROM NewStaff";
          
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                   // DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the DataGridView to the DataTable
                
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading trainers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dataTrainer.DataSource = dt;
            if (dataTrainer.Columns["BookButton"]==null)
            {
               DataGridViewButtonColumn btnBook=new DataGridViewButtonColumn();
                btnBook.Name = "BookButton";
                btnBook.HeaderText = "Book Trainer";
                btnBook.Text = "Book";
                btnBook.UseColumnTextForButtonValue = true; 
                dataTrainer.Columns.Add(btnBook);

            }


        }
                private void Trainer_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            LoadTrainers();
        }

        private void dataGridViewTrainers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataTrainer.Columns[e.ColumnIndex].Name == "BookButton" && e.RowIndex >= 0)
            {
               
                int trainerID = Convert.ToInt32(dataTrainer.Rows[e.RowIndex].Cells["SID"].Value);

              
                string availabilityStatus = dataTrainer.Rows[e.RowIndex].Cells["SID"].Value.ToString();
                if (availabilityStatus == "Booked")
                {
                    MessageBox.Show("This trainer is already booked.");
                    return;
                }

                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE NewStaff SET Availability = 0 WHERE SID = @SID";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@SID", trainerID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Show a confirmation message
                MessageBox.Show("Trainer booked successfully!");

                // Refresh the trainer list after booking
                LoadTrainers();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
