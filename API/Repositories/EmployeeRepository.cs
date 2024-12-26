using API.DTO.Employee;
using API.Helpers;
using API.Interfaces;
using API.Models;
using API.Models.Employee;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private MyDbContext _dbContext;
        public EmployeeRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddEmployee(Employee_DTO employee)
        {
            employee.dto_Id = IdGenerator.GenerateUniqueId();
            var emp = new EmployeeDetails()
            {
                UserName = employee.dto_UserName,
                FirstName = employee.dto_FirstName,
                MiddleName = employee.dto_MiddleName,
                LastName = employee.dto_LastName,
                Email = employee.dto_Email,
                Dob = employee.dto_Dob,
                Address = employee.dto_Address,
                City = employee.dto_City,
                State = employee.dto_State,
                Country = employee.dto_Country,
                PostalCode = employee.dto_PostalCode,
                Phone = employee.dto_Phone,
                EmergencyContactName = employee.dto_EmergencyContactName,
                EmergencyContact = employee.dto_EmergencyContact,
                Department = employee.dto_Department,
                Position = employee.dto_Position,
                ReportTo = employee.dto_ReportTo,
                EmployeementType = employee.dto_EmployeementType,
                Status = employee.dto_Status,
                StartDate = employee.dto_StartDate,
                CreatedBy = employee.dto_CreatedBy,
                CreatedOn = employee.dto_CreatedOn,
                ModifiedBy = employee.dto_ModifiedBy,
                ModifiedOn = employee.dto_ModifiedOn,
            };
            await _dbContext.AddAsync(emp);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmployee(string id)
        {
            var emp = _dbContext.employeeDetails.Where(e=>e.Id == id).FirstOrDefault();
            if(emp != null)
            {
                _dbContext.employeeDetails.Remove(emp);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            throw new KeyNotFoundException("Employee Not Found");
        }

        public Task<IEnumerable<Employee_DTO>> GetAllEmployee()
        {
            var emp = _dbContext.employeeDetails.Select(e => new Employee_DTO()
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
                dto_Department = e.Department,
                dto_Position = e.Position,
                dto_ReportTo = e.ReportTo,
                dto_EmployeementType = e.EmployeementType,
                dto_Status = e.Status,
                dto_StartDate = e.StartDate,
                dto_CreatedBy = e.CreatedBy,
                dto_CreatedOn = e.CreatedOn,
                dto_ModifiedBy = e.ModifiedBy,
                dto_ModifiedOn = e.ModifiedOn,
            });

            return ;
        }

        public Task<Employee_DTO> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(Employee_DTO employee)
        {
            throw new NotImplementedException();
        }

    }
}
