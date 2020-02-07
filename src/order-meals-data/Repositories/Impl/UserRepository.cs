using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using order_meals_data.Entities;
using order_meals_data.Options;
using order_meals_data.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace order_meals_data.Repositories.Impl
{
    public class UserRepository : UserManager<UserModel>
    {
        private string _secret;

        public UserRepository(IUserStore<UserModel> store, IOptions<IdentityOptions> optionsAccessor,
                            IPasswordHasher<UserModel> passwordHasher, IEnumerable<IUserValidator<UserModel>> userValidators,
                            IEnumerable<IPasswordValidator<UserModel>> passwordValidators, ILookupNormalizer keyNormalizer,
                            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<UserModel>> logger,
                            IOptions<Secret>secret)
                                : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _secret = secret.Value.Value;
        }


        public async Task<ResponseData> Autheticate(string username, string password)
        {
            var user = await FindByEmailAsync(username);

            if (user == null)
            {
                return new ResponseData { ErrorMessage = "User does not exist" }; ;
            }

            var result = await CheckPasswordAsync(user, password);

            if (!result)
            {
                return  new ResponseData { ErrorMessage= "Invalid password" };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return  new ResponseData { UserId=user.Id, Token= tokenHandler.WriteToken(token) } ;


        }

        public async Task<string> GetNameAsync(ClaimsPrincipal principal)
        {
            var user = await GetUserAsync(principal);
            return $"{user.FirstName} {user.LastName}";
        }


    }
}
