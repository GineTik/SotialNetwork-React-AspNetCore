using SocialNetwork.Data.Models;

namespace SocialNetwork.Data.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task DeleteAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
    }
}
