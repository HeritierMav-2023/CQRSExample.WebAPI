using CQRSExample.Application.Products.Queries;
using CQRSExample.Application.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CQRSExample.Domain.Entities;

namespace CQRSExample.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Attributs
        private readonly ISender _sender;
        private readonly IPublisher _publisher;
        #endregion

        #region Constructeur DI
        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }
        #endregion

        #region Verbs Methods
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));

            //await _publisher.Publish(new ProductAddedNotification(productToReturn));

            //return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
            return Ok(productToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> EditProduct(int id, EditProductCommand command)
        {
            if(id != command.product.Id)
            {
                return BadRequest();
            }
            //return  await _sender.Send(command.product);
            //var productToReturn = await _sender.Send(new EditProductCommand(product));
            //await _publisher.Publish(new ProductAddedNotification(productToReturn));

            //return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
            //return Ok(productToReturn);
            return await _sender.Send(command);
        }

        
        #endregion
    }
}
