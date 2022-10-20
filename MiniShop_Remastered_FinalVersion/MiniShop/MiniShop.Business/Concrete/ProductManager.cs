﻿using MiniShop.Business.Abstract;
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

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetHomePageProductsAsync(string category)
        {
            return await _productRepository.GetHomePageProductsAsync(category);
        }

        public async Task<Product> GetProductDetailsAsync(int id)
        {
            return await _productRepository.GetProductDetailsAsync(id);
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
