using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{   
    [ApiController]
    [Route("app/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _iAuthorService;

        public AuthorsController(IAuthorService iAuthorService)
        {
            _iAuthorService = iAuthorService;
        }

        /// <summary>
        /// Get all authors.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            var authors = await _iAuthorService.GetAuthorsAsync();
            return View("~/Views/Authors/Index.cshtml", authors);
        }

        /// <summary>
        /// Get all authors.
        /// </summary>
        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AuthorDto>> AddAuthor(AddAuthorDto addAuthorDto)
        {
            return await _iAuthorService.AddAuthorAsync(addAuthorDto);
        }

        /// <summary>
        /// Get author.
        /// </summary>
        [HttpGet("{authorID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int authorID)
        {
            return await _iAuthorService.GetAuthorAsync(authorID);
        }

        /// <summary>
        /// Update author.
        /// </summary>
        /// <param name="authorID"></param>
        /// <param name="updateAuthorDto"></param>
        /// <returns></returns>
        [HttpPut("{authorID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AuthorDto>> UpdateAuthor(int authorID, AddAuthorDto addAuthorDto)
        {
            return await _iAuthorService.UpdateAuthorAsync(authorID, addAuthorDto);
        }
    }
}

