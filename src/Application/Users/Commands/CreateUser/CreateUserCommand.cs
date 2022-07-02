
using MediatR;
using nfc_pos.Application.Common.Interfaces;

namespace nfc_pos.Application.Users.Commands.CreateUser;
public class CreateUserCommand : IRequest<string>
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string? NfcId { get; set; }
    public string? Description { get; set; }
    public decimal Balance { get; set; } = 0;

}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IIdentityService _IdentityService;

    public CreateUserCommandHandler(IIdentityService identityService)
    {
        _IdentityService = identityService;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var result = await _IdentityService.CreateUserAsync(
            request.Email,
            request.Name,
            request.Surname,
            request.Description,
            request.NfcId,
            request.Password);

        return result.UserId;
    }
}