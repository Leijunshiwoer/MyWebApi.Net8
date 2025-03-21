using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Model
{
    [Tenant("log")]
    [SplitTable(SplitType.Month)] //按月分表 （自带分表支持 年、季、月、周、日）
    [SugarTable($@"{nameof(AuditSqlLog)}_{{year}}{{month}}{{day}}")]
    //[SugarTable("AuditSqlLog_20231201")]
    public class AuditSqlLog : BaseLog
    {

    }
}
