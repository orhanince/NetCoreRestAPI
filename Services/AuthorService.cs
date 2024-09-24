using Microsoft.AspNetCore.Http.HttpResults;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Repository;

namespace NetCoreRestAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _iAuthorRepository;
        public AuthorService(IAuthorRepository iAuthorRepository)
        {
             _iAuthorRepository = iAuthorRepository;
        }

        public async Task<List<AuthorDto>> GetAuthorsAsync()
        {
            return await _iAuthorRepository.GetAuthorsAsync();
        }

        public async Task<AuthorDto> AddAuthorAsync(AddAuthorDto addAuthorDto)
        {
            return await _iAuthorRepository.AddAuthorAsync(addAuthorDto.name);
        }

        public async Task<AuthorDto> GetAuthorAsync(int authorID)
        {
            return await _iAuthorRepository.GetAuthorAsync(authorID);
        }

        public async Task<bool> AuthorExistsAsync(int authorID)
        {
            return await _iAuthorRepository.AuthorExistsAsync(authorID);
        }
    }
}