using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IEncryptService _iEncryptService;

        public UserService(IEncryptService iEncryptService)
        {
            _iEncryptService = iEncryptService;
        }

        public async Task<User> CreateUser(RegisterDto registerDto)
        {
            var user = new User {
                Id = 1, 
                Username = registerDto.username,
                PasswordHash = await _iEncryptService.HashPasswordAsync(registerDto.password)
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