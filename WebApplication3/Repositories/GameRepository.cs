using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int gameId)
        {
            return await _context.Games.FirstOrDefaultAsync(g => g.GameId == gameId);
        }

        public async Task AddGameAsync(Game game)
        {
            _context.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(Game game)
        {
            _context.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int gameId)
        {
            var game = await _context.Games.FindAsync(gameId);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> GameExistsAsync(int gameId)
        {
            return await _context.Games.AnyAsync(e => e.GameId == gameId);
        }
    }
}