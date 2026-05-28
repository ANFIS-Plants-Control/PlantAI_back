using Application.DTOs.MqttClientOptions;
using Application.Handlers;
using Application.Interfaces.Services;
using Application.Utils.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace TelemetryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MqttController : Controller
    {
        private readonly IMqttClientOptionsService clientOptionsService;
        private readonly MqttClientHandler clientHandler;
        public MqttController(IMqttClientOptionsService clientOptionsService, MqttClientHandler clientHandler)
        {
            this.clientOptionsService = clientOptionsService;
            this.clientHandler = clientHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseMqttClientOptionsDto>> GetMqttClientOptions()
        {
            return await clientOptionsService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMqttClient(CreateMqttClientOptionsDto dto)
        {
            var options = await clientOptionsService.CreateClientAsync(dto);
            await clientHandler.ConnectClientAsync(options.ToConnectDto());
            return CreatedAtAction(nameof(GetClientOptionsById), new { Id = options.Id }, options);
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> SubscribeClientAsync([FromBody] SubscribeMqttClientDto dto)
        {
            var options = await clientOptionsService.GetByClientIdAsync(dto.ClientId);
            await clientHandler.SybscribeClientAsync(dto);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ResponseMqttClientOptionsDto> GetClientOptionsById(int id)
        {
            var client = await clientOptionsService.GetByIdAsync(id);
            return client;
        }

        [HttpGet("sync")]
        public async Task SyncMqttClients()
        {
            var clients = await clientOptionsService.GetAsync();
            clientHandler.SyncClientAsync(clients);
        }

        [HttpGet("subscribed")]
        public async Task<IEnumerable<ResponseMqttClientOptionsDto>> GetSubscribedClients()
        {
            var clientIds = clientHandler.GetSubscribedClients();
            var clients = await clientOptionsService.GetSubscribedClientsAsync(clientIds);
            return clients;
        }
    }
}
