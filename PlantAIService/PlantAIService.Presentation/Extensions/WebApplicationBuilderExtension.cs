using System.Net;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Persistant;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PlantAIService.Extensions
{
    public static class WebApplicationBuilderExtension
    {

        public static void ImplementBuilderServices(this WebApplicationBuilder builder)
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
            string connectionStrign = builder.Configuration["PlantAIDbConnectionString"] + $"Password={dbPassword}";
#endif

            builder.Services.AddDbContext<PlantAIDbContext>(cnt => cnt.UseNpgsql(connectionStrign));

            builder.Services.AddScoped<IFnnAnswerRepository, FnnAnswerRepository>();
            builder.Services.AddScoped<IFnnAnswerService, FnnAnswerService>();

            builder.Services.AddOpenApi();
            builder.Services.AddGrpc();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddGrpcClient<Infrastructure.AiServices.Anfis.NetAnswer.NetAnswerClient>(options =>
            {
                HttpClient.DefaultProxy = new WebProxy();
                options.Address = new Uri("http://worker:50051");
            });

            builder.Services.AddHttpClient("Telemetry", options =>
            {
                options.BaseAddress = new Uri("http://telemetry:8080/api/");
            });
        }

    }
}
