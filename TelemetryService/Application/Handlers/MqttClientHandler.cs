using Application.DTOs.MqttClientOptions;
using Application.Interfaces.Mqtt;
using Application.Utils.Mapping;

namespace Application.Handlers
{
    public class MqttClientHandler
    {

        private IMqttClientService _service;
        public MqttClientHandler(IMqttClientService service)
        {
            _service = service;
        }

        public void SyncClientAsync(IEnumerable<ResponseMqttClientOptionsDto> options)
        {
            var otionsEntities = options.Select(x => x.ToEntity());
            _service.SyncClientsAsync(otionsEntities);
        }

        public async Task ConnectClientAsync(ConnectMqttClientDto dto)
        {
            await _service.ConnectClientAsync(dto.ClientId, dto.Host, dto.Port);
        }

        public async Task SybscribeClientAsync(SubscribeMqttClientDto dto)
        {
            await _service.SubscribeAsync(dto.ClientId, dto.Topic);
        }
        public IEnumerable<string> GetSubscribedClients()
        {
            return _service.GetSubscribedClients();
        }
    }
}
