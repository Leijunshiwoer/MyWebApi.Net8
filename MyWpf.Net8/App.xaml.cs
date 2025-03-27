using Microsoft.Extensions.DependencyInjection;
using MyWpf.Net8.Services;
using MyWpf.Net8.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;

namespace MyWpf.Net8
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            base.OnStartup(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // 注册 HttpRestClient
            if (Debugger.IsAttached)
            {
                services.AddSingleton<HttpRestClient>(provider => new HttpRestClient("http://localhost:5051/"));
            }
            else
            {
                services.AddSingleton<HttpRestClient>(provider => new HttpRestClient("https://your-api-url.com"));
            }
            // 注册 DeepSeekService
            services.AddSingleton<IDeepSeekService, DeepSeekService>();

            // 其他服务注册...


            // 注册 MainViewModel
            services.AddTransient<MainViewModel>();

        }
    }
}
