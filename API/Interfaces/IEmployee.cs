using API.DTO.Employee;
using API.Models.Employee;

namespace API.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<EmployeeDetails>> GetAllEmployee();
        Task<EmployeeDetails> GetEmployeeById(string id);
        Task<EmployeeDetails> AddEmployee(EmployeeDetails employee);
        Task<bool> DeleteEmployee(string id);
        Task UpdateEmployee(EmployeeDetails employee);
    }
}
