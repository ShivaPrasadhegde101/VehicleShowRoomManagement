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
    public partial class Detailchange : Form
    {
        OracleCommand comm;
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        DataRow dr;
        DataTable dt;
        String email,pass;
        int i;
        int flag;
        Form h;
        public Detailchange(string email,Form h)
        {
            InitializeComponent();
            this.email = email;
            this.h = h;
            loader();

        }
        private void loader()
        {
            Db_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from userdetail where email='" + email + "'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_userdetail");

            dt = ds.Tables["Tbl_userdetail"];

            dr = dt.Rows[0];
            label5.Text = dr["fname"].ToString();
            label6.Text = dr["lname"].ToString();
            label7.Text = dr["contact"].ToString();
            label8.Text = dr["email"].ToString();
            pass = dr["password"].ToString();
            conn.Close();
        }
        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            flag = 2;
            Form12 f = new Form12(email, pass, flag,h,this)
            {
                Width = 618,
                Height = 242,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };
            f.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            flag = 3;
            Form12 f = new Form12(email, pass, flag,h,this)
            {
                Width = 618,
                Height = 242,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };
            f.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            flag = 4;
            Form12 f = new Form12(email, pass, flag,h,this)
            {
                Width = 618,
                Height = 242,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };
            f.Show();
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            loader();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            flag = 1;
            Form12 f = new Form12(email,pass,flag,h,this)
            {
                Width = 618,
                Height = 242,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };
            f.Show();
        }

    }

}
