using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model.DBModel
{
    [Table(TableName="tPdDataInfo")]
    public class DBPdDataInfo
    {
        /// <summary>
        /// 仓库编码
        /// </summary>
        [Column(ColumnName="CkCode",DbType=DbType.String,IsNull=false)]
        public string CkCode
        {
            get;
            set;
        }

        /// <summary>
        /// 盘点日期
        /// </summary>
        [Column(ColumnName="PdDate",DbType=DbType.DateTime,IsNull=false)]
        public DateTime PdDate
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

        /// <summary>
        /// 录入时间
        /// </summary>
        [Column(ColumnName="LrDate",DbType=DbType.DateTime)]
        public DateTime LrDate
        {
            get;
            set;
        }
    }
}
