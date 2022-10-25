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
        Task CreateAsync(Product product, int[] categoryIds);
        Task UpdateAsync(Product product, int[] categoryIds);
        Task UpdateIsHomeAsync(Product product);
        Task UpdateIsApprovedAsync(Product product);
        Task<List<Product>> GetHomePageProductsAsync(string category);
        Task<Product> GetProductDetailsAsync(string url);
        Task<Product> GetProductWithCategoriesAsync(int id);
        Task IsDeleteAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetDeletedProducts();
    }
}
