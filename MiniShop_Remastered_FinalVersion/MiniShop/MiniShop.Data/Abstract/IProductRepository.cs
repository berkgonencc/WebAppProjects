using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetHomePageProductsAsync(string category);
        Task<Product> GetProductDetailsAsync(int id);
    }
}
