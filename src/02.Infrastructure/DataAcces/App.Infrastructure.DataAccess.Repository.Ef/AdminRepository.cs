using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _dbContext;

        public AdminRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Admin?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Admins.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<Admin?> GetByAdminCodeAsync(string adminCode, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Admins
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(a => a.AdminCode == adminCode, cancellationToken);
        }

        public async Task AddAsync(Admin admin, CancellationToken cancellationToken = default)
        {
            await _dbContext.Admins.AddAsync(admin, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Admin admin, CancellationToken cancellationToken = default)
        {
            var existingAdmin = await _dbContext.Admins.FindAsync(new object[] { admin.Id }, cancellationToken);

            if (existingAdmin != null)
            {
                existingAdmin.AdminCode = admin.AdminCode;
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var admin = await GetByIdAsync(id, cancellationToken);
            if (admin != null)
            {
                _dbContext.Admins.Remove(admin);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
