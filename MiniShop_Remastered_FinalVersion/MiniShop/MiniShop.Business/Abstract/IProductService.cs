using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Business.Abstract
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task CreateAsync(Product entity);
        void Delete(Product entity);
        void Update(Product entity);
        Task<List<Product>> GetHomePageProductsAsync(string category);
        Task<Product> GetProductDetailsAsync(int id);

    }
}
