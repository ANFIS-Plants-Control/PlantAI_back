using Application.DTOs.MqttClientOptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utils.Mapping;

namespace Application.Services
{
    public class MqttClientOptionsService : IMqttClientOptionsService
    {

        private readonly IMqttClientOptionsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public MqttClientOptionsService(IMqttClientOptionsRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseMqttClientOptionsDto> CreateClientAsync(CreateMqttClientOptionsDto dto)
        {
            var exitsed = await _repository.GetByClientIdAsync(dto.ClientId);
            if (exitsed != null) 
                throw new Exception($"Client {dto.ClientId} already exist");

            var entity = dto.ToEntity();
            await _repository.CreateClientAsync(entity);
            
            var newClient = await _repository.GetByClientIdAsync(dto.ClientId);
            var response = newClient.ToResponseDto();
            
            return response;
        }

        public async Task<IEnumerable<ResponseMqttClientOptionsDto>> GetAsync()
        {
            var options = await _repository.GetAsync();
            return options.Select(x => x.ToResponseDto());
        }

        public async Task<ResponseMqttClientOptionsDto> GetByClientIdAsync(string clientId)
        {
            var client = await _repository.GetByClientIdAsync(clientId);
            if (client == null) 
                throw new Exception($"Client {clientId} does not exsit");

            return client.ToResponseDto();
        }

        public async Task<ResponseMqttClientOptionsDto> GetByIdAsync(int Id)
        {
            var client = await _repository.GetByIdAsync(Id);
            if(client == null) 
                throw new Exception($"Client {Id} does not exsit");

            return client.ToResponseDto();
        }

        public async Task<IEnumerable<ResponseMqttClientOptionsDto>> GetSubscribedClientsAsync(IEnumerable<string> clientIds)
        {
            var clients = await _repository.GetAsync();
            var subscribedClients = clients
                .Where(c => clientIds.Contains(c.ClientId))
                .Select(c => c.ToResponseDto())
                .ToList();
            
            return subscribedClients;
        }
    }
}
