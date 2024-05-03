using CQRSExample.Application.Products.Notifications;
using CQRSExample.Domain.Interfaces;
using MediatR;

namespace CQRSExample.Application.Products.Handlers
{
    public class EmailHandlers : INotificationHandler<ProductAddedNotification>
    {
        //1- object reference unit of work
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructor DI
        public EmailHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Ovverides Methods
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProductRepository.EventOccured(notification.Product, "Cache Invalidated");
            await Task.CompletedTask;
        }
        #endregion
    }
}
