using Application.Features.Auth.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class AuthenticationController : ApiControllerBase
{
    // GET
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync(AuthRegisterCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}