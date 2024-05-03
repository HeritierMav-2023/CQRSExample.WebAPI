using CQRSExample.Domain.Entities;
using MediatR;


namespace CQRSExample.Application.Products.Commands
{
    public record DeleteProductCommand(Product product) : IRequest<Product>;
}
