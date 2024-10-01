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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gym_Management_system
{
    public partial class Makepayment : Form
    {
        private string connectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
        private string loggedInUsername; 
        public Makepayment()
        {
            InitializeComponent();
        }
        public Makepayment(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            LoadPaymentHistory();
            cmbPaymentMethod.SelectedIndex = -1;
            labelpayment.Text = username;
        }
        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentMethod.SelectedIndex != -1)
            {
                btnProceed.Enabled = true;
            }
            else
            {
                btnProceed.Enabled = false;
            }
        }
        private void LoadPaymentHistory()
        {
            string query = "SELECT * FROM Payments WHERE UserName = @UserName ORDER BY PaymentDate DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserName", loggedInUsername);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewPaymentHistory.DataSource = dt;

                    // Optional: Format DataGridView columns
                    dataGridViewPaymentHistory.Columns["PaymentID"].HeaderText = "Payment ID";
                    dataGridViewPaymentHistory.Columns["UserName"].HeaderText = "Username";
                    dataGridViewPaymentHistory.Columns["Amount"].HeaderText = "Amount";
                    dataGridViewPaymentHistory.Columns["PaymentMethod"].HeaderText = "Payment Method";
                    dataGridViewPaymentHistory.Columns["TransactionID"].HeaderText = "Transaction ID";
                    dataGridViewPaymentHistory.Columns["PaymentDate"].HeaderText = "Payment Date";
                    dataGridViewPaymentHistory.Columns["MembershipType"].HeaderText = "Membership Type";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payment history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Makepayment_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)

        {
            decimal amount = Convert.ToDecimal(txtAmount.Text);
            string membershipType = guna2ComboBox1.Text;

            string selectedMethod = cmbPaymentMethod.SelectedItem.ToString();

            switch (selectedMethod)
            {
                case "Bkash":
                    BkashPaymentForm bkashForm = new BkashPaymentForm(loggedInUsername,amount,membershipType );
                    bkashForm.Show();
                 
                    break;
                case "Nagad":
                    NagadPaymentForm nogodForm = new NagadPaymentForm(loggedInUsername, amount, membershipType);
                    nogodForm.Show();
                   
                    break;
                case "AmericanExpress":
                    CreditCard rocketForm = new CreditCard(loggedInUsername, amount, membershipType);
                    rocketForm.Show();
                    
                    break;
                
                case "DebitMasterclass":
                    DebitCard cardForm = new DebitCard(loggedInUsername, amount, membershipType);
                  
                    break;

                default:
                    MessageBox.Show("Please select a valid payment method.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            LoadPaymentHistory();   
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Generalmember  generalmember = new Generalmember(loggedInUsername); 
            generalmember.Show();   
            this.Hide();    
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
