using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities;
using App.src.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public SubCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SubCategory>> GetAllAsync()
        {
            return await _dbContext.SubCategories
                                   .AsNoTracking()
                                   .ToListAsync();
        }

        public async Task<SubCategory?> GetByIdAsync(int id)
        {
            return await _dbContext.SubCategories
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public async Task<SubCategory?> GetByNameAsync(string name)
        {
            return await _dbContext.SubCategories
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(sc => sc.Title == name);
        }

        public async Task AddAsync(SubCategory serviceCategory)
        {
            await _dbContext.SubCategories.AddAsync(serviceCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubCategory serviceCategory)
        {
            var existingCategory = await _dbContext.SubCategories
                                                    .FirstOrDefaultAsync(sc => sc.Id == serviceCategory.Id);

            if (existingCategory != null)
            {
                existingCategory.Title = serviceCategory.Title;
                existingCategory.IsActive = serviceCategory.IsActive;


                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var serviceCategory = await GetByIdAsync(id);
            if (serviceCategory != null)
            {
                _dbContext.SubCategories.Remove(serviceCategory);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}