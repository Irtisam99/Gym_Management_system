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
using Gym_Management_system.MemberUC;
using Microsoft.VisualBasic.ApplicationServices;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gym_Management_system
{
   
    public partial class ViewDietplans : Form
    {
        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
        private string customerUsername; 
        private int customerId;  
        public ViewDietplans(string username)
        {
            InitializeComponent();
            dietmember.Text = username;
        
            this.customerUsername = username;

            // Fetch CustomerID using Username
            this.customerId = GetCustomerIdByUsername();

            if (customerId > 0)
            {
                LoadDietPlan();
            }
            else
            {
                MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private int GetCustomerIdByUsername()
        {
            int customerId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT MID FROM NewMember WHERE Fname = @Fname";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Fname", customerUsername);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            customerId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("No customer found with this username.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching customer ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return customerId;
        }
        private void LoadDietPlan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Fetch the latest DietPlanID for the customer
                    string getDietPlanIdQuery = @"SELECT TOP 1 DietPlanID 
                                             FROM DietPlans 
                                             WHERE MID = @MID 
                                             ORDER BY DateCreated DESC";

                    int dietPlanId = 0;
                    using (SqlCommand cmd = new SqlCommand(getDietPlanIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MID", customerId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            dietPlanId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("No diet plan found for this customer.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Fetch DietPlanDetails
                    string getDietPlanDetailsQuery = @"SELECT DayOfWeek, Breakfast, Lunch, Dinner, Snacks 
                                                   FROM DietPlanDetails 
                                                   WHERE DietPlanID = @DietPlanID 
                                                   ORDER BY 
                                                       CASE 
                                                           WHEN DayOfWeek = 'Monday' THEN 1
                                                           WHEN DayOfWeek = 'Tuesday' THEN 2
                                                           WHEN DayOfWeek = 'Wednesday' THEN 3
                                                           WHEN DayOfWeek = 'Thursday' THEN 4
                                                           WHEN DayOfWeek = 'Friday' THEN 5
                                                           WHEN DayOfWeek = 'Saturday' THEN 6
                                                           WHEN DayOfWeek = 'Sunday' THEN 7
                                                       END";

                    DataTable dietPlanTable = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(getDietPlanDetailsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@DietPlanID", dietPlanId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dietPlanTable);
                    }

                    if (dietPlanTable.Rows.Count > 0)
                    {
                        dgvViewDietPlan.DataSource = dietPlanTable;

                        // Format DataGridView
                        dgvViewDietPlan.Columns["DayOfWeek"].HeaderText = "Day";
                        dgvViewDietPlan.Columns["Breakfast"].HeaderText = "Breakfast";
                        dgvViewDietPlan.Columns["Lunch"].HeaderText = "Lunch";
                        dgvViewDietPlan.Columns["Dinner"].HeaderText = "Dinner";
                        dgvViewDietPlan.Columns["Snacks"].HeaderText = "Snacks";

                        dgvViewDietPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvViewDietPlan.ReadOnly = true;
                        dgvViewDietPlan.AllowUserToAddRows = false;
                    }
                    else
                    {
                        MessageBox.Show("No diet plan details found.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the diet plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ViewDietplans()
        {
            InitializeComponent();
        }

        private void ViewDietplans_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadDietPlan();
        }

        private void dgvViewDietPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }

        private void dgvViewDietPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Generalmember generalmember = new Generalmember(dietmember.Text);  
            generalmember.Show();   
            this.Hide();    
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
