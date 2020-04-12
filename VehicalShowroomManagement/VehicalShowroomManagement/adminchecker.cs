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
    public partial class adminchecker : Form
    {
        OracleCommand comm;
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        DataRow dr;
        DataTable dt;
        public adminchecker()
        {
            InitializeComponent();
            detailLoad();
            textBox2.Hide();
            textBox1.Hide();
            label3.Hide();
            label4.Hide();
        }

        private void detailLoad()
        {
            Db_Connect();
            comm = new OracleCommand();
            comm.CommandText = comm.CommandText = "select * from cars";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            dt = new DataTable();
            da.Fill(dt);
            int t = dt.Rows.Count;
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Db_Connect()
        {
            string ordb = "Data Source=Terminator;Persist Security Info=True;User ID=system;Password=student;";
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            
            Db_Connect();
            int flag = 0;
            comm = new OracleCommand();
            comm.CommandText = "select * from cars";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_userdetail");
            dt = ds.Tables["Tbl_userdetail"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                if (dr["vehical_id"].ToString() == textBox4.Text)
                {
                    flag = 1;

                }
            }
            if (flag == 1)
            {

                if (textBox1.Text != "")
                {
                   
                    try
                    {
                        int p1 = int.Parse(textBox1.Text.ToString());
                        Db_Connect();
                        OracleCommand cm = new OracleCommand();
                        cm.Connection = conn;
                        cm.CommandText = "update cars set prize=:pb where vehical_id =:pdn";
                        cm.CommandType = CommandType.Text;
                        OracleParameter pa1 = new OracleParameter();
                        pa1.ParameterName = "pb";
                        pa1.DbType = DbType.Int32;
                        pa1.Value = p1;
                        OracleParameter pa2 = new OracleParameter();
                        pa2.ParameterName = "pdn";
                        pa2.DbType = DbType.String;
                        pa2.Value = textBox4.Text;
                        cm.Parameters.Add(pa1);
                        cm.Parameters.Add(pa2);
                        cm.ExecuteNonQuery();
                        MessageBox.Show("updated");
                        conn.Close();

                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("Error in input");
                    }
                }
                    if (textBox2.Text != "")
                    {
                        try
                        {
                            int p2 = int.Parse(textBox2.Text.ToString());
                            Db_Connect();
                            OracleCommand cm = new OracleCommand();
                            cm.Connection = conn;
                            cm.CommandText = "update cars set rentalprize=:pb where vehical_id =:pdn";
                            cm.CommandType = CommandType.Text;
                            OracleParameter pa1 = new OracleParameter();
                            pa1.ParameterName = "pb";
                            pa1.DbType = DbType.Int32;
                            pa1.Value = p2;
                            OracleParameter pa2 = new OracleParameter();
                            pa2.ParameterName = "pdn";
                            pa2.DbType = DbType.String;
                            pa2.Value = textBox4.Text;
                            cm.Parameters.Add(pa1);
                            cm.Parameters.Add(pa2);
                            cm.ExecuteNonQuery();
                            MessageBox.Show("updated");
                            conn.Close();

                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show("Error in input");
                        }

                    }
                
            }
            else
            {
                MessageBox.Show("InValid Id");
            }

        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            detailLoad();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox2.Show();
            textBox1.Show();
            label3.Show();
            label4.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]{1,10}$"))
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]{1,10}$"))
            {
                textBox2.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
