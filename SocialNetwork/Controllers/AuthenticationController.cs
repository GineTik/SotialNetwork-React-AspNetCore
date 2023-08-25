using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BusinessLogic.DTOs.Users;
using SocialNetwork.BusinessLogic.Services.Authentication;

namespace SocialNetwork.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("/authentication/login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _authenticationService.LoginAsync(dto);

            if (result.Successfully == false)
                return BadRequest(result.ErrorInfo);

            return Ok(result.Result);
        }

        [HttpPost("/authentication/registration")]
        public async Task<IActionResult> Registration(RegistrationDTO dto)
        {
            var result = await _authenticationService.RegistrationAsync(dto);

            if (result.Successfully == false)
                return BadRequest(result.ErrorInfo);

            return Ok(result.Result);
        }
    }
}
