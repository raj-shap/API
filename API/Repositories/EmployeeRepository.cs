using API.DTO.Employee;
using API.Helpers;
using API.Interfaces;
using API.Models;
using API.Models.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    [Authorize]
    public class EmployeeRepository : IEmployee
    {
        private MyDbContext _dbContext;
        public EmployeeRepository(MyDbContext    dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<EmployeeDetails> AddEmployee(EmployeeDetails employeeDetails)
        {
            try
            {
                _dbContext.employeeDetails.Add(employeeDetails);
                await _dbContext.SaveChangesAsync();
                return employeeDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error while adding employee", ex);
            }
        }

        public async Task<IEnumerable<EmployeeDetails>> GetAllEmployee()
        {
            return await _dbContext.employeeDetails.ToListAsync();
        }

        public async Task<EmployeeDetails> GetEmployeeById(string id)
        {
            var employee = await _dbContext.employeeDetails.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee Not found");
            }
            return employee;
        }

        public async Task UpdateEmployee(EmployeeDetails employee)
        {
            try
            {
                _dbContext.employeeDetails.Update(employee);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error while updating employee", ex);
            }
        }

        public async Task<bool> DeleteEmployee(string id)
        {
            var emp = await _dbContext.employeeDetails.FirstOrDefaultAsync(e => e.Id == id);
            if (emp == null)
            {
                throw new Exception("Employee Not Found");
            }
            try
            {
                _dbContext.employeeDetails.Remove(emp);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting employee", ex);
            }
        }

    }
}
