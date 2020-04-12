using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace VehicalShowroomManagement
{
    public partial class signup : Form
    {
        OracleCommand comm;
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        DataRow dr;
        int cflag = 1,eflag=1,pflag=1;
        public signup()
        {
            InitializeComponent();

        }

        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private bool isvalid(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox6.Hide();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox6.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox5.Text = textBox6.Text;
            textBox8.Text = textBox7.Text;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {

            textBox7.Hide();
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox7.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]{1,10}$"))
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 10)
            {
                cflag = -1;
                MessageBox.Show("InValid Contact Please Enter Valid Contact Number!");
                
            }
            else
            {
                cflag = 1;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!isvalid(textBox3.Text))
            {
                eflag = -1;
                MessageBox.Show("Not a Valid EMail Address");
            
            }
            else
            {
                eflag = 1;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            this.Hide();
            user u = new user();
            u.Show();
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if(textBox6.Text==textBox7.Text)
            {
                pflag = 1;
            }
            else
            {
                MessageBox.Show("Does'nt Match");

                pflag = -1;
            }

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || textBox7.Text == "" || cflag ==-1 || eflag==-1 || pflag==-1)
            {
                MessageBox.Show("Please Enter Valid Details");
            }
            else
            {
                Db_Connect();
                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;
                cm.CommandText = "insert into userdetail values('" + textBox1.Text + "', '" + textBox4.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "')";
                try
                {
                    cm.ExecuteNonQuery();
                    DialogResult dr = MessageBox.Show("Successfully Registered", "Ok", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        this.Hide();
                        user u = new user();
                        u.Show();
                    }
                }
                catch (Exception e1)

                {
                    MessageBox.Show("Email Account is already Registered", "Ok", MessageBoxButtons.OK);
                }

            }
        }
    }
}
