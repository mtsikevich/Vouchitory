
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Vouchitory.Voucher.Extensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder AddVoucherEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGroup("voucher")
            .MapGet("/", () => "Hello World!");
        return builder;
    }
}