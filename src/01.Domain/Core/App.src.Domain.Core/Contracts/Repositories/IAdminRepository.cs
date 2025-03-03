﻿using App.src.Domain.Core.Entities.UserEntities;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IAdminRepository
    {
        Task<Admin?> GetByIdAsync(int id);
        Task<Admin?> GetByAdminCodeAsync(string adminCode);
        Task AddAsync(Admin admin);
        Task UpdateAsync(Admin admin);
        Task DeleteAsync(int id);
    }
}
