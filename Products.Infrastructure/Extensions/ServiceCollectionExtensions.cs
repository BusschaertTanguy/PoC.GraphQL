using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Infrastructure.EntityFramework.Extensions;
using Products.Infrastructure.GraphQL.Extensions;

namespace Products.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddEntityFramework(configuration)
            .AddGraphQl();
    }
}