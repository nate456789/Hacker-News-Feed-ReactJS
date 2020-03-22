using Microsoft.AspNetCore.Mvc;

namespace Hacker_News_Feed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("I'm Alive!");
        }
    }
}