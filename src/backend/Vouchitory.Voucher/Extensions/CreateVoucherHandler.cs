using Rebus.Handlers;
using Vouchitory.Voucher.Command;

namespace Vouchitory.Voucher.Extensions;

internal class CreateVoucherHandler : IHandleMessages<CreateVoucher>
{
    public Task Handle(CreateVoucher message)
    {
        Console.WriteLine("CreateVoucherHandler received a message");
        
        return Task.CompletedTask;
    }
}