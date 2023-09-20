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
    public class PartialDeliveryRepository : IRepository<PartialDelivery>
    {
        private readonly IContext _context;
        public PartialDeliveryRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<PartialDelivery>> AddAsync(PartialDelivery entity)
        {
            DateTime date = (DateTime)entity.EstimatedTimeOfArrival;
            entity.EstimatedTimeOfArrival = new DateTime(date.Year, date.Month, date.Day
                , date.Hour, date.Minute, date.Second, DateTimeKind.Local);
            await _context.PartialDeliveries.AddAsync(entity);
            Task<List<PartialDelivery>> c=null;
            try
            {
                await _context.SaveChangesAsync();
                c=_context.PartialDeliveries.ToListAsync();
            }
            catch (Exception )
            {

                throw;
            }
            
            return await c;
        }

        public async Task<List<PartialDelivery>> DeleteAsync(int id)
        {
            var c = await GetByIdAsync(id);
            _context.PartialDeliveries.Remove(c);
            await _context.SaveChangesAsync();
            return await _context.PartialDeliveries.ToListAsync();
            
        }

        public async Task<List<PartialDelivery>> GetAllAsync()
        {
            return await _context.PartialDeliveries.ToListAsync();
        }

        public async Task<PartialDelivery> GetByIdAsync(int id)
        {
            return await _context.PartialDeliveries.SingleAsync(c => c.PartialDeliveryId == id);
        }

        public async Task<List<PartialDelivery>> UpdateAsync(PartialDelivery entity)
        {
            _context.PartialDeliveries.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.PartialDeliveries.ToListAsync();
        }
    }
}
