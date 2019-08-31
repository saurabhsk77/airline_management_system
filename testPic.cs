using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airlinemanagement
{
    public partial class testPic : UserControl
    {
        public testPic()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                //pictureBox1.Image = null;
                //Image img = Image.FromFile(@"C:\Users\Saurabh\Desktop\FS.png");
                //pictureBox5.Image = img;
                //pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
                //pictureBox5.Location = new Point(3, 43);
                //pictureBox5.Size = new Size(59, 50);
                //ratingLabel.Text = "TEST";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
