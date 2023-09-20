using Microsoft.EntityFrameworkCore;
//using Repositories.Entities;
using Repositories.Entities;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class EmployeesRepository : IRepository<Employee>
    {
        private readonly IContext _context;
        public EmployeesRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> AddAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> DeleteAsync(int id)
        {
            var c = await GetByIdAsync(id);
            _context.Employees.Remove(c);
            await _context.SaveChangesAsync();
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.SingleAsync(c => c.EmployeeId == id);
        }

        public async Task<List<Employee>> UpdateAsync(Employee entity)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.Employees.ToListAsync();
        }
    }
}
