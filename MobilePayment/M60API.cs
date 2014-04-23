using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading; 

namespace MobilePayment
{
    public static class M60API
    {
        //打印相关
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "VAx_Camera_Flash")]
        public static extern int VAx_Camera_Flash(bool mode);

        //打印相关
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "Prn_Init")]
        public static extern int Prn_Init();  //初始化

        /*
         * 设置打印字间距、行间距 
         * x 字间距[点数]。默认字间距为0，最大值为255 
         * y 行间距[点数]。默认字间距为0，最大值为255 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "Prn_SetSpace")]
        public static extern void Prn_SetSpace(byte x, byte y);

        /*
         * 设置字体和放大参数 
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "Prn_SetFont")]
        public static extern int Prn_SetFont(byte AsciiFontHeight, byte ExtendFontHeight, byte Zoom);

        /*
         * 获取打印字体和放大参数 
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "Prn_GetFont")]
        public static extern int Prn_GetFont(byte AsciiFontHeight, byte ExtendFontHeight, byte Zoom);

        /*
         * 送字符串打印数据到打印缓冲
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "Prn_Str")]
        public static extern int Prn_Str(byte[] fmt);

        /*
         * 启动打印
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "Prn_Start")]
        public static extern int Prn_Start();

        /*
         * 查询打印状态
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "Prn_CheckStatus")]
        public static extern int Prn_CheckStatus();

        /*
         * 设置左边界
         * 左边界空白点数，范围：0~336
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "Prn_SetLeftIndent")]
        public static extern int Prn_SetLeftIndent(int x);

        /*
         * 打印进纸设置
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "Prn_Feed")]
        public static extern int Prn_Feed(int Line);

    }
}
