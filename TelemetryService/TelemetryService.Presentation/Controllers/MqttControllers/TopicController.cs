using Application.DTOs.MQTT.Topic;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace TelemetryService.Controllers.MqttControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : Controller
    {
        private readonly ITopicService _service;
        public TopicController(ITopicService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ResponseMqttTopic> Create(string topic)
        {
            var response = await _service.CreateAsync(topic);
            return response;
        }
    }
}
