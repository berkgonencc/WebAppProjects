using BlogApp.Business.Abstract;
using BlogApp.Core;
using BlogApp.Entity;
using BlogApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public AdminController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> PostList()
        {
            List<Post> posts = await _postService.GetAll();
            return View(posts);
        }
        public async Task<IActionResult> PostWrite()
        {
            ViewBag.Categories = await _categoryService.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostWrite(PostWithCategoriesModel postModel, IFormFile file, int[] categoryIds)
        {
            if (ModelState.IsValid && categoryIds.Length > 0 && file != null)
            {
                var url = Jobs.MakeUrl(postModel.Title);
                var summary = postModel.PostContent.Substring(0, 100);
                Post post = new Post()
                {
                    Title = postModel.Title,
                    PostContent = postModel.PostContent,
                    Slug = url,
                    ImageUrl = Jobs.UploadImage(file, url),
                    IsPublished = postModel.IsPublished,
                    Summary = summary
                };
                await _postService.CreateAsync(post, categoryIds);
                TempData["Message"] = Jobs.CreateMessage("Congrats!", "Post is successfully created.", "info");
                return RedirectToAction("Index", "Home");
            }
            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Please choose a category!";
            } else
            {
                ViewData["SelectedCategories"] = categoryIds;
            }
            if (file == null)
            {
                ViewBag.ImageErrorMessage = "Please choose an image!";
            }
            ViewBag.Categories = await _categoryService.GetAll();
            return View(postModel);
        }
    }
}
