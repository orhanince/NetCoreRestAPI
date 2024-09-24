using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface ILanguageRepository
    {
        Task <List<LanguageDto>> GetLanguagesAsync();
        Task <LanguageDto> AddLanguageAsync(string name);
        Task<bool> LanguageExistsAsync(string languageID);
    } 
}
