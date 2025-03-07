
using App.src.Domain.Core.Dtos.Categories;
using App.src.Domain.Core.Entities;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface ISubServiceRepository
    {
        Task<List<CategoryService>> GetAllAsync(CancellationToken cancellationToken);
        Task<CategoryService?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<CategoryService>> GetByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
        Task AddAsync(CreateSubServiceDto dto, CancellationToken cancellationToken);
        Task UpdateAsync(CategoryService service, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
