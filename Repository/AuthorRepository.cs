
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using NetCoreRestAPI.Data;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Helpers;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
{
    private readonly MyAppContext _context;
    private readonly IMapper _iMapper;
    public AuthorRepository(MyAppContext context, IMapper iMapper)
    {
        _context = context;
        _iMapper = iMapper;
    }
    public async Task<List<AuthorDto>> GetAuthorsAsync()
    {
        var authors = await _context.Authors.ToListAsync();
        return  _iMapper.Map<List<AuthorDto>>(authors);
    }

    public async Task<AuthorDto> AddAuthorAsync(string name)
    {   
        var author = new Author {
            Name = name,
            Slug = SlugGenerator.GenerateSlug(name),
            Active = true
        };
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return _iMapper.Map<AuthorDto>(author);
    }

        public async Task<AuthorDto> GetAuthorAsync(int authorID)
        {
            var authorWithBooks = await _context.Authors
                .Include(a => a.BookAuthors!)
                .ThenInclude(ba => ba.Book)
                .FirstOrDefaultAsync(a => a.Id == authorID);
            return _iMapper.Map<AuthorDto>(authorWithBooks);
        }

        public async Task<bool> AuthorExistsAsync(int authorID)
        {
            return await _context.Authors.AnyAsync(a => a.Id == authorID);
        }
    }   
}
