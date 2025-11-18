using Microsoft.EntityFrameworkCore;
using PlantAI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetSection("ConnectionStrings").GetValue(typeof(string), "DefaultConnection").ToString() ?? "";

builder.Services.AddScoped(options => 
    new ApplicationDbContext(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();