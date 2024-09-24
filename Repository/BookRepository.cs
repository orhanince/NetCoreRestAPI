
using System.Globalization;
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

    private readonly IAuthorRepository _iAuthorRepository;
    public BookRepository(MyAppContext context, IMapper iMapper, IAuthorRepository iAuthorRepository)
    {
        _context = context;
        _iMapper = iMapper;
        _iAuthorRepository = iAuthorRepository;
    }
    public async Task<List<BookDto>> GetBooksAsync()
    {
        var books = await _context.Books.ToListAsync();
        return  _iMapper.Map<List<BookDto>>(books);
    }

    public async Task<BookDto> AddBookAsync(string title, int? authorID)
    {
        var book = new Book {
            Title = title,
            Slug = SlugGenerator.GenerateSlug(title),
            Active = true
        };
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return _iMapper.Map<BookDto>(book);
    }

    public async Task<BookDto> GetBookAsync(int bookID)
    {
        var bookWithAuthors = await Task.Run(() => _context.Books.Where(x=> x.Id == bookID)
        .Include(l => l.Language)
        .Include(p => p.Publisher)
        .Include(a => a.BookAuthors!)
        .ThenInclude(ba => ba.Author)
        .FirstOrDefault());

        var aa =  _iMapper.Map<BookDto>(bookWithAuthors);
        return aa;
    }

    public async Task<BookDto> UpdateBookAsync(int bookId, string title, bool active, string? image, string? isbn, string? description, int? authorId, int? languageId, int? publisherId, string? publishedDate)
    {
        var book = await Task.Run(() => _context.Books.Where(x=> x.Id == bookId)
        .Include(l => l.Language)
        .Include(p => p.Publisher)
        .Include(a => a.BookAuthors!)
        .ThenInclude(ba => ba.Author)
        .FirstOrDefault());

        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }
         DateTime? dateTimePublished = null;
        if (!string.IsNullOrEmpty(publishedDate))
        {
        dateTimePublished = DateTime.ParseExact(publishedDate, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToUniversalTime();
        }
        book.Title = title;
        book.ISBN = isbn;
        book.Description = description;
        book.PublishedDate = dateTimePublished;
        book.LanguageId = languageId;
        book.PublisherId = publisherId;
        book.Active = active;
        book.Slug = SlugGenerator.GenerateSlug(title);
        book.Image = image;

        if (authorId != null)
        {
            var bookAuthor = _context.BookAuthors.FirstOrDefault(ba => ba.BookId == bookId && ba.AuthorId == authorId);
            if (bookAuthor == null)
            {
                var author = await _iAuthorRepository.GetAuthorAsync(authorId.Value);
                if (author == null)
                {
                    throw new ArgumentNullException(nameof(author));
                }
                var newBookAuthor = new BookAuthor
                {
                    Book = book,
                    Author = _iMapper.Map<Author>(author)
                };
                _context.BookAuthors.Add(newBookAuthor);
            }
        }
         _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return _iMapper.Map<BookDto>(book);
    }

    public async Task<UserDto> AddBookToUserAsync(int userID, int bookID)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userID);
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        var book = await _context.Books.FirstOrDefaultAsync(u => u.Id == bookID);
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }
        var userBook = new UserBook
        {
            User = user,
            Book = book
        };
        _context.UserBooks.Add(userBook);
        await _context.SaveChangesAsync();
        return _iMapper.Map<UserDto>(user);
    }

    public async Task<List<BookDto>> GetUserBooksAsync(int userID)
    {
        var userBooks = await Task.Run(() => _context.UserBooks.Where(x=> x.UserId == userID)
        .Include(b => b.Book)
        .ThenInclude(l => l.Language)
        .Include(b => b.Book)
        .ThenInclude(p => p.Publisher)
        .Include(b => b.Book)
        .ThenInclude(a => a.BookAuthors!)
        .ThenInclude(ba => ba.Author)
        .ToList());

        var books = userBooks.Select(x => x.Book).ToList();
        return  _iMapper.Map<List<BookDto>>(books);
    }

    public async Task<bool> BookExistsAsync(string title)
    {

        var book = await _context.Books.FirstOrDefaultAsync(u => u.Slug == SlugGenerator.GenerateSlug(title));
        if (book == null)
        {
            return false;
        }

        return true;
    }
    }
}
