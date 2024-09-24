using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class CheckJsonDataMiddleware
{
    private readonly RequestDelegate _next;

    public CheckJsonDataMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IBookService _bookService, IPublisherService _publisherService, ILanguageService _languageService, IAuthorService _authorService)
    {
        if (context.Request.Path.StartsWithSegments("/api/book") && context.Request.Method == HttpMethods.Post)
        {
            context.Request.EnableBuffering();

            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;

                var jsonData = JsonSerializer.Deserialize<JsonElement>(body);
                jsonData.TryGetProperty("title", out var titleElement);
                jsonData.TryGetProperty("authorId", out var authorIdElement);
                jsonData.TryGetProperty("publisherId", out var publisherIdElement); 
                jsonData.TryGetProperty("languageId", out var languageIdElement);
                if (titleElement.ValueKind == JsonValueKind.String)
                {
                    var title = titleElement.GetString();
                    var bookExists = await _bookService.BookExistsAsync(!string.IsNullOrEmpty(title) ? title : "");
                    if (bookExists)
                    {
                        context.Response.StatusCode = StatusCodes.Status409Conflict;
                        await context.Response.WriteAsJsonAsync(new { message = $"Book already exists with given title {title}!" });
                        return;
                    } 
                }
                if (authorIdElement.ValueKind == JsonValueKind.Number)
                {
                    var authorId = authorIdElement.GetInt32();
                    var authorExists = await _authorService.AuthorExistsAsync(authorId);
                    if (!authorExists)   
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsJsonAsync(new { message = $"Author not found with given author id {authorId}!" });
                        return;
                    }
                }
                
                if (publisherIdElement.ValueKind == JsonValueKind.Number)
                {
                    var publisherId = publisherIdElement.GetInt32();
                    var publisherExists = await _publisherService.PublisherExistsAsync(publisherId);
                    if (!publisherExists)   
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsJsonAsync(new { message = $"Publisher not found with given publisher id {publisherId}!" });
                        return;
                    }
                }

                if (languageIdElement.ValueKind == JsonValueKind.Number)
                {
                    var languageId = languageIdElement.GetInt32();
                    var languageExists = await _languageService.LanguageExistsAsync(languageId);
                    if (!languageExists)
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsJsonAsync(new { message = $"Language not found with given language id {languageId}!" });
                        return;
                    }
                }
            }
        }

        await _next(context);
    }
}