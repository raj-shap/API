using API.Models.Employee;

namespace API.Interfaces
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        Task UpdateDepartment(Department department);
        Task<Department> AddDepartment(Department department);
        Task<bool> DeleteDepartment(int id);
    }
}
