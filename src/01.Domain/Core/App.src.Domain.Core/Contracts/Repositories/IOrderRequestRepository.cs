using App.src.Domain.Core.Entities.Orders;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IOrderRequestRepository
    {
        Task<List<Offers>> GetAllAsync();
        Task<Offers?> GetByIdAsync(int id);
        Task<List<Offers>> GetByOrderIdAsync(int orderId);
        Task<List<Offers>> GetBySpecialistIdAsync(int specialistId);
        Task AddAsync(Offers orderRequest);
        Task UpdateAsync(Offers orderRequest);
        Task DeleteAsync(int id);
    }
}
