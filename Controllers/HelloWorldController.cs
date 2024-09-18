using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var greeting = _helloWorldService.GetGreeting();
            return Ok(new { Message = greeting });
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            return Ok(new { Id = id });
        }

        [HttpPost()]
        public ActionResult<Item> Save(CreateItemDto createItemDto)
        {
            try
            {
                var item = new Item
                {
                    Id = 1,
                    Name = createItemDto.Name
                };
                return Ok(item);
            }
            catch (System.Exception e)
            {
                return Ok(new { Message = e });
                throw;
            }

        }
    }
}