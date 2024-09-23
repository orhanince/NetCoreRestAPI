using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _iBookService;

        public BookController(IBookService iBookService)
        {
            _iBookService = iBookService;
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            return await _iBookService.GetBooksAsync();
        }

        /// <summary>
        /// Add book.
        /// </summary>
        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BookDto>> AddBook(AddBookDto addBookDto)
        {
            return await _iBookService.AddBookAsync(addBookDto);
        }

        /// <summary>
        /// Get book.
        /// </summary>
        [HttpGet("{bookID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BookDto>> GetBook(int bookID)
        {
            var aa =  await _iBookService.GetBookAsync(bookID);
            return aa;
        }

        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="updateBookDto"></param>
        /// <returns></returns>
        /// <response code="200">Returns the updated book.</response>
        /// <response code="400">If the book is not found.</response>
        /// <response code="404">If the book is not found.</response>
        /// <response code="500">If there was an internal server error.</response>
        /// <response code="401">If the user is not authenticated.</response>
        /// <response code="403">If the user is not authorized.</response>
        [HttpPut("{bookID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BookDto>> UpdateBook(int bookID, UpdateBookDto updateBookDto)
        {
            return await _iBookService.UpdateBookAsync(bookID, updateBookDto);
        }

        [HttpPost("{userID}/{bookID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserDto>> AddBookToUser(int userID, int bookID)
        {
            return await _iBookService.AddBookToUserAsync(userID, bookID);
        }

        [HttpGet("user/{userID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<BookDto>>> GetUserBooks(int userID)
        {
            return await _iBookService.GetUserBooksAsync(userID);
        }
    }
}

