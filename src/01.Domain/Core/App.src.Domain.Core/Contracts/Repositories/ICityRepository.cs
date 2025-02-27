using App.src.Domain.Core.Entities.BaseEntities;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync();
        Task<City?> GetByIdAsync(int id);
        Task<City?> GetByNameAsync(string name);
        Task AddAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(int id);
    }
}
