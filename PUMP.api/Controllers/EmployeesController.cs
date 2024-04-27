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
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Employees employees)
    {
        var result = await this._employees.SaveEmployees(employees);
        if (result == false)
        {
            return BadRequest(result);

        }
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var result = await this._employees.GetEmployees();
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Employees employees)
    {
        var result = await this._employees.UpdateEmployees(employees);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Employees employees)
    {
        var result = await this._employees.DeleteEmployees(employees);
        if (result == false)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}