using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _dbContext;

        public CityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _dbContext.Cities
                                   .AsNoTracking()
                                   .Include(c => c.Users)
                                   .ToListAsync();
        }

        public async Task<City?> GetByIdAsync(int id)
        {
            return await _dbContext.Cities
                                   .AsNoTracking()
                                   .Include(c => c.Users)
                                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<City?> GetByNameAsync(string name)
        {
            return await _dbContext.Cities
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task AddAsync(City city)
        {
            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(City city)
        {
            var existingCity = await _dbContext.Cities
                                                .FirstOrDefaultAsync(c => c.Id == city.Id);

            if (existingCity != null)
            {
                existingCity.Name = city.Name;
                existingCity.State = city.State;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var city = await GetByIdAsync(id);
            if (city != null)
            {
                _dbContext.Cities.Remove(city);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}