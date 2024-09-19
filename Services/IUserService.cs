using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(RegisterDto registerDto);
        Task<User> GetUser(string email);
    }
}
