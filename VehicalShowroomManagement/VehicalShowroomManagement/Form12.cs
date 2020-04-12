using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace VehicalShowroomManagement
{
    public partial class Form12 : Form
    {
        String email, pass;
        OracleCommand comm;
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        DataRow dr;
        DataTable dt;
        int flag;
        Form h,d;
        public Form12(String email, String pass,int flag,Form h,Form d)
        {
            InitializeComponent();
            this.email = email;
            this.pass = pass;
            this.flag = flag;
            this.h = h;
            this.d = d;
            if (flag == 3)
            {

            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            String passc = textBox2.Text;
            String val = textBox1.Text;
            if (passc == pass && val != "")
            {
                try
                {
                    Db_Connect();
                    OracleCommand cm = new OracleCommand();
                    cm.Connection = conn;
                    if (flag == 1)
                    {
                        cm.CommandText = "update userdetail set fname=:pb where email =:pdn";
                    }
                    else if (flag == 2)
                    {
                        cm.CommandText = "update userdetail set lname=:pb where email =:pdn";
                    }
                    else if (flag == 3)
                    {
                        cm.CommandText = "update userdetail set contact=:pb where email =:pdn";
                    }
                    else if (flag == 4)
                    {
                        cm.CommandText = "update userdetail set email=:pb where email =:pdn";
                        MessageBox.Show("You have Changed Your Mail-Id Please Log In back");
                        d.Close();
                        h.Close();

                    }
                    cm.CommandType = CommandType.Text;
                    OracleParameter pa1 = new OracleParameter();
                    pa1.ParameterName = "pb";
                    pa1.DbType = DbType.String;
                    pa1.Value = val;
                    OracleParameter pa2 = new OracleParameter();
                    pa2.ParameterName = "pdn";
                    pa2.DbType = DbType.String;
                    pa2.Value = email;
                    cm.Parameters.Add(pa1);
                    cm.Parameters.Add(pa2);
                    cm.ExecuteNonQuery();
                    conn.Close();
                    this.Close();
                }
                catch(Exception E1)
                {
                    MessageBox.Show("Error");
                }
                }
            else
            {
                MessageBox.Show("Incorrect Deatails");
                this.Close();

            }
        }

        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }

    }
}
