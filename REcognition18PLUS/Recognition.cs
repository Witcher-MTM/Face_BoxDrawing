using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;

namespace REcognition18PLUS
{
    public class Recognition
    {
        private BasicAWSCredentials awsCredentials { get; set; }
        private AmazonRekognitionClient rekClient { get; set; }
        public string ResLabel { get; set; }
        public string Bucket { get; set; }

        public Recognition()
        {
             awsCredentials = new BasicAWSCredentials("AKIA2SEVNCMGZ3GCJV5X", "zYAzTTLzYYGrr/tZ1E4Vw4MRSF1UA+uw47Fqn6yi");
             rekClient = new AmazonRekognitionClient(awsCreden‌tials, Amazon.RegionEndpoint.USEast1);
          
        }
        public void FindLabels(string photo)
        {
            var image = new Amazon.Rekognition.Model.Image();
            using (var fs = new FileStream(photo, FileMode.Open, FileAccess.Read))
            {
                byte[] data = null;
                data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                image.Bytes = new MemoryStream(data);
            }


            DetectLabelsRequest detectlabelsRequest = new DetectLabelsRequest()
            {
                Image = image,
                MaxLabels = 10,
                MinConfidence = 75F
            };

            try
            {
                DetectLabelsResponse detectLabelsResponse = rekClient.DetectLabels(detectlabelsRequest);
                foreach (Amazon.Rekognition.Model.Label label in detectLabelsResponse.Labels)
                    ResLabel += $"{label.Name}\n";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public async void FindFaces(string pathImage, PictureBox pictureBox)
        {
            string photo = pathImage;
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

                DetectFacesResponse detectFacesResponse = await rekClient.DetectFacesAsync(detectFacesRequest);
                detectFacesResponse.FaceDetails.ForEach(face =>
                {

                    ShowBoundingBoxPositions(
                        pictureBox,
                        face.BoundingBox,
                        face.AgeRange);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void ShowBoundingBoxPositions(PictureBox pictureBox, BoundingBox box, AgeRange age)
        {

            float top = (box.Top * pictureBox.Height);
            float left = (box.Left * pictureBox.Width);
            float right = pictureBox.Width * box.Width;
            float bottom = pictureBox.Height * box.Height;
            Graphics graphic_picture = pictureBox.CreateGraphics();
            graphic_picture.DrawRectangle(new Pen(Color.Aqua, 3f), left, top, right, bottom);
        }

       

    }

}
