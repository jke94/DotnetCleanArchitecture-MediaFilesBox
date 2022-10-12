namespace MediaFilesBox.Infrastructure
{
    #region usign

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Infrastructure.Services;
    using MediaFilesBox.Infrastructure.Persistence.SqlServer;
    using Microsoft.Extensions.Hosting;

    #endregion

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                services.AddDbContext<AppInMemoryDbContext>(options =>
                    options.UseInMemoryDatabase("CleanArchitectureDb"));

                services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppInMemoryDbContext>());
            }
            if (env.IsStaging())
            {
                services.AddDbContext<AppSqlServerDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(AppSqlServerDbContext).Assembly.FullName)));

                services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppSqlServerDbContext>());
            }

            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
