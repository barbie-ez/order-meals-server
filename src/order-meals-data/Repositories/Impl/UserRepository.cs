using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using order_meals_data.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace order_meals_data.Repositories.Impl
{
    public class UserRepository : UserManager<UserModel>
    {

        public UserRepository(IUserStore<UserModel> store, IOptions<IdentityOptions> optionsAccessor,
                            IPasswordHasher<UserModel> passwordHasher, IEnumerable<IUserValidator<UserModel>> userValidators,
                            IEnumerable<IPasswordValidator<UserModel>> passwordValidators, ILookupNormalizer keyNormalizer,
                            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<UserModel>> logger)
                                : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }

        public async Task<string> GetNameAsync(ClaimsPrincipal principal)
        {
            var user = await GetUserAsync(principal);
            return $"{user.FirstName} {user.LastName}";
        }


    }
}
