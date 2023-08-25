namespace SocialNetwork.Data.Models
{
    public class User
    {
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string HashedPassword { get; set; } = default!;
        public string PublicName { get; set; } = default!;
    }
}
