namespace SocialNetwork.BusinessLogic.DTOs.Users
{
    public class AuthenticationResultDTO
    {
        public string AccessToken { get; set; } = default!;
        public UserDTO UserInfo { get; set; } = default!;
    }
}
