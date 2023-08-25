using SocialNetwork.BusinessLogic.DTOs.Results;
using SocialNetwork.BusinessLogic.DTOs.Users;

namespace SocialNetwork.BusinessLogic.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<OperationResult<AuthenticationResultDTO>> LoginAsync(LoginDTO dto);
        Task<OperationResult<AuthenticationResultDTO>> RegistrationAsync(RegistrationDTO dto);
    }
}
