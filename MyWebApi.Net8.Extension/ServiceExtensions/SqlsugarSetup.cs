﻿using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Net8.Common;
using MyWebApi.Net8.Common.DB;
using SqlSugar;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Extension.ServiceExtensions
{/// <summary>
 /// SqlSugar 启动服务
 /// </summary>
    public static class SqlsugarSetup
    {
        public static void AddSqlsugarSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // 默认添加主数据库连接
            if (!string.IsNullOrEmpty(AppSettings.app("MainDB")))
            {
                MainDb.CurrentDbConnId = AppSettings.app("MainDB");
            }

            BaseDBConfig.MutiConnectionString.allDbs.ForEach(m =>
            {
                var config = new ConnectionConfig()
                {
                    ConfigId = m.ConnId.ObjToString().ToLower(),
                    ConnectionString = m.Connection,
                    DbType = (DbType)m.DbType,
                    IsAutoCloseConnection = true,
                    MoreSettings = new ConnMoreSettings()
                    {
                        IsAutoRemoveDataCache = true,
                        SqlServerCodeFirstNvarchar = true,
                    },
                    InitKeyType = InitKeyType.Attribute
                };
                if (SqlSugarConst.LogConfigId.ToLower().Equals(m.ConnId.ToLower()))
                {
                    BaseDBConfig.LogConfig = config;
                }
                else
                {
                    BaseDBConfig.ValidConfig.Add(config);
                }

                BaseDBConfig.AllConfigs.Add(config);
            });

            if (BaseDBConfig.LogConfig is null)
            {
                throw new ApplicationException("未配置Log库连接");
            }

            // SqlSugarScope是线程安全，可使用单例注入
            // 参考：https://www.donet5.com/Home/Doc?typeId=1181
            services.AddSingleton<ISqlSugarClient>(o =>
            {
                return new SqlSugarScope(BaseDBConfig.AllConfigs);
            });
        }
    }
}
