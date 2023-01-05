using BlogApp.Business.Abstract;
using BlogApp.Entity;
using BlogApp.Web.Models;
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
            ViewBag.AllPosts = await _postService.GetRecentPostsAsync();
            return View(posts);
        }
        public async Task<IActionResult> ReadMore(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }
            Post post = await _postService.GetFullPostAsync(slug);
            PostModel postModel = new PostModel()
            {
                Post = post,
                Categories = post.PostCategories.Select(pc=>pc.Category).ToList()
            };
            return View(postModel);
        }
        public async Task<IActionResult> PostList(string category)
        {
            var homePagePosts = await _postService.GetHomePagePostsAsync(category);
            ViewBag.AllPosts = await _postService.GetRecentPostsAsync();

            return View("Index", homePagePosts);
        }


        public IActionResult Privacy()
        {
            return View();
        }


    }
}