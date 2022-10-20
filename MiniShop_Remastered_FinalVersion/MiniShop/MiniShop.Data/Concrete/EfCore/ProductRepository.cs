using Microsoft.EntityFrameworkCore;
using MiniShop.Data.Abstract;
using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Data.Concrete.EfCore
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }
        private MyAppContext context
        {
            get
            {
                return _dbContext as MyAppContext;
            }
        }

        public async Task<List<Product>> GetHomePageProductsAsync(string category)
        {
            var products = context
                .Products
                .Where(p => p.IsDeleted == false && p.IsHome && p.IsApproved)
                .AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                products = products
                    .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                    .Where(p => p.ProductCategories.Any(pc => pc.Category.Url == category));
            }
            return await products.ToListAsync();
        }

        public Task<Product> GetProductDetailsAsync(int id)
        {
            return context
                .Products
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
