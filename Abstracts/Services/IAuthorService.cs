using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAuthorsAsync();
        Task<AuthorDto> AddAuthorAsync(AddAuthorDto addAuthorDto);
        Task<AuthorDto> GetAuthorAsync(int authorID);
        Task<bool> AuthorExistsAsync(int authorID);
    }
}
