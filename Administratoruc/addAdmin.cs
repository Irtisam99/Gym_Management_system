using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Gym_Management_system.Administratoruc
{
    public partial class addAdmin : UserControl
    {
        public addAdmin()
        {
            InitializeComponent();
        }

        private void addAdmin_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String userrole = guna2ComboBoxadmin.Text;
            String password = guna2Textadminpass.Text;
            String username= guna2Textadminname.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into admin (userRole,admin_name,pass) values ('" + userrole+ "','" + username + "','" + password + "')";
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("data saved");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Textadminpass.Clear();
           
            guna2Textadminname.Clear(); 
        }
    }
}
