using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IBookService
    {
        Task <List<BookDto>> GetBooksAsync();
        Task <BookDto> AddBookAsync(AddBookDto addBookDto);
        Task <BookDto> GetBookAsync(int bookID);
        Task <BookDto> UpdateBookAsync(int bookID, UpdateBookDto updateBookDto);
        Task <UserDto> AddBookToUserAsync(int userID, int bookID);
        Task <List<BookDto>> GetUserBooksAsync(int userID);
    }
}
