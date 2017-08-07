using System.Drawing;

namespace FaceCompareTool
{
    public class Face
    {
        public string fileName { get; set; }
        public string face_token { get; set; }

        public Bitmap image { get; set; }

        public void saveImage()
        {
            if (image != null)
            {
                this.image.Save(this.fileName);
                this.image.Dispose();
            }
        }

    }
}
