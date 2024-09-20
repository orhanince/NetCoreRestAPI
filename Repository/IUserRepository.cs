using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IUserRepository
    {
        Task <List<UserDto>> GetUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByID(int userID);
        Task<User> UpdateUserAsync(int userID, string username);
        Task<bool> DeleteUserAsync(int userID);
    } 
}
