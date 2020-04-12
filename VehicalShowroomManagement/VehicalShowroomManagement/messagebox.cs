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
    public partial class messagebox : Form
    {
        String vid,email;
        public messagebox(String id,String email)
        {
            InitializeComponent();
            vid = id;
            this.email = email;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rent r = new rent(email,vid);
            r.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            payment p = new payment(vid,email);
            p.Show();
            this.Close();
           
        }
    }
}
