using Elsa.Http;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using System.Net;

namespace MyWebApi.Net8.WorkFlows
{
    public class HelloWorldHttpWorkflow : WorkflowBase
    {
        protected override void Build(IWorkflowBuilder builder)
        {
            builder.Root = new Sequence
            {
                Activities =
            {
                new HttpEndpoint
                {
                    Path = new("/hello-world"),
                    SupportedMethods = new([HttpMethods.Get]),
                    CanStartWorkflow = true
                },
                new WriteHttpResponse
                {
                    StatusCode = new(HttpStatusCode.OK),
                    Content = new("Hello world!")
                }
            }
            };
        }
    }
}