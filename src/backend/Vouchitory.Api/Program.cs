using Scalar.AspNetCore;
using Vouchitory.Voucher.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.AddRabbitMQClient("message-queue");
builder.Services.AddVoucherRebusIntegration(null);

builder.Services.AddOpenApi();
var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();
app.AddVoucherEndpoints();
app.Run();
