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
    public partial class addEquipment : UserControl
    {
        public addEquipment()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void addEquipment_Load(object sender, EventArgs e)
        {

        }

        private void guna2Texttraincity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Texttrainstate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Texttrainmobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String EquipName = guna2Textequipname.Text;
            String Description = guna2Textdescription.Text;
            String MUsed = guna2Textmusclesused.Text;
            String DDate = guna2DateTimePickerdelivery.Text;
            Int64 cost = Int64.Parse(guna2Textcost.Text);


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into Equipment (EquipName,EDescription,MUsed,DDate,Cost) values ('" + EquipName + "','" + Description + "', '" + MUsed + "', '" + DDate + "', '" + cost + "')";
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            DataSet DS = new DataSet();
            DA.Fill(DS);

            MessageBox.Show("data saved ", "Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Textequipname.Clear();
            guna2Textdescription.Clear();
            guna2Textmusclesused.Clear();
            guna2Textcost.Clear();

            guna2DateTimePickerdelivery.Value = DateTime.Now;

        }
    }
}
