using Microsoft.Extensions.Hosting;
using MQTTnet;
using System.Text;

namespace Infrastructure.MQTTSubscriber
{
    public class MQTTSubscriber : BackgroundService
    {
        public string Host = "plantai_broker";
        public int Port = 1883;
        public string ClientId ="SubscriberClient";
        public string Topic = "test/topic";

        private IMqttClient client;
        private MqttClientOptions options;

        public MQTTSubscriber() { }
        public MQTTSubscriber(string host, int port, string clientId, string topic)
        {
            Host = host;
            Port = port;
            ClientId = clientId;
            Topic = topic;
        }

        public void CreateSubscriber()
        {
            var mqttFactory = new MqttClientFactory();
            client = mqttFactory
                .CreateMqttClient();

            options = new MqttClientOptionsBuilder()
                .WithTcpServer(Host, Port)
                .WithClientId(ClientId)
                .Build();

            client.ApplicationMessageReceivedAsync += e =>
            {
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                Console.WriteLine($"[Received] Topic: {e.ApplicationMessage.Topic}, Message: {payload}");
                return Task.CompletedTask;
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            CreateSubscriber();
            await client.ConnectAsync(options);
            Console.WriteLine("Subscriber connected.");

            await client.SubscribeAsync(Topic);
            Console.WriteLine($"Subscribed to {Topic}");
        }
    }
}
