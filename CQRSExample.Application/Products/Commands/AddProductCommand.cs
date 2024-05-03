using CQRSExample.Domain.Entities;
using MediatR;


namespace CQRSExample.Application.Products.Commands
{
    /// <summary>
    /// MediatR Command
    /// </summary>
    /// <param name="product"></param>
    public record AddProductCommand(Product product) : IRequest<Product>;
}
