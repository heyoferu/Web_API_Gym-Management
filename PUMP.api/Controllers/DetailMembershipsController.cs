using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/detailMemberships")]
public class DetailMembershipsController : ControllerBase
{
    private readonly IDetailMemberships _detailMemberships;

    public DetailMembershipsController(IDetailMemberships detailMemberships)
    {
        _detailMemberships = detailMemberships;
    }
    
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

    [HttpGet]
    public async Task<IActionResult> ReadDetailMemberships()
    {
        var result = await this._detailMemberships.Read();
        return Ok(result);
    }
    
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

    [HttpDelete]
    public async Task<IActionResult> DeleteDetailMemberships([FromBody] DetailMemberships detailMemberships)
    {
        var result = await this._detailMemberships.Delete(detailMemberships);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}