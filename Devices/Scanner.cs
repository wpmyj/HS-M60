using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Devices
{
    public class Scanner
    {
        /// <summary>
        /// 扫描头类型
        /// </summary>
        public static int ScannerType
        {
            get;
            set;
        }

        /// <summary>
        /// 接收扫描信息委托
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public delegate void RecScanCodeDlg(IntPtr ptr,int i);

        /// <summary>
        /// 初始化扫描
        /// </summary>
        /// <param name="_ScannerType"></param>
        public static void Init(int _ScannerType)
        {
            ScannerType = _ScannerType;
        }

        /// <summary>
        /// 打开扫描头
        /// </summary>
        /// <returns></returns>
        public static void Open()
        {
            M60API.GMPS_Init();//对GPRS、GPS、SCAN设备进行初始化工作
            M60API.VAx_BCR_Open(ScannerType);
            M60API.SCAN_POWER_CONTROL(true);
            int i = M60API.SCAN_AWAKE_CONTROL(true);//唤醒
           // M60API.SCAN_TRIGGER_CONTROL(true);
           
        }

        /// <summary>
        /// 开启扫描，读取数据
        /// </summary>
        /// <param name="CallBackFun">读取到数据回调函数</param>
        /// <returns></returns>
        public static bool Read(Delegate _CallBackFun)
        {
            M60API.VAx_BCR_Read_Fun(_CallBackFun);
            int i=M60API.VAx_BCR_Trigger(false);
            return i== 0;
        }

        /// <summary>
        /// 关闭扫描头
        /// </summary>
        public static void Close()
        {
            int i;
            i=M60API.VAx_BCR_Close();
            i=M60API.SCAN_AWAKE_CONTROL(false);
            i=M60API.SCAN_TRIGGER_CONTROL(false);
            i=M60API.SCAN_POWER_CONTROL(false);
        }
    }

}
