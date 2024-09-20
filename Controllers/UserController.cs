using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;

        public UserController(IUserService iUserService)
        {
            _iUserService = iUserService;
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="username">The username for the new user.</body>
        /// <param name="email">The email for the new user.</param>
        /// <param name="password">The password for the new user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return await _iUserService.GetUsersAsync();
        }

        [HttpGet("{userID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserDto>> GetUserById(int userID)
        {

            return await _iUserService.GetUserByIdAsync(userID);
        }


        [HttpPut("{userID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> UpdateUser(int userID, [FromBody] UpdateUserDto updateUserDto)
        {

            return await _iUserService.UpdateUserAsync(userID, updateUserDto);
        }

        [HttpDelete("{userID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> DeleteUser(int userID)
        {

            return await _iUserService.DeleteUserAsync(userID);
        }
    }
}

