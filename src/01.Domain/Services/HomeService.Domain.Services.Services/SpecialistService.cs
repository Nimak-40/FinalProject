using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Contracts.Service;
using App.src.Domain.Core.Entities.Resualt;

namespace App.Domain.Services.Services
{
    public class SpecialistService : ISpecialistService
    {
        private readonly ISpecialistRepository _repository;

        // Constructor to inject the repository dependency
        public SpecialistService(ISpecialistRepository repository)
        {
            _repository = repository;
        }

        // Method to create a new specialist
        public async Task<Result> Create(int userId, string resume, CancellationToken cancellationToken)
        {
            return await _repository.Create(userId, resume, cancellationToken);
        }

        // Method to get the total count of specialists
        public async Task<int> GetTotalCount(CancellationToken cancellationToken)
        {
            return await _repository.GetTotalCount(cancellationToken);
        }
    }
}
