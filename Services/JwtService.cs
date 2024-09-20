using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;


namespace NetCoreRestAPI.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _iConfiguration;
        public JwtService(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
        }

        public async Task<JwtResponseDto> GenerateJwtTokenAsync(User user)
        {
            // Simulate some async work, e.g., checking user data in a database
            await Task.Delay(100); // This simulates an asynchronous operation
            var jwtSettings = _iConfiguration.GetSection("Jwt");
            var jwtSettingsKey = jwtSettings.GetSection("Key")?.Value;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettingsKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var accessToken = new JwtSecurityToken(
                issuer: _iConfiguration["Jwt:Issuer"],
                audience: _iConfiguration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            var refreshToken = new JwtSecurityToken(
                issuer: _iConfiguration["Jwt:Issuer"],
                audience: _iConfiguration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: creds);
            return new JwtResponseDto {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                ExpiresIn = 60 * 1000,
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken),
                RefreshTokenExpiresIn = 180 * 1000
            };
        }

        public async Task<bool> JwtVerify(string token)
        {
            await Task.CompletedTask;
            return true;
        }

    }
}