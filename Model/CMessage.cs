using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 通讯消息类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CMessage<T>
    {
        /// <summary>
        /// 返回的状态
        /// </summary>
        public int Status;

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Message;

        /// <summary>
        /// 返回的对象
        /// </summary>
        public T Obj;
    }
}
