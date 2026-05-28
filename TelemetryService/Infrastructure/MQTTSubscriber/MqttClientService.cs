using MQTTnet;
using Application.Interfaces.Mqtt;
using Infrastructure.MQTTSubscriber;
using Core=Core.Models;
using Application.Interfaces.Services;
using System.IO.Pipes;

namespace Infrastructure.Services
{
    public class MqttClientService : IMqttClientService
    {
        private MqttClientCollector collector;
        private IMqttClientOptionsService service;
        public MqttClientService(MqttClientCollector collector, IMqttClientOptionsService service)
        {
            this.collector = collector;
            this.service = service;
        }

        public async Task SyncClientsAsync(IEnumerable<Core::MqttClientOptions> options)
        {
            options.ToList().ForEach(async o =>
            {
                collector.DeleteClient(o.ClientId);
                await ConnectClientAsync(o.ClientId, o.Host, o.Port);
            });
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
            await service.SetIsSubscribedClientAsync(clientId, true);
        }

        public IEnumerable<string> GetSubscribedClients()
        {
            var clients = collector.GetClients().Where(c => c.IsSubscribed).ToList();
            return clients.Select(x => x.Options.ClientId);
        }
    }
}
