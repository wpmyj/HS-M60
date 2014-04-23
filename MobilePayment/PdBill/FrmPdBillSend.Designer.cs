namespace MobilePayment.PdBill
{
    partial class FrmPdBillSend
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
            this.components = new System.ComponentModel.Container();
            this.dBPdDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbCkCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPdDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dBPdDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dBPdDataBindingSource
            // 
            this.dBPdDataBindingSource.AllowNew = false;
            this.dBPdDataBindingSource.DataSource = typeof(Model.DBModel.DBPdData);
            // 
            // dgBillMx
            // 
            this.dgBillMx.DataSource = this.dBPdDataBindingSource;
            this.dgBillMx.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.dgBillMx.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // tbCkCode
            // 
            this.tbCkCode.Location = new System.Drawing.Point(164, 13);
            this.tbCkCode.Name = "tbCkCode";
            this.tbCkCode.ReadOnly = true;
            this.tbCkCode.Size = new System.Drawing.Size(73, 23);
            this.tbCkCode.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(125, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "仓库";
            // 
            // tbPdDate
            // 
            this.tbPdDate.Location = new System.Drawing.Point(43, 13);
            this.tbPdDate.Name = "tbPdDate";
            this.tbPdDate.ReadOnly = true;
            this.tbPdDate.Size = new System.Drawing.Size(70, 23);
            this.tbPdDate.TabIndex = 14;
            this.tbPdDate.Text = "2013-01-01";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "日期";
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.MappingName = "DBPdData";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "品名";
            this.dataGridTextBoxColumn1.MappingName = "PluName";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 125;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "F2";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "售价";
            this.dataGridTextBoxColumn2.MappingName = "Price";
            this.dataGridTextBoxColumn2.NullText = "0.00";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "数量";
            this.dataGridTextBoxColumn3.MappingName = "SjCount";
            this.dataGridTextBoxColumn3.NullText = "0";
            // 
            // FrmPdBillSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tbCkCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPdDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPdBillSend";
            this.Text = "FrmPdBillSend";
            this.Load += new System.EventHandler(this.FrmPdBillSend_Load);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.dgBillMx, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbPdDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbCkCode, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dBPdDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbCkCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPdDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dBPdDataBindingSource;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
    }
}