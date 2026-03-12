using Paramore.Brighter.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using Vouchitory.Voucher.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddBrighter()
    .AddVoucherOutboundMessages(builder.Configuration);

builder.Services.AddVoucherInboundMessages();

builder.Services.AddOpenApi();
var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();
app.MapGet("/", () => "Hello World!");
app.AddVoucherEndpoints();
app.Run();

