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
    }
}

