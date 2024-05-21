using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/memberships/details")]
public class DetailMembershipsController : ControllerBase
{
    private readonly IDetailMemberships _detailMemberships;

    public DetailMembershipsController(IDetailMemberships detailMemberships)
    {
        _detailMemberships = detailMemberships;
    }
    
    [Authorize(Policy = "General")]
    [HttpPost]
    public async Task<IActionResult> CreateDetailMemberships([FromBody] DetailMemberships detailMemberships)
    {
        var result = await this._detailMemberships.Create(detailMemberships);
        if (result == false)
        {
            return BadRequest(result);

        }
        return Ok(result);
    }

    [Authorize(Policy = "General")]
    [HttpGet]
    public async Task<IActionResult> ReadDetailMemberships(int? id)
    {
        var result = await this._detailMemberships.Read(id);
        if (result == null)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    [Authorize(Policy = "General")]
    [HttpPut]
    public async Task<IActionResult> UpdateDetailMemberships([FromBody] DetailMemberships detailMemberships)
    {
        var result = await this._detailMemberships.Update(detailMemberships);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpDelete]
    public async Task<IActionResult> DeleteDetailMemberships(int? id)
    {
        var result = await this._detailMemberships.Delete(id);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}