using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Core.Models;
using Infrastructure.Extensions.mqtt;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using System.Text;
using System.Text.Json;
using TelemetryService.Application.DTOs.SensorData;

namespace Infrastructure.MQTTSubscriber
{
    public class MqttClientCollector
    {

        private List<IExtendedMqttClient> clients = new List<IExtendedMqttClient>();
        private IServiceProvider _provider;
        public MqttClientCollector(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IMqttClient CreateClient()
        {
            var factory = new MqttClientFactory();
            var client = factory.CreateMqttClient();

            client.ApplicationMessageReceivedAsync += async e =>
            {
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                var data = JsonSerializer.Deserialize<DataGroup>(payload);

                using (var scope = _provider.CreateAsyncScope())
                {
                    var topicRepository = scope.ServiceProvider.GetRequiredService<ITopicRepository>();
                    var topic = await topicRepository.GetByTopicStringAsync(e.ApplicationMessage.Topic);

                    var clientRepo = scope.ServiceProvider.GetRequiredService<IMqttClientsRepository>();
                    var client = await clientRepo.GetByClientIdAsync(e.ClientId);

                    var dataGroupService = scope.ServiceProvider.GetRequiredService<IDataGroupService>();
                    var group = await dataGroupService.SaveAsync(client.Id, topic.Id);

                    var sensorDataService = scope.ServiceProvider.GetRequiredService<ISensorDataService>();
                    await sensorDataService.SaveAsync(data.SensorsData.Select(x => new CreateSensorDataDto(x.Value, x.SensorTypeId)), group.Id);
                }
                
            };
            return client;
        }

        public void SaveClient(IExtendedMqttClient client)
        {
            clients.Add(client);
        }

        public IExtendedMqttClient GetClientById(string clientId)
        {
            var client = clients.FirstOrDefault(c => c.Options.ClientId == clientId);
            if (client == null) throw new Exception($"Client {clientId} not connected");
            
            return client;
        }
        public IEnumerable<IExtendedMqttClient> GetClients()
            => clients;
        
        public void DeleteClient(string clientId)
        {
            var client = clients.FirstOrDefault(c => c.Options.ClientId == clientId);
            if (client != null)
            {
                clients.Remove(client);
            }
        }
    }
}
