using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;

        public HomeController(IPostService postService, ICategoryService categoryService, ICommentService commentService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetTrendingPostsAsync();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}