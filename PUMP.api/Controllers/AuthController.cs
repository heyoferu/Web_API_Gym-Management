using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[Route("v1/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuth _auth;

    public AuthController(IAuth auth)
    {
        _auth = auth;
    }

    [HttpPost]
    public async Task<IActionResult> Auth([FromBody] Users users)
    {
        var result = await this._auth.Login(users.Username, users.Password);

        if (result == null)
        {
            return Unauthorized(result);
        }

        return Ok(result);
    }
    
    [Authorize]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Users users)
    {
        var result = await this._auth.Register(users.Username, users.Password);

        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
    

