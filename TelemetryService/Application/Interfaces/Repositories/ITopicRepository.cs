using Core.Models.mqtt;

namespace Application.Interfaces.Repositories
{
    public interface ITopicRepository
    {
        public Task<IEnumerable<TopicDefinition>> GetAllAsync();
        public Task<TopicDefinition> GetByIdAsync(int id);
        public Task CreateAsync(TopicDefinition entity);
        public Task<TopicDefinition> GetByTopicStringAsync(string topic);
    }
}
