using API.DTO.Employee;
using API.Helpers;
using API.Interfaces;
using API.Models;
using API.Models.Employee;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        //for check HttpPatch --remove after HttpPatch testing complete
        private readonly MyDbContext _dbContext;

        public EmployeeController(EmployeeService employeeService, MyDbContext dbContext)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(EmployeeService));
            _dbContext = dbContext;
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
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


        //Update employee using HttpPatch it's send only the changed details not all details 
        // HttpPut send all details if we only change some fields 
        [HttpPatch("{id}/UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> UpdateEmployeePartial(string id, [FromBody] JsonPatchDocument<Employee_DTO> patchDocument)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Please enter a valid id");
            }
            try
            {
                var existingEmployee = _dbContext.employeeDetails.Where(s => s.Id == id).FirstOrDefault();

                if (existingEmployee == null)
                {
                    return NotFound($"employee with Id {id} not found");
                }

                var employeeDTO = new Employee_DTO
                {
                    dto_Id = existingEmployee.Id,
                    dto_UserName = existingEmployee.UserName,
                    dto_FirstName = existingEmployee.FirstName,
                    dto_MiddleName = existingEmployee.MiddleName,
                    dto_LastName = existingEmployee.LastName,
                    dto_Email = existingEmployee.Email,
                    dto_Dob = existingEmployee.Dob,
                    dto_Address = existingEmployee.Address,
                    dto_City = existingEmployee.City,
                    dto_State = existingEmployee.State,
                    dto_Country = existingEmployee.Country,
                    dto_PostalCode = existingEmployee.PostalCode,
                    dto_Phone = existingEmployee.Phone,
                    dto_EmergencyContactName = existingEmployee.EmergencyContactName,
                    dto_EmergencyContact = existingEmployee.EmergencyContact,
                    dto_Department = existingEmployee.DepartmentId,
                    dto_Position = existingEmployee.PositionId,
                    dto_ReportTo = existingEmployee.ReportTo,
                    dto_EmployeementType = existingEmployee.EmployeementType,
                    dto_Status = existingEmployee.Status,
                    dto_StartDate = existingEmployee.StartDate,
                    dto_CreatedBy = existingEmployee.CreatedBy,
                    dto_CreatedOn = existingEmployee.CreatedOn,
                    dto_ModifiedBy = existingEmployee.ModifiedBy,
                    dto_ModifiedOn = existingEmployee.ModifiedOn,

                };

                patchDocument.ApplyTo(employeeDTO, ModelState);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                {
                    existingEmployee.UserName = employeeDTO.dto_UserName;
                    existingEmployee.FirstName = employeeDTO.dto_FirstName;
                    existingEmployee.MiddleName = employeeDTO.dto_MiddleName;
                    existingEmployee.LastName = employeeDTO.dto_LastName;
                    existingEmployee.Email = employeeDTO.dto_Email;
                    existingEmployee.Dob = employeeDTO.dto_Dob;
                    existingEmployee.Address = employeeDTO.dto_Address;
                    existingEmployee.City = employeeDTO.dto_City;
                    existingEmployee.State = employeeDTO.dto_State;
                    existingEmployee.Country = employeeDTO.dto_Country;
                    existingEmployee.PostalCode = employeeDTO.dto_PostalCode;
                    existingEmployee.Phone = employeeDTO.dto_Phone;
                    existingEmployee.EmergencyContactName = employeeDTO.dto_EmergencyContactName;
                    existingEmployee.EmergencyContact = employeeDTO.dto_EmergencyContact;
                    existingEmployee.DepartmentId = employeeDTO.dto_Department;
                    existingEmployee.PositionId = employeeDTO.dto_Position;
                    existingEmployee.ReportTo = employeeDTO.dto_ReportTo;
                    existingEmployee.EmployeementType = employeeDTO.dto_EmployeementType;
                    existingEmployee.Status = employeeDTO.dto_Status;
                    existingEmployee.StartDate = employeeDTO.dto_StartDate;
                    existingEmployee.CreatedBy = employeeDTO.dto_CreatedBy;
                    existingEmployee.CreatedOn = employeeDTO.dto_CreatedOn;
                    existingEmployee.ModifiedBy = employeeDTO.dto_ModifiedBy;
                    existingEmployee.ModifiedOn = employeeDTO.dto_ModifiedOn;
                }

                _dbContext.Update(existingEmployee);
                await _dbContext.SaveChangesAsync();

                return Ok(existingEmployee);
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
