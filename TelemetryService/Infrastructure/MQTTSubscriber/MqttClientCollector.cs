using MQTTnet;
using System.Text;

namespace Infrastructure.MQTTSubscriber
{
    public class MqttClientCollector
    {

        private List<IExtendedMqttClient> clients = new List<IExtendedMqttClient>();

        public IMqttClient CreateClient()
        {
            var factory = new MqttClientFactory();
            var client = factory.CreateMqttClient();

            client.ApplicationMessageReceivedAsync += e =>
            {
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                Console.WriteLine($"[Received] Topic: {e.ApplicationMessage.Topic}, Message: {payload}");
                return Task.CompletedTask;
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
            if (client == null) throw new Exception("Client not exist");
            
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
