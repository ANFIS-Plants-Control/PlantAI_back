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
            builder.Services.AddScoped<IMqttClientService,  MqttClientService>();
            builder.Services.AddScoped<MqttClientHandler>();

            builder.Services.AddScoped<IMqttClientOptionsRepository, MqttClientOptionsRepository>();
            builder.Services.AddScoped<IMqttClientOptionsService, MqttClientOptionsService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
