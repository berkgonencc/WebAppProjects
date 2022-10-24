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

        public async Task CreateAsync(Product product, int[] categoryIds)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            product.ProductCategories = categoryIds.Select(catId => new ProductCategory
            {
                CategoryId = catId,
                ProductId = product.Id
            }).ToList();
            await context.SaveChangesAsync();
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

        public async Task<Product> GetProductDetailsAsync(string url)
        {
            return await context
               .Products
               .Where(p => p.Url == url)
               .Include(p => p.ProductCategories)
               .ThenInclude(pc => pc.Category)
               .FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductWithCategoriesAsync(int id)
        {
            return await context
                .Products
                .Where(p => p.Id == id && p.IsDeleted == false)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Product product, int[] categoryIds)
        {
            Product entity = await context
                .Products
                .Include(p => p.ProductCategories)
                .FirstOrDefaultAsync(pc => pc.Id == product.Id);
            entity.Name = product.Name;
            entity.Properties = product.Properties;
            entity.Price = product.Price;
            entity.Url = product.Url;
            entity.ImageUrl = product.ImageUrl;
            entity.IsApproved = product.IsApproved;
            entity.IsHome = product.IsHome;
            entity.ProductCategories = categoryIds
                .Select(catId => new ProductCategory()
                {
                    ProductId = entity.Id,
                    CategoryId = catId
                }).ToList();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
