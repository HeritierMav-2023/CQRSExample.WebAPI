using CQRSExample.Application.Products.Queries;
using CQRSExample.Domain.Entities;
using CQRSExample.Domain.Interfaces;
using MediatR;


namespace CQRSExample.Application.Products.Handlers
{
    public class GetProductsHandlers : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        //1- DataContext
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructor DI
        public GetProductsHandlers(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }
    }
}
