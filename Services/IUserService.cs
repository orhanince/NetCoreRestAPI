using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(RegisterDto registerDto);
        Task<User> GetUserByEmailAsync(string email);
    }
}
