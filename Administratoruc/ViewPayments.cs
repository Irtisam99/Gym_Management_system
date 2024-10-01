using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_system.Administratoruc
{
    public partial class ViewPayments : UserControl
    {
        private string connectionString;
        public ViewPayments()
        {
            InitializeComponent();
            connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            LoadAllPayments();
            InitializePaymentMethodFilter();
        }
        private void InitializePaymentMethodFilter()
        {
            cmbFilterMethod.Items.Clear();
            cmbFilterMethod.Items.Add("All");
            cmbFilterMethod.Items.Add("Bkash");
            cmbFilterMethod.Items.Add("Nagad");
          
            cmbFilterMethod.Items.Add("American Express");
            //cmbFilterMethod.Items.Add("Debit Card");
            cmbFilterMethod.SelectedIndex = 0; // Set default to "All"
        }
        private void LoadAllPayments()
        {
            string query = "SELECT PaymentID, UserName, Amount, PaymentMethod, TransactionID, PaymentDate, MembershipType FROM Payments ORDER BY PaymentDate DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    guna2DataGridView1.DataSource = dt;

                    // Adjust DataGridView columns
                    guna2DataGridView1.Columns["PaymentID"].HeaderText = "Payment ID";
                    guna2DataGridView1.Columns["UserName"].HeaderText = "Username";
                    guna2DataGridView1.Columns["Amount"].HeaderText = "Amount ($)";
                    guna2DataGridView1.Columns["PaymentMethod"].HeaderText = "Payment Method";
                    guna2DataGridView1.Columns["TransactionID"].HeaderText = "Transaction ID";
                    guna2DataGridView1.Columns["PaymentDate"].HeaderText = "Payment Date";
                    guna2DataGridView1.Columns["MembershipType"].HeaderText = "Membership Type";
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string usernameFilter = guna2TextBox1.Text.Trim();
            DateTime? startDate = dtpStartDate.Value.Date;
            DateTime? endDate = dtpEndDate.Value.Date;
            string paymentMethod = cmbFilterMethod.SelectedItem.ToString();

            string query = "SELECT PaymentID, UserName, Amount, PaymentMethod, TransactionID, PaymentDate, MembershipType FROM Payments WHERE 1=1";

            if (!string.IsNullOrEmpty(usernameFilter))
            {
                query += " AND UserName LIKE @UserName";
            }

            if (paymentMethod != "All")
            {
                query += " AND PaymentMethod = @PaymentMethod";
            }

            query += " AND PaymentDate BETWEEN @StartDate AND @EndDate ORDER BY PaymentDate DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (!string.IsNullOrEmpty(usernameFilter))
                    {
                        cmd.Parameters.AddWithValue("@UserName", "%" + usernameFilter + "%");
                    }

                    if (paymentMethod != "All")
                    {
                        cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    }

                    cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value.AddDays(1).AddSeconds(-1)); // Include the entire end date

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error applying filters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            dtpStartDate.Value = DateTime.Now.AddMonths(-1); // Default to one month ago
            dtpEndDate.Value = DateTime.Now;
            cmbFilterMethod.SelectedIndex = 0; // Reset to "All"
            LoadAllPayments();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create a new Excel file
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string excelPath = Path.Combine(desktopPath, $"Payments_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv");

                using (StreamWriter sw = new StreamWriter(excelPath))
                {
                    // Write headers
                    for (int i = 0; i < guna2DataGridView1.Columns.Count; i++)
                    {
                        sw.Write(guna2DataGridView1.Columns[i].HeaderText);
                        if (i < guna2DataGridView1.Columns.Count - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();

                    // Write rows
                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < guna2DataGridView1.Columns.Count; i++)
                            {
                                sw.Write("\"" + row.Cells[i].Value?.ToString().Replace("\"", "\"\"") + "\"");
                                if (i < guna2DataGridView1.Columns.Count - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }
                }

                MessageBox.Show($"Payments exported successfully to {excelPath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, open the file
                System.Diagnostics.Process.Start(excelPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message, "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payment record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
            int paymentID = Convert.ToInt32(selectedRow.Cells["PaymentID"].Value);
            string username = selectedRow.Cells["UserName"].Value.ToString();
            string paymentMethod = selectedRow.Cells["PaymentMethod"].Value.ToString();
            decimal amount = Convert.ToDecimal(selectedRow.Cells["Amount"].Value);
            string transactionID = selectedRow.Cells["TransactionID"].Value.ToString();
            DateTime paymentDate = Convert.ToDateTime(selectedRow.Cells["PaymentDate"].Value);
            string membershipType = selectedRow.Cells["MembershipType"].Value.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the payment record:\n\n" +
                $"Payment ID: {paymentID}\n" +
                $"Username: {username}\n" +
                $"Amount: {amount:C}\n" +
                $"Payment Method: {paymentMethod}\n" +
                $"Transaction ID: {transactionID}\n" +
                $"Payment Date: {paymentDate}\n" +
                $"Membership Type: {membershipType}\n\n" +
                $"This action cannot be undone.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Payments WHERE PaymentID = @PaymentID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@PaymentID", paymentID);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Payment record deleted successfully.", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllPayments();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
