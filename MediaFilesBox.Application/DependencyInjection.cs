namespace MediaFilesBox.Application
{
    using MediatR;
    #region usign

    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    #endregion

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
