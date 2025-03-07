
using App.src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCategory>> GetAllAsync();
        Task<SubCategory?> GetByIdAsync(int id);
        Task<SubCategory?> GetByNameAsync(string name);
        Task AddAsync(SubCategory serviceCategory);
        Task UpdateAsync(SubCategory serviceCategory);
        Task DeleteAsync(int id);
    }
}
