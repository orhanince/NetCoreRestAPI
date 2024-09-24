using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface ILanguageService
    {
        Task<List<LanguageDto>> GetLanguagesAsync();
        Task<LanguageDto> AddLanguageAsync(AddLanguageDto addLanguageDto);
        Task<bool> LanguageExistsAsync(string languageID); 
    }
}
