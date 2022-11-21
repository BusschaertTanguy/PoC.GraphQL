using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Repositories;
using Products.Infrastructure.EntityFramework.Contexts;
using Products.Infrastructure.EntityFramework.Repositories;

namespace Products.Infrastructure.EntityFramework.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<ProductContext>(builder => builder.UseNpgsql(configuration.GetConnectionString("ProductsDb")))
            .AddTransient<IProductRepository, ProductRepository>()
            .AddTransient<IReviewRepository, ReviewRepository>();
    }
}