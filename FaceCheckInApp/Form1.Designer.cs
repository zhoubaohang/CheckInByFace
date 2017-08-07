namespace FaceCheckInApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.UnComeData = new System.Windows.Forms.DataGridView();
            this.HasComeData = new System.Windows.Forms.DataGridView();
            this.UnComerNumber = new System.Windows.Forms.Label();
            this.HasComerNumber = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UnComeData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasComeData)).BeginInit();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(450, 35);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(449, 289);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "开始签到";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(773, 332);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 59);
            this.button3.TabIndex = 3;
            this.button3.Text = "点击签到";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // UnComeData
            // 
            this.UnComeData.AllowUserToAddRows = false;
            this.UnComeData.AllowUserToDeleteRows = false;
            this.UnComeData.AllowUserToResizeColumns = false;
            this.UnComeData.AllowUserToResizeRows = false;
            this.UnComeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnComeData.Location = new System.Drawing.Point(12, 35);
            this.UnComeData.MultiSelect = false;
            this.UnComeData.Name = "UnComeData";
            this.UnComeData.ReadOnly = true;
            this.UnComeData.RowTemplate.Height = 23;
            this.UnComeData.Size = new System.Drawing.Size(212, 354);
            this.UnComeData.TabIndex = 4;
            this.UnComeData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UnComeData_CellClick);
            // 
            // HasComeData
            // 
            this.HasComeData.AllowUserToAddRows = false;
            this.HasComeData.AllowUserToDeleteRows = false;
            this.HasComeData.AllowUserToResizeColumns = false;
            this.HasComeData.AllowUserToResizeRows = false;
            this.HasComeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HasComeData.Location = new System.Drawing.Point(230, 35);
            this.HasComeData.MultiSelect = false;
            this.HasComeData.Name = "HasComeData";
            this.HasComeData.ReadOnly = true;
            this.HasComeData.RowTemplate.Height = 23;
            this.HasComeData.Size = new System.Drawing.Size(214, 354);
            this.HasComeData.TabIndex = 5;
            // 
            // UnComerNumber
            // 
            this.UnComerNumber.AutoSize = true;
            this.UnComerNumber.Font = new System.Drawing.Font("宋体", 10F);
            this.UnComerNumber.Location = new System.Drawing.Point(12, 12);
            this.UnComerNumber.Name = "UnComerNumber";
            this.UnComerNumber.Size = new System.Drawing.Size(77, 14);
            this.UnComerNumber.TabIndex = 6;
            this.UnComerNumber.Text = "未到人数：";
            // 
            // HasComerNumber
            // 
            this.HasComerNumber.AutoSize = true;
            this.HasComerNumber.Font = new System.Drawing.Font("宋体", 10F);
            this.HasComerNumber.Location = new System.Drawing.Point(227, 12);
            this.HasComerNumber.Name = "HasComerNumber";
            this.HasComerNumber.Size = new System.Drawing.Size(77, 14);
            this.HasComerNumber.TabIndex = 7;
            this.HasComerNumber.Text = "已到人数：";
            // 
            // button2
            // 
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Location = new System.Drawing.Point(613, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 59);
            this.button2.TabIndex = 8;
            this.button2.Text = "停止点到";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(448, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "姓名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(615, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "身份号码";
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("宋体", 10F);
            this.tb_name.Location = new System.Drawing.Point(489, 9);
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = true;
            this.tb_name.Size = new System.Drawing.Size(100, 23);
            this.tb_name.TabIndex = 11;
            // 
            // tb_id
            // 
            this.tb_id.Font = new System.Drawing.Font("宋体", 10F);
            this.tb_id.Location = new System.Drawing.Point(684, 9);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(100, 23);
            this.tb_id.TabIndex = 12;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("宋体", 12F);
            this.Result.ForeColor = System.Drawing.Color.Red;
            this.Result.Location = new System.Drawing.Point(809, 12);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(0, 16);
            this.Result.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(911, 403);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.HasComerNumber);
            this.Controls.Add(this.UnComerNumber);
            this.Controls.Add(this.HasComeData);
            this.Controls.Add(this.UnComeData);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Name = "Form1";
            this.Text = "人脸识别签到记录系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UnComeData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasComeData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView UnComeData;
        private System.Windows.Forms.DataGridView HasComeData;
        private System.Windows.Forms.Label UnComerNumber;
        private System.Windows.Forms.Label HasComerNumber;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label Result;
    }
}

