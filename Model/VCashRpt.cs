using System;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model
{
    [Table(TableName = "vCashRpt")]
    public class VCashRpt
    {
        [Column(ColumnName="Operator",SQLDbType=SqlDbType.NVarChar)]
        public string Operator
        {
            get;
            set;
        }

        [Column(ColumnName="ZfName",SQLDbType=SqlDbType.NVarChar)]
        public string ZfName
        {
            get;
            set;
        }

        [Column(ColumnName="total",SQLDbType=SqlDbType.Decimal)]
        public decimal total
        {
            get;
            set;
        }
    }
}
