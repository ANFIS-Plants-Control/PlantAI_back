using MQTTnet;
using MQTTnet.Diagnostics.PacketInspection;

namespace Infrastructure.Extensions.mqtt
{
    public class ExtendedMqttClient : IExtendedMqttClient
    {
        private readonly IMqttClient _innerClient;
        public ExtendedMqttClient(IMqttClient innerClient)
        {
            _innerClient = innerClient;
        }
        public bool IsSubscribed { get; set; }

        public bool IsConnected => _innerClient.IsConnected;

        public MqttClientOptions Options => _innerClient.Options;

        public event Func<MqttApplicationMessageReceivedEventArgs, Task> ApplicationMessageReceivedAsync
        {
            add => _innerClient.ApplicationMessageReceivedAsync += value;
            remove => _innerClient.ApplicationMessageReceivedAsync -= value;
        }

        public event Func<MqttClientConnectedEventArgs, Task> ConnectedAsync
        {
            add => _innerClient.ConnectedAsync += value;
            remove => _innerClient.ConnectedAsync -= value;
        }

        public event Func<MqttClientConnectingEventArgs, Task> ConnectingAsync
        {
            add => _innerClient.ConnectingAsync += value;
            remove => _innerClient.ConnectingAsync -= value;
        }
        public event Func<MqttClientDisconnectedEventArgs, Task> DisconnectedAsync
        {
            add => _innerClient.DisconnectedAsync += value;
            remove => _innerClient.DisconnectedAsync -= value;
        }
        public event Func<InspectMqttPacketEventArgs, Task> InspectPacketAsync
        {
            add => _innerClient.InspectPacketAsync += value;
            remove => _innerClient.InspectPacketAsync -= value;
        }

        public Task<MqttClientConnectResult> ConnectAsync(MqttClientOptions options, CancellationToken cancellationToken = default)
        {
            return _innerClient.ConnectAsync(options, cancellationToken);
        }

        public Task DisconnectAsync(MqttClientDisconnectOptions options, CancellationToken cancellationToken = default)
        {
            return _innerClient.DisconnectAsync(options, cancellationToken);
        }

        public void Dispose()
        {
            _innerClient.Dispose();
        }

        public Task PingAsync(CancellationToken cancellationToken = default)
        {
            return _innerClient.PingAsync(cancellationToken);
        }

        public Task<MqttClientPublishResult> PublishAsync(MqttApplicationMessage applicationMessage, CancellationToken cancellationToken = default)
        {
            return _innerClient.PublishAsync(applicationMessage, cancellationToken);
        }

        public Task SendEnhancedAuthenticationExchangeDataAsync(MqttEnhancedAuthenticationExchangeData data, CancellationToken cancellationToken = default)
        {
            return _innerClient.SendEnhancedAuthenticationExchangeDataAsync(data, cancellationToken);
        }

        public Task<MqttClientSubscribeResult> SubscribeAsync(MqttClientSubscribeOptions options, CancellationToken cancellationToken = default)
        {
            IsSubscribed = true;

            return _innerClient.SubscribeAsync(options, cancellationToken);
        }

        public Task<MqttClientUnsubscribeResult> UnsubscribeAsync(MqttClientUnsubscribeOptions options, CancellationToken cancellationToken = default)
        {
            IsSubscribed = false;
            return _innerClient.UnsubscribeAsync(options, cancellationToken);
        }
    }
}
