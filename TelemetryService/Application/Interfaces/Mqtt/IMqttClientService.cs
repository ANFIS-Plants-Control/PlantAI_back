using Core.Models.mqtt;

namespace Application.Interfaces.Mqtt
{
    public interface IMqttClientService
    {

        public Task ConnectClientAsync(string clientId, string host, int port);
        public Task SubscribeAsync(string topic, string clientId);
        public Task SyncClientsAsync();
        public IEnumerable<string> GetSubscribedClients();
    }
}
