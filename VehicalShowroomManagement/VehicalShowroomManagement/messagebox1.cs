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
    public partial class messagebox1 : Form
    {
        String id,email;
        public messagebox1(String id,String email)
        {
            InitializeComponent();
            this.id = id;
            this.email = email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            payment p = new payment(id,email);
            p.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
