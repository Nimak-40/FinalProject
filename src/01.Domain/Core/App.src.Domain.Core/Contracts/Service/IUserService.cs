using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.src.Domain.Core.Contracts.Service
{
    public interface IUserService
    {
        Task<Result> ChargeUserBalanceAsync(int id, decimal money, CancellationToken cancellationToken);
        Task<Result> ConfirmUserByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<GetAllUserDto>> GetAllUsersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<UserStatusEnum> GetUserStatusByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result> RejectUserByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result> UpdateUserProfileAsync(UpdateUserDto model, CancellationToken cancellationToken);
        Task<Result> WithdrawFromBalanceAsync(int id, decimal money, CancellationToken cancellationToken);
    }
}
