using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IJwtService
    {
        Task<JwtResponseDto> GenerateJwtTokenAsync(User user);

        Task<bool> JwtVerify(string token);
    }
}
