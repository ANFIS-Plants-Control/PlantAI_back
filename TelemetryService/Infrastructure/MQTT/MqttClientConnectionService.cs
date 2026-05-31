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
        public MqttClientConnectionService(MqttClientCollector collector, IMqttClientsRepository repository)
        {
            this.collector = collector;
            _repository = repository;
        }

        public async Task SyncClientsAsync()
        {
            var dashboards = await _repository.GetDashboardAsync();

            foreach(var d in dashboards)
            {
                foreach(var c in d.Clients)
                {
                    collector.DeleteClient(c.ClientId);
                    await ConnectClientAsync(c.ClientId, d.Host, d.Port);
                }
            }
        }

        public async Task ConnectClientAsync(string clientId, string host, int port)
        {
            var client = collector.CreateClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(host, port)
                .WithClientId(clientId)
                .Build();
            
            try
            {
                await client.ConnectAsync(options);

                var extendedClient = new ExtendedMqttClient(client);

                collector.SaveClient(extendedClient);
            }
            catch(Exception ex) 
            {
                throw new Exception($"Broker on {host}:{port} not avialable");
            }
        }
        public async Task SubscribeAsync(string clientId, string topic)
        {
            var client = collector.GetClientById(clientId);
            await client.SubscribeAsync(topic);
        }

        public IEnumerable<string> GetSubscribedClients()
        {
            var clients = collector.GetClients().Where(c => c.IsSubscribed).ToList();
            return clients.Select(x => x.Options.ClientId);
        }
    }
}
