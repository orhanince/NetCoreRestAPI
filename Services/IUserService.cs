using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> CreateUserAsync(RegisterDto registerDto);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> UpdateUserAsync(int userID, UpdateUserDto updateUserDto);
    }
}
