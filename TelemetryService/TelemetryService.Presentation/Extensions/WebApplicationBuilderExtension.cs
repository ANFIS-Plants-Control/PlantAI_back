using Application.Handlers;
using Application.Interfaces.Mqtt;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.MQTTSubscriber;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace TelemetryService.Extenstions
{
    public static class WebApplicationBuilderExtension
    {

        public static void ImplementServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                const string corsName = "PlantAI_Front";

                options.AddPolicy(
                    name: corsName,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

#if DEBUG
            string connectionStrign = builder.Configuration.GetConnectionString("devConnection");
#else
            builder.Configuration.AddKeyPerFile(directoryPath: "/run/secrets", optional: true);

            string dbPassword = builder.Configuration["DbPassword"];
            string connectionStrign = builder.Configuration["TelemetryDbConnectionString"] + $"Password={dbPassword}";
#endif
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<TelemetryDbContext>(cnt => cnt.UseNpgsql(connectionStrign));

            builder.Services.AddSingleton<MqttClientCollector>();
            builder.Services.AddScoped<MqttClientHandler>();

            builder.Services.AddScoped<ISensorDataRepository,  SensorDataRepository>();
            builder.Services.AddScoped<ISensorDataService, SensorDataService>();
            builder.Services.AddScoped<IDataGroupRepository, DataGroupRepository>();
            builder.Services.AddScoped<IDataGroupService, DataGroupsService>();
            builder.Services.AddScoped<IBrokersParametersRepository, BrokerParamtersRepository>();
            builder.Services.AddScoped<IBrokerParametersService, BrokerParametersService>();
            builder.Services.AddScoped<ITopicRepository, TopicRepository>();
            builder.Services.AddScoped<ITopicService, TopicService>();
            builder.Services.AddScoped<IMqttClientsRepository, MqttClientsRepository>();
            builder.Services.AddScoped<IMqttClientsService, MqttClientsService>();
            builder.Services.AddScoped<IMqttClientService, MqttClientConnectionService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
