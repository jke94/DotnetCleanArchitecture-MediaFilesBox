namespace MediaFilesBox.WebApi
{
    #region

    using MediaFilesBox.Application;
    using MediaFilesBox.Infrastructure;
    using MediaFilesBox.Infrastructure.Persistence;
    using Microsoft.OpenApi.Models;

    #endregion

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Media Files Box",
                    Description = "Media Files Box API - Clean Architecture Solution in .NET 6",
                });
            });

            var app = builder.Build();

            // Seed Data
            using (var scope = app.Services.CreateScope())
            {
                var scopeProvider = scope.ServiceProvider;
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                await ApplicationDbContextSeed.SeedSampleDataAsync(dbContext);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}