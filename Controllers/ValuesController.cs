using Microsoft.AspNetCore.Mvc;

namespace PlantAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok("All okay");
        }
    }
}
