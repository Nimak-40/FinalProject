using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AppDbContext _dbContext;

        public OfferRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Offer>> GetAllAsync()
        {
            return await _dbContext.Offers
                                   .AsNoTracking()
                                   .Include(r => r.Order)
                                   .Include(r => r.Specialist)
                                   .ToListAsync();
        }

        public async Task<Offer?> GetByIdAsync(int id)
        {
            return await _dbContext.Offers
                                   .AsNoTracking()
                                   .Include(r => r.Order)
                                   .Include(r => r.Specialist)
                                   .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Offer>> GetByOrderIdAsync(int orderId)
        {
            return await _dbContext.Offers
                                   .AsNoTracking()
                                   .Where(r => r.OrderId == orderId)
                                   .Include(r => r.Specialist)
                                   .ToListAsync();
        }

        public async Task<List<Offer>> GetBySpecialistIdAsync(int specialistId)
        {
            return await _dbContext.Offers
                                   .AsNoTracking()
                                   .Where(r => r.SpecialistId == specialistId)
                                   .Include(r => r.Order)
                                   .ToListAsync();
        }

        public async Task AddAsync(Offer orderRequest)
        {
            await _dbContext.Offers.AddAsync(orderRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Offer orderRequest)
        {
            var existingOrderRequest = await _dbContext.Offers
                                                     .FirstOrDefaultAsync(r => r.Id == orderRequest.Id);

            if (existingOrderRequest != null)
            {
                existingOrderRequest.Status = orderRequest.Status;
                existingOrderRequest.RequestDate = orderRequest.RequestDate;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var orderRequest = await GetByIdAsync(id);
            if (orderRequest != null)
            {
                _dbContext.Offers.Remove(orderRequest);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}