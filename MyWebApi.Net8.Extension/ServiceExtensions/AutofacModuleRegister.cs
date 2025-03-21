using Autofac;
using Autofac.Extras.DynamicProxy;
using MyWebApi.Net8.Extension.ServiceExtensions;
using MyWebApi.Net8.IServices;
using MyWebApi.Net8.Repository.Base;
using MyWebApi.Net8.Repository.UnitOfWorks;
using MyWebApi.Net8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Extension
{
   public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            var basePath = AppContext.BaseDirectory;
            var servicesDllFile = Path.Combine(basePath, "MyWebApi.Net8.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "MyWebApi.Net8.Repository.dll");
            //注册AOP
            var aopTypes = new List<Type>() { typeof(ServiceAOP),typeof(TranAOP)};
            builder.RegisterType<ServiceAOP>();
            builder.RegisterType<TranAOP>();

            //注册拦截器 
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>)).EnableInterfaceInterceptors().InterceptedBy(aopTypes.ToArray()).InstancePerDependency();

            //注册服务
            builder.RegisterAssemblyTypes(Assembly.LoadFrom(servicesDllFile))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerDependency().PropertiesAutowired().EnableInterfaceInterceptors().InterceptedBy(aopTypes.ToArray());
            //注册仓储
            builder.RegisterAssemblyTypes(Assembly.LoadFrom(repositoryDllFile))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerDependency().PropertiesAutowired();
            //注册工作单元
            builder.RegisterType<UnitOfWorkManage>().As<IUnitOfWorkManage>()
           .AsImplementedInterfaces()
           .InstancePerLifetimeScope()
           .PropertiesAutowired();

        }
    }
}
