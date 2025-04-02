using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyWebApi.Net8.Common;
using MyWebApi.Net8.Common.Cache;
using MyWebApi.Net8.Common.Core;
using MyWebApi.Net8.Common.Option;
using MyWebApi.Net8.IServices;
using MyWebApi.Net8.Model;
using MyWebApi.Net8.Repository.UnitOfWorks;
using MyWebApi.Net8.Services;
using MyWebApi.Net8.WorkFlow.WorkFlows;
using WorkflowCore.Interface;


namespace MyWebApi.Net8.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize(Roles ="SuperAdmin")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IUserService userService;
    private readonly IRoleService roleService;
    private readonly IAuditSqlLogService auditSqlLogService;
    private readonly IOptions<RedisOptions> _options;
    private readonly ICaching _caching;
    private readonly IUnitOfWorkManage _unitOfWorkManage;
    private readonly IWorkflowHost _workflowHost;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IUserService userService,
        IRoleService roleService,
        IAuditSqlLogService auditSqlLogService,
        IOptions<RedisOptions> options,
        ICaching caching,
        IUnitOfWorkManage unitOfWorkManage,
        IWorkflowHost workflowHost
        )
    {
        _logger = logger;
        this.userService = userService;
        this.roleService = roleService;
        this.auditSqlLogService = auditSqlLogService;
        _options = options;
        _caching = caching;
        _unitOfWorkManage = unitOfWorkManage;
        _workflowHost = workflowHost;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<object> Get()
    {
        //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //{
        //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //    TemperatureC = Random.Shared.Next(-20, 55),
        //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //})
        //.ToArray();

        //var id = (DateTime.Now.ToUniversalTime() - new DateTime(1999, 1, 20)).TotalSeconds.ObjToLong();
        //await auditSqlLogService.AddSplit(new AuditSqlLog { Id = id, DateTime = DateTime.Now });
        //return await auditSqlLogService.QuerySplit(a => true);


        //var roleserviceObjNew=App.GetService<IBaseService<Role,RoleVo>>(false);
        //var roles = await roleserviceObjNew.Query();

        //var redisOptions = _options.Value;
        //Console.WriteLine(JsonConvert.SerializeObject(redisOptions));

        // var cacheKey = "cache-key";

        // await _caching.SetStringAsync(cacheKey, "Hello world" );
        // var cacheKeys = await _caching.GetAllCacheKeysAsync();

        //await Console.Out.WriteAsync(JsonConvert.SerializeObject(cacheKeys));

        // var str = await _caching.GetStringAsync(cacheKey);
        // await Console.Out.WriteAsync(str);
        // return string.Empty;
       var a= await _workflowHost.StartWorkflow(nameof(HelloWorkFlow));
        return "OK";
    }

    //[HttpGet(Name = "GetTest")]
    //public async Task<object> Test()
    //{
    //    await _workflowHost.StartWorkflow(nameof(HelloWorkFlow));
    //    return "OK";
    //}
}
