using MQTTnet;
using Application.Interfaces.Mqtt;
using Infrastructure.MQTTSubscriber;
using Infrastructure.Extensions.mqtt;
using Application.Interfaces.Repositories;

namespace Infrastructure.Services
{
    public class MqttClientConnectionService : IMqttClientService
    {
        private MqttClientCollector collector;
        private readonly IMqttClientsRepository _repository;
        private readonly IBrokersParametersRepository _brokerRepository;
        private readonly ITopicRepository _topicRepository;
        public MqttClientConnectionService(MqttClientCollector collector, IMqttClientsRepository repository, ITopicRepository topicRepository, IBrokersParametersRepository brokerRepository)
        {
            this.collector = collector;
            _repository = repository;
            _topicRepository = topicRepository;
            _brokerRepository = brokerRepository;
        }

        public async Task SyncClientsAsync()
        {
            var brokers = await _brokerRepository.GetBrokersWithClientsAsync();
            foreach (var broker in brokers)
            {
                foreach(var client in broker.Clients)
                {
                    collector.DeleteClient(client.ClientId);
                    if (await ConnectClientAsync(client.ClientId, broker.Host, broker.Port))
                    {
                        var connectedClient = collector.GetClientById(client.ClientId);
                        var clientLinkTopics = await _repository.GetByClientIdWithTopicsAsync(client.ClientId);
                        foreach (var topic in clientLinkTopics.Topics)
                        {
                            await connectedClient.SubscribeAsync(topic.Topic);
                        }
                    }
                }
            }
        }

        public async Task<bool> ConnectClientAsync(string clientId, string host, int port)
        {
            try
            {
                var client = collector.CreateClient();

                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer(host, port)
                    .WithClientId(clientId)
                    .Build();

                var response = await client.ConnectAsync(options);
                if (response.ResultCode == MqttClientConnectResultCode.Success)
                {
                    var extendedClient = new ExtendedMqttClient(client);

                    collector.SaveClient(extendedClient);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }
        public async Task SubscribeAsync(string clientId, int topicId)
        {
            var client = await _repository.GetByClientIdAsync(clientId);
            if (client == null)
                throw new Exception($"Client {clientId} does not exists");

            var topic = await _topicRepository.GetByIdAsync(topicId);
            if (topic == null)
                throw new Exception($"Topic with id {topicId} is not exists");
            
            var collectedClient = collector.GetClientById(clientId);
            await collectedClient.SubscribeAsync(topic.Topic);
        }

        public IEnumerable<string> GetSubscribedClients()
        {
            var clients = collector.GetClients().Where(c => c.IsSubscribed).ToList();
            return clients.Select(x => x.Options.ClientId);
        }
    }
}
