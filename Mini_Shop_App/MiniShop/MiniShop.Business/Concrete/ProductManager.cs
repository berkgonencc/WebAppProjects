using MiniShop.Business.Abstract;
using MiniShop.Data.Abstract;
using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Product product, int[] categoryIds)
        {
            return _productRepository.CreateAsync(product, categoryIds);
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetHomePageProductsAsync(string category)
        {
            return await _productRepository.GetHomePageProductsAsync(category);
        }

        public async Task<Product> GetProductDetailsAsync(string url)
        {
            return await _productRepository.GetProductDetailsAsync(url);
        }

        public async Task<Product> GetProductWithCategoriesAsync(int id)
        {
            return await _productRepository.GetProductWithCategoriesAsync(id);
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Product product, int[] categoryIds)
        {
            await _productRepository.UpdateAsync(product, categoryIds);
        }
    }
}
