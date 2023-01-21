using Microsoft.AspNetCore.Mvc;

namespace LakshmiMovieApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
