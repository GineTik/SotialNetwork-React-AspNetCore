using SocialNetwork.Data.Models;

namespace SocialNetwork.BusinessLogic.Factoies.JwtFactory
{
    public interface IJwtFactory
    {
        string CreateToken(User user);
    }
}
