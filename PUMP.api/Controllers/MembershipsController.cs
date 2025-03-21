using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/memberships")]
public class MembershipsController : ControllerBase
{
    private readonly IMemberships _memberships;

    public MembershipsController(IMemberships memberships)
    {
        _memberships = memberships;
    }
    
    [Authorize(Policy = "General")]
    [HttpPost]
    public async Task<IActionResult> CreateMemberships([FromBody] Memberships memberships)
    {
        var result = await this._memberships.Create(memberships);
        if (result == false)
        {
            return BadRequest(result);

        }
        return Ok(result);
    }

    [Authorize(Policy = "General")]
    [HttpGet]
    public async Task<IActionResult> ReadMemberships(int? id)
    {
        var result = await this._memberships.Read(id);
        if (result == null)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    [Authorize(Policy = "General")]
    [HttpPut]
    public async Task<IActionResult> UpdateMemberships([FromBody] Memberships memberships)
    {
        var result = await this._memberships.Update(memberships);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpDelete]
    public async Task<IActionResult> DeleteMemberships(int? id)
    {
        var result = await this._memberships.Delete(id);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}