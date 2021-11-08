using Microsoft.IdentityModel.Tokens;
using Supermarket.Domain.Dtos;
using Supermarket.Domain.Interfaces.Repositories;
using Supermarket.Domain.Interfaces.Services.Users;
using Supermarket.Domain.Security;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Supermarket.Service.Services.Users
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly SigningConfiguration _signingConfiguration;
        private readonly TokenConfiguration _tokenConfiguration;

        public LoginService(IUserRepository userRepository,
                            SigningConfiguration signingConfiguration,
                            TokenConfiguration tokenConfiguration)
        {
            _userRepository = userRepository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public async Task<object> FindByLogin(LoginDto login)
        {
            var registeredUser = await _userRepository.FindByLogin(login);
            if (registeredUser == null)
                return Unauthenticated();

            var identity = new ClaimsIdentity(
                new GenericIdentity(login.Email),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, login.Email)
                }
            );

            var createDate = DateTime.Now;
            var expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = CreateToken(identity, createDate, expirationDate, tokenHandler);

            return SuccessObject(login, createDate, expirationDate, token);
        }

        private static object Unauthenticated()
        {
            return new
            {
                authenticated = false,
                message = "Falha ao autenticar: Usuário ou senha estão incorretos"
            };
        }

        private static object SuccessObject(LoginDto login, DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = login.Email,
                message = "Usuário autenticado com sucesso"
            };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler tokenHandler)
        {
            var securityToken = tokenHandler.CreateToken(new SecurityTokenDescriptor 
            { 
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
