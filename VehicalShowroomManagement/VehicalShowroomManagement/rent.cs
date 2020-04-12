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
    public partial class rent : Form
    {
        String email, vid;
        OracleCommand comm;
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        DataRow dr;
        DataTable dt;
        int v,amt,days;
        public rent(String email,String vid)
        {
            InitializeComponent();
            label2.Hide();
            button2.Hide();
            this.email = email;
            this.vid = vid;
            Db_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select RENTALPRIZE from cars where VEHICAL_ID='" + vid+"'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_cars");

            dt = ds.Tables["Tbl_cars"];
            dr = dt.Rows[0];
            v = int.Parse(dr["RENTALPRIZE"].ToString());
            conn.Close();

        }
        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            String val = comboBox1.Text;
            String[] r = val.Split(' ');
            days = int.Parse(r[0]);
            double ans = v*(days/30.0);
            amt = Convert.ToInt32(ans);
            label3.Text=amt.ToString();

            label2.Show();
            button2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String add = textBox3.Text;
            if (add == "")
            {
                MessageBox.Show("Address has to be filled");
            }
            else
            {
                Rentdetail rd = new Rentdetail(email, vid, add, amt, days);
                rd.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
