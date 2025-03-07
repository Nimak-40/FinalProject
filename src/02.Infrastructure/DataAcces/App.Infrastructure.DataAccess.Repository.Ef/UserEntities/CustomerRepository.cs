
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Entities.UserEntities;
using App.src.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository.Ef.UserEntities
{


    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<SpecialistRepository> _logger;

        public CustomerRepository(AppDbContext dbContext, ILogger<SpecialistRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<int> GetTotalCount(CancellationToken cancellationToken)
        {
            try
            {
                var totalCount = await _dbContext.Customers.AsNoTracking()
                    .Include(c => c.User)
                    .Where(c => c.User!.Status != src.Domain.Core.Enums.UserStatusEnum.Rejected)
                    .CountAsync(cancellationToken);

                return totalCount;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {RepositoryName}: {ErrorMessage}", "CustomerEfRepository", ex.Message);
                return 0;
            }
        }

        public async Task<Result> Create(int userId, string firstName, int cityId, CancellationToken cancellationToken)
        {
            try
            {
                var customer = new Customer()
                {
                    FirstName = firstName,
                    CityId = cityId,
                    UserId = userId,
                };

                await _dbContext.Customers.AddAsync(customer, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Result.Success("مشتری جدید با موفقیت ایجاد شد");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {RepositoryName}: {ErrorMessage}", "CustomerEfRepository", ex.Message);
                return Result.Failure("مشکلی در دیتا بیس وجود دارد");
            }
        }
    }
}


