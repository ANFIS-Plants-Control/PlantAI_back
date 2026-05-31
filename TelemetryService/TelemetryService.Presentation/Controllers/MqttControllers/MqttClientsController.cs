using Application.DTOs.MQTT.Subscriptions;
using Application.Handlers;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TelemetryService.Controllers.MqttControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MqttClientsController : Controller
    {
        private readonly IMqttClientsService _clientService;
        private readonly MqttClientHandler _clientHandler;
        public MqttClientsController(IMqttClientsService clientService, MqttClientHandler clientHandler)
        {
            _clientService = clientService;
            _clientHandler = clientHandler;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var dashboard = await _clientService.GetMqttDashboardAsync();
            return Ok(dashboard);
        }

        [HttpGet]
        public async Task<IActionResult> GetMqttClients()
        {
            try
            {
                var clients = await _clientService.GetMqttClientsAsync();
                return Ok(clients);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMqttClientDto dto)
        {
            try
            {
                var client = await _clientService.CreateMqttClientAsync(dto);
                return Ok(client);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("synchronize")]
        public async Task<IActionResult> Synchronize()
        {
            try
            {
                await _clientHandler.SyncClientAsync();
                return Ok(new { Message = "All existed clients connected" });
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
