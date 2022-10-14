namespace MediaFilesBox.WebApi
{
    #region

    using FluentValidation.AspNetCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;
    using MediaFilesBox.Application;
    using MediaFilesBox.Infrastructure;
    using MediaFilesBox.Infrastructure.Persistence.Providers.InMemory;
    using MediaFilesBox.Infrastructure.Persistence.Providers.SqlServer;
    using MediaFilesBox.Infrastructure.Persistence.SqlServer;

    #endregion

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(
                builder.Configuration, 
                builder.Environment);

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

            builder.Services.AddFluentValidationAutoValidation();

            var app = builder.Build();

            // Seed Data
            using (var scope = app.Services.CreateScope())
            {
                if (app.Environment.IsDevelopment())
                {
                    var scopeProvider = scope.ServiceProvider;
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppInMemoryDbContext>();

                    await AppInMemoryDbContextSeed.SeedSampleDataAsync(dbContext);
                }
                if (app.Environment.IsStaging())
                {
                    var scopeProvider = scope.ServiceProvider;
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppSqlServerDbContext>();

                    dbContext.Database.Migrate();

                    await AppSqlServerDbContextSeed.SeedSampleDataAsync(dbContext);
                }
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            // TODO: Uncomment with SLL certificate.
            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}