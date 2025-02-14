using App.src.Domain.Core.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface ISpecialistRepository
    {
        Task<List<Specialist>> GetAllAsync();
        Task<Specialist?> GetByIdAsync(int id);
        Task<Specialist?> GetByUsernameAsync(string username);
        Task AddAsync(Specialist specialist);
        Task UpdateAsync(Specialist specialist);
        Task DeleteAsync(int id);
    }
}
