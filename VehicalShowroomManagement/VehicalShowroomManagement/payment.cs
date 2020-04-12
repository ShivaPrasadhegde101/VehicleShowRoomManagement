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
    
    public partial class payment : Form
    {
        String vid,email;
        public payment(String vid,String email)
        {
            InitializeComponent();
            this.vid = vid;
            this.email = email;

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            this.Close();
            
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text != null || textBox1.Text != "")
            {
                label4.Hide();
            }
            else
            {
                label4.Show();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text != null || textBox3.Text != "")
            {
                label9.Hide();
            }
            else
            {
                label9.Show();
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text != null || textBox2.Text != "")
            {
                label10.Hide();
            }
            else
            {
                label10.Show();
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text != null || textBox4.Text != "")
            {
                label11.Hide();
            }
            else
            {
                label11.Show();
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text != null || textBox5.Text != "")
            {
                label12.Hide();
            }
            else
            {
                label12.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(textBox1.Text=="" || textBox2.Text=="" || textBox3.Text=="" || textBox4.Text=="" || textBox5.Text=="")
            {
                MessageBox.Show("Please Enter valid Details");
            }
           else
            {
                MessageBox.Show("Payment Successfully done");
                recepit r = new recepit(vid,email);
                r.Show();
                this.Hide();
            }
        }
    }
   
   
}
