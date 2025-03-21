
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyWebApi.Net8.Common;
using MyWebApi.Net8.Common.Core;
using MyWebApi.Net8.Common.Option;
using MyWebApi.Net8.Extension;
using MyWebApi.Net8.Extension.ServiceExtensions;


namespace MyWebApi.Net8;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterModule(new AutofacModuleRegister());
        }).ConfigureAppConfiguration((hostingContext, config) =>
            {
                //config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                hostingContext.Configuration.ConfigureApplication();
            });

        builder.ConfigureApplication();
        // Add services to the container.
        //  builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        //添加AutoMapper（实体Dto和数据库交互，model和用户交互，中间就需要用到映射，用model和数据库交互存在数据库的安全隐患）
        builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
        AutoMapperConfig.RegisterMappings();
        //配置
        builder.Services.AddSingleton(new AppSettings(builder.Configuration));
        builder.Services.AddAllOptionRegister();
        //缓存
        builder.Services.AddCacheSetup();
        //sqlsuar
        builder.Services.AddSqlsugarSetup();
        //jwt
        //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddJwtBearer(options =>
        //    {
        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,

        //            ValidIssuer = "Blog.Core",
        //            ValidAudience = "wr",
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfsdfsrty45634kkhllghtdgdfss345t678fs"))
        //        };
        //    });
        //builder.Services.AddAuthorization(option =>
        //{
        //    option.AddPolicy("Client", policy => policy.RequireClaim("Client").Build());
        //    option.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin").Build());
        //});

        // builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // builder.Services.AddElsa(elsa => elsa.AddWorkflowsFrom<Program>().UseHttp());

        // Enable Elsa HTTP module (for HTTP related activities). 

        var app = builder.Build();
        app.ConfigureApplication();
        app.UseApplicationSetup();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
         app.UseAuthorization();
        app.MapControllers();
        //app.UseWorkflows();
        app.Run();
    }
}
