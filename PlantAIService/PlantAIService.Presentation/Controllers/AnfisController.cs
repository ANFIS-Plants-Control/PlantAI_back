using Application.Extensions;
using Infrastructure;
using Infrastructure.AiServices.Anfis;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace PlantAIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnfisController : Controller
    {
        private NetAnswer.NetAnswerClient _client;
        private TelemetryService _telemetryService;
        public AnfisController(NetAnswer.NetAnswerClient client, TelemetryService telemetryService)
        {
            _client = client;
            _telemetryService = telemetryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _telemetryService.GetLastDatasAsync();
                var climateStatus = data.DataGroupToClimatStatus();
                var netAnswer = await _client.GetNetAnswerAsync(new SensorDatas() { Temperature = climateStatus.temperature, Humidity = climateStatus.humidity, Co2 = climateStatus.co2 });
                return Ok(netAnswer);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
