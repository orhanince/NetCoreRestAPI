using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IUserProfileRepository
    {
        Task <List<UserProfile>> GetUserProfilesAsync();
    } 
}
