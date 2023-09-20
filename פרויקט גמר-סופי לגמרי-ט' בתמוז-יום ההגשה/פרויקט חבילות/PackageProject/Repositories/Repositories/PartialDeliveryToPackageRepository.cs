using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class PartialDeliveryToPackageRepository:IRepository<PartialDeliveryToPackage>
    {
        private readonly IContext _context;
        public PartialDeliveryToPackageRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<PartialDeliveryToPackage>> AddAsync(PartialDeliveryToPackage entity)
        {

            await _context.PartialDeliveryToPackages.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await _context.PartialDeliveryToPackages.ToListAsync();
        }

        public async Task<List<PartialDeliveryToPackage>> DeleteAsync(int id)
        {
            var c = await GetByIdAsync(id);
            _context.PartialDeliveryToPackages.Remove(c);
            await _context.SaveChangesAsync();
            return await _context.PartialDeliveryToPackages.ToListAsync();
        }

        public async Task<List<PartialDeliveryToPackage>> GetAllAsync()
        {
            return await _context.PartialDeliveryToPackages.ToListAsync();
        }

        public async Task<PartialDeliveryToPackage> GetByIdAsync(int id)
        {
            return await _context.PartialDeliveryToPackages.SingleAsync(c => c.PartialDeliveryToPackagesId == id);
        }

        public async Task<List<PartialDeliveryToPackage>> UpdateAsync(PartialDeliveryToPackage entity)
        {
            _context.PartialDeliveryToPackages.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.PartialDeliveryToPackages.ToListAsync();
        }
    }
}
