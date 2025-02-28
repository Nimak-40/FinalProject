using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IAdminRepository
    {
        Task<Admin?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Admin?> GetByAdminCodeAsync(string adminCode, CancellationToken cancellationToken = default);

        Task AddAsync(Admin admin, CancellationToken cancellationToken = default);

        Task UpdateAsync(Admin admin, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }   
}
