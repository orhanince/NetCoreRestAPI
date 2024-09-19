using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IUserRepository
    {
        Task<User> CreateUser(string username, string password);
        Task<User> GetUser(string email);
        Task<User> GetUserByID(int userID);
        Task<User> UpdateUser();
    } 
}
