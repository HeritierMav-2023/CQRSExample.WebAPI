using CQRSExample.Application.Products.Queries;
using CQRSExample.Domain.Entities;
using CQRSExample.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSExample.Application.Products.Handlers
{
    public class GetProductByHandlers : IRequestHandler<GetProductByIdQuery, Product>
    {
        //1- object reference unit of work
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructor DI
        #region Constructor DI
        public GetProductByHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }
        #endregion

        #region Ovveride Methods
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetbyIdAsync(request.Id);
        }
        #endregion
    }
}
