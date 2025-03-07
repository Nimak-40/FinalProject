using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Contracts.Service;
using App.src.Domain.Core.Contracts.AppServices;

namespace App.Domain.Service.AppServices.Users
{
    public class SpecialistAppService(ISpecialistService expertService) : ISpecialistAppService
    {
        private readonly ISpecialistService _specialistService = expertService;

        public async Task<Result> Create(int userId, string resume, CancellationToken cancellationToken)
        {
            if (userId <= 0 || string.IsNullOrEmpty(resume))
                return Result.Failure("مشخصات وارد شده نامعتبر است");
            return await _specialistService.Create(userId, resume, cancellationToken);
        }

        public async Task<int> GetTotalCount(CancellationToken cancellationToken)
        {
            return await _specialistService.GetTotalCount(cancellationToken);
        }
    }
    
}
