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
    public partial class admin : Form
    {
        OracleCommand comm;
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        DataRow dr;
        DataTable dt;

        public admin()
        {
            InitializeComponent();
        }


        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox5.Text = textBox6.Text;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox6.Hide();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox6.Show();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            Db_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from admindetail";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_admindetail");
            dt = ds.Tables["Tbl_admindetail"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                if (dr["email"].ToString() == textBox3.Text && dr["password"].ToString() == textBox6.Text)
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                admininterface ai = new admininterface();
                this.Hide();
                ai.Show();
            }
            else
            {
                MessageBox.Show("InValid Email-id/password");
            }
        }
    }
}
