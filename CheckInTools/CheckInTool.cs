using SQLDBTool;
using AForge.Controls;
using System.Windows.Forms;
using FaceCompareTool;

namespace CheckInTools
{
    public class CheckInTool
    {
        private static double PASS_MINNEST_PERCENT = 80.0;

        private SQLDBHelper db = null;
        private CameraTool.CameraTool camera = null;
        private FaceCompareTools FCTool = null;
        private DataGridView DGV_HasCome = null;
        private DataGridView DGV_UnCome = null;

        public CheckInTool(VideoSourcePlayer videoSource, DataGridView hasCome, DataGridView unCome)
        {
            db = new SQLDBHelper();
            camera = new CameraTool.CameraTool(videoSource);
            FCTool = new FaceCompareTools();
            this.DGV_HasCome = hasCome;
            this.DGV_UnCome = unCome;
        }
        /// <summary>
        /// 每次开始签到时，进行 CheckIn 表的更新
        /// </summary>
        public void LoadCheckIn()
        {
            string timeNow = System.DateTime.Now.ToString("yyyy-MM-dd");
            db.UpdateCheckInTable(timeNow);
            this.UpdateDataGridView();
        }
        /// <summary>
        /// 更新 DataGridView 控件数据
        /// </summary>
        private void UpdateDataGridView()
        {
            this.DGV_HasCome.DataSource = db.queryUsersByState(true);
            this.DGV_UnCome.DataSource = db.queryUsersByState(false);
        }

        /// <summary>
        /// 开始签到
        /// </summary>
        public void StartCheckIn()
        {
            camera.OpenCamera();
        }
        /// <summary>
        /// 结束签到
        /// </summary>
        public void StopCheckIn()
        {
            camera.CloseCamera();
        }
        /// <summary>
        /// 进行面部识别
        /// </summary>
        /// <param name="id">用户的身份号码 id</param>
        /// <returns>true：识别成功  false：识别失败</returns>
        public bool CheckIn(string id)
        {
            bool result = false;
            string imagePath = db.SelectFaceImagesPath(id);
            if (System.IO.File.Exists(imagePath) == true)
            {
                string tmpPath = "tmp" + id + ".jpg";
                camera.CatchPhotoeAndSave(tmpPath);
                double comRes = 0.0;
                comRes = FCTool.CompareFace(imagePath, tmpPath);
                if (comRes >= PASS_MINNEST_PERCENT)
                {
                    db.UpdateUserStatue(id);
                    this.UpdateDataGridView();
                    result = true;
                }
                else
                {
                    //MessageBox.Show("对不起，签到失败....");
                }
                if (System.IO.File.Exists(tmpPath) == true)
                {
                    System.IO.File.Delete(tmpPath);
                }
            }
            else
            {
                MessageBox.Show("未找到您的人脸信息图片，请联系管理员...");
            }
            return result;
        }
    }
}
