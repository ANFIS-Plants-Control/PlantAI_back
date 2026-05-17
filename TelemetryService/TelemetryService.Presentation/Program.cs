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