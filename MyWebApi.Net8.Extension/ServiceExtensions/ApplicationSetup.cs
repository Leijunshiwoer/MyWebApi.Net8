using Microsoft.AspNetCore.Builder;
using MyWebApi.Net8.Common.Core;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Extension.ServiceExtensions
{
   public static class ApplicationSetup
    {
        public static void UseApplicationSetup(this WebApplication app) 
        { 
            app.Lifetime.ApplicationStarted.Register(() =>
            {
               App.IsRun = true;

            });
            app.Lifetime.ApplicationStopped.Register(() =>
            {
                App.IsRun = false;
                //关闭日志
                Log.CloseAndFlush();
            });
        }
    }
}
