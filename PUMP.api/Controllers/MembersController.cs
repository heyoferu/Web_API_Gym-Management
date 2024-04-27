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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Members members)
    {
        var result = await this._members.Save(members);
        if (!result)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var result = await this._members.Get();
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Members members)
    {
        var result = await this._members.Update(members);
        if (!result)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Members members)
    {
        var result = await this._members.Delete(members);
        if (!result)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
}