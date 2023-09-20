using Microsoft.EntityFrameworkCore;
//using Repositories.Entities;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Entities;

namespace Repositories.Repositories
{
    public class BusinessDaysRepository : IRepository<BusinessDay>
    {
        private readonly IContext _context;
        public BusinessDaysRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<BusinessDay>> AddAsync(BusinessDay entity)
        {
            await _context.BusinessDays.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await _context.BusinessDays.ToListAsync();
        }

        public async Task<List<BusinessDay>> DeleteAsync(int id)
        {
            var c = await GetByIdAsync(id);
            _context.BusinessDays.Remove(c);
            await _context.SaveChangesAsync();
            return  await _context.BusinessDays.ToListAsync();
        }

        public async Task<List<BusinessDay>> GetAllAsync()
        {
            return await _context.BusinessDays.ToListAsync();
        }

        public async Task<BusinessDay> GetByIdAsync(int id)
        {
            return await _context.BusinessDays.SingleAsync(c => c.BusinessDayId == id);
        }

        public async Task<List<BusinessDay>> UpdateAsync(BusinessDay entity)
        {
            _context.BusinessDays.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.BusinessDays.ToListAsync();
        }
    }
}
