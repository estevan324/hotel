using System.Reflection;
using Hotel.Application.Services;
using Hotel.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(config
            => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}