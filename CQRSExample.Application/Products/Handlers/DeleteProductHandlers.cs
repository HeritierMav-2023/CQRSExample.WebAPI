using CQRSExample.Application.Products.Commands;
using CQRSExample.Domain.Entities;
using CQRSExample.Domain.Interfaces;
using MediatR;

namespace CQRSExample.Application.Products.Handlers
{
    public class DeleteProductHandlers : IRequestHandler<DeleteProductCommand, Product>
    {
        //1- DataContext
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructor DI
        public DeleteProductHandlers(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }
        #region Ovveride Methods
        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.DeleteAsync(request.product);
        }
        #endregion
    }
}
