using API.DTO.Employee;
using API.Helpers;
using API.Interfaces;
using API.Models;
using API.Models.Employee;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeRepository;
        private readonly EmployeeService _employeeService;

        public EmployeeController(IEmployee employeeRepository, EmployeeService employeeService)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(EmployeeRepository));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(EmployeeService));
        }

        [HttpPost("AddEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddEmployee(Employee_DTO employee)
        {
            if(employee is null)
            {
                return BadRequest("Employee Data is null.");
            }
            await _employeeRepository.AddEmployee(employee);

            //await _dbContext.employeeDetails.AddAsync(employee);
            //await _dbContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpGet("GetAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employee = await _employeeRepository.GetAllEmployee();
            if(employee is null|| !employee.Any())
            {
                return NotFound("No Data Found");
            }
            return Ok(employee);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> GetEmployeeById(string id)
        {
            if(id == null)
            {
                return BadRequest("Please enter a valid Id");
            }
            var employee = await _employeeService.GetEmployeeById(id);
            if(employee == null)
            {
                return NotFound($"Employee with ID {id} Not Found.");
            }
            return Ok(employee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> UpdateEmployee(string id,Employee_DTO employee)
        {
            if(id == null)
            {
                return BadRequest("Please enter a valid id");
            }
            var updateEmployee = await _employeeService.UpdateEmployee(id, employee);
            if(updateEmployee == null)
            {
                return NotFound($"employee with Id {id} not found");
            }
            return Ok(updateEmployee);
        }
    }
}
