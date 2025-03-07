using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> GetTotalCount(CancellationToken cancellationToken);
        Task<Result> Create(int userId, string firstName, int cityId, CancellationToken cancellationToken);
    }
}
