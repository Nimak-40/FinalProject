using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using App.src.Domain.Core.Entities.Resualt;
using App.src.Domain.Core.Contracts.Service;
using App.src.Domain.Core.Dtos.UserEntities;
using App.src.Domain.Core.Entities.UserEntities;
using App.src.Domain.Core.Enums;
using App.src.Domain.Core.Contracts.AppServices;

namespace App.Domain.Service.AppServices.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService ;
        private readonly ICustomerAppService _customerAppService;
        private readonly ISpecialistAppService _SpecialistAppService;
        private readonly UserManager<User> _userManager ;
        private readonly SignInManager<User> _signInManager ;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ILogger<UserAppService> _logger ;
        public UserAppService(IUserService userService, ICustomerAppService customerAppService, ISpecialistAppService specialistAppService, UserManager<User> userManager, SignInManager<User> signInManager, IPasswordHasher<User> passwordHasher, ILogger<UserAppService> logger)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = userService;
            _passwordHasher = passwordHasher;
            _SpecialistAppService = specialistAppService;
            _customerAppService = customerAppService;
        }
        public async Task<Result> AddFundsToUserAsync(int userId, decimal amount, CancellationToken cancellationToken)
        {
            if (userId <= 0)
                return Result.Failure("کاربری با این مشخصات وجود ندارد");
            if (amount <= 0)
                return Result.Failure("مقدار مبلغ مورد نظر نامعتبر است");
            return await _userService.ChargeUserBalanceAsync(userId, amount, cancellationToken);
        }

        public async Task<Result> ApproveUserAsync(int userId, CancellationToken cancellationToken)
        {
            if (userId <= 0)
                return Result.Failure("کاربری با این مشخصات وجود ندارد");
            return await _userService.ConfirmUserByIdAsync(userId, cancellationToken);
        }

        public async Task<List<GetAllUserDto>> RetrieveAllUsersAsync(int pageIndex, CancellationToken cancellationToken)
        {
            if (pageIndex <= 0)
                pageIndex = 1;
            return await _userService.GetAllUsersAsync(pageIndex, 10, cancellationToken);
        }

        public async Task<UserStatusEnum> VerifyUserApprovalAsync(int userId, CancellationToken cancellationToken)
        {
            if (userId <= 0)
                return UserStatusEnum.Pending;
            _logger.LogInformation("Checking admin confirmation status for user ID {userId}", userId);
            return await _userService.GetUserStatusByIdAsync(userId, cancellationToken);
        }

        public async Task<Result> DeclineUserAsync(int userId, CancellationToken cancellationToken)
        {
            _logger.LogWarning("Attempting to reject user ID {userId}", userId);
            if (userId <= 0)
                return Result.Failure("کاربری با این مشخصات یافت نشد");
            return await _userService.RejectUserByIdAsync(userId, cancellationToken);
        }

        public async Task<Result> ModifyUserAsync(UpdateUserDto model, CancellationToken cancellationToken)
        {
            if (model.Id <= 0)
                return Result.Failure("کاربری با این مشخصات یافت نشد");
            return await _userService.UpdateUserProfileAsync(model, cancellationToken);
        }

        public async Task<Result> DeductFundsFromUserAsync(int userId, decimal amount, CancellationToken cancellationToken)
        {
            if (userId <= 0)
                return Result.Failure("کاربری با این مشخصات یافت نشد");
            if (amount <= 0)
                return Result.Failure("مقدار مبلغ مورد نظر نامعتبر است");
            return await _userService.WithdrawFromBalanceAsync(userId, amount, cancellationToken);
        }

        public async Task<IdentityResult> RegisterNewUserAsync(CreateUserDto model, CancellationToken cancellationToken)
        {
            string assignedRole = string.Empty;
            var user = new User
            {
                UserName = model.Email,
                CityId = model.CityId,
                Status = UserStatusEnum.Pending,
                LockoutEnabled = false,
                Email = model.Email
            };

            if (model.Role == UserRoleEnum.Customer)
            {
                assignedRole = "Customer";
                user.Customer = new Customer { CityId = model.CityId };
            }
            else if (model.Role == UserRoleEnum.Specialist)
            {
                assignedRole = "Expert";
                user.Specialist = new Specialist();
            }

            var creationResult = await _userManager.CreateAsync(user, model.Password);
            if (creationResult.Succeeded)
            {
                _logger.LogInformation("User registered with role: {assignedRole}", assignedRole);
                await _userManager.AddToRoleAsync(user, assignedRole);
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, assignedRole));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));
                if (model.Role == UserRoleEnum.Customer)
                {
                    await _userManager.AddClaimAsync(user, new Claim("CustomerId", user.Customer!.Id.ToString()));
                }
                else if (model.Role == UserRoleEnum.Specialist)
                {
                    await _userManager.AddClaimAsync(user, new Claim("SpecialistId", user.Specialist!.Id.ToString()));
                }
            }
            return creationResult;
        }

        public async Task<IdentityResult> AuthenticateUserAsync(string username, string password, CancellationToken cancellationToken)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(username, password, true, false);
            if (loginResult.Succeeded)
            {
                _logger.LogInformation("User {username} logged in successfully", username);
            }
            else
            {
                _logger.LogWarning("Login attempt failed for user {username}", username);
            }
            return loginResult.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }
    }


}
