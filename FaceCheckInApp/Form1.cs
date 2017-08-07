using System;
using System.Windows.Forms;
using AutoSizeForm;
using CheckInTools;

namespace FaceCheckInApp
{
    public partial class Form1 : Form
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        CheckInTool checkTool = null;
        bool flag = false;

        private readonly static string SUCCESS = "签到成功！";
        private readonly static string FAILED = "签到失败！";
        private readonly static string HASCOMERNUMBER = "已到人数为：";
        private readonly static string UNCOMERNUMBER = "未到人数为：";


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                checkTool.LoadCheckIn();
                checkTool.StartCheckIn();
                flag = true;
            }
            UpdatePeopleNumber();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag == true)
            {
                checkTool.StopCheckIn();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Result.Text = "";
            if (flag == true)
            {
                if (tb_id.Text == "")
                {
                    MessageBox.Show("请到 未到列表 点击你的姓名 ");
                }
                else
                {
                    if (checkTool.CheckIn(tb_id.Text) == true)
                    {
                        Result.Text = SUCCESS;
                    }
                    else
                    {
                        Result.Text = FAILED;
                    }
                }
            }
            else
            {
                MessageBox.Show("请点击 开始签到 按钮... ");
            }
            UpdatePeopleNumber();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            checkTool = new CheckInTool(videoSourcePlayer1, HasComeData, UnComeData);
            UpdatePeopleNumber();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                checkTool.StopCheckIn();
                flag = false;
            }
        }

        private void UpdatePeopleNumber()
        {
            UnComerNumber.Text = UNCOMERNUMBER + UnComeData.RowCount;
            HasComerNumber.Text = HASCOMERNUMBER + HasComeData.RowCount;
        }

        private void UnComeData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tb_name.Text = UnComeData.Rows[e.RowIndex].Cells["姓名"].Value.ToString().Trim();
                tb_id.Text = UnComeData.Rows[e.RowIndex].Cells["身份号码"].Value.ToString().Trim();
            }
        }

    }
}
