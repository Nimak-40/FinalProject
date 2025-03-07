using Microsoft.AspNetCore.Identity;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.src.Domain.Core.Contracts.AppServices
{
    public interface IUserAppService
    {
        Task<Result> AddFundsToUserAsync(int userId, decimal amount, CancellationToken cancellationToken);
        Task<Result> ApproveUserAsync(int userId, CancellationToken cancellationToken);
        Task<List<GetAllUserDto>> RetrieveAllUsersAsync(int pageIndex, CancellationToken cancellationToken);
        Task<UserStatusEnum> VerifyUserApprovalAsync(int userId, CancellationToken cancellationToken);
        Task<Result> DeclineUserAsync(int userId, CancellationToken cancellationToken);
        Task<Result> ModifyUserAsync(UpdateUserDto model, CancellationToken cancellationToken);
        Task<Result> DeductFundsFromUserAsync(int userId, decimal amount, CancellationToken cancellationToken);
        Task<IdentityResult> RegisterNewUserAsync(CreateUserDto model, CancellationToken cancellationToken);
        Task<IdentityResult> AuthenticateUserAsync(string username, string password, CancellationToken cancellationToken);
    }

}
