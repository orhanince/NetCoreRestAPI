using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _iPublisherService;

        public PublisherController(IPublisherService iPublisherService)
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
            return await _iPublisherService.GetPublisherListAsync();
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

