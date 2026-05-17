using Infrastructure.MQTTSubscriber;
using Microsoft.EntityFrameworkCore;
using TelemetryService.Infrastructure.Persistant;

namespace TelemetryService.Extenstions
{
    public static class WebApplicationBuilderExtension
    {

        public static void ImplementServices(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddKeyPerFile(directoryPath: "/run/secrets", optional: true);

            string dbPassword = builder.Configuration["dbPassword"];
            string connectionStrign = builder.Configuration["connectionString"] + $"Password={dbPassword}";

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddHostedService<MQTTSubscriber>();

            builder.Services.AddDbContext<TelemetryDbContext>(cnt => cnt.UseNpgsql(connectionStrign));
        }
    }
}
