using Common.Domain.ValueObjects;
using MediatR;
using Products.Domain.Entities;
using Products.Domain.Repositories;

namespace Products.Application.Commands;

public static class AddProduct
{
    public sealed record Command(string Name, decimal Price) : IRequest;

    internal sealed class Handler : IRequestHandler<Command>
    {
        private readonly IProductRepository _productRepository;

        public Handler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var (name, price) = request;

            var product = new Product
            (
                EntityId.New(),
                new(name),
                new(price)
            );

            await _productRepository.Save(product);

            return Unit.Value;
        }
    }
}