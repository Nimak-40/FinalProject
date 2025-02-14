using Achare.Infrastructure;
using Achare.src.Domain.Core.Entities;
using App.src.Domain.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _dbContext;

        public AdminRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            return await _dbContext.Admins
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Admin?> GetByAdminCodeAsync(string adminCode)
        {
            return await _dbContext.Admins
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(a => a.AdminCode == adminCode);
        }

        public async Task AddAsync(Admin admin)
        {
            await _dbContext.Admins.AddAsync(admin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Admin admin)
        {
            var existingAdmin = await _dbContext.Admins
                                                .FirstOrDefaultAsync(a => a.Id == admin.Id);

            if (existingAdmin != null)
            {
                existingAdmin.AdminCode = admin.AdminCode;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var admin = await GetByIdAsync(id);
            if (admin != null)
            {
                _dbContext.Admins.Remove(admin);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}