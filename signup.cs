using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace airlinemanagement
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
            textBox3.Mask = "##########";
            textBox4.Mask = "################";
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Saurabh\Documents\USERREGISTRATION.mdf;Integrated Security=True;Connect Timeout=30");

        public string imageLocation = "";

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private byte[] convertToImgArray()
        {

            Image img = new Bitmap(picLabel.Text);
            //picLabel.Text = "";
            MemoryStream stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imgByteArray = stream.ToArray();
            return imgByteArray;
        }





        private void button1_Click(object sender, EventArgs e)
        {
            //private void textBox5_Leave(object sender, EventArgs e)
            //{
            //try
            //{
            //    string pattern = "^([0-9a-zA-Z](-\\.\\w])*[0-9a-zA-Z][.\\w]*@([0-9a-zA-Z](-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            //    if (Regex.IsMatch(textBox5.Text, pattern))
            //    {
            //        errorProvider1.Clear();
            //    }
            //    else
            //    {
            //        errorProvider1.SetError(this.textBox5, "please provide valid mail address");
            //        return;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            if (textBox6.Text == "" || textBox7.Text == "" || picLabel.Text=="" )
                MessageBox.Show("please fill mandatory fields and upload image");
            else if (textBox7.Text != textBox8.Text)
                MessageBox.Show("password do not match");
           
            else
            {
                try
                {
                    string str = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=C:\USERS\SAURABH\DOCUMENTS\USERREGISTRATION.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    string query = "insert into Signup(firstname,lastname,phone,aadhar,email,gender,username,password, img) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.comboBox1.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "','" + picLabel.Text + "');";
                    SqlConnection con = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("registered successfully");
                    this.Hide();
                    login mm = new login();
                    mm.Show();
                }
                catch (Exception)
                {

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select an image";
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*"; //mast
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picLabel.Text = dialog.FileName;
               pictureBox2.Image = new Bitmap(dialog.FileName);
            }
        }

        private void picLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            try
            {
                const string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
                if (Regex.IsMatch(textBox5.Text, pattern))
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool nameExists()
        {
            if (con.State == ConnectionState.Closed){
                con.Open();
                string q_ = "select * from Signup where username = '" + textBox6.Text + "';";
                SqlCommand cmd = new SqlCommand(q_, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                        return true;
                    else return false;
                }
            }
            else if(con.State == ConnectionState.Open)
                con.Close();
            return false;

        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (nameExists())
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider1.SetError(textBox6, "Name already exists");
            }
            else if (!nameExists())
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }

        private void textBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            login f1 = new login();
            f1.ShowDialog();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void textBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
