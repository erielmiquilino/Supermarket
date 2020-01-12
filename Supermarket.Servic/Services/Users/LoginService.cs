using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Domain.Dtos;
using Supermarket.Domain.Entities;
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
        private IUserRepository _userRepository;
        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;
        private IConfiguration _configuration;

        public LoginService(IUserRepository userRepository,
                            IConfiguration configuration,
                            SigningConfiguration signingConfiguration,
                            TokenConfiguration tokenConfiguration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public async Task<object> FindByLogin(LoginDto login)
        {
            if (login != null && !string.IsNullOrEmpty(login.Email))
            {
                var registredUser = await _userRepository.FindByLogin(login.Email);
                if (registredUser == null)
                    return Unauthenticated();
                else
                {
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

                    return SucessObject(login, createDate, expirationDate, token);
                }
            }
            else
                return Unauthenticated();
        }

        private static object Unauthenticated()
        {
            return new
            {
                authenticated = false,
                message = "Falha ao autenticar: Usuário ou senha estão incorretos"
            };
        }

        private static object SucessObject(LoginDto login, DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = login.Email,
                message = "Usuário Logado com sucesso"
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
