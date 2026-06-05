using Application.DTOs.MQTT.Topic;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utils.Mapping;
using Core.Models.mqtt;

namespace Application.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _repository;
        public TopicService(ITopicRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseMqttTopic> CreateAsync(string topic)
        {
            var existed = await _repository.GetByTopicStringAsync(topic);
            if (existed != null)
                throw new Exception($"Topic {topic} already exists");

            var entity = new TopicDefinition { Topic = topic };
            await _repository.CreateAsync(entity);

            var response = await _repository.GetByTopicStringAsync(topic);
            return response.ToResponse();
        }

        public async Task<IEnumerable<ResponseMqttTopic>> GetAllAsync()
        {
            var topics = await _repository.GetAllAsync();
            return topics.Select(x => x.ToResponse());
        }
    }
}
