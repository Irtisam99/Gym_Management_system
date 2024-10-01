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
    public partial class vieworder : UserControl
    {
        public vieworder()
        {
            InitializeComponent();
           LoadPurchaseData();
        }
        private void LoadPurchaseData()
        {
            
            string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";

          
            string query = "SELECT PurchaseID, ProductName, CustomerName, Contact, Address, Email,Payment, TransactionID FROM Purchases";

           
            DataTable purchaseTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    
                    adapter.Fill(purchaseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            viewpurchase.DataSource = purchaseTable;
        }
        private void vieworder_Load(object sender, EventArgs e)
        {

        }
    }
}
