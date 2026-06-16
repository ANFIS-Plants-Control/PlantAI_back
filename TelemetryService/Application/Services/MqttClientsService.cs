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
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MqttClientsService(IMqttClientsRepository repository, ITopicRepository topicRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseMqttClientDto> CreateMqttClientAsync(CreateMqttClientDto dto)
        {
            var subscriptions = await _repository.GetByClientIdAsync(dto.clientId);
            if (subscriptions != null)
                throw new Exception($"Client {dto.clientId} already exists");

            var entity = dto.ToEntity();
            await _repository.CreateClientAsync(entity);

            var response = await _repository.GetByClientIdAsync(dto.clientId);
            return response.ToResponse();
        }

        public async Task<IEnumerable<ResponseMqttClientDto>> GetMqttClientsAsync()
        {
            var clients = await _repository.GetAsync();
            return clients.Select(x => x.ToResponse());
        }

        public async Task BindMqttClientTopicAsync(SubscribeMqttClientDto dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var client = await _repository.GetByClientIdWithTopicsAsync(dto.clientId);
                if (client == null)
                    throw new Exception($"Client {dto.clientId} does not exists");

                var topic = await _topicRepository.GetByIdAsync(dto.topicId);
                if (topic == null)
                    throw new Exception($"Topic with id={dto.topicId} does not exists");

                if (!client.Topics.Any(x => x.Id == topic.Id)) 
                {
                    client.Topics.Add(topic);

                    await _unitOfWork.SaveChangesAsync();
                    await _unitOfWork.CommitAsync();
                }
                else 
                    await _unitOfWork.RollbackAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReponseMqttClientWithTopicDto>> GetMqttClientsWithTopicsAsync()
        {
            var clients = await _repository.GetClientsWithTopicsAsync();
            return clients.Select(x => x.ToResponseWithTopic());
        }
    }
}
