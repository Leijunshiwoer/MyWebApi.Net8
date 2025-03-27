using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Net8.Models
{
    public class QueryParameter
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int Id { get; set; }

        public int Status { get; set; }

        public string? Code { get; set; }
    }
}
