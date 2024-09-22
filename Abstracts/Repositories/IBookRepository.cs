using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IBookRepository
    {
        Task <List<BookDto>> GetBooksAsync();
        Task <BookDto> AddBookAsync(string title, int? authorID);
        Task <BookDto> GetBookAsync(int bookID);
    } 
}
