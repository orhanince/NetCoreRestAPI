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

        public async Task<User> CreateUser(RegisterDto registerDto)
        {
            // TODO
            // Add user to db.
            var user = new User { 
                Username = registerDto.username,
                Email = registerDto.email,
                Password = await _iEncryptService.HashPasswordAsync(registerDto.password),
                Active = true
            };
            await _iUserRepository.CreateUser(user);
            return user;
        }

        public async Task<User> GetUser(string email)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}