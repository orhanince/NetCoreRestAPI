
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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
    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return await Task.FromResult(user);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);  
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return user;
        }
        catch (System.Exception)
        {      
            throw;
        }
        
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
