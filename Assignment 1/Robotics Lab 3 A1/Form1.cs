using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
namespace Robotics_Lab_3_A1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Image<Bgr, byte> IMG = null;
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    IMG = new Image<Bgr, byte>(openFileDialog1.FileName);
                    pictureBox1.Image = IMG.ToBitmap();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IMG != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    IMG.Save(saveFileDialog.FileName);
                }
            }
        }

    }
}
