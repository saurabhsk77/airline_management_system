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
using System.IO;

namespace airlinemanagement
{
    public partial class main : Form
    {
        
        public static byte[] shit; //wow
        public static int val = 0;
        static int no_of_clicks = 1;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Saurabh\Documents\USERREGISTRATION.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda = new SqlDataAdapter();


        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
           
            timer1.Start();
            label25.Text = DateTime.Now.ToLongDateString();
            label26.Text = DateTime.Now.ToLongTimeString();
            updateGrid();
            if (textBox5.Text != "aa")
            {
                pictureBox4.Hide();
            }
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox8.BackColor = Color.Transparent;
            pictureBox9.BackColor = Color.Transparent;
           
                conn.Open();
                string q_ = "select img from Signup where username = '" + textBox5.Text + "'";
                SqlCommand cmd5 = new SqlCommand(q_, conn);
                SqlDataReader dr = cmd5.ExecuteReader();
            if (dr.Read())
            {
                avatarbox.Image = Image.FromFile(dr["img"].ToString());
                avatarbox.SizeMode = PictureBoxSizeMode.Zoom;
            }
                //cmd5.Parameters.AddWithValue("@val", textBox5.Text);
                dr.Close();

           

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from flight_search";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            dr.Close();
            
            
            //DataTable dp = new DataTable();
            //SqlDataAdapter daa = new SqlDataAdapter(cmd);
            //daa.Fill(dp);

            //dataGridView3.DataSource = dp;
            conn.Close();
            //display1();
            //display();




        }

        public void updateGrid()
        {
            conn.Open();
            string q_ = "select * from pass_details where username='" + textBox5.Text + "'";
            SqlCommand cmd = new SqlCommand(q_, conn);
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                int n = dataGridView3.Rows.Add();
                if (dr1.HasRows)
                {
                    dataGridView3.Rows[n].Cells[0].Value = dr1["PNR"].ToString();
                    dataGridView3.Rows[n].Cells[1].Value = dr1["flight_no"].ToString();
                    dataGridView3.Rows[n].Cells[2].Value = dr1["name"].ToString();
                    dataGridView3.Rows[n].Cells[3].Value = dr1["age"].ToString();
                    dataGridView3.Rows[n].Cells[4].Value = dr1["email"].ToString();
                    dataGridView3.Rows[n].Cells[5].Value = dr1["address"].ToString();
                    dataGridView3.Rows[n].Cells[6].Value = dr1["phone"].ToString();
                    dataGridView3.Rows[n].Cells[7].Value = dr1["source"].ToString();
                    dataGridView3.Rows[n].Cells[8].Value = dr1["destination"].ToString();
                    dataGridView3.Rows[n].Cells[9].Value = dr1["cost"].ToString();
                    dataGridView3.Rows[n].Cells[10].Value = dr1["username"].ToString();
                    dataGridView3.Rows[n].Cells[11].Value = dr1["journeydate"].ToString();
                    dataGridView3.Rows[n].Cells[12].Value = dr1["seats"].ToString();
                }
            }
            conn.Close();
        }
        

        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void bOOKAFLIGHTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //main mm = new main();
            //mm.Show();
        }

        private void menuStrip5_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            login f1 = new login();
            f1.Show();
        }

        private void fLIGHTSCHEDULESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "aa")
            {
                updation up = new updation();
                up.Show();
            }
            else
            {
                MessageBox.Show("page under construction", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == comboBox2.Text)
                {
                    MessageBox.Show("no flight match!!");
                }
                else if (comboBox1.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Enter the mandatory field");
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from flight_search where source='" + comboBox1.Text + "' and destination='" + comboBox2.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }




        private void tabPage9_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from flight_search";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                Refresh();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HOME_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void mANAGEYOURTRIPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        void display()
        {
            try
            {
                
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *  from flight_search";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            string a1 = dateTimePicker1.Text.ToString(); 
            try
            {
                if (comboBox1.Text == comboBox2.Text)
                {
                    MessageBox.Show("no flight match!!");
                }
                else if (comboBox1.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Enter the mandatory field");
                }
                else
                {
                   
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                   
                     cmd.CommandText = "Select * from flight_search where source='" + comboBox1.Text + "' and destination='" + comboBox2.Text + "'";
                     cmd.ExecuteNonQuery();
                    
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    
                    conn.Close();
                    
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            main mm = new main();
            mm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            reservation m = new reservation();//eh nhi hai
            m.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            m.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            m.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
            m.ShowDialog();
            dataGridView1.Hide();
           


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "aa")
            {
                admin e1 = new admin();
                e1.Show(); //eh?
            }
            



        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void pictureBox5_Click(object sender, EventArgs e)
        {

            try
            {
                if (no_of_clicks == 1 || no_of_clicks == 0)
                {
                    val = 1;
                    pictureBox5.Visible = false;
                    container.Controls.Clear();
                    container.Controls.Add(new UserRating());
                    //obj.Show();

                    Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\FILLED.png");
                    pictureBox5.Image = img;
                    if (pictureBox5.Image == img)
                    {
                        ratingLabel.Text = "I hate it";
                    }
                    pictureBox5.Visible = true;

                    pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox5.Location = new Point(3, 3);
                    pictureBox5.Size = new Size(59, 50);

                    no_of_clicks = 10;

                }
                else
                {
                    no_of_clicks = 0;
                    pictureBox5.Visible = false;
                    Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\NOTFILLED.png");

                    pictureBox5.Image = img;
                    if (pictureBox5.Image == img)
                    {
                        ratingLabel.Text = "";
                    }
                    pictureBox6.Image = img;
                    pictureBox7.Image = img;
                    pictureBox8.Image = img;
                    pictureBox9.Image = img;
                    pictureBox5.Visible = true;
                    pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox5.Location = new Point(3, 3);
                    pictureBox5.Size = new Size(59, 50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //container.Controls.Clear();
            //container.Controls.Add(new testPic());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(no_of_clicks.ToString());
            if (no_of_clicks == 10 || no_of_clicks == 0)
            {


                container.Controls.Clear();

                container.Controls.Add(new UserRating());
                //obj.Show();

                Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\FILLED.png");


                val = 2;
                pictureBox6.Visible = false;
                pictureBox6.Image = img;
                if (pictureBox6.Image == img)
                {
                    ratingLabel.Text = "OK OK!";
                }




                pictureBox6.Visible = true;
                pictureBox5.Image = img;


                pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox6.Location = new Point(68, 3);
                pictureBox6.Size = new Size(59, 50);
                no_of_clicks = 11;
            }
            else
            {
                no_of_clicks = 0;
                pictureBox6.Visible = false;
                Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\NOTFILLED.png");
                val = 0;
                pictureBox6.Visible = true;
                pictureBox6.Image = img;
                if (pictureBox6.Image == img)
                {
                    ratingLabel.Text = " I hate it";
                }




                pictureBox7.Image = img;
                pictureBox8.Image = img;
                pictureBox9.Image = img;

                pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox6.Location = new Point(68, 3);
                pictureBox6.Size = new Size(59, 50);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            if (no_of_clicks == 11 || no_of_clicks == 0)
            {
                pictureBox7.Visible = false;

                container.Controls.Clear();
                container.Controls.Add(new UserRating());
                //obj.Show();

                Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\FILLED.png");


                val = 3;
                pictureBox7.Image = img;

                if (pictureBox7.Image == img)
                {
                    ratingLabel.Text = "I like it";
                }


                pictureBox6.Image = img;
                pictureBox5.Image = img;

                pictureBox7.Visible = true;
                pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox7.Location = new Point(133, 3);
                pictureBox7.Size = new Size(59, 50);

                no_of_clicks = 12;
            }
            else
            {
                no_of_clicks = 0;
                pictureBox7.Visible = false;
                Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\NOTFILLED.png");
                val = 0;
                //reBox7.Image = img;
                pictureBox8.Image = img;
                pictureBox7.Image = img;
                if (pictureBox7.Image == img)
                {
                    ratingLabel.Text = "OK OK!";
                }



                pictureBox9.Image = img;
                pictureBox7.Visible = true;
                pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox7.Location = new Point(133, 3);
                pictureBox7.Size = new Size(59, 50);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (no_of_clicks == 12 || no_of_clicks == 0)
            {
                pictureBox8.Visible = false;

                container.Controls.Clear();
                container.Controls.Add(new UserRating());


                Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\FILLED.png");


                val = 4;
                pictureBox8.Image = img;
                if (pictureBox8.Image == img)
                {
                    ratingLabel.Text = "It's kinda good";
                }


                pictureBox7.Image = img;
                pictureBox6.Image = img;
                pictureBox5.Image = img;

                pictureBox8.Visible = true;
                pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox8.Location = new Point(198, 3);
                pictureBox8.Size = new Size(59, 50);
                no_of_clicks = 13;
            }
            else
            {
                no_of_clicks = 0;
                pictureBox8.Visible = false;
                Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\NOTFILLED.png");
                val = 0;
                // pictureBox8.Image = img;
                pictureBox9.Image = img;
                pictureBox8.Image = img;

                if (pictureBox8.Image == img)
                {
                    ratingLabel.Text = "I like it";
                }
                pictureBox8.Visible = true;
                pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox8.Location = new Point(198, 3);
                pictureBox8.Size = new Size(59, 50);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (no_of_clicks == 13 || no_of_clicks == 0)
            {

                pictureBox9.Visible = false;

                //call usercontrol
                container.Controls.Clear();
                container.Controls.Add(new UserRating());

                Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\FILLED.png");



                val = 5;
                pictureBox9.Image = img;
                if (pictureBox9.Image == img)
                {
                    ratingLabel.Text = "I REALLY LOVE IT";
                }
                pictureBox8.Image = img;
                pictureBox7.Image = img;
                pictureBox6.Image = img;
                pictureBox5.Image = img;

                pictureBox9.Visible = true;
                pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox9.Location = new Point(263, 3);
                pictureBox9.Size = new Size(59, 50);
                no_of_clicks = 13337;
            }
            else
            {
                no_of_clicks = 0;
                pictureBox9.Visible = false;
                Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\NOTFILLED.png");
                val = 0;
                pictureBox9.Image = img;
                if (pictureBox9.Image == img)
                {
                    ratingLabel.Text = "It's kinda good";
                }

                pictureBox9.Visible = true;
                pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox9.Location = new Point(263, 3);
                pictureBox9.Size = new Size(59, 50);
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void sEARCHBYPNRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "aa")
            {
                admin ee = new admin();
                ee.Show();
            }
            else
            {
                MessageBox.Show("page under construction", "information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button3_Click_2(object sender, EventArgs e)
        {

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Signup set firstname='" + textBox1.Text + "',lastname='" + textBox2.Text + "',phone='" + textBox3.Text + "',email='" + textBox4.Text + "'where username='" + textBox5.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("details updated successfully");

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = (dr["firstname"].ToString());
                textBox2.Text = (dr["lastname"].ToString());
                textBox3.Text = (dr["phone"].ToString());
                textBox4.Text = (dr["email"].ToString());
                textBox5.Text = dr["username"].ToString();



            }



            conn.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("enter valid PNR!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    dataGridView1.Enabled = false;
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select PNR,flight_no,name,age,phone,source,destination,journeydate,cost from pass_details where PNR='" + textBox8.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
            }
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {
            //display1();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label26.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            //updateGrid();
        }
    }
}


