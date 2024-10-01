using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_system.Administratoruc
{
    public partial class UC_dashboard : UserControl
    {

        function fn = new function();
        String query;
        DataSet ds;
        String query1;
        String  query2; 


        public UC_dashboard()
        {
            InitializeComponent();
        }

        private void UC_dashboard_Load(object sender, EventArgs e)
        {

            query = "select count (userRole) from NewMember where userRole=  'User'";
            ds= fn.getData(query);
            setLabel(ds, labelcustomer);


            query1 = "select count (userRole) from NewStaff where userRole=  'Trainer'";
            ds = fn.getData(query1);
            setLabel(ds, labeltrainer);

            query2 = "select count (userRole) from admin where userRole=  'Admin'";
            ds = fn.getData(query2);
            setLabel(ds, labeladministrator);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void setLabel(DataSet ds,Label lbl)

        {
            if (ds.Tables[0].Rows.Count != 0)
            {
                lbl.Text = ds.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                lbl.Text="0";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_dashboard_Load(this, null);
        }

        private void labeltrainer_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
