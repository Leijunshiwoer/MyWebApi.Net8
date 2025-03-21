using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class UseTranAttribute : Attribute
    {
        /// <summary>
        /// 事务传播方式
        /// </summary>
        public Propagation Propagation { get; set; } = Propagation.Required;
    }
}
