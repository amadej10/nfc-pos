using MediatR;
using nfc_pos.Application.Common.Interfaces;

namespace nfc_pos.Application.Common.DeductUserBalance;



public class DeductUserBalanceCommand : IRequest<UserBalanceVm>
{
    public string NfcId { get; set; } = null!;
    public decimal Amount { get; set; } = 0;

}


public class DeductUserBalanceCommandHandler : IRequestHandler<DeductUserBalanceCommand, UserBalanceVm>
{
    private readonly IIdentityService _IdentityService;

    public DeductUserBalanceCommandHandler(IIdentityService identityService)
    {
        _IdentityService = identityService;
    }

    public async Task<UserBalanceVm> Handle(DeductUserBalanceCommand request, CancellationToken cancellationToken)
    {
        var newBalance = await _IdentityService.DeductBalanceAsync(request.NfcId, request.Amount);

        return new UserBalanceVm
        {
            Balance = newBalance
        };
    }
}

