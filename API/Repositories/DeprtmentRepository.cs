using API.Interfaces;
using API.Models;
using API.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class DeprtmentRepository : IDepartment
    {
        private readonly MyDbContext _context;
        public DeprtmentRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Department> AddDepartment(Department department)
        {
            try
            {
                await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync();
                return department;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            try
            {
                var department = await _context.Departments.FindAsync(id);
                _context.Departments.Remove(department);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            try
            {
                var employees = await _context.Departments.Select(e => new Department()).ToListAsync();
                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            try
            {
                var employee = await _context.Departments.FindAsync(id);
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task UpdateDepartment(Department department)
        {
            try
            {
                _context.Departments.Update(department);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
