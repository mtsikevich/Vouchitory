var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.Vouchitory_Api>("vouchitory-api");
builder.Build().Run();