using MVCwithWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCwithWebAPI.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlDbContext _dbContext = new SqlDbContext();
        public async Task Add(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();
            _dbContext.Employees.Add(employee);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Employee> GetEmployee(string id)
        {
            try
            {
                Employee employee = await _dbContext.Employees.FindAsync(id);
                if (employee == null)
                {
                    return null;
                }
                return employee;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                var employees = await _dbContext.Employees.ToListAsync();
                return employees.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(string id)
        {
            try
            {
                Employee employee = await _dbContext.Employees.FindAsync(id);
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        private bool EmployeeExists(string id)
        {
            return _dbContext.Employees.Count(e => e.Id == id) > 0;
        }

    }
}