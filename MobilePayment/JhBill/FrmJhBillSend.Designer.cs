namespace MobilePayment.JhBill
{
    partial class FrmJhBillSend
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
            this.dBJhBillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLrUser = new System.Windows.Forms.TextBox();
            this.tbCheckUser = new System.Windows.Forms.TextBox();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dBJhBillBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dBJhBillBindingSource
            // 
            this.dBJhBillBindingSource.AllowNew = false;
            this.dBJhBillBindingSource.DataSource = typeof(Model.DBModel.DBJhBill);
            // 
            // dgBillMx
            // 
            this.dgBillMx.DataSource = this.dBJhBillBindingSource;
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "录入人";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(120, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "核检人";
            // 
            // tbLrUser
            // 
            this.tbLrUser.BackColor = System.Drawing.Color.Black;
            this.tbLrUser.ForeColor = System.Drawing.Color.White;
            this.tbLrUser.Location = new System.Drawing.Point(59, 14);
            this.tbLrUser.Name = "tbLrUser";
            this.tbLrUser.ReadOnly = true;
            this.tbLrUser.Size = new System.Drawing.Size(60, 23);
            this.tbLrUser.TabIndex = 12;
            // 
            // tbCheckUser
            // 
            this.tbCheckUser.BackColor = System.Drawing.Color.Black;
            this.tbCheckUser.ForeColor = System.Drawing.Color.White;
            this.tbCheckUser.Location = new System.Drawing.Point(172, 14);
            this.tbCheckUser.Name = "tbCheckUser";
            this.tbCheckUser.ReadOnly = true;
            this.tbCheckUser.Size = new System.Drawing.Size(60, 23);
            this.tbCheckUser.TabIndex = 13;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.MappingName = "DBJhBill";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "品名";
            this.dataGridTextBoxColumn1.MappingName = "PluName";
            this.dataGridTextBoxColumn1.Width = 125;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "采购数";
            this.dataGridTextBoxColumn2.MappingName = "CgCount";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "验收数";
            this.dataGridTextBoxColumn3.MappingName = "SsCount";
            // 
            // FrmJhBillSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tbCheckUser);
            this.Controls.Add(this.tbLrUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmJhBillSend";
            this.Text = "FrmJhBillSend";
            this.Load += new System.EventHandler(this.FrmJhBillSend_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.dgBillMx, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbLrUser, 0);
            this.Controls.SetChildIndex(this.tbCheckUser, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dBJhBillBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLrUser;
        private System.Windows.Forms.TextBox tbCheckUser;
        private System.Windows.Forms.BindingSource dBJhBillBindingSource;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
    }
}