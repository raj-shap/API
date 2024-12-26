using API.DTO.Employee;

namespace API.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee_DTO>> GetAllEmployee();
        Task<Employee_DTO> GetEmployeeById(int id);
        Task AddEmployee(Employee_DTO employee);
        Task<bool> DeleteEmployee(string id);
        Task UpdateEmployee(Employee_DTO employee);
    }
}
