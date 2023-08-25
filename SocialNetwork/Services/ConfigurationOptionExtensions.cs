using Microsoft.AspNetCore.Authentication;
using SocialNetwork.Options;

namespace SocialNetwork.Services
{
    public static class ConfigurationOptionExtensions
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationOptions>(configuration.GetSection(nameof(AuthenticationOptions)));
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

            return services;
        }
    }
}
