using CQRSExample.Application.Products.Commands;
using CQRSExample.Domain.Entities;
using CQRSExample.Domain.Interfaces;
using MediatR;


namespace CQRSExample.Application.Products.Handlers
{
    public class AddProductHandlers : IRequestHandler<AddProductCommand, Product>
    {
        //1- DataContext
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructeur DI
        public AddProductHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Ovveride Methods
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
           var product =  await _unitOfWork.ProductRepository.CreateAsync(request.product);
            return product;
        }
        #endregion
    }
}
