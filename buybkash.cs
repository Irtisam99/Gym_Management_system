using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_system
{
    public partial class buybkash : Form
    {
        public buybkash()
        {
            InitializeComponent();
        }

        private void buybkash_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtBkashTransactionID.Text != "") 
            {

                MessageBox.Show("Paid Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error!");
            }
            
            
        }

    private void buybkash_Click(object sender, EventArgs e)


    {

    }

        private void txtBkashTransactionID_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();           
        }
    }
}
