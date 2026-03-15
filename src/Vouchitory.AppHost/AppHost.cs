var builder = DistributedApplication.CreateBuilder(args);
var messageQueue = builder.AddLavinMQ("message-queue");
builder.AddProject<Projects.Vouchitory_Api>("vouchitory-api")
    .WithReference(messageQueue)
    .WaitFor(messageQueue);
builder.Build().Run();