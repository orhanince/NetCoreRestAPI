using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IAuthorRepository
    {
        Task <List<AuthorDto>> GetAuthorsAsync();
        Task <AuthorDto> AddAuthorAsync(string name, string surname);
        Task <AuthorDto> GetAuthorAsync(int authorID);
    } 
}
