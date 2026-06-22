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

app.UseHttpsRedirection();

app.Run();