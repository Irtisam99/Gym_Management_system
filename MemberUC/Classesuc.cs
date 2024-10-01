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

namespace Gym_Management_system.MemberUC
{
    public partial class Classesuc : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

       
       

        public Classesuc()
        {
            InitializeComponent();
            LoadAvailableClasses();
        }
      

       


        private void LoadAvailableClasses()
        {
            string query = "SELECT ClassID, ClassName, SID, DateTime FROM Classes";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    dataAdapter = new SqlDataAdapter(query, conn);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridViewClasses.DataSource = dataTable;

                    // Optional: Adjust DataGridView columns for better display
                    dataGridViewClasses.Columns["ClassID"].HeaderText = "Class ID";
                    dataGridViewClasses.Columns["ClassName"].HeaderText = "Class Name";
                    dataGridViewClasses.Columns["SID"].HeaderText = "Trainer ID";
                    dataGridViewClasses.Columns["DateTime"].HeaderText = "Date & Time";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading classes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Classesuc_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtClassName.Text) ||
                string.IsNullOrWhiteSpace(txtTrainerID.Text))
            {
                MessageBox.Show("Please enter both Class Name and Trainer ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO Classes (ClassName, SID, DateTime) VALUES (@ClassName, @SID, @DateTime)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClassName", txtClassName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SID", int.Parse(txtTrainerID.Text.Trim()));
                    cmd.Parameters.AddWithValue("@DateTime", dtpClassTime.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Class added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAvailableClasses();
                    ClearInputFields();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Trainer ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding class: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClassID.Text) ||
                string.IsNullOrWhiteSpace(txtClassName.Text) ||
                string.IsNullOrWhiteSpace(txtTrainerID.Text))
            {
                MessageBox.Show("Please select a class and enter Class Name and Trainer ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Classes SET ClassName = @ClassName, SID = @SID, DateTime = @DateTime WHERE ClassID = @ClassID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClassID", int.Parse(txtClassID.Text.Trim()));
                    cmd.Parameters.AddWithValue("@ClassName", txtClassName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SID", int.Parse(txtTrainerID.Text.Trim()));
                    cmd.Parameters.AddWithValue("@DateTime", dtpClassTime.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Class updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAvailableClasses();
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("No class found with the provided Class ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Class ID and Trainer ID must be valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating class: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtClassID.Text))
            {
                MessageBox.Show("Please select a class to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this class?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            string query = "DELETE FROM Classes WHERE ClassID = @ClassID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClassID", int.Parse(txtClassID.Text.Trim()));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Class deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAvailableClasses();
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("No class found with the provided Class ID.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Class ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting class: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
        }
            private void ClearInputFields()
            {
                txtClassID.Text = "";
                txtClassName.Text = "";
                txtTrainerID.Text = "";
                dtpClassTime.Value = DateTime.Now;
            }

        private void dataGridViewClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewClasses.Rows.Count)
            {
                DataGridViewRow row = dataGridViewClasses.Rows[e.RowIndex];
                txtClassID.Text = row.Cells["ClassID"].Value.ToString();
                txtClassName.Text = row.Cells["ClassName"].Value.ToString();
                txtTrainerID.Text = row.Cells["SID"].Value.ToString();
                dtpClassTime.Value = Convert.ToDateTime(row.Cells["DateTime"].Value);
            }
        }

       

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewClasses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a class to book.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewClasses.SelectedRows[0];
            int selectedClassID = Convert.ToInt32(selectedRow.Cells["ClassID"].Value);

            string query = "INSERT INTO ClassBookings (ClassID, BookingDate) VALUES (@ClassID, @BookingDate)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClassID", selectedClassID);
                    cmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Class booked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error booking class: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
