using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Exceptions;


namespace NetCoreRestAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _iUserService;
        private readonly IJwtService _iJwtService;
        private readonly IEncryptService _iEncryptService;

        public AuthService(IUserService iUserService, IJwtService iJwtService, IEncryptService iEncryptService)
        {
            _iUserService = iUserService;
            _iJwtService = iJwtService;
            _iEncryptService = iEncryptService;
        }
        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {
            var user = await _iUserService.CreateUserAsync(registerDto);
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
            var user = await _iUserService.GetUserByEmailAsync(loginDto.email);
            var isMatchedPassword = await _iEncryptService.VerifyPasswordAsync(loginDto.password, user.Password);
            if (!isMatchedPassword)
            {
                throw new PasswordMismatchException();
            }
            
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