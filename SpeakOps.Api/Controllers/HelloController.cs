using Microsoft.AspNetCore.Mvc;

namespace SpeakOps.Api.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(new {hello = "world"});
        }
    }
}
