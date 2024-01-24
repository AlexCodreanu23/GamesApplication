using MessagePack;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;


namespace WebApplication3.Repositories
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developers>> GetAllDevelopersAsync();
        Task<Developers> GetDeveloperByIdAsync(int developerId);
        Task AddDeveloperAsync(Developers developer);
        Task UpdateDeveloperAsync(Developers developer);
        Task DeleteDeveloperAsync(int developerId);
        Task<bool>DeveloperExistsAsync(int developerId);

    }
}
