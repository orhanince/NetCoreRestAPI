using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface ILanguageService
    {
        Task<List<LanguageDto>> GetLanguagesAsync();
        Task<LanguageDto> AddLanguageAsync(AddLanguageDto addLanguageDto);
    }
}
