using MediatR;
using Products.Domain.Repositories;

namespace Products.Application.Commands;

public static class AddReviewToProduct
{
    public sealed record Command(Guid ProductId, string Description) : IRequest;

    internal sealed class Handler : IRequestHandler<Command>
    {
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;

        public Handler(IProductRepository productRepository, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var (productId, description) = request;

            var product = await _productRepository.GetById(new(productId));
            var review = product.CreateReview(new(description));

            await _reviewRepository.Save(review);

            return Unit.Value;
        }
    }
}