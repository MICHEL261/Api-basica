using Employees.Backend.UnitsOfWork.interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Orders.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : GenericController<Employee>
    {
        private readonly IEmployeesUnitOfWork _employeeUnitOfWork;

        public EmployeeController(IGenericUnitOfWork<Employee> baseUnit, IEmployeesUnitOfWork employeeUnit) : base(baseUnit)
        {
            _employeeUnitOfWork = employeeUnit;
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _employeeUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("search/{text}")]
        public async Task<IActionResult> SearchAsync(string text)
        {
            var action = await _employeeUnitOfWork.GetAsync(text);
            if (action.WasSuccess)
                return Ok(action.Result);

            return NotFound();
        }

    }



}