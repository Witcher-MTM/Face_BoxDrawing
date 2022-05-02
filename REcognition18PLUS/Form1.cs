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
        public Form1()
        {
            InitializeComponent();
            res = string.Empty;
        }

        private void img_add_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "png|*.png|jpeg|*.jpeg";

                
               if(file.ShowDialog() == DialogResult.OK)
               {
                    this.pictureBox1.Image = System.Drawing.Image.FromFile(file.FileName);
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    Main(file.FileName);
               }

            }
            
        }
        public async Task Main(string pathImage)
        {
            string photo = pathImage;

            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials("AKIA2SEVNCMGZ3GCJV5X", "zYAzTTLzYYGrr/tZ1E4Vw4MRSF1UA+uw47Fqn6yi");
            var rekognitionClient = new Amazon.Rekognition.AmazonRekognitionClient(awsCreden‌tials, Amazon.RegionEndpoint.USEast1);

            var image = new Amazon.Rekognition.Model.Image();
            try
            {
                using (var fs = new FileStream(photo, FileMode.Open, FileAccess.Read))
                {
                    byte[] data = null;
                    data = new byte[fs.Length];
                    fs.Read(data, 0, (int)fs.Length);
                    image.Bytes = new MemoryStream(data);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load file " + photo);
                return;
            }

            int height;
            int width;

            // Used to extract original photo width/height
            using (var imageBitmap = new Bitmap(photo))
            {
                height = imageBitmap.Height;
                width = imageBitmap.Width;
            }

            try
            {
                var detectFacesRequest = new DetectFacesRequest()
                {
                    Image = image,
                    Attributes = new List<string>() { "ALL" },
                };

                DetectFacesResponse detectFacesResponse = await rekognitionClient.DetectFacesAsync(detectFacesRequest);
                detectFacesResponse.FaceDetails.ForEach(face =>
                {
                  
                    ShowBoundingBoxPositions(
                        height,
                        width,
                        face.BoundingBox,
                        face.AgeRange);
                   
                });
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            
        }

        
        public void ShowBoundingBoxPositions(int imageHeight, int imageWidth, BoundingBox box, AgeRange age)
        {
           
            float top = (box.Top * pictureBox1.Height);
            float left = (box.Left * pictureBox1.Width);
            float right = pictureBox1.Width * box.Width;
            float bottom = pictureBox1.Height * box.Height;
             MessageBox.Show("Drawing rects");

            Graphics graphic_picture = this.pictureBox1.CreateGraphics();
            graphic_picture.DrawRectangle(new Pen(Color.Aqua,3f),left,top,right,bottom);
            graphic_picture.DrawString($"{age.High.ToString()}-Age",new Font(FontFamily.GenericSansSerif,15f),Brushes.GreenYellow,new PointF(left,right));
        }

        private void clearpicture_btn_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
        }
    }
}
