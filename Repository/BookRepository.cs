
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
    public class BookRepository : IBookRepository
{
    private readonly MyAppContext _context;
    private readonly IMapper _iMapper;
    public BookRepository(MyAppContext context, IMapper iMapper)
    {
        _context = context;
        _iMapper = iMapper;
    }
    public async Task<List<BookDto>> GetBooksAsync()
    {
        var books = await _context.Books.ToListAsync();
        return  _iMapper.Map<List<BookDto>>(books);
    }

    public async Task<BookDto> AddBookAsync(string title, int? authorID)
    {
        /**var existAuthor = await _context.Authors.FirstOrDefaultAsync(u => u.Name == SlugHelper.GenerateSlug(name));  
        if (existAuthor != null)
        {
            throw new ArgumentNullException(nameof(existAuthor));
        }*/
        
        var book = new Book {
            Title = title,
            Active = true
        };
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return _iMapper.Map<BookDto>(book);
    }

    public async Task<BookDto> GetBookAsync(int bookID)
    {
        var bookWithAuthors = await Task.Run(() => _context.Books.Where(x=> x.Id == bookID).Include(a => a.BookAuthors).ThenInclude(ba => ba.Author).FirstOrDefault());
        var aa =  _iMapper.Map<BookDto>(bookWithAuthors);
        return aa;
    }
    }   
}
