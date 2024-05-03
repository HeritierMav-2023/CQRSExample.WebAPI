using CQRSExample.Domain.Entities;
using MediatR;


namespace CQRSExample.Application.Products.Notifications
{
    public record ProductAddedNotification(Product Product) : INotification;
}
