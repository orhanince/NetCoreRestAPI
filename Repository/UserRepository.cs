
using NetCoreRestAPI.Data;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Repository
{
    public class UserRepository : IUserRepository
{
    private readonly MyAppContext _context;
    public UserRepository(MyAppContext context)
    {
        _context = context;
    }
    public async Task<User> CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return await Task.FromResult(user);
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
