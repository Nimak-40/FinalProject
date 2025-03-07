using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Contracts.Service;
using App.src.Domain.Core.Entities.Resualt;

namespace App.Domain.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        // Constructor to inject the repository dependency
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Create(int userId, string firstName, int cityId, CancellationToken cancellationToken)
        {
            return await _repository.Create(userId, firstName, cityId, cancellationToken);
        }

        public async Task<int> GetTotalCount(CancellationToken cancellationToken)
        {
            return await _repository.GetTotalCount(cancellationToken);
        }


    }
}
