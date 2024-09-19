using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NetCoreRestAPI.Dtos;


namespace NetCoreRestAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _iUserService;
        private readonly IJwtService _iJwtService;

        public AuthService(IUserService iUserService, IJwtService iJwtService)
        {
            _iUserService = iUserService;
            _iJwtService = iJwtService;
        }
        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {
            var user = await _iUserService.CreateUser(registerDto);
            JwtResponseDto jwtResponseDto = await _iJwtService.GenerateJwtTokenAsync(user);

            return new AuthResponseDto {
                userID = user.Id,
                AccessToken = jwtResponseDto.AccessToken,
                ExpiresIn = jwtResponseDto.ExpiresIn,
                RefreshToken = jwtResponseDto.RefreshToken,
                RefreshTokenExpiresIn = jwtResponseDto.RefreshTokenExpiresIn
            };
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var user = await _iUserService.GetUser(loginDto.email);
            JwtResponseDto jwtResponseDto = await _iJwtService.GenerateJwtTokenAsync(user);
            return new AuthResponseDto {
                userID = user.Id,
                AccessToken = jwtResponseDto.AccessToken,
                ExpiresIn = jwtResponseDto.ExpiresIn,
                RefreshToken = jwtResponseDto.RefreshToken,
                RefreshTokenExpiresIn = jwtResponseDto.RefreshTokenExpiresIn
            };
        }

    }
}