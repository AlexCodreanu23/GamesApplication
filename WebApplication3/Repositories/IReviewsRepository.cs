using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public interface IReviewsRepository
    {
        Task<IEnumerable<Reviews>> GetAllReviewsAsync();
        Task<Reviews> GetReviewByIdAsync(int reviewId);
        Task AddReviewAsync(Reviews review);
        Task UpdateReviewAsync(Reviews review);
        Task DeleteReviewAsync(int reviewId);
        Task<bool> ReviewExistsAsync(int reviewId);
    }
}