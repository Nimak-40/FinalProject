using Achare.Infrastructure;
using Achare.src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class ServiceCategoryRepository : App.src.Domain.Core.Contracts.Repositories.IServiceCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public ServiceCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ServiceCategory>> GetAllAsync()
        {
            return await _dbContext.ServiceCategories
                                   .AsNoTracking()
                                   .ToListAsync();
        }

        public async Task<ServiceCategory?> GetByIdAsync(int id)
        {
            return await _dbContext.ServiceCategories
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public async Task<ServiceCategory?> GetByNameAsync(string name)
        {
            return await _dbContext.ServiceCategories
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(sc => sc.Name == name);
        }

        public async Task AddAsync(ServiceCategory serviceCategory)
        {
            await _dbContext.ServiceCategories.AddAsync(serviceCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ServiceCategory serviceCategory)
        {
            var existingCategory = await _dbContext.ServiceCategories
                                                    .FirstOrDefaultAsync(sc => sc.Id == serviceCategory.Id);

            if (existingCategory != null)
            {
                existingCategory.Name = serviceCategory.Name;
                existingCategory.Icon = serviceCategory.Icon;
                existingCategory.Description = serviceCategory.Description;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var serviceCategory = await GetByIdAsync(id);
            if (serviceCategory != null)
            {
                _dbContext.ServiceCategories.Remove(serviceCategory);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}