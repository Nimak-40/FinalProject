using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Dtos.Categories;
using App.src.Domain.Core.Entities;
using App.src.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class SubServiceRepository : ISubServiceRepository
    {
        private readonly AppDbContext _dbContext;

        public SubServiceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoryService>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Services
                                   .AsNoTracking()
                                   .ToListAsync(cancellationToken);
        }

        public async Task<CategoryService?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Services
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<List<CategoryService>> GetByCategoryIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Services
                                   .AsNoTracking()
                                   .Where(s => s.SubCategoryId == categoryId)
                                   .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(CreateSubServiceDto dto, CancellationToken cancellationToken)
        {
            var service = new CategoryService
            {
                SubCategoryId = dto.SubCategoryId,
                Title = dto.Title,
                Price = dto.BasePrice,
                Description = dto.Description,
                ImagePath = dto.ImagePath
            };

            await _dbContext.Services.AddAsync(service, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(CategoryService service, CancellationToken cancellationToken)
        {
            var existingService = await _dbContext.Services
                                                   .FirstOrDefaultAsync(s => s.Id == service.Id, cancellationToken);

            if (existingService != null)
            {
                existingService.SubCategoryId = service.SubCategoryId;
                existingService.Title = service.Title;
                existingService.Price = service.Price;
                existingService.Description = service.Description;
                existingService.ImagePath = service.ImagePath;
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var service = await GetByIdAsync(id, cancellationToken);
            if (service != null)
            {
                _dbContext.Services.Remove(service);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
