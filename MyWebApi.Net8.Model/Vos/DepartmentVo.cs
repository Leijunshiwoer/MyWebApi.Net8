﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Model
{
    ///<summary>
    /// 部门表视图模型
    ///</summary>
    public class DepartmentVo
    {
        public string CodeRelationship { get; set; }
        public string Name { get; set; }
        public string Leader { get; set; }
        public int OrderSort { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
