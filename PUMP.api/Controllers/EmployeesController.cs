using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.api.Controllers;

[ApiController]
[Route("v1/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployees _employees;

    public EmployeesController(IEmployees employees)
    {
        _employees = employees;
    }
    
    [Authorize(Policy = "Administrator")]
    [HttpPost]
    public async Task<IActionResult> CreateEmployees([FromBody] Employees employees)
    {
        var result = await this._employees.Create(employees);
        if (result == false)
        {
            return BadRequest(result);

        }
        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpGet]
    public async Task<IActionResult> ReadEmployees(int? id)
    {
        var result = await this._employees.Read(id);
        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [Authorize(Policy = "Administrator")]
    [HttpPut]
    public async Task<IActionResult> UpdateEmployees([FromBody] Employees employees)
    {
        var result = await this._employees.Update(employees);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [Authorize(Policy = "Administrator")]
    [HttpDelete]
    public async Task<IActionResult> DeleteEmployees(int? id)
    {
        var result = await this._employees.Delete(id);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}