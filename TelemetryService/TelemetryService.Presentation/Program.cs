using Microsoft.EntityFrameworkCore;
using TelemetryService.Extenstions;
using TelemetryService.Infrastructure.Persistant;

var builder = WebApplication.CreateBuilder(args);

builder.ImplementServices();

var app = builder.Build();

app.UseCors("PlantAI_Front");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

#if RELEASE
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    Console.WriteLine("Start migrations");
    var context = services.GetRequiredService<TelemetryDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}
#endif

app.Run();