using Microsoft.AspNetCore.Http.HttpResults;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Repository;

namespace NetCoreRestAPI.Services
{
    public class UserService : IUserService
    {
         private readonly IUserRepository _iUserRepository;
        private readonly IEncryptService _iEncryptService;
        public UserService(IUserRepository iUserRepository, IEncryptService iEncryptService)
        {
             _iUserRepository = iUserRepository;
            _iEncryptService = iEncryptService;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _iUserRepository.GetUsersAsync();
        }

        public async Task<User> CreateUserAsync(RegisterDto registerDto)
        {
            // TODO
            // Add user to db.
            var user = new User { 
                Username = registerDto.username,
                Email = registerDto.email,
                Password = await _iEncryptService.HashPasswordAsync(registerDto.password),
                Active = true
            };
            await _iUserRepository.CreateUserAsync(user);
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _iUserRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
           return user; 
        }

        public async Task<User> UpdateUserAsync(int userID, UpdateUserDto updateUserDto)
        {
            return await _iUserRepository.UpdateUserAsync(userID, updateUserDto.username);
        }
    }
}