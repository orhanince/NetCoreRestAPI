using Microsoft.AspNetCore.Http.HttpResults;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Repository;

namespace NetCoreRestAPI.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _iLanguageRepository;
        public LanguageService(ILanguageRepository iLanguageRepository)
        {
             _iLanguageRepository = iLanguageRepository;
        }

        public async Task<List<LanguageDto>> GetLanguagesAsync()
        {
            return await _iLanguageRepository.GetLanguagesAsync();
        }

        public async Task<LanguageDto> AddLanguageAsync(AddLanguageDto addLanguageDto)
        {
            return await _iLanguageRepository.AddLanguageAsync(addLanguageDto.name);
        }

        public async Task<bool> LanguageExistsAsync(int languageID)
        {
            return await _iLanguageRepository.LanguageExistsAsync(languageID);
        }

    }
}