using CQRSExample.Application.Products.Commands;
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

    public class EditProductHandlers : IRequestHandler<EditProductCommand, Product>
    {
        //1- DataContext
        private readonly IUnitOfWork _unitOfWork;

        //2-Constructeur DI
        public EditProductHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Ovveride Methods
        public async Task<Product> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var editProduct = await _unitOfWork.ProductRepository.UpdateAsync(request.product);
            return editProduct;
        }
        #endregion
    }
}
