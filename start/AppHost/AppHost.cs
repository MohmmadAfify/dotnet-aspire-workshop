using Projects;

var builder = DistributedApplication.CreateBuilder(args);


var myCache = builder.AddRedis("cache");

var myApi = builder.AddProject<Api>("api")
    .WithReference(myCache);


var web = builder.AddProject<MyWeatherHub>("myweatherhub")
    .WithReference(myApi)
    .WithExternalHttpEndpoints();

builder.Build().Run();
