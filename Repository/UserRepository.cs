
using AutoMapper;
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
    private readonly IMapper _iMapper;
    public UserRepository(MyAppContext context, IMapper iMapper)
    {
        _context = context;
        _iMapper = iMapper;
    }

    public async Task<List<UserDto>> GetUsersAsync()
    {
        var users = await _context.Users.ToListAsync();
        return _iMapper.Map<List<UserDto>>(users);
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

    public async Task<UserDto> GetUserByIDAsync(int userID)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userID); 
        return _iMapper.Map<UserDto>(user);
    }

    public async Task<User> UpdateUserAsync(int userID, string username)
    {
        
        var user = await _context.Users.FindAsync(userID);
        if (user == null)
        {
           throw new ArgumentNullException(nameof(user));
        }
            
        user.Username = username;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(int userID)
    {
        var user = await _context.Users.FindAsync(userID);
        if (user == null)
        {
           throw new ArgumentNullException(nameof(user));
        }
            
        user.Active = false;
        user.UpdatedAt = DateTime.UtcNow;
        user.DeletedAt = DateTime.UtcNow;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return true;
    }
    }   
}
