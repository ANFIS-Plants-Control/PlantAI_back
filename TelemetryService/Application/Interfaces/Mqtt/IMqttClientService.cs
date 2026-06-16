using Core.Models.mqtt;

namespace Application.Interfaces.Mqtt
{
    public interface IMqttClientService
    {
        public Task<bool> ConnectClientAsync(string clientId, string host, int port);
        public Task SubscribeAsync(string clientId, int topicId);
        public Task SyncClientsAsync();
        public IEnumerable<string> GetSubscribedClients();
    }
}
