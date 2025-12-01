using Microsoft.Extensions.DependencyInjection;
using PlantAI;
using PlantAI.Grpc;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddScoped(options => 
    new ApplicationDbContext());

builder.Services.AddGrpc();

builder.Services.AddGrpcClient<Calculator.CalculatorClient>(provider =>
{
    HttpClient.DefaultProxy = new WebProxy();
    provider.Address = new Uri("http://localhost:50051");
});

var app = builder.Build(); 



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();