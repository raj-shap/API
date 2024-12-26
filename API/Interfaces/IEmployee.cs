using API.DTO.Employee;
using API.Models.Employee;

namespace API.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee_DTO>> GetAllEmployee();
        Task<EmployeeDetails> GetEmployeeById(string id);
        Task AddEmployee(Employee_DTO employee);
        Task<bool> DeleteEmployee(string id);
        Task UpdateEmployee(EmployeeDetails employee);
    }
}
