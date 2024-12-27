using API.DTO.Employee;
using API.Helpers;
using API.Interfaces;
using API.Models.Employee;
using API.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Services
{
    public class EmployeeService
    {
        private readonly IEmployee _employeeRepository;

        public EmployeeService(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee_DTO> AddEmployee(Employee_DTO employeeDTO)
        {
            employeeDTO.dto_Id = IdGenerator.GenerateUniqueId();

            var employeeDetails = new EmployeeDetails()
            {
                Id = employeeDTO.dto_Id,
                UserName = employeeDTO.dto_UserName,
                FirstName = employeeDTO.dto_FirstName,
                MiddleName = employeeDTO.dto_MiddleName,
                LastName = employeeDTO.dto_LastName,
                Email = employeeDTO.dto_Email,
                Dob = employeeDTO.dto_Dob,
                Address = employeeDTO.dto_Address,
                City = employeeDTO.dto_City,
                State = employeeDTO.dto_State,
                Country = employeeDTO.dto_Country,
                PostalCode = employeeDTO.dto_PostalCode,
                Phone = employeeDTO.dto_Phone,
                EmergencyContactName = employeeDTO.dto_EmergencyContactName,
                EmergencyContact = employeeDTO.dto_EmergencyContact,
                DepartmentId = employeeDTO.dto_Department,
                PositionId = employeeDTO.dto_Position,
                ReportTo = employeeDTO.dto_ReportTo,
                EmployeementType = employeeDTO.dto_EmployeementType,
                Status = employeeDTO.dto_Status,
                StartDate = employeeDTO.dto_StartDate,
                CreatedBy = employeeDTO.dto_CreatedBy,
                CreatedOn = employeeDTO.dto_CreatedOn,
                ModifiedBy = employeeDTO.dto_ModifiedBy,
                ModifiedOn = employeeDTO.dto_ModifiedOn,
            };
            var addedEmployee = await _employeeRepository.AddEmployee(employeeDetails);

            return new Employee_DTO
            {
                dto_Id = addedEmployee.Id,
                dto_UserName = addedEmployee.UserName,
                dto_FirstName = addedEmployee.FirstName,
                dto_MiddleName = addedEmployee.MiddleName,
                dto_LastName = addedEmployee.LastName,
                dto_Email = addedEmployee.Email,
                dto_Dob = addedEmployee.Dob,
                dto_Address = addedEmployee.Address,
                dto_City = addedEmployee.City,
                dto_State = addedEmployee.State,
                dto_Country = addedEmployee.Country,
                dto_PostalCode = addedEmployee.PostalCode,
                dto_Phone = addedEmployee.Phone,
                dto_EmergencyContactName = addedEmployee.EmergencyContactName,
                dto_EmergencyContact = addedEmployee.EmergencyContact,
                dto_Department = addedEmployee.DepartmentId,
                dto_Position = addedEmployee.PositionId,
                dto_ReportTo = addedEmployee.ReportTo,
                dto_EmployeementType = addedEmployee.EmployeementType,
                dto_Status = addedEmployee.Status,
                dto_StartDate = addedEmployee.StartDate,
                dto_CreatedBy = addedEmployee.CreatedBy,
                dto_CreatedOn = addedEmployee.CreatedOn,
                dto_ModifiedBy = addedEmployee.ModifiedBy,
                dto_ModifiedOn = addedEmployee.ModifiedOn
            };
        }

        public async Task<IEnumerable<Employee_DTO>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployee();
            return employees.Select(e => new Employee_DTO
            {
                dto_Id = e.Id,
                dto_UserName = e.UserName,
                dto_FirstName = e.FirstName,
                dto_MiddleName = e.MiddleName,
                dto_LastName = e.LastName,
                dto_Email = e.Email,
                dto_Dob = e.Dob,
                dto_Address = e.Address,
                dto_City = e.City,
                dto_State = e.State,
                dto_Country = e.Country,
                dto_PostalCode = e.PostalCode,
                dto_Phone = e.Phone,
                dto_EmergencyContactName = e.EmergencyContactName,
                dto_EmergencyContact = e.EmergencyContact,
                dto_Department = e.DepartmentId,
                dto_Position = e.PositionId,
                dto_ReportTo = e.ReportTo,
                dto_EmployeementType = e.EmployeementType,
                dto_Status = e.Status,
                dto_StartDate = e.StartDate,
                dto_CreatedBy = e.CreatedBy,
                dto_CreatedOn = e.CreatedOn,
                dto_ModifiedBy = e.ModifiedBy,
                dto_ModifiedOn = e.ModifiedOn,
            }).ToList();


        }

        public async Task<Employee_DTO> GetEmployeeById(string id)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeById(id);

                return new Employee_DTO
                {
                    dto_Id = employee.Id,
                    dto_UserName = employee.UserName,
                    dto_FirstName = employee.FirstName,
                    dto_MiddleName = employee.MiddleName,
                    dto_LastName = employee.LastName,
                    dto_Email = employee.Email,
                    dto_Dob = employee.Dob,
                    dto_Address = employee.Address,
                    dto_City = employee.City,
                    dto_State = employee.State,
                    dto_Country = employee.Country,
                    dto_PostalCode = employee.PostalCode,
                    dto_Phone = employee.Phone,
                    dto_EmergencyContactName = employee.EmergencyContactName,
                    dto_EmergencyContact = employee.EmergencyContact,
                    dto_Department = employee.DepartmentId,
                    dto_Position = employee.PositionId,
                    dto_ReportTo = employee.ReportTo,
                    dto_EmployeementType = employee.EmployeementType,
                    dto_Status = employee.Status,
                    dto_StartDate = employee.StartDate,
                    dto_CreatedBy = employee.CreatedBy,
                    dto_CreatedOn = employee.CreatedOn,
                    dto_ModifiedBy = employee.ModifiedBy,
                    dto_ModifiedOn = employee.ModifiedOn,
                };
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occured", ex);
            }
        }

        public async Task<Employee_DTO> UpdateEmployee(string id, Employee_DTO employeedto)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeById(id);
                if (employee == null)
                {
                    return null;
                }
                employee.UserName = employeedto.dto_UserName;
                employee.FirstName = employeedto.dto_FirstName;
                employee.LastName = employeedto.dto_LastName;
                employee.Email = employeedto.dto_Email;
                employee.Dob = employeedto.dto_Dob;
                employee.Address = employeedto.dto_Address;
                employee.City = employeedto.dto_City;
                employee.State = employeedto.dto_State;
                employee.Country = employeedto.dto_Country;
                employee.PostalCode = employeedto.dto_PostalCode;
                employee.Phone = employeedto.dto_Phone;
                employee.EmergencyContactName = employeedto.dto_EmergencyContactName;
                employee.EmergencyContact = employeedto.dto_EmergencyContact;
                employee.DepartmentId = employeedto.dto_Department;
                employee.PositionId = employeedto.dto_Position;
                employee.ReportTo = employeedto.dto_ReportTo;
                employee.EmployeementType = employeedto.dto_EmployeementType;
                employee.Status = employeedto.dto_Status;
                employee.StartDate = employeedto.dto_StartDate;
                employee.CreatedOn = employeedto.dto_CreatedOn;
                employee.CreatedBy = employeedto.dto_CreatedBy;
                employee.ModifiedOn = employeedto.dto_ModifiedOn;
                employee.ModifiedBy = employeedto.dto_ModifiedBy;

                await _employeeRepository.UpdateEmployee(employee);
                return new Employee_DTO
                {
                    dto_Id = employee.Id,
                    dto_UserName = employee.UserName,
                    dto_FirstName = employee.FirstName,
                    dto_MiddleName = employee.MiddleName,
                    dto_LastName = employee.LastName,
                    dto_Email = employee.Email,
                    dto_Dob = employee.Dob,
                    dto_Address = employee.Address,
                    dto_City = employee.City,
                    dto_State = employee.State,
                    dto_Country = employee.Country,
                    dto_PostalCode = employee.PostalCode,
                    dto_Phone = employee.Phone,
                    dto_EmergencyContactName = employee.EmergencyContactName,
                    dto_EmergencyContact = employee.EmergencyContact,
                    dto_Department = employee.DepartmentId,
                    dto_Position = employee.PositionId,
                    dto_ReportTo = employee.ReportTo,
                    dto_EmployeementType = employee.EmployeementType,
                    dto_Status = employee.Status,
                    dto_StartDate = employee.StartDate,
                    dto_CreatedBy = employee.CreatedBy,
                    dto_CreatedOn = employee.CreatedOn,
                    dto_ModifiedBy = employee.ModifiedBy,
                    dto_ModifiedOn = employee.ModifiedOn,
                };

            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occured", ex);
            }

        }

        public async Task<OperationResult<bool>> DeleteEmployee(string id)
        {
            try
            {
                var deleted = await _employeeRepository.DeleteEmployee(id);
                if (!deleted)
                {
                    return OperationResult<bool>.ErrorResult("Employee not found", 404);
                }
                return OperationResult<bool>.SuccessResult(true, 204);
            }
            catch (Exception ex)
            {
                //for log
                Console.WriteLine(ex.Message);
                return OperationResult<bool>.ErrorResult(ex.Message, 500);
            }

        }
    }
}
