using Microsoft.AspNetCore.Mvc;
using nfc_pos.Application.Common.Interfaces;
using nfc_pos.Application.Users.Commands.CreateUser;

namespace nfc_pos.WebUI.Controllers;
public class UsersController : ApiControllerBase
{
    public UsersController(IIdentityService identityService)
    {
        _IdentityService = identityService;
    }

    public IIdentityService _IdentityService { get; }

     [HttpPost]
    public async Task<ActionResult<string>> Create(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }
}
