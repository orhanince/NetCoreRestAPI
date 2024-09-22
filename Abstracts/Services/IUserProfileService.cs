using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IUserProfileService
    {
        Task<List<UserProfile>> GetUserProfilesAsync();
    }
}
