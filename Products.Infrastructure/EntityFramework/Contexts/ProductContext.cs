using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Products.Infrastructure.EntityFramework.Contexts;

public sealed class ProductContext : DbContext
{
    public ProductContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}