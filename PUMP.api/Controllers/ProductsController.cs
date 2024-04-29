using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IProducts _products;
    public ProductsController(IProducts products)
    {
        this._products = products;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Products products)
    {
        var result = await this._products.Create(products);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ReadProducts()
    {
        var result = await this._products.Read();

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProducts([FromBody] Products products)
    {
        var result = await this._products.Update(products);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromBody] Products products)
    {
        var result = await this._products.Delete(products);
        return Ok(result);
    }
}