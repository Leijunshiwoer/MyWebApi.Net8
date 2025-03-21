using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Model
{
    public class AuditSqlLogVo
    {
        public DateTime? DateTime { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Properties { get; set; }
    }
}
