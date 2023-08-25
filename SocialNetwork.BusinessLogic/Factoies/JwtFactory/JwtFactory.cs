using Microsoft.Extensions.Options;
using SocialNetwork.Data.Models;
using SocialNetwork.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SocialNetwork.BusinessLogic.Factoies.JwtFactory
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtOptions _jwtOptions;

        public JwtFactory(
            IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string CreateToken(User user)
        {
            var utcNow = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                notBefore: utcNow,
                claims: takeClaims(user),
                expires: utcNow.Add(TimeSpan.FromMinutes(_jwtOptions.LifeTimeInMinutes)),
                signingCredentials: _jwtOptions.GetSigningCredentials()
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private static IEnumerable<Claim> takeClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
            };
        }
    }
}
