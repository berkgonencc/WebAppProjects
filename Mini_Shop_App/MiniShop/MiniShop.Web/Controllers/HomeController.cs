using Microsoft.AspNetCore.Mvc;
using MiniShop.Business.Abstract;
using MiniShop.Entity;
using MiniShop.Web.Models;
using System.Diagnostics;

namespace MiniShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetHomePageProductsAsync(null);

            return View(products);
        }  
        public async Task<IActionResult> ProductList(string category)
        {
            var homePageProducts = await _productService.GetHomePageProductsAsync(category);
            return View("Index",homePageProducts);
        }
        public async Task<IActionResult> Details(string url)
        {
            if (string.IsNullOrEmpty(url)) 
            { 
                return NotFound(); 
            }
            Product product = await _productService.GetProductDetailsAsync(url);
            ProductDetailModel productDetailModel = new ProductDetailModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(pc => pc.Category).ToList()

            };
            return View(productDetailModel);
        }
    }
}