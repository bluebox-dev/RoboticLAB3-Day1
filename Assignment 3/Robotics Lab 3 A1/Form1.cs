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
        private VideoCapture _capture = null;
        private bool _captureInProgress;
        private Mat _frame;
        public Form1()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            try
            {
                _capture = new VideoCapture(0);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
            _frame = new Mat();
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

        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                _capture.Retrieve(_frame, 0);

                pictureBox1.Image = _frame.ToBitmap();
                IMG = new Image<Bgr, byte>(_frame);
            }
        }

        Image<Gray, byte> Red = null;
        private void button4_Click(object sender, EventArgs e)
        {
            if (IMG != null)
            {
                Red = IMG[0];
                pictureBox1.Image = Red.ToBitmap();
                histogramBox1.ClearHistogram();
                histogramBox1.GenerateHistograms(Red, 256);
                histogramBox1.Refresh();
            }
        }
    }
}
