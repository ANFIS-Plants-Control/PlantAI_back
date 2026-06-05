using Application.DTOs.MQTT.BrokerParameters;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TelemetryService.Controllers.MqttControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerParametersController : Controller
    {
        private readonly IBrokerParametersService _service;
        public BrokerParametersController(IBrokerParametersService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ResponseBrokerParametersDto> Create(CreateBrokerParametersDto dto)
        {
            var response = await _service.CreateAsync(dto);

            return response;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }
    }
}
