using Common.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Domain.Mementos;
using Products.Domain.Repositories;
using Products.Infrastructure.EntityFramework.Contexts;

namespace Products.Infrastructure.EntityFramework.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<Product> GetById(EntityId id)
    {
        var memento = await _context
            .Set<ProductMemento>()
            .AsNoTracking()
            .FirstAsync(m => m.Id == id.Value);

        return Product.FromMemento(memento);
    }

    public async Task Save(Product rootEntity)
    {
        var newProduct = new ProductMemento
        {
            Id = rootEntity.Id.Value,
            Name = rootEntity.Name.Value,
            Price = rootEntity.Price.Value,
            Reviews = new List<ReviewMemento>()
        };

        var existingProduct = await _context
            .Set<ProductMemento>()
            .FindAsync(newProduct.Id);

        if (existingProduct == null)
        {
            await _context.Set<ProductMemento>().AddAsync(newProduct);
        }
        else
        {
            _context.Entry(existingProduct).CurrentValues.SetValues(newProduct);
        }

        await _context.SaveChangesAsync();
    }
}