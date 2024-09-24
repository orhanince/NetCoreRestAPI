using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{   
    [ApiController]
    [Route("app/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _iBookService;

        public BooksController(IBookService iBookService)
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
            var books = await _iBookService.GetBooksAsync();
            return View("~/Views/Books/Index.cshtml", books);
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
            var book = await _iBookService.GetBookAsync(bookID);
            Console.WriteLine(book);
            return View("~/Views/Books/Detail.cshtml", book);
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

        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="updateBookDto"></param>
        /// <returns></returns>
        [HttpPut("{bookID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BookDto>> UpdateBook(int bookID, AddBookDto addBookDto)
        {
            return await _iBookService.UpdateBookAsync(bookID, addBookDto);
        }
    }
}

