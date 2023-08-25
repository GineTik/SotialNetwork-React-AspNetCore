using SocialNetwork.Data.Models;

namespace SocialNetwork.Data.Repositories
{
    public interface IRepository<TModel>
    {
        Task InsertAsync(User user);
    }
}
