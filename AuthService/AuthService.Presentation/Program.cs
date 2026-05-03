using AuthService.Extensions;

Console.WriteLine("Starting initializing the app");

var builder = WebApplication.CreateBuilder(args);

builder.ImplementServices();

var app = builder.Build();

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