using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities;
using System.Data.SQLite;
using System.Data;
namespace DAL
{
    public class BaseDAL
    {
        /// <summary>
        /// 数据库访问工具
        /// </summary>
        protected static ISqlTool DBTool = ToolBuilder.CreateSqlTool();

        /// <summary>
        /// 对象工具
        /// </summary>
        public static IObjectTool ObjTool = ToolBuilder.CreateObjectTool();
        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <returns></returns>
        public static bool Open(string ConnectionStr , out string msg)
        {
            return DBTool.Open(ConnectionStr, out msg);
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        /// <returns></returns>
        public static void Close()
        {
            DBTool.Close();
        }
        /// <summary>
        /// Insert
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="i">影响行数</param>
        /// <param name="msg">返回的消息</param>
        /// <returns>是否成功</returns>
        public static bool Insert<T>(T obj, out int i,out string msg)
        {
            return DBTool.Insert(obj, out i, out msg);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="i">影响行数</param>
        /// <param name="msg">返回的消息</param>
        /// <returns>是否成功</returns>
        public static bool Update<T>(T obj, out int i, out string msg)
        {
            return DBTool.Update(obj, out i, out msg);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="i">影响的行数</param>
        /// <param name="msg">返回的消息</param>
        /// <returns>是否成功</returns>
        public static bool Delete<T>(T obj, out int i, out string msg)
        {
            return DBTool.Delete(obj, out i, out msg);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool Select<T>(string Condition,T model,string OrderBy,out DataTable dt,out string msg)
        {
            return DBTool.Select(Condition, model, OrderBy, out dt, out msg);
        }

    }
}
