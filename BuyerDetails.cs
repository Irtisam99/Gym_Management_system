using Gym_Management_system.Welcome;
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
    public partial class BuyerDetails : Form
    {
        public BuyerDetails()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string producttype=productype.Text;
            string customerName = namee.Text;
            string contact =contacttt.Text;
            string address = addressss.Text;
            string email = emaile.Text;
            string paymethod=paymethodd.Text;   
            string transactionID = transs.Text;

            // Call the method to store the purchase in the database
            SavePurchaseToDatabase(producttype,customerName, contact, address, email,paymethod, transactionID);
            MessageBox.Show("Ordered Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SavePurchaseToDatabase(string producttype,string customerName, string contact, string address, string email,string paymethod, string transactionID)
        {
            // Define your connection string (update with your SQL server details)
            string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";

            // Define your SQL Insert query
            string query = "INSERT INTO Purchases (ProductName, CustomerName, Contact, Address, Email,Payment,TransactionID) " +
                           "VALUES (@ProductName, @CustomerName, @Contact, @Address, @Email,@Payment, @TransactionID)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@ProductName", producttype);
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Payment", paymethod);
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID);

                    // Execute the query
                    cmd.ExecuteNonQuery();
                }
            }

            // Show success message
            MessageBox.Show("Product purchased successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optionally, close the form
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            namee.Clear();
            contacttt.Clear();
            addressss.Clear();
            emaile.Clear();
            transs.Clear();
           
            
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            buyproduct buyproduct = new buyproduct();
            buyproduct.Show();
            this.Hide();
        }

        private void BuyerDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
