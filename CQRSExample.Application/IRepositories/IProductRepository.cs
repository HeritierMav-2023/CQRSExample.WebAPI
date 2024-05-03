using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSExample.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Domain.Entities.Product>
    {
    }
}
