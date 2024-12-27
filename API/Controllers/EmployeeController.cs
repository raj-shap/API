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
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(EmployeeService));
        }

        [HttpPost("AddEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Employee_DTO>> AddEmployee(Employee_DTO employeeDto)
        {
            if (employeeDto is null)
            {
                return BadRequest("Employee Data is null.");
            }
            try
            {
                var addedEmployee = await _employeeService.AddEmployee(employeeDto);
                return CreatedAtAction(nameof(AddEmployee), new { id = addedEmployee.dto_Id }, addedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internl Server error : {ex.Message}");
            }
        }

        [HttpGet("GetAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employee = await _employeeService.GetAllEmployees();
                if (employee is null || !employee.Any())
                {
                    return NotFound("No Data Found");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internl Server error : {ex.Message}");
            }
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

            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Please enter a valid Id");
            }
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} Not Found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internl Server error : {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> UpdateEmployee(string id, Employee_DTO employee)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Please enter a valid id");
            }
            try
            {
                var updateEmployee = await _employeeService.UpdateEmployee(id, employee);
                if (updateEmployee == null)
                {
                    return NotFound($"employee with Id {id} not found");
                }
                return Ok(updateEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internl Server error : {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Please enter a valid Id");
            }
            try
            {
                await _employeeService.DeleteEmployee(id);
                return Ok("Employee Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internl Server error : {ex.Message}");
            }
        }
    }
}
