using Microsoft.AspNetCore.Mvc;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
    }
}