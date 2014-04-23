using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSForSM90.Interface;
using System.Data.SqlClient;
using System.Configuration;
using SqlUtilities;
using SqlUtilities.Interface;
namespace WSForSM90.DAL
{
    public class BaseDAL<T>:IDisposable where T : IDBObject
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            }
        }

        SqlConnection connection;

        /// <summary>
        /// 数据库连接
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(ConnectionString);
                }
                return connection;
            }
            set
            {
                connection = value;
            }
        }

        ISqlTool dbTool;
        /// <summary>
        /// 数据库工具
        /// </summary>
        protected ISqlTool DbTool
        {
            get
            {
                if (dbTool == null)
                {
                    dbTool = ToolBuilder.CreateSqlTool(Connection);
                }
                return dbTool;
            }
        }

        /// <summary>
        /// 对象工具
        /// </summary>
        protected static IObjectTool ObjTool = ToolBuilder.CreateObjectTool();



        #region IDisposable 成员

        public void Dispose()
        {
            string s;
            try
            {
                DbTool.Close(out s);
            }
            catch
            {
            }
            connection = null;
        }

        #endregion
    }
}
