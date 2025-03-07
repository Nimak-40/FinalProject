using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Contracts.Service;
using App.src.Domain.Core.Contracts.AppServices;

namespace App.Domain.Service.AppServices.Users
{
    public class CustomerAppService(ICustomerService customerService) : ICustomerAppService
    {
        private readonly ICustomerService _customerService = customerService;

        public async Task<Result> Create(int userId, string firstName, int cityId, CancellationToken cancellationToken)
        {
            if (userId <= 0 || cityId <= 0 || string.IsNullOrEmpty(firstName))
                return Result.Failure("مشخصات وارد شده نامعتبر است");
            return await _customerService.Create(userId, firstName, cityId, cancellationToken);

        }

        public async Task<int> GetTotalCount(CancellationToken cancellationToken)
        {
            return await _customerService.GetTotalCount(cancellationToken);
        }
    }
    
}
