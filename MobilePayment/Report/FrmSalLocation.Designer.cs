namespace MobilePayment.Report
{
    partial class FrmSalLocation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxbFlowNo = new System.Windows.Forms.TextBox();
            this.TxbOperator = new System.Windows.Forms.TextBox();
            this.TxbVipCardno = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "流水号";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "会员号";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.Text = "操作员";
            // 
            // TxbFlowNo
            // 
            this.TxbFlowNo.Location = new System.Drawing.Point(64, 10);
            this.TxbFlowNo.Name = "TxbFlowNo";
            this.TxbFlowNo.Size = new System.Drawing.Size(100, 23);
            this.TxbFlowNo.TabIndex = 3;
            // 
            // TxbOperator
            // 
            this.TxbOperator.Location = new System.Drawing.Point(64, 60);
            this.TxbOperator.Name = "TxbOperator";
            this.TxbOperator.Size = new System.Drawing.Size(100, 23);
            this.TxbOperator.TabIndex = 4;
            // 
            // TxbVipCardno
            // 
            this.TxbVipCardno.Location = new System.Drawing.Point(64, 106);
            this.TxbVipCardno.Name = "TxbVipCardno";
            this.TxbVipCardno.Size = new System.Drawing.Size(100, 23);
            this.TxbVipCardno.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 6;
            this.button1.TabStop = false;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmSalDetaiLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(183, 178);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxbVipCardno);
            this.Controls.Add(this.TxbOperator);
            this.Controls.Add(this.TxbFlowNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSalDetaiLocation";
            this.Text = "流水定位";
            this.Load += new System.EventHandler(this.FrmSalDetaiLocation_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSalDetaiLocation_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxbFlowNo;
        private System.Windows.Forms.TextBox TxbOperator;
        private System.Windows.Forms.TextBox TxbVipCardno;
        private System.Windows.Forms.Button button1;
    }
}