using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Devices
{
    public class M60API
    {

        #region 侧键
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?KeyMonitorSwitchInit@@YAXXZ")]
        public static extern void KeyMonitorSwitchInit();
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?KeyMonitorSwitch@@YAX_N@Z")]
        public static extern void KeyMonitorSwitch(bool open);
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?VAx_Key_Left@@YAHP6AXXZ@Z")]
        public static extern void  VAx_Key_Left(Delegate ExecLeft);
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?VAx_Key_Right@@YAHP6AXXZ@Z")]
        public static extern void VAx_Key_Right(Delegate ExecRight);

        #endregion

        #region 扫描相关
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?GMPS_Init@@YAKXZ")]
        public static extern int GMPS_Init();

        /// <summary>
        /// 端口是否上电，由函数参数决定
        /// </summary>
        /// <param name="on"></param>
        /// <returns>0成功 其他失败</returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?SCAN_POWER_CONTROL@@YAH_N@Z")]
        public static extern int SCAN_POWER_CONTROL(bool on);

        /// <summary>
        /// 启动扫描仪器，开始扫描
        /// </summary>
        /// <returns>0成功 其他失败</returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?VAx_BCR_Trigger@@YAH_N@Z")]
        public static extern int VAx_BCR_Trigger(bool on);

        /// <summary>
        /// 打开串口
        /// 串口打开一次即可连续扫描，打开多次则不能多次扫描
        /// </summary>
        /// <param name="mode">BCR_TYPE_1D   一维条码
        /// BCR_TYPE_2D   二维条码</param>
        /// <returns>0成功 1失败</returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?VAx_BCR_Open@@YAHE@Z")]
        public static extern int VAx_BCR_Open(int mode);

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?VAx_BCR_Close@@YAHXZ")]
        public static extern int VAx_BCR_Close();

        /// <summary>
        /// 读取串口数据
        /// </summary>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?VAx_BCR_Read_Fun@@YAHP6AXPADH@Z@Z")]
        public static extern int VAx_BCR_Read_Fun(Delegate delg);

        /// <summary>
        /// 触发控制
        /// </summary>
        /// <param name="on"></param>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?SCAN_TRIGGER_CONTROL@@YAH_N@Z")]
        public static extern int SCAN_TRIGGER_CONTROL(bool on);

        /// <summary>
        /// 唤醒/休眠
        /// </summary>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?SCAN_AWAKE_CONTROL@@YAH_N@Z")]
        public static extern int SCAN_AWAKE_CONTROL(bool on);
        #endregion

        #region 打印相关
        ////打印相关
        //[DllImport("VPOS362_APIDLL.dll", EntryPoint = "VAx_Camera_Flash")]
        //public static extern int VAx_Camera_Flash(bool mode);

        //打印相关
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Prn_Init@@YAHXZ")]
        public static extern int Prn_Init();  //初始化

        /*
         * 设置打印字间距、行间距 
         * x 字间距[点数]。默认字间距为0，最大值为255 
         * y 行间距[点数]。默认字间距为0，最大值为255 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Prn_SetSpace@@YAXEE@Z")]
        public static extern void Prn_SetSpace(byte x, byte y);

        /*
         * 设置字体和放大参数 
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Prn_SetFont@@YAHEEE@Z")]
        public static extern int Prn_SetFont(byte AsciiFontHeight, byte ExtendFontHeight, byte Zoom);

        /*
         * 获取打印字体和放大参数 
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Prn_GetFont@@YAHPAE00@Z")]
        public static extern int Prn_GetFont(byte AsciiFontHeight, byte ExtendFontHeight, byte Zoom);

        /*
         * 送字符串打印数据到打印缓冲
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Prn_Str@@YAHPADZZ")]
        public static extern int Prn_Str(byte[] fmt);

        /*
         * 启动打印
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Prn_Start@@YAHXZ")]
        public static extern int Prn_Start();

        /*
         * 查询打印状态
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Prn_CheckStatus@@YAHXZ")]
        public static extern int Prn_CheckStatus();

        /*
         * 设置左边界
         * 左边界空白点数，范围：0~336
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Prn_SetLeftIndent@@YAHH@Z")]
        public static extern int Prn_SetLeftIndent(int x);

        /*
         * 打印进纸设置
         * 
         */
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Prn_Feed@@YAHI@Z")]
        public static extern int Prn_Feed(int Line);
        #endregion

        #region 磁卡读卡器
        /// <summary>
        /// 打开磁卡阅读器
        /// </summary>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_Open@@YAXXZ")]
        public extern static void Mcr_Open();


        /// <summary>
        /// 关闭磁卡阅读器
        /// </summary>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_Close@@YAXXZ")]
        public extern static void Mcr_Close();


        /// <summary>
        /// 复位磁卡信息缓冲
        /// </summary>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_Reset@@YAXXZ")]
        public extern static void Mcr_Reset();


        /// <summary>
        /// 检测刷卡状态
        /// </summary>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_Check@@YAHXZ")]
        public extern static int Mcr_Check();

        /// <summary>
        /// 取磁卡磁道信息
        /// </summary>
        /// <param name="track1">存放1磁道数据的指针 [应用层缓冲区要设为256]</param>
        /// <param name="track2">存放2磁道数据的指针 [应用层缓冲区要设为256]</param>
        /// <param name="track3">存放3磁道数据的指针 [应用层缓冲区要设为256]</param>
        /// <remarks>与MCR_Check函数配合使用。如果不需要某磁道数据，可以将该磁道对应的指针置为NULL，这时将不会输出该磁道的数据。
        /// 一般读取符合ISO7811标准的磁卡时：
        /// track1的空间为79字节
        /// track2的空间为40字节
        /// track3的空间为107字节
        /// </remarks>
        /// <returns>0 刷卡错误
        /// 其它值（＞0）
        /// bit0 = 1  正确读出 1磁道数据
        /// bit1 = 1  正确读出2磁道数据
        /// bit2 = 1  正确读出3磁道数据
        /// bit4 = 1  1磁道数据有校验错
        /// bit5 = 1  2磁道数据有校验错
        /// bit6 = 1  3磁道数据有校验错
        /// </returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_Read@@YAHPAE00@Z")]
        public extern static int Mcr_Read(IntPtr track1, IntPtr track2, IntPtr track3);
        #endregion

        #region 加密磁卡读卡器606
        /// <summary>
        /// 读取磁卡磁道信息
        /// </summary>
        /// <param name="ptr1"></param>
        /// <param name="ptr2"></param>
        /// <param name="ptr3"></param>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_606_Read@@YAHPAE00@Z")]
        public unsafe extern static int Mcr_606_Read(IntPtr ptr1, IntPtr ptr2, IntPtr ptr3);

        /// <summary>
        /// 磁头休眠
        /// </summary>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_606_Sleep@@YAHXZ")]
        public extern static int Mcr_606_Sleep();

        /// <summary>
        /// 磁头唤醒
        /// </summary>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_606_Wake@@YAHXZ")]
        public extern static int Mcr_606_Wake();
        /// <summary>
        /// 磁头复位
        /// </summary>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_606_Reset@@YAHXZ")]
        public extern static int Mcr_606_Reset();

        /// <summary>
        /// 磁头认证
        /// </summary>
        /// <param name="key">16个字节长度的密钥</param>
        /// <returns></returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Mcr_606_GetAuthor@@YAHPAE@Z")]
        public extern static int Mcr_606_GetAuthor(byte[] key);
        #endregion
        
        #region 蜂鸣器
        /// <summary>
        /// 蜂鸣器初始化
        /// </summary>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Buzzer_Init@@YAHXZ")]
        public extern static void Buzzer_Init();

        /// <summary>
        /// 蜂鸣器使能控制
        /// </summary>
        /// <param name="nState">0:蜂鸣器鸣叫使能  1:蜂鸣器停止鸣叫使能</param>
        /// <returns>1 成功  0 失败</returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Buzzer_ControlEN@@YAHH@Z")]
        public extern static int Buzzer_ControlEN(int nState);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nFrq">蜂鸣器鸣叫频率选择(取值范围:1-16)</param>
        /// <param name="nTime">蜂鸣器鸣叫时间设置</param>
        /// <remarks>若要使蜂鸣器鸣叫，一定要调用Buzzer_ControlEN（0）进行使能设置;
        ///             打开蜂鸣器后，可以用Buzzer_ControlEN（1）进行关闭
        /// </remarks>
        /// <returns>1 成功 0 失败</returns>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Buzzer_Beep@@YAHHH@Z")]
        public extern static int Buzzer_Beep(int nFrq, int nTime);

        /// <summary>
        /// 蜂鸣器退出
        /// </summary>
        [DllImport("VPOS362_APIDLL.dll", EntryPoint = "?Buzzer_Exit@@YAHXZ")]
        public extern static void Buzzer_Exit();
        #endregion
    }
}
