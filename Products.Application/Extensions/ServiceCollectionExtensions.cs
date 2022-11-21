using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Products.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        return services
            .AddMediatR(Assembly.GetExecutingAssembly());
    }
}