
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Rebus.Bus;
using Trellis;
using Trellis.Asp;
using Vouchitory.Voucher.Command;

namespace Vouchitory.Voucher.Extensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder AddVoucherEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("voucher");
        group.MapGet("/", (IBus bus) =>
            GetVouchers()
                .Tap(result => Console.WriteLine("successfully retrieved vouchers"))
                .TapOnFailure(error => Console.WriteLine($"failed to retrieve vouchers: {error}"))
                .ToHttpResult());

        group.MapGet("/b", async ([FromServices]IBus bus) =>
        {
            await bus.Publish(new CreateVoucher());
        });
        
        return builder;
    }

    private static Result<string> GetVouchers()
    {
        if(DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            return"Only Sundays are allowed to retrieve vouchers";

        return Result.Success("Pretend you are looking at a list of vouchers")
            .Ensure(_ => DateTime.Now.DayOfWeek == DayOfWeek.Sunday, Error.PreconditionFailed("Only Sundays are allowed to retrieve vouchers"))
            .Tap(result => Console.WriteLine("successfully retrieved vouchers. Result {0}", result))
            .TapOnFailure(error => Console.WriteLine($"failed to retrieve vouchers: {error}"));
    }
}
