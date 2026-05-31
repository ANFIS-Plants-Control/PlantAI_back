using Application.DTOs.MQTT;
using Core.Models.mqtt;

namespace Application.Interfaces.Repositories
{
    public interface IMqttClientsRepository
    {
        public Task<IEnumerable<MqttClient>> GetAsync();
        public Task CreateSubscriptionAsync(MqttClient options);
        public Task<MqttClient> GetByClientIdAsync(string clientId);
        public Task<IEnumerable<BrokerParpameters>> GetDashboardAsync();
    }
}
