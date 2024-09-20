using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByID(int userID);
        Task<User> UpdateUser();
    } 
}
