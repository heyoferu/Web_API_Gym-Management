using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/productPayments")]
public class ProductsPaymentsController : ControllerBase
{
    private readonly IProductsPayments _productPayments;
    public ProductsPaymentsController(IProductsPayments productPayments)
    {
        this._productPayments = productPayments;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductsPayments productPayments)
    {
        var result = await this._productPayments.Create(productPayments);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ReadProductsPayments(int? id)
    {
        var result = await this._productPayments.Read(id);
        if (result == null)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductsPayments([FromBody] ProductsPayments productPayments)
    {
        var result = await this._productPayments.Update(productPayments);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromBody] ProductsPayments productPayments)
    {
        var result = await this._productPayments.Delete(productPayments);
        return Ok(result);
    }
}