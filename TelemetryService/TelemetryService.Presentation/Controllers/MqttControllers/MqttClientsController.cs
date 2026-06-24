using Application.DTOs.MQTT.Clients;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clients = await _clientService.GetMqttClientsAsync();
                return Ok(clients);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateMqttClientDto dto)
        {
            try
            {
                var client = await _clientService.CreateMqttClientAsync(dto);
                return Ok(client);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("linked-topics")]
        public async Task<IActionResult> GetMqttClientsWithTopics()
        {
            try 
            {
                var clients = await _clientService.GetMqttClientsWithTopicsAsync();
                return Ok(clients);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("synchronize")]
        public async Task<IActionResult> Synchronize()
        {
            try
            {
                var data = await _clientHandler.SyncClientAsync();
                return Ok(data);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody]SubscribeMqttClientDto dto)
        {
            try
            {
                await _clientService.BindMqttClientTopicAsync(dto);
                await _clientHandler.SybscribeClientAsync(dto);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("subscribed")]
        public async Task<IActionResult> GetSubscribed()
        {
            try
            {
                var clients = await _clientHandler.GetSubscribedClients();
                return Ok(clients);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
