
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NetCoreRestAPI.Data;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Repository
{
    public class UserProfileRepository : IUserProfileRepository
{
    private readonly MyAppContext _context;
    private readonly IMapper _iMapper;
    public UserProfileRepository(MyAppContext context, IMapper iMapper)
    {
        _context = context;
        _iMapper = iMapper;
    }
    public async Task<List<UserProfile>> GetUserProfilesAsync()
    {
        return await _context.UserProfiles.ToListAsync();
    }
    }   
}
