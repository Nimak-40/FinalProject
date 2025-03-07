using App.src.Domain.Core.Entities.Resualt;

namespace App.src.Domain.Core.Contracts.Service
{
    public interface ISpecialistService
    {
        Task<Result> Create(int userId, string resume, CancellationToken cancellationToken);
        Task<int> GetTotalCount(CancellationToken cancellationToken);
    }
}
