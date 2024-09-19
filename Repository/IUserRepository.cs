using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser(string email);
        Task<User> GetUserByID(int userID);
        Task<User> UpdateUser();
    } 
}
