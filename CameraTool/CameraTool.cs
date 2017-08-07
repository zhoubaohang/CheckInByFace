using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video.DirectShow;
using AForge.Controls;
using System.Drawing;

namespace CameraTool
{
    public class CameraTool
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private int selectedDeviceIndex;
        private VideoSourcePlayer videoSourcePlayer;
        public CameraTool(VideoSourcePlayer videoSourcePlayer)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            selectedDeviceIndex = 0;
            videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头。
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            this.videoSourcePlayer = videoSourcePlayer;
            this.videoSourcePlayer.VideoSource = videoSource;
        }

        public bool isRuning()
        {
            if (this.videoSource == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void OpenCamera()
        {
            this.videoSourcePlayer.Start();
        }

        public void CloseCamera()
        {
            this.videoSourcePlayer.Stop();
        }

        public Bitmap CatchPhotoe()
        {
            Bitmap photo = null;
            photo = this.videoSourcePlayer.GetCurrentVideoFrame();
            return photo;
        }

        public void CatchPhotoeAndSave(string fileName)
        {
            Bitmap photoe = CatchPhotoe();
            if (photoe != null)
            {
                photoe.Save(fileName);
            }
        }
    }
}
