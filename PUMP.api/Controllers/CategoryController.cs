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

    [HttpGet]
    public async Task<IActionResult> ReadCategory()
    {
        var result = await this._category.Read();
        return Ok(result);
    }
    
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

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory([FromBody] Category category)
    {
        var result = await this._category.Delete(category);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}