using Application.Handlers;
using Infrastructure.MQTTSubscriber;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Extensions;
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

            builder.ImplementServices();
            builder.ImplementRepositories();
        }
    }
}
