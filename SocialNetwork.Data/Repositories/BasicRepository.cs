using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SocialNetwork.Data.Repositories
{
    public class BasicRepository
    {
        protected string ConnectionString { get; }

        public BasicRepository(
            IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("LocalConnection")
                ?? throw new NullReferenceException("LocalConnection is not set");
        }

        protected SqlConnection CreateSqlConnection() => new SqlConnection(ConnectionString);
    }
}
