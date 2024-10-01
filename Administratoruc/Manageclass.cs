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
    public partial class Manageclass : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False"; 
        private DataTable dataTable;
        private SqlDataAdapter dataAdapter;
        public Manageclass()
        {
            InitializeComponent();
            LoadClasses();
        }

        private void LoadClasses()
        {
            string query = "SELECT * FROM Classes";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    dataAdapter = new SqlDataAdapter(query, conn);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridViewClasses.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading classes: " + ex.Message);
                }
            }
        }
        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Manageclass_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Classes (ClassName, SID, DateTime) VALUES (@ClassName, @SID, @DateTime)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClassName", txtClassName.Text);
                    cmd.Parameters.AddWithValue("@SID", txtTrainerID.Text);
                    cmd.Parameters.AddWithValue("@DateTime", dtpClassTime.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Class added successfully!");
                    LoadClasses();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding class: " + ex.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClassID.Text))
            {
                MessageBox.Show("Please select a class to update.");
                return;
            }

            string query = "UPDATE Classes SET ClassName=@ClassName, SID=@SID, DateTime=@DateTime WHERE ClassID=@ClassID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClassID", txtClassID.Text);
                    cmd.Parameters.AddWithValue("@ClassName", txtClassName.Text);
                    cmd.Parameters.AddWithValue("@SID", txtTrainerID.Text);
                    cmd.Parameters.AddWithValue("@DateTime", dtpClassTime.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Class updated successfully!");
                    LoadClasses();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating class: " + ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClassID.Text))
            {
                MessageBox.Show("Please select a class to delete.");
                return;
            }

            string query = "DELETE FROM Classes WHERE ClassID=@ClassID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClassID", txtClassID.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Class deleted successfully!");
                    LoadClasses();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting class: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
        private void ClearInputs()
        {
            txtClassID.Text = "";
            txtClassName.Text = "";
            txtTrainerID.Text = "";
            dtpClassTime.Value = DateTime.Now;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

