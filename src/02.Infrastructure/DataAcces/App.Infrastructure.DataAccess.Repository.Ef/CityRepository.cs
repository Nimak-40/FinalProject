
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.BaseEntities;
using App.src.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<CityRepository> _logger;


        public CityRepository(AppDbContext dbContext, ILogger<CityRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }
        public async Task<List<City>> GetAll(CancellationToken cancellationToken)
        {
            try
            {


                var items = await _dbContext.Cities.AsNoTracking()
                    .ToListAsync(cancellationToken);
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogError("This Error Raised in {RepositoryName} by {ErrorMessage}", "CityEfRepository", ex.Message);
                return [];
            }

        }
    }
}