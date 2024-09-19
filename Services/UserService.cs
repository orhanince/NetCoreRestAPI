using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public class UserService : IUserService
    {
        public async Task<User> CreateUser(RegisterDto registerDto)
        {
            var user = new User {
                Id = 1, 
                Username = registerDto.username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.password)
            };
            await Task.CompletedTask;
            return user;
        }

        public async Task<User> GetUser(string email)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}