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
    public class ClientsRepository : IRepository<Client>
    {
        private readonly IContext _context;
        public ClientsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> AddAsync(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await _context.Clients.ToListAsync();
        }

        public async Task<List<Client>> DeleteAsync(int id)
        {
            var c = await GetByIdAsync(id);
            _context.Clients.Remove(c);
            await _context.SaveChangesAsync();
            return await _context.Clients.ToListAsync();
        }

        public async Task<List<Client>> GetAllAsync()

        {
           int x= _context.Clients.Count();
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.SingleAsync(c => c.ClientId == id);
        }

        public async Task<List<Client>> UpdateAsync(Client entity)
        {
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync();
            return await _context.Clients.ToListAsync();
        }
    }
}
