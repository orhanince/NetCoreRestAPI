using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IBookService
    {
        Task <List<BookDto>> GetBooksAsync();
        Task <BookDto> AddBookAsync(AddBookDto addBookDto);
        Task <BookDto> GetBookAsync(int bookID);
    }
}
