using Achare.Infrastructure;
using Achare.src.Domain.Core.Entities;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository.Ef.UserEntities
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<SpecialistRepository> _logger ;

        public SpecialistRepository(AppDbContext dbContext, ILogger<SpecialistRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Result> Create(int userId, string resume ,CancellationToken cancellationToken)
        {
            try
            {
                var specialist = new Specialist()
                {
                    Resume = resume,
                    Rating = 0,  // Initial rating can be set to 0 or some default value.
                    IsAvailable = true, // Default availability can be set to true.
                    UserId = userId,
                };

                await _dbContext.Specialists.AddAsync(specialist, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Result.Success("کارشناس جدید با موفقیت ایجاد شد");
            }
            catch (Exception ex)
            {
                _logger.LogError("This Error Raised in {RepositoryName} by {ErrorMessage}", "SpecialistEfRepository", ex.Message);
                return Result.Failure("مشکلی در دیتا بیس وجود دارد");
            }
        }

        public async Task<int> GetTotalCount(CancellationToken cancellationToken)
        {
            try
            {
                var count = await _dbContext.Specialists.AsNoTracking()
                    .Include(s => s.User)
                    .Where(s => s.User!.Status != src.Domain.Core.Enums.UserStatusEnum.Rejected)
                    .CountAsync(cancellationToken);

                return count;
            }
            catch (Exception ex)
            {
                _logger.LogError("This Error Raised in {RepositoryName} by {ErrorMessage}", "SpecialistEfRepository", ex.Message);
                return 0;
            }
        }
    }
}
