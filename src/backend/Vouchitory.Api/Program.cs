using Paramore.Brighter.Extensions.DependencyInjection;
using Vouchitory.Voucher.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBrighter()
    .AddVoucherOutboundMessages();

builder.Services.AddVoucherInboundMessages();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();