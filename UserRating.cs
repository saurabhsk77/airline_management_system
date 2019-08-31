using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace airlinemanagement
{
    public partial class UserRating : UserControl
    {
        public UserRating()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Saurabh\Documents\USERREGISTRATION.mdf;Integrated Security=True;Connect Timeout=30");


        private void ratingButton_Click(object sender, EventArgs e)
        {
            conn.Open();
            String q_ = "insert into ratingTable(userName, rating) values(@name, @rating)";
            SqlCommand cmd = new SqlCommand(q_, conn);
            cmd.Parameters.AddWithValue("@name", ratingName.Text);
            cmd.Parameters.AddWithValue("@rating", main.val);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Thanks for rating");

        }
    }
}
