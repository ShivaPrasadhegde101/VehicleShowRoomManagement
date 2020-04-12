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
    public partial class userinterface : Form
    {
        String email;
        OracleCommand comm;
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        DataRow dr;
        DataTable dt;
        String type;
        String range;
        String[] r;
        int i;
        public userinterface(string f,string l,string email)
        {
            InitializeComponent();
            label4.Text = label4.Text + "Mr." + f + " " + l;
            this.email = email;
        }

        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            
            
            range = comboBox1.Text;
            r = range.Split('-');
            if (radioButton1.Checked)
            {
                type = radioButton1.Text;
            }
            else if(radioButton2.Checked)
            {
                type = radioButton2.Text;
            }

            if (range == "" || type == null)
            {
                MessageBox.Show("Enter The Details Before Searching");
            }
            else
            {
                listrefresh();
            }
        }
        private void listrefresh()
        {
            label5.Text = "Click on the Id to Buy/Rent:";
            String ans = "Buy";
            listView1.Items.Clear();
            Db_Connect();
            int min = int.Parse(r[0]);
            int max = int.Parse(r[1]);
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select VEHICAL_ID,model_name,MODEL_NO,DOM,PRIZE,RENTALPRIZE from cars where type='" + type + "' and prize between'" + min + "' and '" + max + "'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_cars");

            dt = ds.Tables["Tbl_cars"];

            //dr = dt.Rows[i];
            for (i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());


            }


            comm.ExecuteNonQuery();
            conn.Close();

        
    }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_Click(object sender, EventArgs e)
        {
           
            int i1 = listView1.FocusedItem.Index;
            dr = dt.Rows[i1];
            String id = dr["vehical_id"].ToString();
            if (int.Parse(dr["rentalprize"].ToString())!=0)
            {
                    messagebox m = new messagebox(id,email);
                    listView1.Items.Clear();
                    m.Show();
            }
            else
            {
                messagebox1 b1 = new messagebox1(id,email);
                listView1.Items.Clear();
                b1.Show();
            }
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            Detailchange d = new Detailchange(email,this);
            d.Show();
        }
    }
}
