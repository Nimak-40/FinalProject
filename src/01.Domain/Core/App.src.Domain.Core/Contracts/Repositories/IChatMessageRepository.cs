using Achare.src.Domain.Core.Entities;
using App.src.Domain.Core.Entities.BaseEntities;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface ICommentRepository
    {
        Task AddAsync(Comment comment);
        Task DeleteAsync(int id);
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<List<Comment>> GetByOrderIdAsync(int orderId);
        Task UpdateAsync(Comment comment);
    }
}
