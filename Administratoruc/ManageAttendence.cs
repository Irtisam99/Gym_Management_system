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
    public partial class ManageAttendence : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
        public ManageAttendence()
        {
            InitializeComponent();
            LoadAttendance();
        }
        private void LoadAttendance(DateTime? startDate = null, DateTime? endDate = null)
        {
            string query = "SELECT * FROM Attendance";

            if (startDate.HasValue && endDate.HasValue)
            {
                query += " WHERE Date BETWEEN @StartDate AND @EndDate";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (startDate.HasValue && endDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewAttendance.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManageAttendence_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadAttendance(dtpStartDate.Value, dtpEndDate.Value);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewAttendance.SelectedRows.Count > 0)
            {
                int attendanceID = Convert.ToInt32(dataGridViewAttendance.SelectedRows[0].Cells["AttendanceID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Attendance WHERE AttendanceID = @AttendanceID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AttendanceID", attendanceID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record deleted successfully!");
                    LoadAttendance();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a row is selected
            {
                DataGridViewRow row = this.dataGridViewAttendance.Rows[e.RowIndex];
                txtAttendanceID.Text = row.Cells["AttendanceID"].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtAttendanceID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
