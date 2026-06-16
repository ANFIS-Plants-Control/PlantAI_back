using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TelemetryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorDataController : Controller
    {
        private readonly ISensorDataService _sensorDataService;
        private readonly IDataGroupService _dataGroupService;
        public SensorDataController(ISensorDataService sensorDataService, IDataGroupService dataGroupService)
        {
            _sensorDataService = sensorDataService;
            _dataGroupService = dataGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _sensorDataService.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("data-groups")]
        public async Task<IActionResult> GetDataGroups()
        {
            try
            {
                var response = await _dataGroupService.GetAllAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
