using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMarket.Core.Models;

namespace NetMarket.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();

        Task<Product> Get(int id);
    }
}
