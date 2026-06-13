using Application.Interfaces.Mqtt;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Services;

namespace TelemetryService.Extensions
{
    public static class DiServicesImplementation
    {
        public static void ImplementServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddScoped<ISensorDataService, SensorDataService>();

            builder.Services.AddScoped<IDataGroupService, DataGroupsService>();

            builder.Services.AddScoped<IBrokerParametersService, BrokerParametersService>();

            builder.Services.AddScoped<ITopicService, TopicService>();

            builder.Services.AddScoped<IMqttClientsService, MqttClientsService>();
            builder.Services.AddScoped<IMqttClientService, MqttClientConnectionService>();
        }
    }
}
