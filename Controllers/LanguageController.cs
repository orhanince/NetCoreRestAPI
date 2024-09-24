using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{   
    [ApiController]
    [Route("app/[controller]")]
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _iLanguageService;

        public LanguagesController(ILanguageService iLanguageService)
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
            var languages = await _iLanguageService.GetLanguagesAsync();
            return View("~/Views/Languages/Index.cshtml", languages);
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

