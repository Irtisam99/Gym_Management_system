using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_system.Welcome
{
    public partial class UCHOME : UserControl
    {
        public UCHOME()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Userlogin userlogin = new Userlogin();
            userlogin.Show();
            Welcome1 welcome1 = new Welcome1();     
              welcome1.Hide();  
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
