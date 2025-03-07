using App.src.Domain.Core.Contracts.Service;
using App.src.Domain.Core.Entities.Resualt;

namespace App.src.Domain.Core.Contracts.AppServices
{
    public interface ISpecialistAppService
    {

        Task<Result> Create(int userId, string resume, CancellationToken cancellationToken);
        Task<int> GetTotalCount(CancellationToken cancellationToken);
    }
}
