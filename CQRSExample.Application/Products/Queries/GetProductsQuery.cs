using CQRSExample.Domain.Entities;
using MediatR;


namespace CQRSExample.Application.Products.Queries
{
    /// <summary>
    /// MediatR with Queries
    /// </summary>
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
}
