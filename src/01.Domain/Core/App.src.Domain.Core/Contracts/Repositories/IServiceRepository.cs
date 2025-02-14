using Achare.src.Domain.Core.Entities;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllAsync();
        Task<Service?> GetByIdAsync(int id);
        Task<List<Service>> GetByCategoryIdAsync(int categoryId);
        Task AddAsync(Service service);
        Task UpdateAsync(Service service);
        Task DeleteAsync(int id);
    }
}
