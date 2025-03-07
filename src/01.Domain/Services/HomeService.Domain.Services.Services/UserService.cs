using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Contracts.Service;
using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> ChargeUserBalanceAsync(int id, decimal money, CancellationToken cancellationToken)
        {
            return await _repository.ChargeUserBalanceAsync(id, money, cancellationToken);
        }

        public async Task<Result> ConfirmUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repository.ConfirmUserByIdAsync(id, cancellationToken);
        }

        public async Task<List<GetAllUserDto>> GetAllUsersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _repository.GetAllUsersAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task<UserStatusEnum> GetUserStatusByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetUserStatusByIdAsync(id, cancellationToken);
        }

        public async Task<Result> RejectUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repository.RejectUserByIdAsync(id, cancellationToken);
        }

        public async Task<Result> UpdateUserProfileAsync(UpdateUserDto model, CancellationToken cancellationToken)
        {
            return await _repository.UpdateUserProfileAsync(model, cancellationToken);
        }

        public async Task<Result> WithdrawFromBalanceAsync(int id, decimal money, CancellationToken cancellationToken)
        {
            return await _repository.WithdrawFromBalanceAsync(id, money, cancellationToken);
        }
    }

}
