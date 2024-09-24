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
            return await _iAuthorRepository.AddAuthorAsync(addAuthorDto.name, addAuthorDto.image, addAuthorDto.about);
        }

        public async Task<AuthorDto> GetAuthorAsync(int authorID)
        {
            return await _iAuthorRepository.GetAuthorAsync(authorID);
        }

        public async Task<bool> AuthorExistsAsync(int authorID)
        {
            return await _iAuthorRepository.AuthorExistsAsync(authorID);
        }

        public async Task<AuthorDto> UpdateAuthorAsync(int authorID, AddAuthorDto addAuthorDto)
        {
            return await _iAuthorRepository.UpdateAuthorAsync(authorID, addAuthorDto.name, addAuthorDto.image, addAuthorDto.about);
        }

    }
}