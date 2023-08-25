using Dapper;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Data.Models;
using System.Data;

namespace SocialNetwork.Data.Repositories.Users
{
    public class UserRepository : BasicRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            using IDbConnection db = CreateSqlConnection();

            var sqlQuery = "SELECT TOP 1 * FROM Users WHERE Email = @email";
            
            return (await db.QueryAsync<User>(sqlQuery, new { email })).FirstOrDefault();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            using IDbConnection db = CreateSqlConnection();

            var sqlQuery = "SELECT TOP 1 * FROM Users WHERE Username = @username";

            return (await db.QueryAsync<User>(sqlQuery, new { username })).FirstOrDefault();
        }

        public async Task InsertAsync(User user)
        {
            using IDbConnection db = CreateSqlConnection();

            var sqlQuery = "INSERT INTO " +
                "Users (Email, Username, HashedPassword, PublicName) " +
                "VALUES(@Email, @Username, @HashedPassword, @PublicName)";

            await db.ExecuteAsync(sqlQuery, user);
        }

        public async Task DeleteAsync(string username)
        {
            using IDbConnection db = CreateSqlConnection();

            var sqlQuery = "DELETE FROM Users WHERE Username = @username";

            await db.ExecuteAsync(sqlQuery, new { username });
        }
    }
}
