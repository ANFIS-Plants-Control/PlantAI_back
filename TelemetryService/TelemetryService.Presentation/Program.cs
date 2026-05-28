using TelemetryService.Extenstions;

var builder = WebApplication.CreateBuilder(args);

builder.ImplementServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();




//System.AggregateException: 'Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: Application.Interfaces.Mqtt.IMqttClientService Lifetime: Singleton ImplementationType: Infrastructure.Services.MqttClientService': Cannot consume scoped service 'TelemetryService.Infrastructure.Persistant.TelemetryDbContext' from singleton 'Application.Interfaces.Mqtt.IMqttClientService'.) (Error while validating the service descriptor 'ServiceType: Application.Handlers.MqttClientHandler Lifetime: Scoped ImplementationType: Application.Handlers.MqttClientHandler': Cannot consume scoped service 'TelemetryService.Infrastructure.Persistant.TelemetryDbContext' from singleton 'Application.Interfaces.Mqtt.IMqttClientService'.) (Error while validating the service descriptor 'ServiceType: Application.Interfaces.Services.IMqttClientOptionsService Lifetime: Scoped ImplementationType: Application.Services.MqttClientOptionsService': Cannot consume scoped service 'TelemetryService.Infrastructure.Persistant.TelemetryDbContext' from singleton 'Application.Interfaces.Repositories.IUnitOfWork'.) (Error while validating the service descriptor 'ServiceType: Application.Interfaces.Repositories.IUnitOfWork Lifetime: Singleton ImplementationType: Infrastructure.Repository.UnitOfWork': Cannot consume scoped service 'TelemetryService.Infrastructure.Persistant.TelemetryDbContext' from singleton 'Application.Interfaces.Repositories.IUnitOfWork'.)'
//InvalidOperationException: Cannot consume scoped service 'TelemetryService.Infrastructure.Persistant.TelemetryDbContext' from singleton 'Application.Interfaces.Mqtt.IMqttClientService'.
