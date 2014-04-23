using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Devices
{
    /// <summary>
    /// 侧键
    /// </summary>
    public class SideBtn
    {

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            M60API.KeyMonitorSwitchInit();
        }

        /// <summary>
        /// 开始监听按键
        /// </summary>
        /// <param name="LeftBtnOnclick"></param>
        /// <param name="RightBtnOnclick"></param>
        public static void StatWatch()
        {
            M60API.KeyMonitorSwitch(true);
        }

        /// <summary>
        /// 设置左键
        /// </summary>
        /// <param name="RightBtnOnclick"></param>
        public static void SetRightBtn(Delegate RightBtnOnclick)
        {
            M60API.VAx_Key_Right(RightBtnOnclick);
        }

        /// <summary>
        /// 设置右键
        /// </summary>
        /// <param name="LeftBtnOnclick"></param>
        public static void SetLeftBtn(Delegate LeftBtnOnclick)
        {
            M60API.VAx_Key_Left(LeftBtnOnclick);
        }

        /// <summary>
        /// 结束监听侧键
        /// </summary>
        public static void EndWatch()
        {
            M60API.KeyMonitorSwitch(false);
        }
    }
}
