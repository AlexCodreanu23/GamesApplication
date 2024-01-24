using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public class SystemRequirementRepository : ISystemRequirementRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemRequirementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SystemRequirements>> GetAllSystemRequirementsAsync()
        {
            return await _context.SystemRequirements.ToListAsync();
        }

        public async Task<SystemRequirements> GetSystemRequirementsByIdAsync(int requirementId)
        {
            return await _context.SystemRequirements.FirstOrDefaultAsync(sr => sr.RequirementsId == requirementId);
        }

        public async Task AddSystemRequirementAsync(SystemRequirements systemRequirements)
        {
            _context.SystemRequirements.Add(systemRequirements);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSystemRequirementAsync(SystemRequirements systemRequirements)
        {
            _context.SystemRequirements.Update(systemRequirements);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSystemRequirementAsync(int requirementId)
        {
            var systemRequirement = await _context.SystemRequirements.FindAsync(requirementId);
            if (systemRequirement != null)
            {
                _context.SystemRequirements.Remove(systemRequirement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SystemRequirementExistsAsync(int requirementId)
        {
            return await _context.SystemRequirements.AnyAsync(e => e.RequirementsId == requirementId);
        }
    }
}
