using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/auth")]
public class AuthenticationController : ControllerBase
{
    // add deps injection
    private readonly IAuthentication _authentication;
    public AuthenticationController(IAuthentication authentication)
    {
        _authentication = authentication;
    }

    [HttpPost]
    public async Task<IActionResult> Auth([FromBody] Employees employees)
    {
        var result = await this._authentication.Login(employees);
        return Ok(result);
    }
}