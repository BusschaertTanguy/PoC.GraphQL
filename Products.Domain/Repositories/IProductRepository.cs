using Common.Domain.Repositories;
using Products.Domain.Entities;

namespace Products.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
}