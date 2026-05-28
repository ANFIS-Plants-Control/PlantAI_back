using Core.Models;

namespace Application.Interfaces.Repositories
{
    public interface IMqttClientOptionsRepository
    {
        public Task<IEnumerable<MqttClientOptions>> GetAsync();
        public Task CreateClientAsync(MqttClientOptions options);
        public Task<MqttClientOptions> GetByClientIdAsync(string ClientId);
        public Task<MqttClientOptions> GetByIdAsync(int Id);
    }
}
