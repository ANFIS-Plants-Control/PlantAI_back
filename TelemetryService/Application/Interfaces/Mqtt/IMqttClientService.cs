using Core.Models;

namespace Application.Interfaces.Mqtt
{
    public interface IMqttClientService
    {

        public Task ConnectClientAsync(string clientId, string host, int port);
        public Task SubscribeAsync(string topic, string clientId);
        public Task SyncClientsAsync(IEnumerable<MqttClientOptions> options);
        public IEnumerable<string> GetSubscribedClients();
    }
}
