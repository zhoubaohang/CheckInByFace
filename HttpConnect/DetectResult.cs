using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpConnect
{
    public class DetectResult
    {
        public string image_id { get; set; }
        public string request_id { get; set; }
        public int time_used { get; set; }

        public List<Face> faces { get; set; }

    }

    public class Face
    {
        public FaceRectangle face_rectangle { get; set; }
        public string face_token { get; set; }

    }

    public class FaceRectangle
    {
        public int width { get; set; }
        public int top { get; set; }
        public int left { get; set; }
        public int height { get; set; }

    }
}
