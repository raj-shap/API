using API.DTO.Employee;
using API.Interfaces;

namespace API.Services
{
    public class EmployeeService
    {
        private readonly IEmployee _employeeRepository;

        public EmployeeService(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee_DTO> GetEmployeeById(string id)
        {
            try
            {
                var employee = await  _employeeRepository.GetEmployeeById(id);
                if (employee == null)
                {
                    return null;
                }
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
                if(employee == null)
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
                employee.ModifiedOn= employeedto.dto_ModifiedOn;
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
            catch(KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occured", ex);
            }

        }
    }
}
