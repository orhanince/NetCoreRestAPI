using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _iUserProfileService;

        public UserProfileController(IUserProfileService iUserProfileService)
        {
            _iUserProfileService = iUserProfileService;
        }

        /// <summary>
        /// Get all users profile.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<UserProfile>>> GetUserProfiles()
        {
            return await _iUserProfileService.GetUserProfilesAsync();
        }
    }
}

