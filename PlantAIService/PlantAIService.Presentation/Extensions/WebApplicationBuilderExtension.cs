using Infrastructure;
using System.Net;

namespace PlantAIService.Extensions
{
    public static class WebApplicationBuilderExtension
    {

        public static void ImplementBuilderServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddOpenApi();
            builder.Services.AddGrpc();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddGrpcClient<Infrastructure.AiServices.Anfis.NetAnswer.NetAnswerClient>(options =>
            {
                HttpClient.DefaultProxy = new WebProxy();
                options.Address = new Uri("http://localhost:50051");
            });

            builder.Services.AddScoped<TelemetryService>(builder => new TelemetryService("http://plantai-telemetry:8081"));
        }

    }
}
