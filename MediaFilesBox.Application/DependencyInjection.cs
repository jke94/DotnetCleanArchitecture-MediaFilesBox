namespace MediaFilesBox.Application
{
    #region usign

    using MediatR;
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    #endregion

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
