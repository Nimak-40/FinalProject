using App.src.Domain.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace App.src.Domain.Core.Contracts.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetAll(CancellationToken cancellationToken);

    }
}
