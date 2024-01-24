using MessagePack;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;


namespace WebApplication3.Repositories
{
    public interface ISystemRequirementRepository
    {
        Task<IEnumerable<SystemRequirements>> GetAllSystemRequirementsAsync();
        Task<SystemRequirements> GetSystemRequirementsByIdAsync(int requirementId);
        Task AddSystemRequirementAsync(SystemRequirements systemRequirements);
        Task UpdateSystemRequirementAsync(SystemRequirements systemRequirements);
        Task DeleteSystemRequirementAsync(int requirementId);
        Task<bool> SystemRequirementExistsAsync(int requirementId);

    }
}
