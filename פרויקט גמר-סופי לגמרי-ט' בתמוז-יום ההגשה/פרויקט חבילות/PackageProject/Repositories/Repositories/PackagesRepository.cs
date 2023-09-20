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
    public class PackagesRepository : IRepository<Package>
    {
        private readonly IContext _context;
        public PackagesRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<Package>> AddAsync(Package entity)
        {
            await _context.Packages.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await _context.Packages.ToListAsync();
        }

        public async Task<List<Package>> DeleteAsync(int id)
        {
            var c = await GetByIdAsync(id);
            _context.Packages.Remove(c);
            await _context.SaveChangesAsync();
            return await _context.Packages.ToListAsync();
        }

        public async Task<List<Package>> GetAllAsync()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package> GetByIdAsync(int id)
        {
            return await _context.Packages.SingleAsync(c => c.PackageId == id);
        }

        public async Task<List<Package>> UpdateAsync(Package entity)
        {
            Package package =await GetByIdAsync(entity.PackageId);
            package.AddressDestination= entity.AddressDestination;
            package.AddressSource= entity.AddressSource;
            package.ClientId= entity.ClientId;
            package.CollectingPointId= entity.CollectingPointId;
            package.State=entity.State;

           // _context.Packages.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.Packages.ToListAsync();
        }
        //public async Task<List<Meeting>> UpdateAsync(Meeting entity) 
        //{
        //    var old = await _context.meetings.FindAsync(entity.IDMeeting);
        //    _context.Meetings.remove(old); await AddAsync(entity);
        //    await _context.SaveChangesAsync(); return await _context.Meetings.ToListAsync();
        //}

    }
}
