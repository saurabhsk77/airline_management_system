using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace airlinemanagement
{
    public partial class reservation : Form
    {
        string[] queries = new string[5];
        public reservation()
        {
            InitializeComponent();
            seat1.Enabled = false;
            seat2.Enabled = false;
            seat3.Enabled = false;
            seat4.Enabled = false;
            seat1.Hide();
            seat2.Hide();
            seat3.Hide();
            seat4.Hide();
        }

           
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Saurabh\Documents\USERREGISTRATION.mdf;Integrated Security=True;Connect Timeout=30");

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Now && comboBox1.Text!="")
            {
                con.Open();
                int seats = 0;
                string q1 = "select seats from flight_search where flight_no='" + textBox1.Text + "'";
                SqlCommand c2 = new SqlCommand(q1, con);
                SqlDataReader myreader1 = c2.ExecuteReader();
                if (myreader1.Read())
                {
                    if (myreader1.HasRows)
                    {
                        seats = Convert.ToInt32(myreader1["seats"].ToString());
                        seats -= Convert.ToInt32(comboBox1.Text);
                    }

                    string q2 = "update flight_search set seats='" + seats + "'where flight_no='" + textBox1.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(q2, con);
                    myreader1.Close();
                    cmd2.ExecuteNonQuery();
                    //String rr = "insert into pass_details(flight_no,source,destination,cost,name,age,phone,email,address,pnr,username,journeydate) values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + this.textBox6.Text + "','" + this.textBox9.Text + "','" + this.textBox10.Text + "','" + textBox11.Text + "','" + dateTimePicker1.Value.ToString() + "');";
                    //SqlCommand cmd = new SqlCommand(rr, con);
                    //myreader1 = cmd.ExecuteReader();
                    //MessageBox.Show("ticket booked  successfully");

                    //querie[0]
                    queries[0] = "insert into pass_details(flight_no, PNR, journeydate, name, age, source, destination, cost, username, phone, address, email, seats) values ('" + textBox1.Text + "', " + textBox10.Text + ", '" + dateTimePicker1.Text + "', '" + textBox5.Text + "', " + textBox7.Text + ", '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ", '" + textBox11.Text + "', " + textBox8.Text + ", '" + textBox9.Text + "', '" + textBox6.Text + "',"+comboBox1.Text+")";
                    queries[1] = "insert into pass_details(flight_no, PNR, journeydate, name, age, username) values('" + textBox1.Text + "', " + textBox10.Text + ", '" + dateTimePicker1.Text + "', '"+ textBox13.Text + "', " + textBox12.Text + ", '" +textBox11.Text+"')";
                    queries[2] = "insert into pass_details(flight_no, PNR, journeydate, name, age, username) values('" + textBox1.Text + "', " + textBox10.Text + ", '" + dateTimePicker1.Text + "', '" + textBox14.Text + "', " + textBox15.Text + ", '" + textBox11.Text + "')";
                    queries[3] = "insert into pass_details(flight_no, PNR, journeydate, name, age, username) values('" + textBox1.Text + "', " + textBox10.Text + ", '" + dateTimePicker1.Text + "', '" + textBox16.Text + "', " + textBox17.Text + ", '" + textBox11.Text + "')";
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            query1();
                            break;
                        case 1:
                            query1();
                            query2();
                            break;
                        case 2:
                            query1();
                            query2();
                            query3();
                            break;
                        case 3:
                            query1();
                            query2();
                            query3();
                            query4();
                            break;

                    }

                }
                //main mm = new main();

                //    mm.Show();
                MessageBox.Show("ticket confirmed", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                con.Close();


            }else
            {
                MessageBox.Show("enter correct date and fill all the fields", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            }

        public void query1()
        {
            //con.Open();
            string query1 = queries[0];
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
            
            //con.Close();
    
        }

        public void query2()
        {
            //con.Open();
            string query1 = queries[1];
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
            
            //con.Close();

        }

        public void query3()
        {
            //con.Open();
            string query1 = queries[2];
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
           
            //con.Close();

        }
        public void query4()
        {
            //con.Open();
            string query1 = queries[3];
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
           
            //con.Close();

        }


        public void display1()
        {
            try
            {
                con.Open();
                main mm = new main();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from pass_details where username='" + textBox5.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                mm.dataGridView3.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label9.Text = DateTime.Now.ToLongDateString();
            label18.Text = DateTime.Now.ToLongTimeString();
            SqlDataAdapter sda1 = new SqlDataAdapter("select isnull (max(cast(PNR as int)),76587978)+1 from pass_details", con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            textBox10.Text = dt.Rows[0][0].ToString();
            textBox11.Text = login.passingtext;
                 
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    con.Open();
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    string query1 = "select cost from flight_search where flight_no='" + textBox1.Text + "'";
        //    cmd = new SqlCommand(query1, con);
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while(dr.Read())
        //    {
        //        textBox4.Text = dr["cost"].ToString();
        //    }
        //    con.Close();
        //}

        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    con.Open();
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    string query1 = "select cost from flight_search where flight_no='" + textBox1.Text + "'";
        //    cmd = new SqlCommand(query1, con);
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        textBox4.Text = dr["cost"].ToString();
        //    }
        //    int Cost = Convert.ToInt32(textBox4.Text);
        //    Cost = Cost * 2;
        //    textBox4.Text = Cost.ToString();
        //    con.Close();
        //}

        //private void radioButton3_CheckedChanged(object sender, EventArgs e)
        //{
        //    con.Open();
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    string query1 = "select cost from flight_search where flight_no='" + textBox1.Text + "'";
        //    cmd = new SqlCommand(query1, con);
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        textBox4.Text = dr["cost"].ToString();
        //    }
        //    int Cost = Convert.ToInt32(textBox4.Text);
        //    Cost = Cost * 3;
        //    textBox4.Text = Cost.ToString();
        //    con.Close();
        //}

        //private void radioButton4_CheckedChanged(object sender, EventArgs e)
        //{
        //    con.Open();
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    string query1 = "select cost from flight_search where flight_no='" + textBox1.Text + "'";
        //    cmd = new SqlCommand(query1, con);
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        textBox4.Text = dr["cost"].ToString();
        //    }
        //    int Cost = Convert.ToInt32(textBox4.Text);
        //    Cost = Cost * 4;
        //    textBox4.Text = Cost.ToString();
        //    con.Close();
        //}

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string query1 = "select cost from flight_search where flight_no='" + textBox1.Text + "'";
            cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox4.Text = dr["cost"].ToString();
            }
            if(comboBox1.SelectedIndex == 0)
            {
                seat1.Enabled = true;
                seat2.Hide();
                seat3.Hide();
                seat4.Hide();
                seat1.Show();
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                seat2.Enabled = true;
                seat1.Enabled = true;
                seat3.Hide();
                seat4.Hide();
                seat1.Show();
                seat2.Show();
            }else if(comboBox1.SelectedIndex == 2)
            {
                seat4.Hide();
                seat1.Enabled = true;
                seat2.Enabled = true;
                seat3.Enabled = true;
                seat1.Show();
                seat2.Show();
                seat3.Show();
            }
            else
            {
                seat1.Enabled = true;
                seat2.Enabled = true;
                seat3.Enabled = true;
                seat4.Enabled = true;
                seat1.Show();
                seat2.Show();
                seat3.Show();
                seat4.Show();
            }
            int Cost = Convert.ToInt32(textBox4.Text);
            int no = Convert.ToInt32(comboBox1.Text);
            Cost = Cost *no;
            textBox4.Text = Cost.ToString();
            con.Close();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(comboBox1)==1)
            {

            }
        }

        private void pass11_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label18.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            try
            {
                const string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
                if (Regex.IsMatch(textBox6.Text, pattern))
                {
                    errorProvider1.Clear();
                }
                else
                {
                    errorProvider1.SetError(this.textBox5, "please provide valid mail address");
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
