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

namespace airlinemanagement
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=C:\USERS\SAURABH\DOCUMENTS\USERREGISTRATION.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void loginMethod()
        {
            SqlCommand cmd = new SqlCommand();
            
            con.Open();
            cmd = new SqlCommand("select * from airport", con);
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
               
                textBox10.Text = (dr["a_name"].ToString());
                textBox11.Text = (dr["a_location"].ToString());
                comboBox3.Text = (dr["type"].ToString());
                textBox13.Text = (dr["airport_id"].ToString());

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == "" && textBox4.Text == "")
                {

                    MessageBox.Show("enter all the fields");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("autoID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = textBox2.Text;
                    cmd.Parameters.Add("@phone", SqlDbType.NChar).Value = textBox3.Text;
                    cmd.Parameters.Add("@salary", SqlDbType.Float).Value = textBox4.Text;
                    cmd.Parameters.Add("@job", SqlDbType.VarChar).Value = comboBox1.Text;
                    cmd.Parameters.Add("@nation", SqlDbType.VarChar).Value = textBox5.Text;
                    cmd.Parameters.Add("@joiningdate", SqlDbType.Date).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox6.Text;
                    cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = comboBox5.Text;
                    cmd.Parameters.Add("@village", SqlDbType.VarChar).Value = textBox7.Text;
                    //SqlCommand cmd = con.CreateCommand();
                    //cmd.CommandType = CommandType.Text;

                    //cmd.CommandText = "insert into employee(name,datejoined,salary,address,phone,email,gender,village,job,nationalty) values('" + textBox1.Text + "','" + dateTimePicker1.Value + "','" + textBox4.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + comboBox5.Text + "','" + textBox7.Text + "','" + comboBox1.Text + "','" + this.textBox5.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("detail inserted successfully");

                    con.Close();
                    display();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }
        public void display()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from employee";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView3.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            display();
            loginMethod();
        }



        private void button7_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from employee where ID='" + textBox16.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox23.Text = dr["name"].ToString();
                    textBox22.Text = dr["address"].ToString();
                    textBox21.Text = dr["phone"].ToString();
                    textBox20.Text = dr["salary"].ToString();
                    textBox19.Text = dr["nationalty"].ToString();
                    comboBox6.Text = dr["job"].ToString();
                    textBox18.Text = dr["email"].ToString();
                    textBox17.Text = dr["village"].ToString();
                    comboBox2.Text = dr["gender"].ToString();
                    dateTimePicker3.Text = dr["datejoined"].ToString();
                }
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView3.DataSource = dt;
                con.Close();
                if (i == 0)
                {
                    MessageBox.Show("no employee with this ID");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update employee set name='" + textBox23.Text + "',address='" + textBox22.Text + "',phone=" + textBox21.Text + ",salary=" + textBox20.Text + ",job='" + comboBox6.Text + "',nationalty='" + textBox19.Text + "',datejoined='" + dateTimePicker3.Value + "',email='" + textBox18.Text + "',gender='" + comboBox2.Text + "',village='" + textBox17.Text + "' where id=" + textBox16.Text + " ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("details updated successfully");
                con.Close();
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete  from employee where id='" + textBox16.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("deleted successfully");
                con.Close();
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("enter valid PNR!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select PNR,flight_no,name,age,phone,source,destination,journeydate,cost from pass_details where PNR='" + textBox8.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                MessageBox.Show("enter flight No.!!!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select flight_no,PNR,name,age,phone,source,destination,journeydate,username from pass_details where flight_no='" + textBox9.Text + "'and journeydate='" + dateTimePicker2.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                con.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    con.Open();
            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "insert into airport(a_name,a_location,type,airport_id) values('" + this.textBox10.Text + "','" + this.textBox11.Text + "','" + this.comboBox3.Text + "','" + this.textBox13.Text + "')";
            //    cmd.ExecuteNonQuery();
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        this.Hide();

            //        this.textBox10.Text = (dr["a_name"].ToString());
            //        this.textBox11.Text = (dr["a_location"].ToString());
            //        this.comboBox3.Text = (dr["type"].ToString());
            //        this.textBox13.Text = (dr["airport_id"].ToString());
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

          
           
        }
    }
}
