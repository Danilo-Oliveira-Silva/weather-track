namespace Weather.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Weather.Application.Common.Interfaces;
using Weather.Infrastructure.Data.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMeasureRepository, MeasureRepository>();
        return services;
    }
}