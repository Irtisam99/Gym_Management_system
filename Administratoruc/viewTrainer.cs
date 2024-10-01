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
    public partial class viewTrainer : UserControl
    {

        String currentUser = " ";
        public viewTrainer()
        {
            InitializeComponent();
        }
        public String ID
        {

            set { currentUser = value; }
        }

        private void viewTrainer_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStaff";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            guna2DataGridViewtrainer.DataSource = DS.Tables[0];
        }

        private void guna2Texttrainersearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStaff where Fname like '" + guna2Texttrainersearch.Text + "%'";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            guna2DataGridViewtrainer.DataSource = DS.Tables[0];
        }
        String userName;

        private void guna2DataGridViewtrainer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try

            {
                userName = guna2DataGridViewtrainer.Rows[e.RowIndex].Cells[1].Value.ToString();




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

                    cmd.CommandText = "delete from NewStaff where Fname= '" + userName + "'";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    viewTrainer_Load(this, null);
                }

                else
                {


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "select * from NewStaff";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    guna2DataGridViewtrainer.DataSource = DS.Tables[0];


                }
            }
            }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            viewTrainer_Load(this, null);
        }
    }
}
