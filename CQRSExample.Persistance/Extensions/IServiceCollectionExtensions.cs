using CQRSExample.Domain.Interfaces;
using CQRSExample.Persistance.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace CQRSExample.Persistance.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
