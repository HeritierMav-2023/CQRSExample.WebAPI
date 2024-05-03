using CQRSExample.Domain.Interfaces;
using CQRSExample.Persistance.Context;

namespace CQRSExample.Persistance.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        //private readonly ExampleCqrsContext _context;
        //1-Déclaration d'objets repository
        public IProductRepository ProductRepository { get; }

        //2-Constructeur DI
        public UnitOfWork(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }
    }
}
