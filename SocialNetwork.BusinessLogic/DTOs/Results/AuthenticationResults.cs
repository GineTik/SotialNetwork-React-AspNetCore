using SocialNetwork.BusinessLogic.DTOs.Users;

namespace SocialNetwork.BusinessLogic.DTOs.Results
{
    public abstract class AuthenticationResults : OperationResult<AuthenticationResultDTO>
    {
        private static string _authenticationCode = "AuthenticationError";

        public static OperationResult<AuthenticationResultDTO> EmailOrPasswordIncorrect = 
            Error(new ErrorInfo()
            {
                Code = _authenticationCode,
                Message = "Username or password incorrect"
            });

        public static OperationResult<AuthenticationResultDTO> EmailAlreadyRegistered =
           Error(new ErrorInfo()
           {
               Code = _authenticationCode,
               Message = "User with current email already registered"
           });

        public static OperationResult<AuthenticationResultDTO> UsernameAlreadyRegistered = 
            Error(new ErrorInfo()
            {
                Code = _authenticationCode,
                Message = "User with current username already registered"
            });

        public static OperationResult<AuthenticationResultDTO> UsernameContainsIncorrectSymbols = 
            Error(new ErrorInfo()
            {
                Code = _authenticationCode,
                Message = "The username must not contains the @ symbol"
            });
    }
}
