using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

using System.Windows.Forms;

namespace airlinemanagement
{
    public partial class imagetest : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Saurabh\Documents\USERREGISTRATION.mdf;Integrated Security=True;Connect Timeout=30");

        public imagetest()
        {
            InitializeComponent();
        }

        private void chotusala_Load(object sender, EventArgs e)
        {
            con.Open();
            string q_ = "select * from imgTest";
            SqlCommand cmd = new SqlCommand(q_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                // MemoryStream ms = new MemoryStream((byte[])dr["Images"]);

               pictureBox1.Image = Image.FromFile(dr["img"].ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
