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
    public partial class UC_viewuser : UserControl
    {

        String currentUser = " ";
        public UC_viewuser()
        {
            InitializeComponent();
        }
        public String ID
        {

            set { currentUser = value; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_viewuser_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewMember";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            guna2DataGridView1.DataSource = DS.Tables[0];
        }

        private void guna2Textsearchname_TextChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewMember where Fname like '" + guna2Textsearchname.Text + "%'";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            guna2DataGridView1.DataSource = DS.Tables[0];
        }
        String userName;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try

            {
                userName = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();




            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {



            if (MessageBox.Show("This will delete your data.Confrim?", "Delete Data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                if (currentUser != userName)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "delete from NewMember where Fname= '" + userName + "'";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    UC_viewuser_Load(this, null);
                }

                else
                {


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "select * from NewMember";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    guna2DataGridView1.DataSource = DS.Tables[0];


                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_viewuser_Load(this, null);
        }
    }
}
