using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class OrderRequestRepository : IOrderRequestRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRequestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Offers>> GetAllAsync()
        {
            return await _dbContext.OrderRequests
                                   .AsNoTracking()
                                   .Include(r => r.Order)
                                   .Include(r => r.Specialist)
                                   .ToListAsync();
        }

        public async Task<Offers?> GetByIdAsync(int id)
        {
            return await _dbContext.OrderRequests
                                   .AsNoTracking()
                                   .Include(r => r.Order)
                                   .Include(r => r.Specialist)
                                   .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Offers>> GetByOrderIdAsync(int orderId)
        {
            return await _dbContext.OrderRequests
                                   .AsNoTracking()
                                   .Where(r => r.OrderId == orderId)
                                   .Include(r => r.Specialist)
                                   .ToListAsync();
        }

        public async Task<List<Offers>> GetBySpecialistIdAsync(int specialistId)
        {
            return await _dbContext.OrderRequests
                                   .AsNoTracking()
                                   .Where(r => r.SpecialistId == specialistId)
                                   .Include(r => r.Order)
                                   .ToListAsync();
        }

        public async Task AddAsync(Offers orderRequest)
        {
            await _dbContext.OrderRequests.AddAsync(orderRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Offers orderRequest)
        {
            var existingOrderRequest = await _dbContext.OrderRequests
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
                _dbContext.OrderRequests.Remove(orderRequest);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}