using Microsoft.AspNetCore.Mvc;
using nfc_pos.Application.Common;
using nfc_pos.Application.Common.DeductUserBalance;
using nfc_pos.Application.Common.Interfaces;
using nfc_pos.Application.Common.TopUpUserBalance;
using nfc_pos.Application.Users.Commands.CreateUser;
using nfc_pos.Application.Users.Queries;

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

    [HttpGet]
    public async Task<ActionResult<UserVm>> GetUserNameAndBalance([FromQuery] GetUserQuery query)
    {
        return await Mediator.Send(query);
    }


    [HttpPost("TopUpBalance")]
    public async Task<ActionResult<UserBalanceVm>> TopUpBalance(TopUpUserBalanceCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPost("DeductBalance")]
    public async Task<ActionResult<UserBalanceVm>> DeductBalance(DeductUserBalanceCommand command)
    {
        return await Mediator.Send(command);
    }
}
