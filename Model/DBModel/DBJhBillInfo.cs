using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model.DBModel
{
    [Table(TableName="tJhBillInfo")]
    public class DBJhBillInfo
    {
        /// <summary>
        /// 是否为采购验收
        /// </summary>
        [Column(ColumnName="IsCgJh",DbType=DbType.Boolean,IsNull=false,Default=true)]
        public bool IsCgJh
        {
            get;
            set;
        }

        /// <summary>
        /// 前置关联号
        /// </summary>
        [Column(ColumnName = "PreRefBillNo",DbType=DbType.String,IsNull=false,Default="")]
        public string PreRefBillNo
        {
            get;
            set;
        }

        /// <summary>
        /// 关联号
        /// </summary>
        [Column(ColumnName="RefBillNo",DbType=DbType.String,IsNull=false)]
        public string RefBillNo
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [Column(ColumnName = "CkCode", DbType = DbType.String, IsNull = false)]
        public string CkCode
        {
            get;
            set;
        }

        /// <summary>
        /// 录入人
        /// </summary>
        [Column(ColumnName="LrUser",DbType=DbType.String,IsNull=false)]
        public string LrUser
        {
            get;
            set;
        }
    }
}
