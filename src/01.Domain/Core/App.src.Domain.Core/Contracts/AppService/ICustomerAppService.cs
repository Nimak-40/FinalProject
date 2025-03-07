using App.src.Domain.Core.Entities.Resualt;

namespace App.src.Domain.Core.Contracts.AppServices
{
    public interface ICustomerAppService
    {

        Task<Result> Create(int userId, string firstName, int cityId, CancellationToken cancellationToken);

        Task<int> GetTotalCount(CancellationToken cancellationToken);

    }
}
