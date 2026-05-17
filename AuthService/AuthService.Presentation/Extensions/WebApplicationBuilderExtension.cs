using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using AuthService.Infrastructure.Persistant;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthService.Extensions
{
    public static class WebApplicationBuilderExtension
    {

        public static void ImplementServices(this WebApplicationBuilder builder)
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

            builder.Configuration.AddKeyPerFile(directoryPath: "/run/secrets", optional: true);
            string secretKey = builder.Configuration["secretKey"];
#if RELEASE
            string dbPassword = builder.Configuration["DbPassword"];
            string connectionString = builder.Configuration["AuthDbConnectionString"]+$"Password={dbPassword}";
#else
            string connectionString = builder.Configuration.GetConnectionString("devConnection");
#endif
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddScoped<ProjectOptions>(po => { return new ProjectOptions(connectionString, secretKey); });

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AuthDbContext>(c => c.UseNpgsql(connectionString));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<TokenBuilderService>();

            builder.Services.AddEndpointsApiExplorer();
        }

    }
}
