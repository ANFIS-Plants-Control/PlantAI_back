using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PlantAIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private TelemetryService _telemetryService;
        public DataController(TelemetryService telemetryService)
        {
            _telemetryService = telemetryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try 
            {
                var datas = _telemetryService.GetLastDatasAsync();
                return Ok(datas);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }        
        }
    }
}
