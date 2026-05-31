using Application.DTOs.MQTT.Clients;
using Application.DTOs.MQTT.Subscriptions;
using Application.Interfaces.Mqtt;

namespace Application.Handlers
{
    public class MqttClientHandler
    {

        private IMqttClientService _service;
        public MqttClientHandler(IMqttClientService service)
        {
            _service = service;
        }

        public async Task SyncClientAsync()
        {
            await _service.SyncClientsAsync();
        }

        public async Task ConnectClientAsync(ConnectMqttClientDto dto)
        {
            await _service.ConnectClientAsync(dto.clientId, dto.host, dto.port);
        }

        public async Task SybscribeClientAsync(SubscribeMqttClientDto dto)
        {
            await _service.SubscribeAsync(dto.clientId, dto.topic);
        }
        public IEnumerable<string> GetSubscribedClients()
        {
            return _service.GetSubscribedClients();
        }
    }
}
