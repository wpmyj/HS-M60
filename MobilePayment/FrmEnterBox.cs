﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePayment
{
    public partial class FrmEnterBox : Form
    {
        public FrmEnterBox()
        {
            InitializeComponent();
            this.Location =
                new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        /// <summary>
        /// 输入值
        /// </summary>
        public decimal Value
        {
            get;
            set;
        }

        private void FrmEnterBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter :
                    button1_Click(null, null);
                    break;
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("请输入！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                textBox1.Focus();
                return;
            }
            try
            {
                Value = decimal.Parse(textBox1.Text.Trim());
            }
            catch
            {
                MessageBox.Show("输入非法！");
                return;
            }
            textBox1.Text = string.Empty;
            this.DialogResult = DialogResult.OK;
        }

        private void FrmEnterBox_Load(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }
}