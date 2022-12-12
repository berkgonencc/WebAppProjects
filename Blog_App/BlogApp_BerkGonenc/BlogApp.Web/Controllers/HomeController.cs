using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApp.Web.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}