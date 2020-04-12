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
    public partial class Rentdetail : Form
    {
        String email, vid, add;
        OracleCommand comm,comm1,comm2;
        OracleConnection conn;
        OracleDataAdapter da,da1,da2,da3;

        private void button1_Click(object sender, EventArgs e)
        {
            
              
            this.Close();
        }

        DataSet ds;
        DataRow dr,dr1;
        DataTable dt,dt1;
        int amt,days;
        public Rentdetail(String email,String vid,String add,int amt,int days)
        {
            InitializeComponent();
            this.email = email;
            this.vid = vid;
            this.add = add;
            this.amt = amt;
            this.days = days;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void rentdetail_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int rno = r.Next();
            String d = (DateTime.Now.ToShortDateString());
            DateTime det = DateTime.Now;
            DateTime due = det.AddDays(days);
            String duedate = due.ToShortDateString();
            label13.Text = d;
            label14.Text = rno.ToString();
            label16.Text = add;
            label19.Text = duedate;
            Db_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select model_name,model_no from cars where VEHICAL_ID='" + vid + "'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_cars");

            dt = ds.Tables["Tbl_cars"];
            dr = dt.Rows[0];
            String model = dr["model_name"].ToString() + "," + dr["model_no"].ToString();
            label21.Text = model;
            comm1 = new OracleCommand();
            comm1.Connection = conn;
            comm1.CommandText = "select fname,lname,contact from userdetail where email='" + email + "'";
            comm1.CommandType = CommandType.Text;
            ds = new DataSet();
            da1 = new OracleDataAdapter(comm1.CommandText, conn);
            da1.Fill(ds, "Tbl_userdetail");

            dt = ds.Tables["Tbl_userdetail"];
            dr = dt.Rows[0];
            String name = dr["fname"].ToString() + " " + dr["lname"].ToString();
            String contact = dr["contact"].ToString();
            label15.Text = name;
            label17.Text = contact;
            label18.Text = amt.ToString();
            conn.Close();

            //Inserting into the Rent Database
            Db_Connect();
           
                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;
                cm.CommandText = "insert into rent values('" + vid + "', '" + model + "','" + name + "','" + email + "','" + contact + "','" + duedate + "','" + amt + "','" + add + "')";
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();
                conn.Close();
        
                Db_Connect();
                comm2 = new OracleCommand();
                comm2.Connection = conn;
                comm2.CommandText = "select * from cars where VEHICAL_ID='" + vid + "'";
                comm2.CommandType = CommandType.Text;
                ds = new DataSet();
                da2 = new OracleDataAdapter(comm2.CommandText, conn);
                da2.Fill(ds, "Tbl_cars");

                dt1 = ds.Tables["Tbl_cars"];
                dr1 = dt1.Rows[0];
                DateTime newd = DateTime.Parse(dr1["dom"].ToString());
                String dom = newd.ToShortDateString();
                OracleCommand cim = new OracleCommand();
                cim.Connection = conn;
                cim.CommandText = "insert into cars_recovery values('" + dr1["type"].ToString() + "', '" + dr1["vehical_id"].ToString() + "','" + dr1["model_name"].ToString() + "','" + dr1["model_no"].ToString() + "','" + dom + "','" + int.Parse(dr1["prize"].ToString()) + "','" + int.Parse(dr1["rentalprize"].ToString()) +"')";
                cim.CommandType = CommandType.Text;
                cim.ExecuteNonQuery();
                OracleCommand comm3 = new OracleCommand();
                comm3.Connection = conn;
                comm3.CommandText = "delete from cars where vehical_id='" + dr1["vehical_id"].ToString() + "'";
                comm3.CommandType = CommandType.Text;
                comm3.ExecuteNonQuery();
                conn.Close();
            
         
        }
        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }
    }
}
