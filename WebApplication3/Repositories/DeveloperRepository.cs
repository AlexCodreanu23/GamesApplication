using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ApplicationDbContext _context;

        public DeveloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Developers>> GetAllDevelopersAsync()
        {
            return await _context.Developers.ToListAsync();
        }

        public async Task<Developers> GetDeveloperByIdAsync(int developerId)
        {
            return await _context.Developers.FirstOrDefaultAsync(d => d.DeveloperId == developerId);
        }

        public async Task AddDeveloperAsync(Developers developer)
        {
            _context.Add(developer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDeveloperAsync(Developers developer)
        {
            _context.Update(developer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDeveloperAsync(int developerId)
        {
            var developer = await _context.Developers.FindAsync(developerId);
            if (developer != null)
            {
                _context.Developers.Remove(developer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeveloperExistsAsync(int developerId)
        {
            return await _context.Developers.AnyAsync(e => e.DeveloperId == developerId);
        }
    }
}