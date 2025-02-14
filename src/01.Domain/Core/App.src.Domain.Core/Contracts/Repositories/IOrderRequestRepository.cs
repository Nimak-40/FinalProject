using App.src.Domain.Core.Entities.Orders;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IOrderRequestRepository
    {
        Task<List<OrderRequest>> GetAllAsync();
        Task<OrderRequest?> GetByIdAsync(int id);
        Task<List<OrderRequest>> GetByOrderIdAsync(int orderId);
        Task<List<OrderRequest>> GetBySpecialistIdAsync(int specialistId);
        Task AddAsync(OrderRequest orderRequest);
        Task UpdateAsync(OrderRequest orderRequest);
        Task DeleteAsync(int id);
    }
}
