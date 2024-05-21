using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategory _category;

    public CategoryController(ICategory category)
    {
        _category = category;
    }
    
    [Authorize(Policy = "Adminstrator")]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] Category category)
    {
        var result = await this._category.Create(category);
        if (result == false)
        {
            return BadRequest(result);

        }
        return Ok(result);
    }

    [Authorize(Policy = "General")]
    [HttpGet]
    public async Task<IActionResult> ReadCategory(int? id)
    {
        var result = await this._category.Read(id);
        if (result == null)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    [Authorize(Policy = "Administrator")]
    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] Category category)
    {
        var result = await this._category.Update(category);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int? id)
    {
        var result = await this._category.Delete(id);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}