using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/accesses")]
public class AccessesController : ControllerBase
{
    private readonly IAccesses _accesses;

    public AccessesController(IAccesses accesses)
    {
        _accesses = accesses;
    }
    
    [Authorize(Policy = "General")]
    [HttpPost]
    public async Task<IActionResult> CreateAccesses([FromBody] Accesses accesses)
    {
        var result = await this._accesses.Create(accesses);
        if (result == false)
        {
            return BadRequest(result);

        }
        return Ok(result);
    }

    [Authorize(Policy = "General")]
    [HttpGet]
    public async Task<IActionResult> ReadAccesses(int? id)
    {
        var result = await this._accesses.Read(id);
        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [Authorize(Policy = "Administrator")]
    [HttpPut]
    public async Task<IActionResult> UpdateAccesses([FromBody] Accesses accesses)
    {
        var result = await this._accesses.Update(accesses);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAccesses(int? id)
    {
        var result = await this._accesses.Delete(id);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}