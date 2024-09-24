
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
    public class LanguageRepository : ILanguageRepository
{
        private readonly MyAppContext _context;
        private readonly IMapper _iMapper;
        public LanguageRepository(MyAppContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }
        public async Task<List<LanguageDto>> GetLanguagesAsync()
        {
            var languages = await _context.Languages.ToListAsync();
            return  _iMapper.Map<List<LanguageDto>>(languages);
        }

        public async Task<LanguageDto> AddLanguageAsync(string name)
        {
            var existLang = await _context.Languages.FirstOrDefaultAsync(u => u.Key == SlugHelper.GenerateSlug(name));  
            if (existLang != null)
            {
                throw new ArgumentNullException(nameof(existLang));
            }
            
            var language = new Language {
                Name = name,
                Key = SlugHelper.GenerateSlug(name),
                Active = true
            };
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();
            return _iMapper.Map<LanguageDto>(language);
        }

        public async Task<bool> LanguageExistsAsync(string languageID)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(u => u.Key == languageID);
            if (language == null)
            {
                return false;
            }
            return true;
        }   
    }
}
