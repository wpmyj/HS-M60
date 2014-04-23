using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using SqliteUtilities;
using System.Data;

namespace DAL
{
    public abstract class BaseDAL<T>
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        private  SQLiteConnection Connection
        {
            get;
            set;
        }

        #region 事务操作

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool BeginTran(out SQLiteTransaction tran,out string msg)
        {
            return SqlTool.BeginTransaction(Connection, out tran, out msg);
        }

        public bool Commit(SQLiteTransaction tran,out string msg)
        {
            return SqlTool.CommitTransaction(tran,out msg);
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool RollBack(SQLiteTransaction tran, out string msg)
        {
            return SqlTool.RollbackTransaction(tran, out msg);
        }
        #endregion

        #region 数据库操作工具
        /// <summary>
        /// 数据库操作工具
        /// </summary>
        public static ISqlTool SqlTool = ToolBuilder.CreateSqlTool();

        /// <summary>
        /// 对象操作工具
        /// </summary>
        public static IObjectTool ObjectTool = ToolBuilder.CreateObjectTool();

        #endregion

        #region 构造函数
        public BaseDAL(SQLiteConnection _Connection)
        {
            this.Connection = _Connection;
        }

        #endregion

        #region 数据库操作

        /// <summary>
        /// 读取数据库对象
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool Load(ref T obj, out string msg)
        {
            return SqlTool.Load(ref obj, Connection, out msg);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public  virtual bool Save(ref T obj,out int i, out string msg)
        {
            return SqlTool.Save(ref obj, Connection, out i, out msg);
        }

        /// <summary>
        /// 保存并启用事务
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="i"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool Save(T obj,SQLiteTransaction tran,out int i,out string msg)
        {
            return SqlTool.Save(ref obj, Connection, tran, out i, out msg);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public  virtual bool Delete(T obj, out int i,out string msg)
        {
            return SqlTool.Delete(obj,Connection,out i,out msg);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Condition"></param>
        /// <param name="dataTable"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool Select(string Condition, string OrderBy, out DataTable result, out string msg)
        {
            return SqlTool.Select<T>(Condition, OrderBy, Connection, out result, out msg);
        }
        #endregion
    }
}
