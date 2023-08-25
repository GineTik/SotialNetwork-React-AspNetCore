using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BusinessLogic.DTOs.Users
{
    public class RegistrationDTO
    {
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некоректний адрес")]
        public string Email { get; set; } = default!;
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%-]+")]
        public string Username { get; set; } = default!;
        [Required]
        [MinLength(4)]
        [MaxLength(255)]
        public string Password { get; set; } = default!;
    }
}
