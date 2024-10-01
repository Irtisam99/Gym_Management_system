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
    public partial class ViewEqui : UserControl
    {
        String currentUser = " ";
        public ViewEqui()
        {
            InitializeComponent();
        }
        public String ID
        {

            set { currentUser = value; }
        }

        private void guna2Textequisearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from Equipment where EquipName like '" +guna2Textequisearch.Text + "%'";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            guna2DataGridViewequi.DataSource = DS.Tables[0];
        }

        private void ViewEqui_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from Equipment";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            guna2DataGridViewequi.DataSource = DS.Tables[0];
        }
        String userName;

        private void guna2DataGridViewequi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try

            {
                userName = guna2DataGridViewequi.Rows[e.RowIndex].Cells[1].Value.ToString();




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

                    cmd.CommandText = "delete from Equipment where EquipName= '" + userName + "'";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    ViewEqui_Load(this, null);
                }

                else
                {


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "select * Equipment";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                   guna2DataGridViewequi.DataSource = DS.Tables[0];


                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ViewEqui_Load(this, null);
        }
    }
}
