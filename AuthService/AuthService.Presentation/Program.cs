using AuthService.Extensions;
using AuthService.Infrastructure.Persistant;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Starting initializing the app");

var builder = WebApplication.CreateBuilder(args);

builder.ImplementServices();

var app = builder.Build();
const string corsName = "PlantAI_Front";
app.UseCors(corsName);

#if DEBUG
var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
dbContext.Database.Migrate();
#endif

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
Console.WriteLine("The app has been started");
app.Run();