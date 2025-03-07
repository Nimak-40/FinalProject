using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Entities.UserEntities;
using App.src.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IUserRepository
    {

        Task<List<GetAllUserDto>> GetAllUsersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<UserStatusEnum> GetUserStatusByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result> WithdrawFromBalanceAsync(int id, decimal amount, CancellationToken cancellationToken);
        Task<Result> ChargeUserBalanceAsync(int id, decimal amount, CancellationToken cancellationToken);
        Task<Result> UpdateUserProfileAsync(UpdateUserDto model, CancellationToken cancellationToken);
        Task<Result> ConfirmUserByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result> RejectUserByIdAsync(int id, CancellationToken cancellationToken);
    }
}
