using MediatR;
using nfc_pos.Application.Common.Interfaces;

namespace nfc_pos.Application.Users.Queries;
public class GetUserQuery : IRequest<UserVm>
{
    public string NfcId { get; set; } = null!;

}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserVm>
{

    private readonly IIdentityService _IdentityService;

    public GetUserQueryHandler(IIdentityService identityService)
    {
        _IdentityService = identityService;
    }

    public async Task<UserVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _IdentityService.GetUserNameAndBalanceAsync(request.NfcId);

        return new UserVm
        {
            FullName = user.Name,
            Balance = user.Balance
        };
    }
}