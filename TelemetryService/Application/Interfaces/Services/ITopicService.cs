using Application.DTOs.MQTT.Topic;

namespace Application.Interfaces.Services
{
    public interface ITopicService
    {

        public Task<ResponseMqttTopic> CreateAsync(string topic);
        public Task<IEnumerable<ResponseMqttTopic>> GetAllAsync();

    }
}
