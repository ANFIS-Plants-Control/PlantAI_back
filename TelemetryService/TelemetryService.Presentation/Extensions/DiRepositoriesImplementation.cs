using Application.Interfaces.Repositories;
using Infrastructure.Repository;

namespace TelemetryService.Extensions
{
    public static class DiRepositoriesImplementation
    {

        public static void ImplementRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ISensorDataRepository, SensorDataRepository>();
            builder.Services.AddScoped<IDataGroupRepository, DataGroupRepository>();
            builder.Services.AddScoped<IBrokersParametersRepository, BrokerParamtersRepository>();
            builder.Services.AddScoped<ITopicRepository, TopicRepository>();
            builder.Services.AddScoped<IMqttClientsRepository, MqttClientsRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
