using MyWebApi.Net8.WorkFlow.StepBodys;
using WorkflowCore.Interface;

namespace MyWebApi.Net8.WorkFlow.WorkFlows;

public class HelloWorkFlow : IWorkflow
{
    public string Id => nameof(HelloWorkFlow);

    public int Version => 1;

    public void Build(IWorkflowBuilder<object> builder)
    {
        builder
            .StartWith<HelloWorld>(); //helloworld为手动创建的一个step
    }
}   
