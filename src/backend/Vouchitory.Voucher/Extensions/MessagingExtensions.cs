using Microsoft.Extensions.DependencyInjection;
using Paramore.Brighter;
using Paramore.Brighter.Extensions.DependencyInjection;
using Paramore.Brighter.ServiceActivator.Extensions.DependencyInjection;

namespace Vouchitory.Voucher.Extensions;

public static class MessagingExtensions
{
    public static IBrighterBuilder AddVoucherOutboundMessages(
        this IBrighterBuilder builder,
        Action<ProducersConfiguration> configure = null,
        ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
    {
        builder.AddProducers(configure, serviceLifetime);
        return builder;
    }
    
    public static IServiceCollection AddVoucherInboundMessages(
        this IServiceCollection services,
        Action<ConsumersOptions>? configure = null)
    {
        services.AddConsumers(configure);
        return services;
    }

    private static Action<ProducersConfiguration> OutboundMessageConfigurator => (ProducersConfiguration producersConfiguration) =>
    {
        
    };
    
    private static Action<ConsumersOptions> InboundMessageConfigurator => (ConsumersOptions consumersOptions) =>
    {
        
    };
}

