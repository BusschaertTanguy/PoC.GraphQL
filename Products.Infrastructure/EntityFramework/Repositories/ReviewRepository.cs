using Common.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Domain.Mementos;
using Products.Domain.Repositories;
using Products.Infrastructure.EntityFramework.Contexts;

namespace Products.Infrastructure.EntityFramework.Repositories;

internal sealed class ReviewRepository : IReviewRepository
{
    private readonly ProductContext _context;

    public ReviewRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<Review> GetById(EntityId id)
    {
        var memento = await _context
            .Set<ReviewMemento>()
            .Include(r => r.Product)
            .AsNoTracking()
            .FirstAsync(m => m.Id == id.Value);

        return Review.FromMemento(memento);
    }

    public async Task Save(Review rootEntity)
    {
        var newReview = new ReviewMemento
        {
            Id = rootEntity.Id.Value,
            Description = rootEntity.Description.Value,
            Product = await _context.Set<ProductMemento>().FirstAsync(p => p.Id == rootEntity.ProductId.Value)
        };

        var existingReview = await _context
            .Set<ReviewMemento>()
            .Include(r => r.Product)
            .FirstOrDefaultAsync(r => r.Id == newReview.Id);

        if (existingReview == null)
        {
            await _context.Set<ReviewMemento>().AddAsync(newReview);
        }
        else
        {
            _context.Entry(existingReview).CurrentValues.SetValues(newReview);
        }

        await _context.SaveChangesAsync();
    }
}