using Microsoft.Extensions.Logging;
using Paramore.Brighter;

namespace Vouchitory.Voucher.Command;

public partial class CreateVoucher(): Paramore.Brighter.Command(Id.Random())
{
    //public Id? CorrelationId { get; set; }
    //public Id Id { get; set; }
}

public partial class CreateVoucher;

public class CreateVoucherHandler(ILogger<CreateVoucherHandler> logger) : RequestHandlerAsync<CreateVoucher>
{
    public override Task<CreateVoucher> HandleAsync(CreateVoucher command, CancellationToken cancellationToken = new CancellationToken())
    {
        // todo: implement
        return Task.FromResult(command);
    }
}