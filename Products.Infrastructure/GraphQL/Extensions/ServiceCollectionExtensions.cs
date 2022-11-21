using Microsoft.Extensions.DependencyInjection;
using Products.Infrastructure.GraphQL.Queries;

namespace Products.Infrastructure.GraphQL.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddProjections()
            .AddFiltering();

        return services;
    }
}