using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Devices
{
    public class Printer
    {
        /// <summary>
        /// 初始化打印机
        /// </summary>
        /// <param name="WordSpace">字间距</param>
        /// <param name="LineSpace">行间距</param>
        /// <param name="AsciiFontHeight">字体大小</param>
        /// <param name="ExtendFontHeight">字体大小</param>
        /// <param name="Zoom"></param>
        /// <returns></returns>
        public static bool Init(byte WordSpace, byte LineSpace, byte AsciiFontHeight, byte ExtendFontHeight, byte Zoom)
        {
            M60API.Prn_SetSpace(WordSpace, LineSpace);
            M60API.Prn_SetFont(AsciiFontHeight, ExtendFontHeight, Zoom);
            return M60API.Prn_Init()==0;
        }

        /// <summary>
        /// 进纸
        /// </summary>
        /// <param name="line">行数</param>
        /// <returns></returns>
        public static bool Feed(int line)
        {
            return M60API.Prn_Feed(line) == 0;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="texts">打印内容</param>
        /// <returns></returns>
        public static bool Print(string txt)
        {
            M60API.Prn_Str(Encoding.Default.GetBytes(txt));
            return M60API.Prn_Start() == 0;
        }
    }
}
