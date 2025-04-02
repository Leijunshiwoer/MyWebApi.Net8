using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Net8.Common.DB;
using MyWebApi.Net8.Services;
using MyWebApi.Net8.WorkFlow.StepBodys;
using MyWebApi.Net8.WorkFlow.WorkFlows;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Persistence.EntityFramework.Services;

namespace MyWebApi.Net8.Extension.ServiceExtensions
{
    public static class WorkflowSetup
    {
        public static void AddWorkflowSetup(this IServiceCollection services)
        {
           //services.AddWorkflow(x => x.UseSqlite(BaseDBConfig.ValidConfig[0].ConnectionString, true));
            // services.AddWorkflow();
           services.AddWorkflow(x => x.UseMySQL("Server=localhost; Port=3306;Database=workflowcore;Uid=root;Pwd=Kstopa123?;", true, true));
        }

        public static void UseWorkflow(this IApplicationBuilder app)
        {
            var host = app.ApplicationServices.GetRequiredService<IWorkflowHost>();
            host.RegisterWorkflow<HelloWorkFlow>();
            host.Start();
        }
    }

}
