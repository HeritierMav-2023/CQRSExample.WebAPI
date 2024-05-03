using CQRSExample.Domain.Entities;
using MediatR;


namespace CQRSExample.Application.Products.Queries
{
    /// <summary>
    /// MediatR with Queries
    /// </summary>
    /// <param name="Id"></param>
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
