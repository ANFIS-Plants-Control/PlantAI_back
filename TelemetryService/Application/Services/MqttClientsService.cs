using Application.DTOs;
using Application.DTOs.MQTT.Clients;
using Application.DTOs.MQTT.Subscriptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utils.Mapping;

namespace Application.Services
{
    public class MqttClientsService : IMqttClientsService
    {

        private readonly IMqttClientsRepository _repository;
        public MqttClientsService(IMqttClientsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseMqttClientDto> CreateMqttClientAsync(CreateMqttClientDto dto)
        {
            var subscriptions = await _repository.GetByClientIdAsync(dto.clientId);
            if (subscriptions != null)
                throw new Exception($"Client {dto.clientId} already exists");

            var entity = dto.ToEntity();
            await _repository.CreateSubscriptionAsync(entity);

            var response = await _repository.GetByClientIdAsync(dto.clientId);
            return response.ToResponse();
        }

        public async Task<IEnumerable<ResponseMqttClientDto>> GetMqttClientsAsync()
        {
            var clients = await _repository.GetAsync();
            return clients.Select(x => x.ToResponse());
        }
        public async Task<IEnumerable<ResponseMqttDashboardDto>> GetMqttDashboardAsync()
        {
            var dashboard = await _repository.GetDashboardAsync();
            return dashboard.Select(x => x.ToDashboardResponse());
        }
    }
}
