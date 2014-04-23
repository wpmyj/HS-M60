using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Pub
{
    public class ProcessControl
    {
        /// <summary>
        /// 打开进程
        /// </summary>
        /// <param name="fileName"></param>
        public static void Start(string fileName)
        {
            System.Diagnostics.Process exep = System.Diagnostics.Process.Start(fileName, null);

            exep.Start();
        }

        /// <summary>
        /// 打开进程并阻塞当前进程，直到该进程关闭
        /// </summary>
        /// <param name="fileName"></param>
        public static void WaitForExit(string fileName)
        {
            System.Diagnostics.Process exep = System.Diagnostics.Process.Start(fileName, null);

            exep.WaitForExit();
        }
    }
}
