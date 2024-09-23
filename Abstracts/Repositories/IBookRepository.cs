using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IBookRepository
    {
        Task <List<BookDto>> GetBooksAsync();
        Task <BookDto> AddBookAsync(string title, int? authorID);
        Task <BookDto> GetBookAsync(int bookID);
        Task <BookDto> UpdateBookAsync(int bookID, string title, int? authorID);
        Task <UserDto> AddBookToUserAsync(int userID, int bookID);
        Task <List<BookDto>> GetUserBooksAsync(int userID);
    } 
}
