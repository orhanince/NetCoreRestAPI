using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<User> CreateUserAsync(RegisterDto registerDto);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> UpdateUserAsync(int userID, UpdateUserDto updateUserDto);
        Task<bool> DeleteUserAsync(int userID);
        Task<UserDto> GetUserByIdAsync(int userID);
    }
}
