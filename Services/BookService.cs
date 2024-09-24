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

        public Task<BookDto> UpdateBookAsync(int bookID, UpdateBookDto updateBookDto)
        {
            return _iBookRepository.UpdateBookAsync(bookID, updateBookDto.title, updateBookDto.authorID);
        }

        public Task<UserDto> AddBookToUserAsync(int userID, int bookID)
        {
            return _iBookRepository.AddBookToUserAsync(userID, bookID);
        }

        public Task<List<BookDto>> GetUserBooksAsync(int userID)
        {
            return _iBookRepository.GetUserBooksAsync(userID);
        }

        public Task<bool> BookExistsAsync(string title)
        {
            return _iBookRepository.BookExistsAsync(title);
        }
    }
}