using Microsoft.EntityFrameworkCore;
using Products.Domain.Mementos;
using Products.Infrastructure.EntityFramework.Contexts;

namespace Products.Infrastructure.GraphQL.Queries;

public sealed class Query
{
    [UseProjection]
    [UseFiltering]
    public IQueryable<ProductMemento> Products([Service(ServiceKind.Synchronized)] ProductContext context)
    {
        return context.Set<ProductMemento>().Include(p => p.Reviews).AsNoTracking();
    }

    [UseProjection]
    [UseFiltering]
    public IQueryable<ReviewMemento> Reviews([Service(ServiceKind.Synchronized)] ProductContext context)
    {
        return context.Set<ReviewMemento>().Include(r => r.Product).AsNoTracking();
    }
}