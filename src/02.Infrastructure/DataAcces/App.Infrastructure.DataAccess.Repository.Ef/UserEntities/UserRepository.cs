
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Entities.UserEntities;
using App.src.Domain.Core.Enums;
using App.src.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository.Ef.UserEntities
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<List<GetAllUserDto>> GetAllUsersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.Users.AsNoTracking()
                    .Where(u => u.Status != UserStatusEnum.Rejected)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Include(u => u.City)
                    .Select(u => new GetAllUserDto
                    {
                        Id = u.Id,
                        Status = u.Status,
                        ImagePath = u.ImagePath,
                        Email = u.Email,
                        LastName = u.LastName ?? "نامشخص",
                        RoleName = _dbContext.Roles
                            .Where(r => _dbContext.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == r.Id))
                            .Select(r => r.Name)
                            .FirstOrDefault()
                    })
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {RepositoryName}: {ErrorMessage}", "UserEfRepository", ex.Message);
                return [];
            }
        }

        public async Task<UserStatusEnum> GetUserStatusByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.Users.AsNoTracking()
                    .Where(u => u.Id == id)
                    .Select(u => u.Status)
                    .FirstAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {RepositoryName}: {ErrorMessage}", "UserEfRepository", ex.Message);
                return UserStatusEnum.Pending;
            }
        }

        public async Task<Result> WithdrawFromBalanceAsync(int id, decimal amount, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.Users.FirstAsync(u => u.Id == id, cancellationToken);
                if (user.Balance < amount)
                    return Result.Failure("موجودی حساب کافی نیست، لطفا کیف پول خود را شارژ کنید");

                user.Balance -= amount;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Result.Success("مبلغ با موفقیت برداشت شد");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {RepositoryName}: {ErrorMessage}", "UserEfRepository", ex.Message);
                return Result.Failure("خطایی در پایگاه داده رخ داده است");
            }
        }

        public async Task<Result> ChargeUserBalanceAsync(int id, decimal amount, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
                if (user is null)
                    return Result.Failure("کاربر یافت نشد");

                user.Balance += amount;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Result.Success("کیف پول با موفقیت شارژ شد");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {RepositoryName}: {ErrorMessage}", "UserEfRepository", ex.Message);
                return Result.Failure("خطایی در پایگاه داده رخ داده است");
            }
        }

        public async Task<Result> UpdateUserProfileAsync(UpdateUserDto model, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == model.Id, cancellationToken);
                if (user is null)
                    return Result.Failure("کاربر یافت نشد");

                user.FirstName = model.FirstName;
                user.ImagePath = model.ImagePath;
                user.LastName = model.LastName;
                user.CityId = model.CityId;
                user.Email = model.Email;
                user.Balance = model.Balance;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return Result.Success("پروفایل با موفقیت بروزرسانی شد");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {RepositoryName}: {ErrorMessage}", "UserEfRepository", ex.Message);
                return Result.Failure("خطایی در پایگاه داده رخ داده است");
            }
        }

        public async Task<Result> ConfirmUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
                if (user is null)
                    return Result.Failure("کاربر یافت نشد");

                user.Status = UserStatusEnum.Accepted;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Result.Success("کاربر تایید شد");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {RepositoryName}: {ErrorMessage}", "UserEfRepository", ex.Message);
                return Result.Failure("خطایی در پایگاه داده رخ داده است");
            }
        }

        public async Task<Result> RejectUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
                if (user is null)
                    return Result.Failure("کاربر یافت نشد");

                user.Status = UserStatusEnum.Rejected;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {RepositoryName}: {ErrorMessage}", "UserEfRepository", ex.Message);
                return Result.Failure("خطایی در پایگاه داده رخ داده است");
            }
        }

    }
}
