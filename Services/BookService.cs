using Microsoft.AspNetCore.Http.HttpResults;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Repository;

namespace NetCoreRestAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _iBookRepository;
        public BookService(IBookRepository iBookRepository)
        {
             _iBookRepository = iBookRepository;
        }

        public async Task<List<BookDto>> GetBooksAsync()
        {
            return await _iBookRepository.GetBooksAsync();
        }

        public Task<BookDto> AddBookAsync(AddBookDto addBookDto)
        {
            return _iBookRepository.AddBookAsync(addBookDto.title, addBookDto.authorID);
        }

        public Task<BookDto> GetBookAsync(int bookID)
        {
            return _iBookRepository.GetBookAsync(bookID);
        }
    }
}