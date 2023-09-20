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
    public class CollectingPointRepository:IRepository<CollectingPoint>
    {
        private readonly IContext _context;
        public CollectingPointRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<CollectingPoint>> AddAsync(CollectingPoint entity)
        {
            await _context.CollectingPoints.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await _context.CollectingPoints.ToListAsync();
        }

        public async Task<List<CollectingPoint>> DeleteAsync(int id)
        {
            var c = await GetByIdAsync(id);
            _context.CollectingPoints.Remove(c);
            await _context.SaveChangesAsync();
            return await _context.CollectingPoints.ToListAsync();
        }

        public async Task<List<CollectingPoint>> GetAllAsync()
        {
            return await _context.CollectingPoints.ToListAsync();
        }

        public async Task<CollectingPoint> GetByIdAsync(int id)
        {
            return await _context.CollectingPoints.SingleAsync(c => c.CollectingPointId == id);
        }

        public async Task<List<CollectingPoint>> UpdateAsync(CollectingPoint entity)
        {
            CollectingPoint collectingPoint=await GetByIdAsync(entity.CollectingPointId);
            collectingPoint.LocationX= entity.LocationX;
            collectingPoint.LocationY = entity.LocationY;
            collectingPoint.State = entity.State;
            collectingPoint.Address = entity.Address;
            collectingPoint.PackageId = entity.PackageId;
            collectingPoint.CollectingPointName = entity.CollectingPointName;
            collectingPoint.ColPointType = entity.ColPointType;
            //_context.CollectingPoints.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.CollectingPoints.ToListAsync();
        }
    }
}
