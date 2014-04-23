namespace MobilePayment
{
    partial class FrmBase
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.button_1 = new System.Windows.Forms.Button();
            this.button_2 = new System.Windows.Forms.Button();
            this.button_3 = new System.Windows.Forms.Button();
            this.button_4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 296);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(240, 24);
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_1.Location = new System.Drawing.Point(0, 267);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(60, 30);
            this.button_1.TabIndex = 1;
            this.button_1.Text = "button1";
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_2.Location = new System.Drawing.Point(60, 267);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(60, 30);
            this.button_2.TabIndex = 2;
            this.button_2.Text = "button2";
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_3.Location = new System.Drawing.Point(120, 267);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(60, 30);
            this.button_3.TabIndex = 3;
            this.button_3.Text = "button3";
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_4.Location = new System.Drawing.Point(180, 267);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(60, 30);
            this.button_4.TabIndex = 5;
            this.button_4.Text = "返回";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.button_4);
            this.Controls.Add(this.button_3);
            this.Controls.Add(this.button_2);
            this.Controls.Add(this.button_1);
            this.Controls.Add(this.statusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBase";
            this.Text = "FrmBase";
            this.Load += new System.EventHandler(this.FrmBase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBar statusBar1;
        protected System.Windows.Forms.Button button_1;
        protected System.Windows.Forms.Button button_2;
        protected System.Windows.Forms.Button button_3;
        protected System.Windows.Forms.Button button_4;
        private System.Windows.Forms.Timer timer1;
    }
}