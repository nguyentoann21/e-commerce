
using e_commerce_server.DataAccess;
using e_commerce_server.Repositories;
using e_commerce_server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            
            //Configure Entity Framework Core with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Register scoped services
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            //init data to db from SeedData.cs
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //save static files - upload files
            app.UseStaticFiles();

            //enable authen and author middleware
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
