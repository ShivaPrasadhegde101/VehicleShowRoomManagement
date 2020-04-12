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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            signup s = new signup();
            this.Hide();
            s.Show();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            login l = new login();
            this.Hide();
            l.Show();
        }
    }
}
