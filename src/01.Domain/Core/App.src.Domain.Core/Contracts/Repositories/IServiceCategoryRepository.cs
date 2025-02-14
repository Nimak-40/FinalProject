using Achare.src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface IServiceCategoryRepository
    {
        Task<List<ServiceCategory>> GetAllAsync();
        Task<ServiceCategory?> GetByIdAsync(int id);
        Task<ServiceCategory?> GetByNameAsync(string name);
        Task AddAsync(ServiceCategory serviceCategory);
        Task UpdateAsync(ServiceCategory serviceCategory);
        Task DeleteAsync(int id);
    }
}
