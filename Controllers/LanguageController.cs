using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _iLanguageService;

        public LanguageController(ILanguageService iLanguageService)
        {
            _iLanguageService = iLanguageService;
        }

        /// <summary>
        /// Get all languages.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<LanguageDto>>> GetLanguages()
        {
            return await _iLanguageService.GetLanguagesAsync();
        }

        /// <summary>
        /// Add new language.
        /// </summary>
        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<LanguageDto>> AddLanguage(AddLanguageDto addLanguageDto)
        {
            return await _iLanguageService.AddLanguageAsync(addLanguageDto);
        }
    }
}

