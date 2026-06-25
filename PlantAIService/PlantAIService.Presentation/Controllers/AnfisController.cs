using Application.DTOs.FnnAnswerDTOs;
using Application.Interfaces.Anfis;
using Application.Interfaces.SensorData;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace PlantAIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnfisController : Controller
    {
        private ISensorDataService _sensorDataService;
        private IAnfisAnswerProvider _anfisAnswerProvider;
        private readonly IFnnAnswerService _fnnAnswerService;

        public AnfisController(IAnfisAnswerProvider anfisAnswerProvider, ISensorDataService sensorDataService, IFnnAnswerService fnnAnswerService)
        {
            _anfisAnswerProvider = anfisAnswerProvider;
            _sensorDataService = sensorDataService;
            _fnnAnswerService = fnnAnswerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var climateStatus = await _sensorDataService.GetClimatStatus();
                var ans = await _anfisAnswerProvider.GetNetAnswer(climateStatus);
                await _fnnAnswerService.CreateAsync(new FnnAnswerCreateDto(1, climateStatus.DataGroupId, 1, ans, DateTime.UtcNow));
                return Ok(ans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
