using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model.DBModel
{
    [Table(TableName="tSalSalePay")]
    public class DBSalSalePay
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(ColumnName="ID",DbType=DbType.Guid,PrimaryKey=true)]
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        /// 组织号
        /// </summary>
        [Column(ColumnName="OrgCode",DbType=DbType.String,IsNull=false)]
        public string OrgCode
        {
            get;
            set;
        }

        /// <summary>
        /// 流水号
        /// </summary>
        [Column(ColumnName = "SaleNo", DbType = DbType.String, IsNull = false)]
        public string SaleNo
        {
            get;
            set;
        }

        /// <summary>
        /// 支付卡号
        /// </summary>
        [Column(ColumnName = "ZfNo", DbType = DbType.String, IsNull = false)]
        public string ZfNo
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式代码
        /// </summary>
        [Column(ColumnName = "ZfCode", DbType = DbType.String, IsNull = false)]
        public string ZfCode
        {
            get;
            set;
        }

        /// <summary>
        /// 支付金额
        /// 实际交的金额
        /// </summary>
        [Column(ColumnName = "ZfTotal", DbType = DbType.Decimal, IsNull = false)]
        public decimal ZfTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 实收金额
        /// 实际冲抵的金额
        /// </summary>
        [Column(ColumnName = "SsTotal", DbType = DbType.Decimal, IsNull = false)]
        public decimal SsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式流水号
        /// </summary>
        [Column(ColumnName = "SerialNo", DbType = DbType.Int16, IsNull = false)]
        public int SerialNo
        {
            get;
            set;
        }

        /// <summary>
        /// 会员卡面号
        /// </summary>
        [Column(ColumnName = "VipNo", DbType = DbType.String, IsNull = false)]
        public string VipNo
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
        [Column(ColumnName="LrDate",DbType=DbType.DateTime,IsNull=false)]
        public DateTime LrDate
        {
            get;
            set;
        }

    }
}
