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
    public partial class Addtrainer : UserControl
    {
        public Addtrainer()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Addtrainer_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String fname = guna2Texttrainerfname.Text;
            String lname = guna2Texttrainerlastname.Text;   
            String password= guna2Texttrainerpass.Text;


            String gender = "";
            bool isChecked = guna2RadioButton1.Checked;
            if (isChecked)
            {
                gender = guna2RadioButton1.Text;

            }
            else
            {
                gender = guna2RadioButton2.Text;
            }

            String dob = guna2DateTimePickertraindob.Text;  
            Int64 mobile = Int64.Parse(guna2Texttrainmobile.Text);
            String email = guna2Texttrainmobile.Text;
            String joindate = guna2DateTimePickertraindatejoin.Text;
           
            String city = guna2Texttraincity.Text;
            String state = guna2Texttrainstate.Text;


            String userrole = guna2Comboboxuserrole.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CBUAB5J;Initial Catalog=GYM;Persist Security Info=True;User ID=sa;Password=nafis99;Encrypt=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into NewStaff (Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,Statee,City,userRole,password) values ('" + fname + "','" + lname + "', '" + gender + "', '" + dob + "', '" + mobile + "', '" + email + "', '" + joindate + "', '" + state+ "', '" + city + "', '" + userrole +"','"+password+ "')";
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("data saved");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Texttrainerfname.Clear();
            guna2Texttrainerlastname.Clear();

            guna2RadioButton1.Checked = false;
            guna2RadioButton2.Checked = false;

            guna2Texttrainmobile.Clear();
            guna2Texttrainemail.Clear();

            guna2Comboboxuserrole.ResetText();
            
            guna2Texttraincity.Clear();

            guna2DateTimePickertraindatejoin.Value = DateTime.Now;
            guna2DateTimePickertraindob.Value = DateTime.Now;

            guna2Texttrainstate.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
