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

namespace Gym_Management_system
{
    public partial class DebitCard : Form
    {
        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
        private decimal amount;
        private string membershipType;
        private string username; // Set during form initialization
        public DebitCard()
        {
            InitializeComponent();
        }
        public DebitCard(string user, decimal paymentAmount, string memType)
        {
            InitializeComponent();
            amount = paymentAmount;
            membershipType = memType;
            username = user;
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string transactionID = txtNogodTransactionID.Text.Trim();

            if (string.IsNullOrEmpty(transactionID))
            {
                MessageBox.Show("Please enter your MasterCard Transaction ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert payment into the database
            string query = "INSERT INTO Payments (UserName, Amount, PaymentMethod, TransactionID, PaymentDate, MembershipType) " +
                           "VALUES (@UserName, @Amount, @PaymentMethod, @TransactionID, @PaymentDate, @MembershipType)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@PaymentMethod", "Debit MasterCard");
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                    cmd.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@MembershipType", membershipType);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    // Generate and save receipt
                    GenerateReceipt("Nogod", amount, transactionID);

                    MessageBox.Show("Payment successful! Receipt saved to your desktop.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();


                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void GenerateReceipt(string paymentMethod, decimal amount, string transactionID)
        {
            string receiptContent = $"Gym Membership Payment Receipt\n" +
                                    $"-----------------------------------\n" +
                                    $"Payment Method: {paymentMethod}\n" +
                                    $"Amount Paid: {amount}\n" +
                                    $"Transaction ID: {transactionID}\n" +
                                    $"Membership Type: {membershipType}\n" +
                                    $"Payment Date: {DateTime.Now}\n" +
                                    $"-----------------------------------\n" +
                                    $"Thank you for your payment!";

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string receiptPath = Path.Combine(desktopPath, $"PaymentReceipt_{username}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt");

            try
            {
                File.WriteAllText(receiptPath, receiptContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DebitCard_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
