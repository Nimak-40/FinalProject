using Achare.Infrastructure;
using Achare.src.Domain.Core.Entities;
using App.src.Domain.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _dbContext;

        public ServiceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _dbContext.Services
                                   .AsNoTracking()
                                   .ToListAsync();
        }

        public async Task<Service?> GetByIdAsync(int id)
        {
            return await _dbContext.Services
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Service>> GetByCategoryIdAsync(int categoryId)
        {
            return await _dbContext.Services
                                   .AsNoTracking()
                                   .Where(s => s.ServiceCategoryId == categoryId)
                                   .ToListAsync();
        }

        public async Task AddAsync(Service service)
        {
            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            var existingService = await _dbContext.Services
                                                   .FirstOrDefaultAsync(s => s.Id == service.Id);

            if (existingService != null)
            {
                existingService.ServiceCategoryId = service.ServiceCategoryId;
                existingService.Name = service.Name;
                existingService.Price = service.Price;
                existingService.Description = service.Description;
                existingService.BasePrice = service.BasePrice;
                existingService.EstimatedDurationInMinutes = service.EstimatedDurationInMinutes;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var service = await GetByIdAsync(id);
            if (service != null)
            {
                _dbContext.Services.Remove(service);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}