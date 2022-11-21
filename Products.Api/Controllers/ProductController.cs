using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Commands;

namespace Products.Api.Controllers;

[Route("api/product")]
public sealed class ProductController : ControllerBase
{
    [HttpPost]
    public async Task<NoContentResult> Add([FromServices] IMediator mediator, [FromBody] AddProduct.Command command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpPost("add-review")]
    public async Task<NoContentResult> AddReview([FromServices] IMediator mediator, [FromBody] AddReviewToProduct.Command command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}