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
    public partial class admininterface : Form
    {
        OracleCommand comm,comm1,comm2;
        OracleConnection conn;
        OracleDataAdapter da,da1,da2;
        DataSet ds;
        DataRow dr,dr1,dr2;
        DataTable dt,dt1,dt2;
        String type;
        int i;
        public admininterface()
        {
            InitializeComponent();
            Db_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from sold";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_sold");

            dt = ds.Tables["Tbl_sold"];

            //dr = dt.Rows[i];
            for (i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());

            }
            comm.ExecuteNonQuery();
            conn.Close();
            RentRefresh();
        }
        private void RentRefresh()
        {
            Db_Connect();
            comm1 = new OracleCommand();
            comm1.Connection = conn;
            comm1.CommandText = "select * from rent";
            comm1.CommandType = CommandType.Text;
            ds = new DataSet();
            da1 = new OracleDataAdapter(comm1.CommandText, conn);
            da1.Fill(ds, "Tbl_rent");

            dt1 = ds.Tables["Tbl_rent"];

            //dr = dt.Rows[i];
            for (i = 0; i < dt1.Rows.Count; i++)
            {
                dr1 = dt1.Rows[i];
                listView2.Items.Add(dt1.Rows[i].ItemArray[0].ToString());
                listView2.Items[i].SubItems.Add(dt1.Rows[i].ItemArray[1].ToString());
                listView2.Items[i].SubItems.Add(dt1.Rows[i].ItemArray[2].ToString());
                listView2.Items[i].SubItems.Add(dt1.Rows[i].ItemArray[3].ToString());
                listView2.Items[i].SubItems.Add(dt1.Rows[i].ItemArray[4].ToString());
                listView2.Items[i].SubItems.Add(dt1.Rows[i].ItemArray[5].ToString());
                listView2.Items[i].SubItems.Add(dt1.Rows[i].ItemArray[6].ToString());
                listView2.Items[i].SubItems.Add(dt1.Rows[i].ItemArray[7].ToString());

            }
            comm1.ExecuteNonQuery();
            conn.Close();
        }
        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]{1,10}$"))
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
           
        }

        private void admininterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]{1,10}$"))
            {
                textBox4.Text = "";
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            int amt = int.Parse(textBox4.Text);
            int rent = int.Parse(textBox5.Text);
            if(radioButton1.Checked)
            {
                type = radioButton1.Text;
            }
            else if(radioButton2.Checked)
            {
                type = radioButton2.Text;
            }
  
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || type==null)
            {
                MessageBox.Show("Enter All the details");
            }
            else
            {
                Db_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into cars values('" + type + "', '" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + monthCalendar1.SelectionRange.Start.ToShortDateString().ToString() + "','" + amt + "','" + rent + "')";
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Successfully added", "Ok", MessageBoxButtons.OK);
               
                }
                catch (Exception e1)


                {
                    MessageBox.Show("ID Exist", "Ok", MessageBoxButtons.OK);
                }

            }
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            int i1 = listView2.FocusedItem.Index;
            dr1=dt1.Rows[i1];
            DialogResult dro = MessageBox.Show("Remove Vehicle From Rented List", "Enter", MessageBoxButtons.YesNoCancel);
            if(dro==DialogResult.Yes)
            {
                String id = dr1["VEHICAL_ID"].ToString();
                Db_Connect();
                OracleCommand comm2 = new OracleCommand();
                comm2.Connection = conn;
                comm2.CommandText = "select * from cars_recovery where VEHICAL_ID='" + id + "'";
                comm2.CommandType = CommandType.Text;
                ds = new DataSet();
                da2 = new OracleDataAdapter(comm2.CommandText, conn);
                da2.Fill(ds, "Tbl_cars_recovery");

                dt2 = ds.Tables["Tbl_cars_recovery"];
                dr2 = dt2.Rows[0];
                DateTime newd = DateTime.Parse(dr2["dom"].ToString());
                String dom = newd.ToShortDateString();
                OracleCommand cim = new OracleCommand();
                cim.Connection = conn;
                cim.CommandText = "insert into cars values('" + dr2["type"].ToString() + "', '" + dr2["vehical_id"].ToString() + "','" + dr2["model_name"].ToString() + "','" + dr2["model_no"].ToString() + "','" + dom + "','" + int.Parse(dr2["prize"].ToString()) + "','" + int.Parse(dr2["rentalprize"].ToString()) + "')";
                cim.CommandType = CommandType.Text;
                cim.ExecuteNonQuery();
                OracleCommand comm3 = new OracleCommand();
                comm3.Connection = conn;
                comm3.CommandText = "delete from rent where vehical_id='" + dr2["vehical_id"].ToString() + "'";
                comm3.CommandType = CommandType.Text;
                comm3.ExecuteNonQuery();
                OracleCommand comm4 = new OracleCommand();
                comm4.Connection = conn;
                comm4.CommandText = "delete from cars_recovery where vehical_id='" + dr2["vehical_id"].ToString() + "'";
                comm4.CommandType = CommandType.Text;
                comm4.ExecuteNonQuery();
                conn.Close();
                listView2.Items.Clear();
                RentRefresh();
            }
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void admininterface_Load(object sender, EventArgs e)
        {

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            adminchecker ad = new adminchecker();
            ad.Show();
        }
    }
}
