using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.API.Models;
using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.API.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly JwtTokenOptions _options;

        public JwtTokenService(IOptions<JwtTokenOptions> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _options = options.Value;
        }

        public Task<TokenViewModel> GenerateAsync(Felhasznalo felhasznalo, CancellationToken cancellationToken)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(30);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken
            (
                issuer: _options.Issuer,
                audience: _options.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials,
                claims: GetClaims(felhasznalo)
            );

            var handler = new JwtSecurityTokenHandler();
            var accessToken = handler.WriteToken(securityToken);

            return Task.FromResult(new TokenViewModel
            {
                AccessToken = accessToken
            });
        }

        private IEnumerable<Claim> GetClaims(Felhasznalo felhasznalo)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, felhasznalo.Email)
            };

            return claims;
        }
    }
}
