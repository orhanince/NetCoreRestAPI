using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IBookRepository
    {
        Task <List<BookDto>> GetBooksAsync();
        Task <BookDto> AddBookAsync(string title, int? authorID);
        Task <BookDto> GetBookAsync(int bookID);
        Task <BookDto> UpdateBookAsync(int bookId, string title, bool active, string? image, string? isbn, string? description, int? authorId, int? languageId, int? publisherId, string? publishedDate);
        Task <UserDto> AddBookToUserAsync(int userID, int bookID);
        Task <List<BookDto>> GetUserBooksAsync(int userID);
        Task <bool> BookExistsAsync(string title);
    } 
}
