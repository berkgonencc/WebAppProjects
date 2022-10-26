using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Business.Abstract;
using MiniShop.Core;
using MiniShop.Entity;
using MiniShop.Web.Models;

namespace MiniShop.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ProductList()
        {
            List<Product> products = await _productService.GetAllProductsAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductWithCategoriesModel productModel, IFormFile file, int[] categoryIds)
        {
            if (ModelState.IsValid && categoryIds.Length > 0 && file != null)
            {
                var url = Jobs.MakeUrl(productModel.Name);
                Product product = new Product()
                {
                    Name = productModel.Name,
                    Properties = productModel.Properties,
                    Price = productModel.Price,
                    Url = url,
                    ImageUrl = Jobs.UploadImage(file, url),
                    IsApproved = productModel.IsApproved,
                    IsHome = productModel.IsHome
                };
                await _productService.CreateAsync(product, categoryIds);
                TempData["Message"] = Jobs.CreateMessage("Congrats!", "Product is successfully created!", "success");
                return RedirectToAction("ProductList");
            }
            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Please choose a category!";
            }
            else
            {
                ViewData["SelectedCategories"] = categoryIds;
            }
            if (file == null)
            {
                ViewBag.ImageErrorMessage = "Please choose an image!";
            }
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View(productModel);
        }
        [HttpGet]
        public async Task<IActionResult> ProductEdit(int id)
        {
            Product product = await _productService.GetProductWithCategoriesAsync(id);
            if (product == null) { return NotFound(); }
            ProductWithCategoriesModel productModel = new ProductWithCategoriesModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Properties = product.Properties,
                IsApproved = product.IsApproved,
                ImageUrl = product.ImageUrl,
                IsHome = product.IsHome,
                SelectedCategories = product.ProductCategories.Select(pc => pc.Category).ToList()
            };
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View(productModel);
        }
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductWithCategoriesModel productModel, IFormFile file, int[] categoryIds)
        {
            if (ModelState.IsValid && categoryIds.Length > 0)
            {
                var url = Jobs.MakeUrl(productModel.Name);
                if (file != null)
                {
                    productModel.ImageUrl = Jobs.UploadImage(file, url);
                }
                Product product = await _productService.GetByIdAsync(productModel.Id);
                if (product == null)
                {
                    return NotFound();
                }
                product.Name = productModel.Name;
                product.Url = url;
                product.Price = productModel.Price;
                product.Properties = productModel.Properties;
                product.IsApproved = productModel.IsApproved;
                product.IsHome = productModel.IsHome;
                if (file != null)
                {
                    product.ImageUrl = productModel.ImageUrl;
                }
                await _productService.UpdateAsync(product, categoryIds);
                TempData["Message"] = Jobs.CreateMessage("Congrats!", "Product is successfully updated.", "warning");
                return RedirectToAction("ProductList");
            }
            if (file == null)
            {
                Product product = await _productService.GetByIdAsync(productModel.Id);
                if (product == null)
                {
                    return NotFound();
                }
                productModel.ImageUrl = product.ImageUrl;

            }
            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Please choose a category!";
            }
            else
            {
                productModel.SelectedCategories = categoryIds.Select(catId => new Category()
                {
                    Id = catId
                }).ToList();
            }
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View(productModel);
        }
        public async Task<IActionResult> UpdateIsHome(int id)
        {
            Product product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.UpdateIsHomeAsync(product);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> UpdateIsApproved(int id)
        {
            Product product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.UpdateIsApprovedAsync(product);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> ProductDelete(int id)
        {
            Product product = await _productService.GetByIdAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            await _productService.IsDeleteAsync(product);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> ShowDeletedProducts()
        {
            List<Product> products = await _productService.GetDeletedProducts();
            return View(products);
        }
        public async Task<IActionResult> ProductUndo(int id)
        {
            Product product = await _productService.GetByIdAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            await _productService.IsDeleteAsync(product);
            return RedirectToAction("ProductList");
        }
    }
}
