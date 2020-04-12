using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicalShowroomManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user u = new user();
            u.Show();
            this.Hide();
        }
    }
}
