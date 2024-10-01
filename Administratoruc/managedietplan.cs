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
    public partial class managedietplan : UserControl
    {
        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
        public managedietplan()
        {
            InitializeComponent();
            InitializeDietPlanGrid();
        }
        private void InitializeDietPlanGrid()
        {
            // Clear existing columns
            dgvDietPlan.Columns.Clear();

            // Add ComboBox for DayOfWeek
            DataGridViewComboBoxColumn dayColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Day of Week",
                Name = "DayOfWeek",
                DataSource = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" },
                FlatStyle = FlatStyle.Flat
            };
            dgvDietPlan.Columns.Add(dayColumn);

            // Add other columns
            dgvDietPlan.Columns.Add("Breakfast", "Breakfast");
            dgvDietPlan.Columns.Add("Lunch", "Lunch");
            dgvDietPlan.Columns.Add("Dinner", "Dinner");
            dgvDietPlan.Columns.Add("Snacks", "Snacks");

            // Prevent adding more than 7 rows
            dgvDietPlan.AllowUserToAddRows = false;

            // Populate rows with days of the week
            foreach (var day in new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" })
            {
                dgvDietPlan.Rows.Add(day, "", "", "", "");
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerID.Text.Trim(), out int customerId))
            {
                MessageBox.Show("Please enter a valid Customer ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsCustomerExists(customerId))
            {
                MessageBox.Show("Customer ID does not exist.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Collect diet plan details
            var dietPlanDetails = new List<DietPlanDetail>();
            foreach (DataGridViewRow row in dgvDietPlan.Rows)
            {
                if (row.IsNewRow) continue;

                string day = row.Cells["DayOfWeek"].Value?.ToString();
                string breakfast = row.Cells["Breakfast"].Value?.ToString() ?? "";
                string lunch = row.Cells["Lunch"].Value?.ToString() ?? "";
                string dinner = row.Cells["Dinner"].Value?.ToString() ?? "";
                string snacks = row.Cells["Snacks"].Value?.ToString() ?? "";

                dietPlanDetails.Add(new DietPlanDetail
                {
                    DayOfWeek = day,
                    Breakfast = breakfast,
                    Lunch = lunch,
                    Dinner = dinner,
                    Snacks = snacks
                });
            }

            if (dietPlanDetails.Count != 7)
            {
                MessageBox.Show("Please enter diet details for all 7 days.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save to database
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        // Insert into DietPlans
                        string insertDietPlanQuery = @"INSERT INTO DietPlans (MID) 
                                                   VALUES (@MID);
                                                   SELECT CAST(SCOPE_IDENTITY() AS INT);";
                        SqlCommand cmdDietPlan = new SqlCommand(insertDietPlanQuery, conn, transaction);
                        cmdDietPlan.Parameters.AddWithValue("@MID", customerId);
                        int dietPlanId = (int)cmdDietPlan.ExecuteScalar();

                        // Insert into DietPlanDetails
                        string insertDietPlanDetailQuery = @"INSERT INTO DietPlanDetails 
                                                         (DietPlanID, DayOfWeek, Breakfast, Lunch, Dinner, Snacks) 
                                                         VALUES 
                                                         (@DietPlanID, @DayOfWeek, @Breakfast, @Lunch, @Dinner, @Snacks)";
                        SqlCommand cmdDietPlanDetail = new SqlCommand(insertDietPlanDetailQuery, conn, transaction);
                        cmdDietPlanDetail.Parameters.Add("@DietPlanID", SqlDbType.Int).Value = dietPlanId;
                        cmdDietPlanDetail.Parameters.Add("@DayOfWeek", SqlDbType.VarChar, 10);
                        cmdDietPlanDetail.Parameters.Add("@Breakfast", SqlDbType.NVarChar, 500);
                        cmdDietPlanDetail.Parameters.Add("@Lunch", SqlDbType.NVarChar, 500);
                        cmdDietPlanDetail.Parameters.Add("@Dinner", SqlDbType.NVarChar, 500);
                        cmdDietPlanDetail.Parameters.Add("@Snacks", SqlDbType.NVarChar, 500);

                        foreach (var detail in dietPlanDetails)
                        {
                            cmdDietPlanDetail.Parameters["@DayOfWeek"].Value = detail.DayOfWeek;
                            cmdDietPlanDetail.Parameters["@Breakfast"].Value = detail.Breakfast;
                            cmdDietPlanDetail.Parameters["@Lunch"].Value = detail.Lunch;
                            cmdDietPlanDetail.Parameters["@Dinner"].Value = detail.Dinner;
                            cmdDietPlanDetail.Parameters["@Snacks"].Value = detail.Snacks;

                            cmdDietPlanDetail.ExecuteNonQuery();
                        }

                        // Commit transaction
                        transaction.Commit();
                    }
                }

                MessageBox.Show("7-Day Diet Plan has been saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, clear the form or close
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the diet plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsCustomerExists(int customerId)
        {
            string query = "SELECT COUNT(1) FROM NewMember WHERE MID = @MID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MID", customerId);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void managedietplan_Load(object sender, EventArgs e)
        {

        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    public class DietPlanDetail
    {
        public string DayOfWeek { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public string Snacks { get; set; }
    }
