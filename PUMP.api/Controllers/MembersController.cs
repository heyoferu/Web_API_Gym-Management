using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/members")]

public class MembersController : ControllerBase
{
    private readonly IMembers _members;

    public MembersController(IMembers members)
    {
        _members = members;
    }

    [Authorize(Policy = "General")]
    [HttpPost]
    public async Task<IActionResult> CreateMembers([FromBody] Members members)
    {
        var result = await this._members.Create(members);
        if (!result)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [Authorize(Policy = "General")]
    [HttpGet]
    public async Task<IActionResult> ReadMembers(int? id)
    {
        var result = await this._members.Read(id);
        if (result == null)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [Authorize(Policy = "General")]
    [HttpPut]
    public async Task<IActionResult> UpdateMebers([FromBody] Members members)
    {
        var result = await this._members.Update(members);
        if (!result)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpDelete]
    public async Task<IActionResult> DeleteMembers(int? id)
    {
        var result = await this._members.Delete(id);
        if (!result)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
}