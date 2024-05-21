using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[Authorize]
[ApiController]
[Route("v1/product/payments")]
public class ProductsPaymentsController : ControllerBase
{
    private readonly IProductsPayments _productPayments;
    public ProductsPaymentsController(IProductsPayments productPayments)
    {
        this._productPayments = productPayments;
    }

    [Authorize(Policy = "General")]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductsPayments productPayments)
    {
        var result = await this._productPayments.Create(productPayments);
        return Ok(result);
    }

    [Authorize(Policy = "General")]
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

    [Authorize(Policy = "Administrator")]
    [HttpPut]
    public async Task<IActionResult> UpdateProductsPayments([FromBody] ProductsPayments productPayments)
    {
        var result = await this._productPayments.Update(productPayments);
        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        var result = await this._productPayments.Delete(id);
        return Ok(result);
    }
}