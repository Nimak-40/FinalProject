using App.src.Domain.Core.Entities.Orders;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IOfferRepository
    {
        Task<List<Offer>> GetAllAsync();
        Task<Offer?> GetByIdAsync(int id);
        Task<List<Offer>> GetByOrderIdAsync(int orderId);
        Task<List<Offer>> GetBySpecialistIdAsync(int specialistId);
        Task AddAsync(Offer orderRequest);
        Task UpdateAsync(Offer orderRequest);
        Task DeleteAsync(int id);
    }
}
