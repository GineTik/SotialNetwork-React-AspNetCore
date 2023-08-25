using SocialNetwork.BusinessLogic.DTOs.Results;
using SocialNetwork.BusinessLogic.DTOs.Users;
using SocialNetwork.BusinessLogic.Factoies.JwtFactory;
using SocialNetwork.BusinessLogic.PasswordHasher;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Repositories.Users;

namespace SocialNetwork.BusinessLogic.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(
            IUserRepository userRepository,
            IJwtFactory jwtFactory,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult<AuthenticationResultDTO>> LoginAsync(LoginDTO dto)
        {
            var findedUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (findedUser == null)
            {
                return AuthenticationResults.EmailOrPasswordIncorrect;
            }

            var passwordIsCorrect = _passwordHasher.Verify(dto.Password, findedUser.HashedPassword);
            
            if (passwordIsCorrect == false)
            {
                return AuthenticationResults.EmailOrPasswordIncorrect;
            }

            var accessToken = _jwtFactory.CreateToken(findedUser);

            return OperationResult<AuthenticationResultDTO>.Success(new()
            {
                AccessToken = accessToken,
                UserInfo = new UserDTO
                {
                    Username = findedUser.Username,
                    Email = findedUser.Email,
                    PublicName = findedUser.PublicName,
                }
            });
        }
        
        public async Task<OperationResult<AuthenticationResultDTO>> RegistrationAsync(RegistrationDTO dto)
        {
            var isFreeResult = await emailAndUsernameIsFreeAsync(dto);

            if (isFreeResult.Successfully == false)
            {
                return (OperationResult<AuthenticationResultDTO>)isFreeResult;
            }

            var newUser = new User
            {
                Email = dto.Email,
                Username = dto.Username,
                HashedPassword = _passwordHasher.Hash(dto.Password),
                PublicName = $"New user {dto.Username}"
            };

            await _userRepository.InsertAsync(newUser);

            var accessToken = _jwtFactory.CreateToken(newUser);

            return OperationResult<AuthenticationResultDTO>.Success(new()
            {
                AccessToken = accessToken,
                UserInfo = new UserDTO
                {
                    Username = newUser.Username,
                    Email = newUser.Email,
                    PublicName = newUser.PublicName,
                }
            });
        }

        private async Task<OperationResult> emailAndUsernameIsFreeAsync(RegistrationDTO dto)
        {
            var findedUserByEmail = await _userRepository.GetByEmailAsync(dto.Email);

            if (findedUserByEmail != null)
            {
                return AuthenticationResults.EmailAlreadyRegistered;
            }

            var findedUserByUsername = await _userRepository.GetByEmailAsync(dto.Email);

            if (findedUserByUsername != null)
            {
                return AuthenticationResults.UsernameAlreadyRegistered;
            }

            return OperationResult.Success();
        }
    }
}
