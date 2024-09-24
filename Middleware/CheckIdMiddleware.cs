using Microsoft.AspNetCore.Http;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class CheckJsonDataMiddleware
{
    private readonly RequestDelegate _next;
    //private readonly IPublisherService _publisherService;
    //private readonly ILanguageService _languageService;

    public CheckJsonDataMiddleware(RequestDelegate next)
    {
        _next = next;
       // _publisherService = publisherService;
        //_languageService = languageService;
    }

    public async Task InvokeAsync(HttpContext context, IPublisherService _publisherService, ILanguageService _languageService)
    {
        if (context.Request.Path.StartsWithSegments("/api/book") && context.Request.Method == HttpMethods.Post)
        {
            context.Request.EnableBuffering();

            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;

                var jsonData = JsonSerializer.Deserialize<JsonElement>(body);

                if (jsonData.TryGetProperty("publisherId", out var publisherIdElement) && 
                    jsonData.TryGetProperty("languageId", out var languageIdElement))
                {
                    var publisherId = publisherIdElement.GetInt32();
                    var languageId = languageIdElement.GetInt32();

                    var publisherExists = await _publisherService.PublisherExistsAsync(publisherId);

                    if (!publisherExists)   
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsJsonAsync(new { message = $"Publisher not found with given publisher id {publisherId}!" });
                        return;
                    }

                    var languageExists = await _languageService.LanguageExistsAsync(languageId.ToString());

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