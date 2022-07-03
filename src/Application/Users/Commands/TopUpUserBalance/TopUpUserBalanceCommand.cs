using MediatR;
using nfc_pos.Application.Common.Interfaces;

namespace nfc_pos.Application.Common.TopUpUserBalance;


public class TopUpUserBalanceCommand : IRequest<UserBalanceVm>
{
    public string NfcId { get; set; } = null!;
    public decimal Amount { get; set; } = 0;

}

public class TopUpUserBalanceCommandHandler : IRequestHandler<TopUpUserBalanceCommand, UserBalanceVm>
{
    private readonly IIdentityService _IdentityService;

    public TopUpUserBalanceCommandHandler(IIdentityService identityService)
    {
        _IdentityService = identityService;
    }

    public async Task<UserBalanceVm> Handle(TopUpUserBalanceCommand request, CancellationToken cancellationToken)
    {

        var newBalance = await _IdentityService.TopUpBalanceAsync(request.NfcId, request.Amount);

        return new UserBalanceVm
        {
            Balance = newBalance
        };

    }
}
