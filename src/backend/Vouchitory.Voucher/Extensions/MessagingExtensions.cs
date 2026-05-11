using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.Serialization.Json;
using Vouchitory.Voucher.Command;

namespace Vouchitory.Voucher.Extensions;

public static class RebusExtensions
{
    public static void AddVoucherRebusIntegration(this IServiceCollection services, Action<RebusConfigurer> configure)
    {
        services.AddRebus((configure,provider ) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var rabbitMqConnectionString = configuration.GetConnectionString("message-queue");
                return configure
                    .Transport(t => t.UseRabbitMq(rabbitMqConnectionString, "voucher"))
                    .Routing( t => t.TypeBased().Map<CreateVoucher>("voucher"))
                    .Serialization(s => s.UseSystemTextJson());
            },
            onCreated: async (bus) =>
            {
                await bus.Subscribe<CreateVoucher>();
            }
        );

        services.AddRebusHandler<CreateVoucherHandler>();
    }
}