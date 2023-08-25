using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SocialNetwork.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public string Key { get; set; } = default!;
        public int LifeTimeInMinutes { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }

        public SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
        }
    }
}
