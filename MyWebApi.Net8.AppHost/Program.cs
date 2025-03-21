var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MyWebApi_Net8>("mywebapi-net8");

builder.Build().Run();
