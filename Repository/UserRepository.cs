
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
    public class UserRepository : IUserRepository
{
    public Task<User> CreateUser(string username, string password)
    {
        var user = new User {
            Id = 1,
            Username = "Alex",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
        };
        
        return Task.FromResult(user);
    }

    Task<User> IUserRepository.GetUser(string email)
    {
        throw new NotImplementedException();
    }

    Task<User> IUserRepository.GetUserByID(int userID)
    {
        throw new NotImplementedException();
    }

    Task<User> IUserRepository.UpdateUser()
    {
        throw new NotImplementedException();
    }
    }   
}
