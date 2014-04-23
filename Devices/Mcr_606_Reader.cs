using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Devices
{
    /// <summary>
    /// 加密磁头读卡器
    /// </summary>
    public class Mcr_606_Reader
    {
        public static  byte[] key = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
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

        public static bool Check()
        {
            return M60API.Mcr_Check() == 0;
        }
        /// <summary>
        /// 磁头复位
        /// </summary>
        /// <returns></returns>
        public static bool Reset()
        {
            return M60API.Mcr_606_Reset() == 0;
        }

        /// <summary>
        /// 磁头认证
        /// </summary>
        /// <returns></returns>
        public static bool GetAuthor()
        {
            return M60API.Mcr_606_GetAuthor(key)==0;
        }

        /// <summary>
        /// 唤醒磁头
        /// </summary>
        /// <returns></returns>
        public static bool Wake()
        {
            return M60API.Mcr_606_Wake() == 0;
        }

        /// <summary>
        /// 磁头休眠
        /// </summary>
        /// <returns></returns>
        public static bool Sleep()
        {
            return M60API.Mcr_606_Sleep()==0;
        }

        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="ptr1"></param>
        /// <param name="ptr2"></param>
        /// <param name="ptr3"></param>
        /// <returns></returns>
        public static bool ReadTranck(ref string track1, ref string track2,ref string track3, out string msg)
        {
            byte[] buff = new byte[500];
            IntPtr ptr1 = new IntPtr();
            IntPtr ptr2 = new IntPtr();
            IntPtr ptr3 = new IntPtr();
            ptr1 = Marshal.AllocHGlobal(500);
            ptr2 = Marshal.AllocHGlobal(500);
            ptr3 = Marshal.AllocHGlobal(500);
            int i = 0;
            i = M60API.Mcr_606_Read(ptr1, ptr2, ptr3);
            int j = 0;
            if (i == 0)
            {
                msg = "读卡错误";
                return false;
            }
            try
            {

                #region 读1轨
                j = i & 17;
                switch (j)
                {
                    case 1:
                        msg = "正确读出 1磁道数据";
                        Marshal.Copy(ptr1, buff, 0, 255);
                        track1 = Encoding.ASCII.GetString(buff, 0, 79);
                        break;
                    case 16:
                        msg = "1磁道数据有校验错";
                        track1 = null;
                        break;
                    case 17 :
                        msg = "1磁道数据有校验错";
                        track1 = null;
                        break;
                }
                #endregion

                #region 读2轨
                j = i & 34;
                switch (j)
                {
                    case 2:
                        msg = "正确读出2磁道数据";
                        Marshal.Copy(ptr2, buff, 0, 255);
                        track2 = Encoding.ASCII.GetString(buff, 0, 40);
                        break;
                    case 32:
                        msg = "2磁道数据有校验错";
                        track2 = null;
                        break;
                    case 34:
                        msg = "2磁道数据有校验错";
                        track2 = null;
                        break;
                }
                #endregion

                #region 读3轨
                j = i & 68;
                switch (j)
                {
                    case 4:
                        msg = "正确读出3磁道数据";
                        Marshal.Copy(ptr3, buff, 0, 255);
                        track3 = Encoding.ASCII.GetString(buff, 0, 107);
                        break;

                    case 64:
                        msg = "3磁道数据有校验错";
                        track3 = null;
                        break;
                    case 68:
                        msg = "3磁道数据有校验错";
                        track3 = null;
                        break;
                }
                #endregion

                msg = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr1);
                Marshal.FreeHGlobal(ptr2);
                Marshal.FreeHGlobal(ptr3);
                buff = null;
            }
            msg = "未知错误";
            return false;
        }
    }
}
