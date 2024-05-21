using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[Authorize]
[ApiController]
[Route("v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IProducts _products;
    public ProductsController(IProducts products)
    {
        this._products = products;
    }

    [Authorize(Policy = "Administrator")]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Products products)
    {
        var result = await this._products.Create(products);
        return Ok(result);
    }

    [Authorize(Policy = "General")]
    [HttpGet]
    public async Task<IActionResult> ReadProducts(int? id)
    {
        var result = await this._products.Read(id);
        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpPut]
    public async Task<IActionResult> UpdateProducts([FromBody] Products products)
    {
        var result = await this._products.Update(products);
        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        var result = await this._products.Delete(id);
        return Ok(result);
    }
}