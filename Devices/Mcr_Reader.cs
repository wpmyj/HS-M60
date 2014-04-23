using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Devices
{
    /// <summary>
    /// 磁卡读卡器
    /// </summary>
    public class Mcr_Reader
    {
        /// <summary>
        /// 打开读卡器
        /// </summary>
        public static void Open()
        {
            M60API.Mcr_Open();
        }

        /// <summary>
        /// 关闭读卡器
        /// </summary>
        public static void Close()
        {
            M60API.Mcr_Close();
        }

        /// <summary>
        /// 重置读卡器
        /// </summary>
        public static void Reset()
        {
            M60API.Mcr_Reset();
        }

        /// <summary>
        /// 检测刷卡状态
        /// </summary>
        /// <returns></returns>
        public static bool Check()
        {
            int i = M60API.Mcr_Check();
            return i==0;
        }

        /// <summary>
        /// 读取磁道信息
        /// </summary>
        /// <param name="track">磁道编号</param>
        /// <param name="info">读取到的信息</param>
        /// <param name="msg">返回的消息</param>
        /// <returns></returns>
        public static bool ReadTranck(int track,out string info, out string msg)
        {
            IntPtr ptr1 = new IntPtr();
            IntPtr ptr2 = new IntPtr();
            IntPtr ptr3 = new IntPtr();
            int i = M60API.Mcr_Read(ptr1, ptr2, ptr3);
            if (i == 0)
            {
                info = null;
                msg = "读卡错误";
                return false;
            }
            byte[] buff = new byte[255];
            switch (track)
            {
                case 1://读1轨
                    i = i & 9;
                    if (i == 1)
                    {
                        msg = "正确读出 1磁道数据";
                        Marshal.Copy(ptr1, buff, 0, 255);
                        info=Encoding.ASCII.GetString(buff,0,79);
                        return true;
                    }
                    else if (i == 9||i==8)
                    {
                        msg = "1磁道数据有校验错";
                        info = null;
                        return false;
                    }
                    break;
                case 2://读2轨
                    i = i & 18;
                    if (i == 2)
                    {
                        msg = "正确读出2磁道数据";
                        Marshal.Copy(ptr2, buff, 0, 255);
                        info=Encoding.ASCII.GetString(buff,0,40);
                        return true;
                    }
                    else if (i == 18 ||i==16)
                    {
                        msg = "2磁道数据有校验错";
                        info = null;
                        return false;
                    }
                    break;
                case 3://读3轨
                    i = i & 36;
                    if (i == 4)
                    {
                        msg = "正确读出3磁道数据";
                        Marshal.Copy(ptr3, buff, 0, 255);
                        info=Encoding.ASCII.GetString(buff,0,107);
                        return true;
                    }
                    else if (i == 36 ||i==32)
                    {
                        msg = "3磁道数据有校验错";
                        info = null;
                        return false;
                    }
                    break;
            }

            info = null;
            msg = "未知错误";
            return false;
        }
    }
}
