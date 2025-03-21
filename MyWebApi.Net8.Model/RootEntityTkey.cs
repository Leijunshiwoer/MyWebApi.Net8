﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Model
{
    public class RootEntityTkey<Tkey> where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// ID
        /// 泛型主键Tkey
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true)]
        public Tkey Id { get; set; }
    }
}
