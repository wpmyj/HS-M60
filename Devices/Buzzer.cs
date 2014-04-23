using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Devices
{
    /// <summary>
    /// 蜂鸣器
    /// </summary>
    public class Buzzer
    {
        const int NFrq=1;//蜂鸣器鸣叫频率选择(取值范围:1-16)
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            M60API.Buzzer_Init();
        }

        /// <summary>
        /// 打开蜂鸣器
        /// </summary>
        /// <returns></returns>
        public static bool Open()
        {
            return M60API.Buzzer_ControlEN(0)==1;
        }

        /// <summary>
        /// 关闭蜂鸣器
        /// </summary>
        /// <returns></returns>
        public static bool Close()
        {
            return M60API.Buzzer_ControlEN(1)==0;
        }

        /// <summary>
        /// 退出蜂鸣器
        /// </summary>
        public static void Exit()
        {
            M60API.Buzzer_Exit();
        }
        /// <summary>
        /// 鸣叫
        /// </summary>
        /// <param name="nFrq">蜂鸣器鸣叫频率选择(取值范围:1-16)</param>
        /// <param name="nTime">蜂鸣器鸣叫时间设置</param>
        /// <returns></returns>
        public static bool Beep(int nFrq, int nTime)
        {
            return M60API.Buzzer_Beep(nFrq, nTime)==1;
        }

        /// <summary>
        /// 成功鸣叫
        /// </summary>
        public static void SuccessBeep()
        {
            Beep(NFrq, 100);
        }

        /// <summary>
        /// 失败鸣叫
        /// </summary>
        public static void FailedBeep()
        {
            Beep(NFrq, 100);
            Thread.Sleep(200);
            Beep(NFrq, 100);

        }
    }
}
