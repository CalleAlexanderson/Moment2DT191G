using Microsoft.AspNetCore.Mvc;

namespace Moment2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Site2()
        {
            return View();
        }

        public IActionResult Site3()
        {
            return View();
        }
    }
}