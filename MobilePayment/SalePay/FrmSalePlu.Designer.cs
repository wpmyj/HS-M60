namespace MobilePayment.SalePay
{
    partial class FrmSalePlu
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
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxbCount = new System.Windows.Forms.TextBox();
            this.TxbPrice = new System.Windows.Forms.TextBox();
            this.TxbPluName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxbBarcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxbVipDsc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxbVipName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxbVipCardNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_1.Text = "会员卡";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_2.Text = "行清";
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_3.Text = "数量";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.button_4.Text = "结算";
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.Text = "条码";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.Text = "原价";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.TxbCount);
            this.panel1.Controls.Add(this.TxbPrice);
            this.panel1.Controls.Add(this.TxbPluName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxbBarcode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 87);
            // 
            // TxbCount
            // 
            this.TxbCount.Location = new System.Drawing.Point(195, 58);
            this.TxbCount.Name = "TxbCount";
            this.TxbCount.Size = new System.Drawing.Size(31, 23);
            this.TxbCount.TabIndex = 19;
            this.TxbCount.Text = "9999";
            this.TxbCount.TextChanged += new System.EventHandler(this.TxbCount_TextChanged);
            // 
            // TxbPrice
            // 
            this.TxbPrice.Location = new System.Drawing.Point(61, 58);
            this.TxbPrice.Name = "TxbPrice";
            this.TxbPrice.ReadOnly = true;
            this.TxbPrice.Size = new System.Drawing.Size(63, 23);
            this.TxbPrice.TabIndex = 17;
            this.TxbPrice.Text = "9999.99";
            // 
            // TxbPluName
            // 
            this.TxbPluName.Location = new System.Drawing.Point(60, 29);
            this.TxbPluName.Name = "TxbPluName";
            this.TxbPluName.ReadOnly = true;
            this.TxbPluName.Size = new System.Drawing.Size(166, 23);
            this.TxbPluName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.Text = "品名";
            // 
            // TxbBarcode
            // 
            this.TxbBarcode.Location = new System.Drawing.Point(60, 0);
            this.TxbBarcode.Name = "TxbBarcode";
            this.TxbBarcode.Size = new System.Drawing.Size(166, 23);
            this.TxbBarcode.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(136, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.Text = "件数";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.TxbVipDsc);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.TxbVipName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TxbVipCardNo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 66);
            // 
            // TxbVipDsc
            // 
            this.TxbVipDsc.Location = new System.Drawing.Point(195, 34);
            this.TxbVipDsc.Name = "TxbVipDsc";
            this.TxbVipDsc.ReadOnly = true;
            this.TxbVipDsc.Size = new System.Drawing.Size(31, 23);
            this.TxbVipDsc.TabIndex = 10;
            this.TxbVipDsc.Text = "90";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(136, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.Text = "折扣";
            // 
            // TxbVipName
            // 
            this.TxbVipName.Location = new System.Drawing.Point(61, 34);
            this.TxbVipName.Name = "TxbVipName";
            this.TxbVipName.ReadOnly = true;
            this.TxbVipName.Size = new System.Drawing.Size(64, 23);
            this.TxbVipName.TabIndex = 3;
            this.TxbVipName.Text = "王某某某";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "姓名";
            // 
            // TxbVipCardNo
            // 
            this.TxbVipCardNo.Location = new System.Drawing.Point(61, 8);
            this.TxbVipCardNo.Name = "TxbVipCardNo";
            this.TxbVipCardNo.ReadOnly = true;
            this.TxbVipCardNo.Size = new System.Drawing.Size(165, 23);
            this.TxbVipCardNo.TabIndex = 1;
            this.TxbVipCardNo.Text = "1234567890123";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.Text = "卡号";
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = false;
            this.bindingSource1.DataSource = typeof(Model.TSalSalePlu);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.DataSource = this.bindingSource1;
            this.dataGrid1.Location = new System.Drawing.Point(3, 165);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(234, 96);
            this.dataGrid1.TabIndex = 16;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            this.dataGrid1.TabStop = false;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.MappingName = "TSalSalePlu";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "行";
            this.dataGridTextBoxColumn1.MappingName = "SerialNo";
            this.dataGridTextBoxColumn1.Width = 20;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.MappingName = "PluName";
            this.dataGridTextBoxColumn2.Width = 108;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "F2";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "金额";
            this.dataGridTextBoxColumn3.MappingName = "FsPrice";
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "数量";
            this.dataGridTextBoxColumn4.MappingName = "XsCount";
            this.dataGridTextBoxColumn4.Width = 30;
            // 
            // FrmSalePlu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSalePlu";
            this.Text = "FrmSalePlu";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.FrmSalePlu_Load);
            this.Activated += new System.EventHandler(this.FrmSalePlu_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmSalePlu_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSalePlu_KeyDown);
            this.Controls.SetChildIndex(this.dataGrid1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxbBarcode;
        private System.Windows.Forms.TextBox TxbCount;
        private System.Windows.Forms.TextBox TxbPrice;
        private System.Windows.Forms.TextBox TxbPluName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxbVipName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxbVipCardNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxbVipDsc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
    }
}