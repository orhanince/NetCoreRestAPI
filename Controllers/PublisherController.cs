using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{   
    [ApiController]
    [Route("app/[controller]")]
    public class PublishersController : Controller
    {
        private readonly IPublisherService _iPublisherService;

        public PublishersController(IPublisherService iPublisherService)
        {
            _iPublisherService = iPublisherService;
        }

        /// <summary>
        /// Get all publishers.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<PublisherDto>>> GetPublisherList()
        {
            var publishers = await _iPublisherService.GetPublisherListAsync();
            Console.WriteLine(publishers);
            return View("~/Views/Publishers/Index.cshtml", publishers);
        }

        /// <summary>
        /// Add publisher
        /// </summary>
        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PublisherDto>> AddPublisher(AddPublisherDto addPublisherDto)
        {

            return await _iPublisherService.AddPublisherAsync(addPublisherDto);
        }
    }
}

