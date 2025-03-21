using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Model
{
    public abstract class BaseLog : RootEntityTkey<long>
    {
        [SplitField]
        public DateTime? DateTime { get; set; }

        [SugarColumn(IsNullable = true)]
        public string Level { get; set; }

        [SugarColumn(IsNullable = true, ColumnDataType = "longtext,text,clob")]
        public string Message { get; set; }

        [SugarColumn(IsNullable = true, ColumnDataType = "longtext,text,clob")]
        public string MessageTemplate { get; set; }

        [SugarColumn(IsNullable = true, ColumnDataType = "longtext,text,clob")]
        public string Properties { get; set; }
    }
}
