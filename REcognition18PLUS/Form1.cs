using Amazon.Rekognition.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REcognition18PLUS
{
    public partial class Form1 : Form
    {
        public static string res { get; set; }
        Recognition recognition = new Recognition();
        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void img_add_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "png|*.png|jpeg|*.jpeg";

                
               if(file.ShowDialog() == DialogResult.OK)
               {
                    this.pictureBox1.Image = System.Drawing.Image.FromFile(file.FileName);
                    recognition.FindFaces(file.FileName, this.pictureBox1);
                    recognition.FindLabels(file.FileName);
               }

            }
            
        }
        private void clearpicture_btn_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
        }

        private void label_check_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(recognition.ResLabel);
        }
    }
}
