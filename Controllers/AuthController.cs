using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _iAuthService;

        public AuthController(IAuthService iAuthService)
        {
            _iAuthService = iAuthService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="username">The username for the new user.</body>
        /// <param name="email">The email for the new user.</param>
        /// <param name="password">The password for the new user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto registerDto)
        {
            return await _iAuthService.Register(registerDto);
        }


        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="username">The username for the new user.</body>
        /// <param name="email">The email for the new user.</param>
        /// <param name="password">The password for the new user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto loginDto)
        {
            return await _iAuthService.Login(loginDto);
        }
    }
}

