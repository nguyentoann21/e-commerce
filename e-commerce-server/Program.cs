
using e_commerce_server.DataAccess;
using e_commerce_server.Middleware;
using e_commerce_server.Repositories;
using e_commerce_server.Repositories.Interfaces;
using e_commerce_server.Services;
using e_commerce_server.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace e_commerce_server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                };
            });

            builder.Services.AddAuthorization();

            //Configure Entity Framework Core with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Register scoped services
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IStorage, Storage>();
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            // Configuring CORS to allow all origins, headers, and methods
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Register logging services for the application
            builder.Services.AddLogging();

            var app = builder.Build();

            // Initialize seed data into the database from SeedData.cs
            using (var scope = app.Services.CreateScope())
            {
                var _logger = app.Services.GetRequiredService<ILogger<Program>>();
                try
                {
                    var services = scope.ServiceProvider;
                    SeedData.Initialize(services, _logger);
                } 
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred seeding the database");
                }
                
            }

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                // Enable Swagger documentation
                app.UseSwagger();
                // Enable Swagger UI for testing APIs
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "e_commerce_server V1");
                    // Set Swagger UI
                    x.RoutePrefix = "swagger";
                });
            }

            // Enable logging middleware
            app.UseMiddleware<LoggingMiddleware>();

            // Enable CORS policy named "AllowAll" globally
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            // Save static files - upload files
            app.UseStaticFiles();

            // Enable authen and author middleware
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionHandler("/error");
            app.UseHsts();

            app.MapControllers();

            app.Run();
        }
    }
}
