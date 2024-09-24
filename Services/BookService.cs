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
            return _iBookRepository.AddBookAsync(addBookDto.title, addBookDto.authorId);
        }

        public Task<BookDto> GetBookAsync(int bookID)
        {
            return _iBookRepository.GetBookAsync(bookID);
        }

        public Task<BookDto> UpdateBookAsync(int bookID, AddBookDto addBookDto)
        {
            return _iBookRepository.UpdateBookAsync(bookID, addBookDto.title, addBookDto.active, addBookDto.image, addBookDto.isbn, addBookDto.description, addBookDto.authorId, addBookDto.languageId, addBookDto.publisherId, addBookDto.publishedDate);
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