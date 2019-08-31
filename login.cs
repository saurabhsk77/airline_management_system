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
    public partial class login : Form
    {

        MemoryStream ms;
        test tt = new test();
        public static string passingtext;
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            signup su = new signup();
            su.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginMethod();
            
        }

        public void loginMethod()
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Saurabh\Documents\USERREGISTRATION.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            cmd = new SqlCommand("select * from Signup where username collate Latin1_General_CS_AS = '" + textBox1.Text + "'and password collate Latin1_General_CS_AS = '" + textBox2.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                this.Hide();
                main mm = new main();
                mm.textBox1.Text = (dr["firstname"].ToString());
                mm.textBox2.Text = (dr["lastname"].ToString());
                mm.textBox3.Text = (dr["phone"].ToString());
                mm.textBox4.Text = (dr["email"].ToString());
                mm.textBox5.Text = dr["username"].ToString();
                passingtext = textBox1.Text;
                mm.Show();
            }
            else
            {
                MessageBox.Show("user authentication fail");
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loginMethod();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
