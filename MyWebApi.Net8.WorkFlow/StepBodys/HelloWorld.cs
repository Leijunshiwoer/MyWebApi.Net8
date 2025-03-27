using MyWebApi.Net8.Model;
using MyWebApi.Net8.Repository.UnitOfWorks;
using MyWebApi.Net8.Repository;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace MyWebApi.Net8.WorkFlow.StepBodys;

public class HelloWorld : StepBody
{

   // private IUserRepository _userRepository;
    public HelloWorld( )
    {
       // _userRepository = userRepository;
    }

    //在这中实现需要执行的方法
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        //为数据库中添加一个新的用户
       

        //_userRepository.Add(new User()
        //{
        //    Name = $"Test",
        //    Status = 0,
        //    CreateTime = DateTime.Now,
        //    UpdateTime = DateTime.Now,
        //    CriticalModifyTime = DateTime.Now,
        //    LastErrorTime = DateTime.Now,
        //    ErrorCount = 0,
        //    Enable = true,
        //    TenantId = 0,
        //});

        return ExecutionResult.Next();
    }
}
