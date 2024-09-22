using Microsoft.AspNetCore.Http.HttpResults;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Repository;

namespace NetCoreRestAPI.Services
{
    public class UserProfileService : IUserProfileService
    {
         private readonly IUserProfileRepository _iUserProfileRepository;
        public UserProfileService(IUserProfileRepository iUserProfileRepository)
        {
             _iUserProfileRepository = iUserProfileRepository;
        }

        public async Task<List<UserProfile>> GetUserProfilesAsync()
        {
            return await _iUserProfileRepository.GetUserProfilesAsync();
        }
    }
}