using API.DTO.Employee;
using API.Interfaces;
using API.Models.Employee;
using API.Repositories;

namespace API.Services
{
    public class DepartmentService
    {
        private readonly IDepartment _departmentRepository;
        public DepartmentService(IDepartment departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Department_DTO> AddDepartment(Department_DTO departmentdto)
        {
            var department = new Department
            {
                DepartmentName = departmentdto.dto_DepartmentName
            };
            try
            {
                var addedDepartment = await _departmentRepository.AddDepartment(department);
                return new Department_DTO
                {
                    dto_Id = addedDepartment.Id,
                    dto_DepartmentName = addedDepartment.DepartmentName
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
