using Infrastructure.Persistant;
using Microsoft.EntityFrameworkCore;
using PlantAIService.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.ImplementBuilderServices();



var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    Console.WriteLine("Start migrations");
    var context = services.GetRequiredService<PlantAIDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.Run();