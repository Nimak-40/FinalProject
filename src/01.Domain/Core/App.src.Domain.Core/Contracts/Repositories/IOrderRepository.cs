using App.src.Domain.Core.Entities.Orders;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<List<Order>> GetByCustomerIdAsync(int customerId);
        Task<List<Order>> GetByServiceIdAsync(int serviceId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
