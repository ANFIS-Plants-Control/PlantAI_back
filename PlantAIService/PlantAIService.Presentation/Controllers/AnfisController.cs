using Application.Interfaces.Anfis;
using Application.Interfaces.SensorData;
using Microsoft.AspNetCore.Mvc;

namespace PlantAIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnfisController : Controller
    {
        private ISensorDataService _sensorDataService;
        private IAnfisAnswerProvider _anfisAnswerProvider;
        public AnfisController(IAnfisAnswerProvider anfisAnswerProvider, ISensorDataService sensorDataService)
        {
            _anfisAnswerProvider = anfisAnswerProvider;
            _sensorDataService = sensorDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var climateStatus = await _sensorDataService.GetClimatStatus();
                var ans = await _anfisAnswerProvider.GetNetAnswer(climateStatus);
                return Ok(ans);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
