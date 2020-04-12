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
    public partial class recepit : Form
    {
        OracleCommand comm,comm1,comm2,comm3,comm4;
        OracleConnection conn;
        OracleDataAdapter da,da1,da2,da3;
        DataSet ds;
        DataRow dr,dr1;

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        DataTable dt,dt1;
        int i = 0;
        String vid, email;
        public recepit(String vid,String email)
        {
            InitializeComponent();
            this.vid = vid;
            this.email = email;
        }
        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void recepit_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int rno = r.Next();
            DateTime d = DateTime.Now;
            label1.Text = d.ToString();
            label4.Text=rno.ToString();
            Db_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select fname,lname from userdetail where email='"+email+"'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_userdetail");
            dt = ds.Tables["Tbl_userdetail"];
            dr = dt.Rows[0];
            string fname = dr["fname"].ToString();
            string lname = dr["lname"].ToString();
            label6.Text = fname + lname;
            comm1 = new OracleCommand();
            comm1.CommandText = "select vehical_id,model_name,prize from cars where vehical_id='" + vid + "'";
            comm1.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm1.CommandText, conn);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            comm2 = new OracleCommand();
            comm2.CommandText= "select vehical_id,model_name,model_no,prize from cars where vehical_id='" + vid + "'";
            comm2.CommandType = CommandType.Text;
            ds = new DataSet();
            da1 = new OracleDataAdapter(comm2.CommandText, conn);
            da1.Fill(ds, "Tbl_cars");
            dt1 = ds.Tables["Tbl_cars"];
            dr1 = dt1.Rows[0];
            comm3 = new OracleCommand();
            comm3.Connection = conn;
            comm3.CommandText = "insert into sold values('" + dr1["vehical_id"].ToString() + "','" + dr1["model_name"].ToString() + "','" + dr1["model_no"].ToString() + "','" + int.Parse(dr1["prize"].ToString()) + "')";
            comm3.CommandType = CommandType.Text;
            comm3.ExecuteNonQuery();
            comm4 = new OracleCommand();
            comm4.Connection = conn;
            comm4.CommandText = "delete from cars where vehical_id='"+dr1["vehical_id"].ToString()+"'";
            comm4.CommandType = CommandType.Text;
            comm4.ExecuteNonQuery();
            conn.Close();
        }
    }
}
