using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IAuthorRepository
    {
        Task <List<AuthorDto>> GetAuthorsAsync();
        Task <AuthorDto> AddAuthorAsync(string name, string? image, string? about);
        Task <AuthorDto> GetAuthorAsync(int authorID);
        Task <bool> AuthorExistsAsync(int authorID);
        Task <AuthorDto> UpdateAuthorAsync(int authorID, string name, string? image, string? about);
    } 
}
